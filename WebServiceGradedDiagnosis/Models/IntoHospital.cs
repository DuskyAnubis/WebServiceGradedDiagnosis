using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class IntoHospital
    {
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string IdentCard { get; set; }
        public string GenderValue { get; set; }
        public string Rcvdate { get; set; }
        public string ActionInChief { get; set; }
        public string AllergicHistory { get; set; }
        public string HisPresentIllness { get; set; }
        public string PastHistory { get; set; }
        public string PersonalHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string RecordDate { get; set; }
        public string PhysicalExamination { get; set; }
        public string AssistantExamination { get; set; }
        public string PrimaryDiagnosis { get; set; }
        public string Process { get; set; }
        public string BloodRoutine { get; set; }
        public string UrineRoutines { get; set; }
        public string AmylaseInUrine { get; set; }
        public string BloodAmylase { get; set; }
        public string ColorUltrasound { get; set; }
        public string DischargeDiagnosis { get; set; }
        public string Recoder { get; set; }
        public string RecordingTime { get; set; }
        public string T { get; set; }
        public string P { get; set; }
        public string R { get; set; }
        public string Bp { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string PID { get; set; }
        public string InpatientNo { get; set; }
        public string DzjkNo { get; set; }

    }
}