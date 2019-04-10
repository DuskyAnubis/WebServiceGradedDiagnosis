using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class Prescription
    {
        public string MedicalCardNo { get; set; }
        public string OutPatientNo { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string IdentCard { get; set; }
        public string GenderValue { get; set; }
        public string ClinicalDiagnosis { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string OrderDate { get; set; }
        public string DoctorDiagnosis { get; set; }
        public string PrescripName { get; set; }
        public string PrescripTypeId { get; set; }
        public string PrescripTypeName { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string PID { get; set; }
        public string DzjkNo { get; set; }

    }
}