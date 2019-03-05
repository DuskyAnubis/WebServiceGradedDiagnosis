using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;

namespace WebServiceGradedDiagnosis.DAL
{
    public class PatientDal
    {
        public Patient GetPatient(Request request)
        {
            Patient patient;
            if (string.IsNullOrEmpty(request.OutPatientNo))
            {
                patient = null;

                return null;
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