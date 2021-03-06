﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class PatientMedicalRecord
    {
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string MedicalCardNo { get; set; }
        public string OutPatientNo { get; set; }
        public string PatientName { get; set; }
        public string IdentCard { get; set; }
        public string GenderValue { get; set; }
        public string PatientAge { get; set; }
        public string ClinicTime { get; set; }
        public string ClinicDepartments { get; set; }
        public string ActionInChief { get; set; }
        public string HisPresentIllness { get; set; }
        public string PastHistory { get; set; }
        public string PersonalHistory { get; set; }
        public string AllergicHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string PhysicalExamination { get; set; }
        public string AuxiliaryExaminations { get; set; }
        public string PreliminaryJudgment { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string PID { get; set; }
        public string DzjkNo { get; set; }

    }
}