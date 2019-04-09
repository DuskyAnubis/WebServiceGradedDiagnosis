using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class JYDetail
    {
        public string ItemName { get; set; }
        public string Result { get; set; }
        public string Units { get; set; }
        public string Indicator { get; set; }
        public string ResultRange { get; set; }
        public string Code { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string HospitalId { get; set; }
        public string ReqId { get; set; }

    }
}