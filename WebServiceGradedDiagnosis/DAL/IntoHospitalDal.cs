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
            string sqlBak = "";
            if (string.IsNullOrEmpty(request.IdentCard))
            {
                sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' order by 入院日期 desc";
            }
            else
            {
                sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' or 身份证号='{request.IdentCard}' order by 入院日期 desc";
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

                IntoHospital intoHospital = new IntoHospital
                {
                    HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                    HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                    HospitalNo = dtBak.Rows[0]["住院号"].ToString(),
                    PatientName = dtBak.Rows[0]["姓名"].ToString(),
                    PatientId = dtBak.Rows[0]["病人编号"].ToString(),
                    PatientAge = dtBak.Rows[0]["年龄"].ToString(),
                    IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                    MedicalCardNo = null,
                    GenderCode = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                    GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                    Nation = dtBak.Rows[0]["民族"].ToString(),
                    MaritalStatus = dtBak.Rows[0]["婚否"].ToString(),
                    Address = dtBak.Rows[0]["家庭住址"].ToString(),
                    Birthday = Convert.ToDateTime(dtBak.Rows[0]["出生日期"]).ToString("yyyy-MM-dd"),
                    HealthFileNo = null,
                    Rcvdate = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    Rcvtype = "01",
                    ActionInChief = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["MainNarrative"].ToString() : null,
                    AllergicHistory = null,
                    HisPresentIllness = null,
                    PastHistory = null,
                    PersonalHistory = null,
                    FamilyHistory = null,
                    HisAcqudata = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    CaseStatement = "本人",
                    GreatDegree = "可靠",
                    RecordDate = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    BedNo = dtBak.Rows[0]["床位"].ToString(),
                    Rcvsection = dtBak.Rows[0]["病室"].ToString(),
                    DeptId = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室代码"].ToString() : null,
                    Rcvmemo = dtBak.Rows[0]["病情"].ToString(),
                    Rcvsymptom = dtBak.Rows[0]["入院诊断"].ToString(),
                    AttdoctNo = dtDoc != null && dtDoc.Rows.Count > 0 ? dtDoc.Rows[0]["医师代码"].ToString() : null,
                    Attdoct = dtBak.Rows[0]["医师代码"].ToString(),
                    HoudoctNo = dtDoc != null && dtDoc.Rows.Count > 0 ? dtDoc.Rows[0]["医师代码"].ToString() : null,
                    Houdoct = dtBak.Rows[0]["医师代码"].ToString(),
                    PhysicalExamination = null,
                    AssistantExamination = null,
                    PrimaryDiagnosis = dtBak.Rows[0]["入院诊断"].ToString(),
                    Process = null,
                    BloodAmylase = null,
                    UrineRoutines = null,
                    AmylaseInUrine = null,
                    BloodRoutine = null,
                    ColorUltrasound = null,
                    DischargeDiagnosis = dtBak.Rows[0]["确诊诊断"].ToString(),
                    Recoder = dtBak.Rows[0]["医师代码"].ToString(),
                    RecordingTime = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd"),
                    DoctorSignature = dtBak.Rows[0]["医师代码"].ToString(),
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
                    OutPatientNo=null,
                    InpatientNo= dtBak.Rows[0]["住院号"].ToString(),
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