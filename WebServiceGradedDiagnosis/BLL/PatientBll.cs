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
    public class PatientBll
    {
        public XmlDocument ConvertPatientToXml(Patient patient)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 0),
                   new XElement("resultMsg", "获取患者基本信息成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("pid", patient.PID),
                       new XElement("patientName", patient.PatientName),
                       new XElement("hospitalId", patient.HospitalId),
                       new XElement("hospitalName", patient.HospitalName),
                       new XElement("genderValue", patient.GenderValue),
                       new XElement("patientAge", patient.PatientAge),
                       new XElement("identCard", patient.IdentCard),
                       new XElement("nation", patient.Nation),
                       new XElement("birthday", patient.Birthday),
                       new XElement("patientStature", patient.PatientStature),
                       new XElement("patientWeight", patient.PatientWeight),
                       new XElement("phone", patient.Phone),
                       new XElement("address", patient.Address),
                       new XElement("contacts", patient.Contacts),
                       new XElement("relationShip", patient.RelationShip),
                       new XElement("contactPhone", patient.ContactPhone),
                       new XElement("contactAddress", patient.ContactAddress),
                       new XElement("insuranceTypeCode", patient.InsuranceTypeCode),
                       new XElement("insuranceTypeName", patient.InsuranceTypeName),
                       new XElement("insuranceNo", patient.InsuranceNo),
                       new XElement("deptCode", patient.DeptCode),
                       new XElement("deptName", patient.DeptName),
                       new XElement("appDiagonse", patient.AppDiagonse),
                       new XElement("chiefComplaint", patient.ChiefComplaint),
                       new XElement("medicalHistory", patient.MedicalHistory),
                       new XElement("patientSign", patient.PatientSign),
                       new XElement("patientExtraStudy", patient.PatientExtraStudy),
                       new XElement("auxiliaryRecord", patient.AuxiliaryRecord),
                       new XElement("checkTime", patient.CheckTime),
                       new XElement("outPatientNo", patient.OutPatientNo),
                       new XElement("inPatientNo", patient.InpatientNo),
                       new XElement("inTime", patient.InTime),
                       new XElement("outTime", patient.OutTime),
                       new XElement("other1", patient.Other1),
                       new XElement("other2", patient.Other2),
                       new XElement("other3", patient.Other3),
                       new XElement("other4", patient.Other4),
                       new XElement("other5", patient.Other5),
                       new XElement("dzjkNo", patient.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public Patient GetPatient(Request request)
        {
            PatientDal patientDal = new PatientDal();

            return patientDal.GetPatient(request);
        }
    }
}