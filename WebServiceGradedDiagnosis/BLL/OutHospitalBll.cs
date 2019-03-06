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
        public XmlDocument ConvertOutHospitalToXml(OutHospital outHospital)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 1),
                   new XElement("resultMsg", "获取患者出院小结成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("patientId", outHospital.PatientId),
                       new XElement("patientName", outHospital.PatientName),
                       new XElement("hospitalId", outHospital.HospitalId),
                       new XElement("hospitalName", outHospital.HospitalName),
                       new XElement("genderCode", outHospital.GenderCode),
                       new XElement("genderValue", outHospital.GenderValue),
                       new XElement("patientAge", outHospital.PatientAge),
                       new XElement("birthday", outHospital.Birthday),
                       new XElement("nation", outHospital.Nation),
                       new XElement("phone", outHospital.Phone),
                       new XElement("address", outHospital.Address),
                       new XElement("contacts", outHospital.Contacts),
                       new XElement("relationShip", outHospital.RelationShip),
                       new XElement("contactPhone", outHospital.ContactPhone),
                       new XElement("contactAddress", outHospital.ContactAddress),
                       new XElement("identCard", outHospital.IdentCard),
                       new XElement("insuranceTypeCode", outHospital.InsuranceTypeCode),
                       new XElement("insuranceTypeName", outHospital.InsuranceTypeName),
                       new XElement("insuranceNo", outHospital.InsuranceNo),
                       new XElement("inpatientNo", outHospital.InpatientNo),
                       new XElement("inTime", outHospital.InTime),
                       new XElement("outTime", outHospital.OutTime),
                       new XElement("inpatientDays", outHospital.InpatientDays),
                       new XElement("bedNo", outHospital.BedNo),
                       new XElement("rcvdiag", outHospital.Rcvdiag),
                       new XElement("lvediag", outHospital.Lvediag),
                       new XElement("rcvsymptom", outHospital.Rcvsymptom),
                       new XElement("mainChecked", outHospital.MainChecked),
                       new XElement("diagCourse", outHospital.DiagCourse),
                       new XElement("lvesymptom", outHospital.Lvesymptom),
                       new XElement("lveda", outHospital.Lveda),
                       new XElement("diagresult", outHospital.Diagresult),
                       new XElement("attdoctNo", outHospital.AttdoctNo),
                       new XElement("attdoct", outHospital.Attdoct),
                       new XElement("pathologyNo", outHospital.PathologyNo),
                       new XElement("fillingData", outHospital.FillingData),
                       new XElement("other1", outHospital.Other1),
                       new XElement("other2", outHospital.Other2),
                       new XElement("other3", outHospital.Other3),
                       new XElement("other4", outHospital.Other4),
                       new XElement("other5", outHospital.Other5),
                       new XElement("PID", outHospital.PID),
                       new XElement("outPatientNo", outHospital.OutPatientNo),
                       new XElement("dzjkNo", outHospital.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public OutHospital GetOutHospital(Request request)
        {
            OutHospitalDal outHospitalDal = new OutHospitalDal();

            return outHospitalDal.GetOutHospital(request);
        }
    }
}