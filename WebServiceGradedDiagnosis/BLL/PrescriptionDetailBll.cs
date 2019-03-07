using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebServiceGradedDiagnosis.DAL;
using WebServiceGradedDiagnosis.Models;

namespace WebServiceGradedDiagnosis.BLL
{
    public class PrescriptionDetailBll
    {
        public List<PrescriptionDetail> GetPrescriptionDetails(string cardNo, string startDate, string endDate)
        {
            PrescriptionDetailDal prescriptionDetailDal = new PrescriptionDetailDal();

            return prescriptionDetailDal.GetPrescriptionDetails(cardNo, startDate, endDate);
        }
    }
}