using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class OutHospital
    {

        public string PatientName { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string GenderValue { get; set; }
        public string PatientAge { get; set; }
        public string IdentCard { get; set; }
        public string InpatientNo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Rcvdiag { get; set; }
        public string Lvediag { get; set; }
        public string Rcvsymptom { get; set; }
        public string MainChecked { get; set; }
        public string DiagCourse { get; set; }
        public string Lvesymptom { get; set; }
        public string Lveda { get; set; }
        public string Diagresult { get; set; }
        public string AttdoctNo { get; set; }
        public string Attdoct { get; set; }
        public string PathologyNo { get; set; }
        public string FillingData { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string PID { get; set; }
        public string DzjkNo { get; set; }

    }
}