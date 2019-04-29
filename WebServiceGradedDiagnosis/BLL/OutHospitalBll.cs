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
    public class OutHospitalBll
    {
        public string ConvertOutHospitalToXml(OutHospital outHospital)
        {
            //XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 0),
                   new XElement("resultMsg", "获取患者出院小结成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("patientName", outHospital.PatientName),
                       new XElement("hospitalId", outHospital.HospitalId),
                       new XElement("hospitalName", outHospital.HospitalName),
                       new XElement("genderValue", outHospital.GenderValue),
                       new XElement("patientAge", outHospital.PatientAge),
                       new XElement("identCard", outHospital.IdentCard),
                       new XElement("inPatientNo", outHospital.InpatientNo),
                       new XElement("inTime", outHospital.InTime),
                       new XElement("outTime", outHospital.OutTime),
                       new XElement("rcvDiag", outHospital.Rcvdiag),
                       new XElement("lveDiag", outHospital.Lvediag),
                       new XElement("rcvsyMptom", outHospital.Rcvsymptom),
                       new XElement("mainChecked", outHospital.MainChecked),
                       new XElement("diagCourse", outHospital.DiagCourse),
                       new XElement("lvesyMptom", outHospital.Lvesymptom),
                       new XElement("lveda", outHospital.Lveda),
                       new XElement("diagResult", outHospital.Diagresult),
                       new XElement("attDoctNo", outHospital.AttdoctNo),
                       new XElement("attDoct", outHospital.Attdoct),
                       new XElement("pathologyNo", outHospital.PathologyNo),
                       new XElement("fillingData", outHospital.FillingData),
                       new XElement("other1", outHospital.Other1),
                       new XElement("other2", outHospital.Other2),
                       new XElement("other3", outHospital.Other3),
                       new XElement("other4", outHospital.Other4),
                       new XElement("other5", outHospital.Other5),
                       new XElement("pid", outHospital.PID),
                       new XElement("dzjkNo", outHospital.DzjkNo)
                   )
                )
            );

            //xmlDoc.LoadXml(xDoc.ToString());

            return xDoc.ToString();
        }

        public OutHospital GetOutHospital(Request request)
        {
            OutHospitalDal outHospitalDal = new OutHospitalDal();

            return outHospitalDal.GetOutHospital(request);
        }
    }
}