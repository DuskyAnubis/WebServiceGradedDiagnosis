using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class Request
    {
        public string HospitalId { get; set; }
        public string PID { get; set; }
        public string IdentCard { get; set; }
        public string InPatientNo { get; set; }
        public string OutPatientNo { get; set; }
        public string DzjkNo { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
    }

    public class JYDetailRequest
    {
        public string HospitalId { get; set; }
        public string ReqId { get; set; } 
    }
}