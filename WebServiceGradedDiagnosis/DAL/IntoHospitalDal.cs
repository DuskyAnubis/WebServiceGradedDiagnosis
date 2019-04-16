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
    public class IntoHospitalDal
    {
        public IntoHospital GetIntoHospital(Request request)
        {
            string sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  住院号='{request.InPatientNo}' and 身份证号='{request.IdentCard}' order by 入院日期 desc";

            DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];

            if (dtBak != null && dtBak.Rows.Count > 0)
            {
                string sqlPatBaseInf = $"select top 1 * from (select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInf union select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInfOut) as EH_PatBasInf where PatId='{dtBak.Rows[0]["住院号"].ToString()}' order by InDate desc";
                DataTable dtPatBaseInf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("DzblConnectionString"), sqlPatBaseInf).Tables[0];

                IntoHospital intoHospital = new IntoHospital
                {
                    HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                    HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                    PatientName = dtBak.Rows[0]["姓名"].ToString(),
                    PatientAge = dtBak.Rows[0]["年龄"].ToString(),
                    IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                    GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "1" : "0",
                    Rcvdate = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    ActionInChief = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 && dtPatBaseInf.Rows[0]["MainNarrative"].ToString() != "" ? dtPatBaseInf.Rows[0]["MainNarrative"].ToString() : "暂无",
                    AllergicHistory = "暂无",
                    HisPresentIllness = "暂无",
                    PastHistory = "暂无",
                    PersonalHistory = "暂无",
                    FamilyHistory = "暂无",
                    RecordDate = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    PhysicalExamination = "暂无",
                    AssistantExamination = "暂无",
                    PrimaryDiagnosis = dtBak.Rows[0]["入院诊断"].ToString(),
                    Process = null,
                    BloodAmylase = null,
                    UrineRoutines = null,
                    AmylaseInUrine = null,
                    BloodRoutine = null,
                    ColorUltrasound = null,
                    DischargeDiagnosis = dtBak.Rows[0]["确诊诊断"].ToString(),
                    Recoder = dtBak.Rows[0]["医师代码"].ToString(),
                    RecordingTime = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd hh:mm:ss"),
                    T = null,
                    P = null,
                    R = null,
                    Bp = null,
                    Other1 = null,
                    Other2 = null,
                    Other3 = null,
                    Other4 = null,
                    Other5 = null,
                    PID = dtBak.Rows[0]["病人编号"].ToString(),
                    InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                    DzjkNo = null
                };

                return intoHospital;
            }
            else
            {
                return null;
            }
        }
    }
}