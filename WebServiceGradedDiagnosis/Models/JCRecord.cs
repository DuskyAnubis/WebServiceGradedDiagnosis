using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class JCRecord
    {
        public string PatientName { get; set; }
        public string GenderValue { get; set; }
        public int PatientAge { get; set; }
        public string AppDiagonse { get; set; }
        public string ChiefComplaint { get; set; }
        public string MedicalHistory { get; set; }
        public string CheckPurpose { get; set; }
        public string ReqId { get; set; }
        public string ItemClass { get; set; }
        public string ItemSubClass { get; set; }
        public string DiagnoseDoc { get; set; }
        public string SendDoc { get; set; }
        public string AuditDoc { get; set; }
        public string Dept { get; set; }
        public string CheckTime { get; set; }
        public string ReportTime { get; set; }
        public string ReceiveTime { get; set; }
        public string CollectTime { get; set; }
        public string ExamView { get; set; }
        public string ExamResult { get; set; }
        public string Impression { get; set; }
        public string Diagnostic { get; set; }
        public int State { get; set; }
        public string HosName { get; set; }
        public string IsKey { get; set; }
        public string DeptCode { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string HospitalId { get; set; }
        public string PID { get; set; }
        public string IdentCard { get; set; }
        public string InpatientNo { get; set; }
        public string OutPatientNo { get; set; }
        public string DzjkNo { get; set; }

    }
}