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
            string sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,治疗情况,住院天数,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where 住院号='{request.InPatientNo}' and 身份证号='{request.IdentCard}' order by 入院日期 desc";

            DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];

            if (dtBak != null && dtBak.Rows.Count > 0)
            {
                string sqlYz = $"select * from (select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_长期医嘱 union select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_临时医嘱) as YZ where 病人编号='{dtBak.Rows[0]["病人编号"].ToString()}' order by 开始时间";
                DataTable dtYz = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlYz).Tables[0];

                if (dtYz != null && dtYz.Rows.Count > 0)
                {
                    string sqlDep = $"select 科室Id, 科室代码,科室名称 from 科室 where 科室名称='{dtBak.Rows[0]["科室"].ToString()}'";
                    DataTable dtDep = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDep).Tables[0];

                    List<PatientCharged> patientChargeds = new List<PatientCharged>();

                    for (int i = 0; i < dtYz.Rows.Count; i++)
                    {
                        PatientCharged patientCharged = new PatientCharged
                        {
                            HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                            HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                            InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                            PatientName = dtBak.Rows[0]["姓名"].ToString(),
                            PatientAge = dtBak.Rows[0]["年龄"].ToString(),
                            IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                            MedicalCardNo = "暂无",
                            GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "1" : "0",
                            Departments = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室名称"].ToString() : "暂无",
                            Promdate = dtYz.Rows[i]["开始时间"] is DBNull ? "暂无" : Convert.ToDateTime(dtYz.Rows[i]["开始时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            DAmemo = dtYz.Rows[i]["名称"].ToString(),
                            Doctor = dtYz.Rows[i]["医师"].ToString(),
                            Nurse = dtYz.Rows[i]["执行人"] is DBNull ? "暂无" : dtYz.Rows[i]["执行人"].ToString(),
                            DAtype = dtYz.Rows[i]["医嘱类别"].ToString() == "长期医嘱" ? "1" : "2",
                            Execdate = dtYz.Rows[i]["执行时间"] is DBNull ? "暂无" : Convert.ToDateTime(dtYz.Rows[i]["执行时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            Enddate = dtYz.Rows[i]["停止时间"] is DBNull ? "暂无" : Convert.ToDateTime(dtYz.Rows[i]["停止时间"]).ToString("yyyy-MM-dd hh:mm:ss"),
                            Medspec = dtYz.Rows[i]["规格"] is DBNull || dtYz.Rows[i]["规格"].ToString().Equals("") ? "暂无" : dtYz.Rows[i]["规格"].ToString(),
                            Medusage = dtYz.Rows[i]["用法"] is DBNull || dtYz.Rows[i]["用法"].ToString().Equals("") ? "暂无" : dtYz.Rows[i]["用法"].ToString(),
                            Dose = dtYz.Rows[i]["用量"] is DBNull || dtYz.Rows[i]["用量"].ToString().Equals("") ? "暂无" : dtYz.Rows[i]["用量"].ToString(),
                            Frequency = dtYz.Rows[i]["执行频率"] is DBNull || dtYz.Rows[i]["执行频率"].ToString().Equals("") ? "暂无" : dtYz.Rows[i]["执行频率"].ToString(),
                            Provide = dtYz.Rows[i]["用量"] is DBNull || dtYz.Rows[i]["用量"].ToString().Equals("") ? "暂无" : dtYz.Rows[i]["用量"].ToString(),
                            Checkpart = "暂无",
                            Remark = "暂无",
                            Other1 = null,
                            Other2 = null,
                            Other3 = null,
                            Other4 = null,
                            Other5 = null,
                            PID = dtBak.Rows[0]["病人编号"].ToString(),
                            DzjkNo = null
                        };

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