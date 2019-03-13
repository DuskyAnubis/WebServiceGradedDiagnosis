using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;
using System.Text;

namespace WebServiceGradedDiagnosis.DAL
{
    public class PatientChargedDal
    {
        public List<PatientCharged> GetPatientChargeds(Request request)
        {
            string sqlBak = "";
            if (string.IsNullOrEmpty(request.IdentCard))
            {
                sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,治疗情况,住院天数,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where 病人编号='{request.PID}' or 住院号='{request.InPatientNo}' order by 入院日期 desc";
            }
            else
            {
                sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,治疗情况,住院天数,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where 病人编号='{request.PID}' or 住院号='{request.InPatientNo}' or 身份证号='{request.IdentCard}' order by 入院日期 desc";
            }
            DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];

            if (dtBak != null && dtBak.Rows.Count > 0)
            {
                string sqlYz = $"select * from (select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_长期医嘱 union select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_临时医嘱) as YZ where 病人编号='{dtBak.Rows[0]["病人编号"].ToString()}' order by 开始时间";
                DataTable dtYz = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlYz).Tables[0];

                if (dtYz != null && dtYz.Rows.Count > 0)
                {
                    string sqlDep = $"select 科室Id, 科室代码,科室名称 from 科室 where 科室名称='{dtBak.Rows[0]["科室"].ToString()}'";
                    string sqlDoc = $"select id,医师代码,医师姓名,所在科室,挂号科室,划价号 from 医师代码 where 医师姓名='{dtBak.Rows[0]["医师代码"].ToString()}'";

                    DataTable dtDep = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDep).Tables[0];
                    DataTable dtDoc = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDoc).Tables[0];

                    List<PatientCharged> patientChargeds = new List<PatientCharged>();

                    for (int i = 0; i < dtYz.Rows.Count; i++)
                    {
                        PatientCharged patientCharged = new PatientCharged
                        {
                            HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                            HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                            InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                            PatientId = dtBak.Rows[0]["病人编号"].ToString(),
                            PatientName = dtBak.Rows[0]["姓名"].ToString(),
                            PatientAge = dtBak.Rows[0]["年龄"].ToString(),
                            IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                            MedicalCardNo = null,
                            SeachType = null,
                            OutPatientNo = null,
                            GenderCode = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                            GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                            Departments = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室名称"].ToString() : null,
                            Promdate = dtYz.Rows[i]["开始时间"] is DBNull ? null : Convert.ToDateTime(dtYz.Rows[i]["开始时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            DAmemo = dtYz.Rows[i]["名称"].ToString(),
                            Doctor = dtYz.Rows[i]["医师"].ToString(),
                            Nurse = dtYz.Rows[i]["执行人"] is DBNull ? null : dtYz.Rows[i]["执行人"].ToString(),
                            MedID = ConfigurationManager.AppSettings["HospitalId"],
                            PromdepNo = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室代码"].ToString() : null,
                            SickWordName = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室名称"].ToString() : null,
                            ExecdepNo = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室代码"].ToString() : null,
                            Promdoct = dtYz.Rows[i]["医师"].ToString(),
                            ExecdoctNo = null,
                            DAtype = dtYz.Rows[i]["医嘱类别"].ToString() == "长期医嘱" ? "长期" : "临时",
                            Execdate = dtYz.Rows[i]["执行时间"] is DBNull ? null : Convert.ToDateTime(dtYz.Rows[i]["执行时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            Enddate = dtYz.Rows[i]["停止时间"] is DBNull ? null : Convert.ToDateTime(dtYz.Rows[i]["停止时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            Medspec = dtYz.Rows[i]["规格"] is DBNull ? null : dtYz.Rows[i]["规格"].ToString(),
                            Medusage = dtYz.Rows[i]["用法"] is DBNull ? null : dtYz.Rows[i]["用法"].ToString(),
                            Dose = dtYz.Rows[i]["用量"] is DBNull ? null : dtYz.Rows[i]["用量"].ToString(),
                            Frequency = dtYz.Rows[i]["执行频率"] is DBNull ? null : dtYz.Rows[i]["执行频率"].ToString(),
                            Provide = dtYz.Rows[i]["用量"] is DBNull ? null : dtYz.Rows[i]["用量"].ToString(),
                            Checkpart = null,
                            Remark = null,
                            Other1 = null,
                            Other2 = null,
                            Other3 = null,
                            Other4 = null,
                            Other5 = null,
                            PID = dtBak.Rows[0]["病人编号"].ToString(),
                            DzjkNo = null
                        };

                        if (patientCharged.Nurse != null)
                        {
                            string sqlNurse = $"select id,代码,姓名,科室 from 工作人员 where 姓名='{patientCharged.Nurse}'";
                            DataTable dtNurse = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlNurse).Tables[0];
                            patientCharged.ExecdoctNo = dtNurse != null && dtNurse.Rows.Count > 0 ? dtNurse.Rows[0]["代码"].ToString() : null;
                        }

                        patientChargeds.Add(patientCharged);
                    }

                    return patientChargeds;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}