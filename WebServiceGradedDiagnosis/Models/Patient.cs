using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class Patient
    {
        public string PID { get; set; }
        public string PatientName { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string GenderValue { get; set; }
        public int PatientAge { get; set; }
        public string IdentCard { get; set; }
        public string Birthday { get; set; }
        public string Nation { get; set; }
        public string PatientStature { get; set; }
        public string PatientWeight { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string RelationShip { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string InsuranceTypeCode { get; set; }
        public string InsuranceTypeName { get; set; }
        public string InsuranceNo { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string AppDiagonse { get; set; }
        public string ChiefComplaint { get; set; }
        public string MedicalHistory { get; set; }
        public string PatientSign { get; set; }
        public string PatientExtraStudy { get; set; }
        public string AuxiliaryRecord { get; set; }
        public string CheckTime { get; set; }
        public string OutPatientNo { get; set; }
        public string InpatientNo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string DzjkNo { get; set; }

    }
}