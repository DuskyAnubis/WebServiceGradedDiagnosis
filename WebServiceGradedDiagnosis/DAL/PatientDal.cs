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
    public class PatientDal
    {
        public Patient GetPatient(Request request)
        {
            Patient patient;
            if (string.IsNullOrEmpty(request.OutPatientNo))
            {
                string sqlBak = "";
                if (string.IsNullOrEmpty(request.IdentCard))
                {
                    sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' order by 入院日期 desc";
                }
                else
                {
                    sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' or 身份证号='{request.IdentCard}' order by 入院日期 desc";
                }

                DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];
                if (dtBak != null && dtBak.Rows.Count > 0)
                {
                    string sqlDep = $"select 科室Id, 科室代码,科室名称 from 科室 where 科室名称='{dtBak.Rows[0]["科室"].ToString()}'";
                    string sqlDoc = $"select id,医师代码,医师姓名,所在科室,挂号科室,划价号 from 医师代码 where 医师姓名='{dtBak.Rows[0]["医师代码"].ToString()}'";
                    string sqlPatBaseInf = $"select top 1 * from (select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInf union select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInfOut) as EH_PatBasInf where PatId='{dtBak.Rows[0]["住院号"].ToString()}' order by InDate desc";

                    DataTable dtDep = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDep).Tables[0];
                    DataTable dtDoc = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDoc).Tables[0];
                    DataTable dtPatBaseInf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("DzblConnectionString"), sqlPatBaseInf).Tables[0];

                    patient = new Patient
                    {
                        PID = dtBak.Rows[0]["病人编号"].ToString(),
                        PatientName = dtBak.Rows[0]["姓名"].ToString(),
                        HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                        HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                        GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                        PatientAge = DateTime.Now.Year - Convert.ToDateTime(dtBak.Rows[0]["出生日期"]).Year,
                        Birthday = Convert.ToDateTime(dtBak.Rows[0]["出生日期"]).ToString("yyyy-MM-dd"),
                        Nation = dtBak.Rows[0]["民族"].ToString(),
                        PatientStature = null,
                        PatientWeight = null,
                        Phone = dtBak.Rows[0]["电话"].ToString(),
                        Address = dtBak.Rows[0]["家庭住址"].ToString(),
                        Contacts = dtBak.Rows[0]["联系人"].ToString(),
                        RelationShip = dtBak.Rows[0]["关系"].ToString(),
                        ContactPhone = dtBak.Rows[0]["联系电话"].ToString(),
                        ContactAddress = dtBak.Rows[0]["联系人地址"].ToString(),
                        IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                        InsuranceTypeCode = null,
                        InsuranceTypeName = dtBak.Rows[0]["医保类型"].ToString(),
                        InsuranceNo = null,
                        DeptCode = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室代码"].ToString() : null,
                        DeptName = dtBak.Rows[0]["科室"].ToString(),
                        AppDiagonse = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["Diagnosis1"].ToString() : null,
                        ChiefComplaint = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["MainNarrative"].ToString() : null,
                        MedicalHistory = null,
                        PatientSign = null,
                        PatientExtraStudy = null,
                        AuxiliaryRecord = null,
                        CheckTime = null,
                        OutPatientNo = null,
                        InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                        InTime = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                        OutTime = dtBak.Rows[0]["出院日期"] is DBNull ? null : Convert.ToDateTime(dtBak.Rows[0]["出院日期"]).ToString("yyyy-MM-dd"),
                        Other1 = null,
                        Other2 = null,
                        Other3 = null,
                        Other4 = null,
                        Other5 = null,
                        DzjkNo = null
                    };

                    return patient;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string sqlMzsf = $"select top 1 * from (select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费流水帐 union select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费) as MZSF where 卡号='{request.OutPatientNo}' order by 日期 desc";
                DataTable dtMzsf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzsf).Tables[0];
                if (dtMzsf != null && dtMzsf.Rows.Count > 0)
                {
                    patient = new Patient
                    {
                        PID = dtMzsf.Rows[0]["卡号"].ToString(),
                        OutPatientNo = dtMzsf.Rows[0]["卡号"].ToString(),
                        InsuranceNo = dtMzsf.Rows[0]["医疗保险号"].ToString(),
                        CheckTime = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd"),
                    };
                    string sqlGh = $"select * from (select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号流水帐 union select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号) as GH where 卡号={request.OutPatientNo}";
                    DataTable dtGh = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("GHConnectionString"), sqlGh).Tables[0];
                    if (dtGh != null && dtGh.Rows.Count > 0)
                    {
                        patient.PatientName = dtGh.Rows[0]["姓名"].ToString();
                        patient.HospitalId = ConfigurationManager.AppSettings["HospitalId"];
                        patient.HospitalName = ConfigurationManager.AppSettings["HospitalName"];
                        patient.GenderValue = dtGh.Rows[0]["性别"].ToString() == "男" ? "0" : "1";
                        patient.PatientAge = Convert.ToInt32(dtGh.Rows[0]["年龄"]);
                        patient.Birthday = null;
                        patient.Nation = dtGh.Rows[0]["民族"].ToString().Trim();
                        patient.PatientStature = null;
                        patient.PatientWeight = null;
                        patient.Phone = dtGh.Rows[0]["电话"].ToString();
                        patient.Address = dtGh.Rows[0]["通信地址"].ToString().Trim();
                        patient.Contacts = null;
                        patient.RelationShip = null;
                        patient.ContactPhone = null;
                        patient.ContactAddress = null;
                        patient.IdentCard = null;
                        patient.InsuranceTypeCode = null;
                        patient.InsuranceTypeName = null;
                        patient.DeptCode = null;
                        patient.DeptName = null;
                        patient.InpatientNo = null;
                        patient.InTime = null;
                        patient.OutTime = null;
                        patient.Other1 = null;
                        patient.Other2 = null;
                        patient.Other3 = null;
                        patient.Other4 = null;
                        patient.Other5 = null;
                        patient.DzjkNo = null;

                        string sqlMzbl = $"select 卡号,门诊号,时间,过敏史,主诉,现病史,既往史,望闻问切,西医诊断,中医诊断,处理,体检,病程,建议 from MZ_BL where 卡号={request.OutPatientNo} order by 时间 desc";
                        DataTable dtMzbl = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzbl).Tables[0];
                        if (dtMzbl != null && dtMzbl.Rows.Count > 0)
                        {
                            patient.AppDiagonse = dtMzbl.Rows[0]["西医诊断"].ToString();
                            patient.ChiefComplaint = dtMzbl.Rows[0]["主诉"].ToString();
                            patient.MedicalHistory = dtMzbl.Rows[0]["现病史"].ToString();
                            patient.PatientSign = null;
                            patient.PatientExtraStudy = null;
                            patient.AuxiliaryRecord = null;
                        }

                        return patient;
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
}