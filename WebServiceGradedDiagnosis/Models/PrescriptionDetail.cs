using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGradedDiagnosis.Models
{
    public class PrescriptionDetail
    {
        public string MedicineNO { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCount { get; set; }
        public string MedicineUnit { get; set; }
        public string Usage { get; set; }
    }
}