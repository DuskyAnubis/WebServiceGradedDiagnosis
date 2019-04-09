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
    public class PatientChargedBll
    {
        public XmlDocument ConvertPatientChargedToXml(List<PatientCharged> patientChargeds)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 1),
                   new XElement("resultMsg", "获取患者医嘱信息成功!"),
                   new XElement
                   (
                     "resultContent",
                     from patientCharged in patientChargeds
                     select new XElement
                     (
                         "yzList",
                         new XElement("hospitalId", patientCharged.HospitalId),
                         new XElement("hospitalName", patientCharged.HospitalName),
                         new XElement("inPatientNo", patientCharged.InpatientNo),
                         new XElement("medicalCardNo", patientCharged.MedicalCardNo),
                         new XElement("patientName", patientCharged.PatientName),
                         new XElement("patientAge", patientCharged.PatientAge),
                         new XElement("genderValue", patientCharged.GenderValue),
                         new XElement("identCard", patientCharged.IdentCard),
                         new XElement("departments", patientCharged.Departments),
                         new XElement("daMemo", patientCharged.DAmemo),
                         new XElement("doctor", patientCharged.Doctor),
                         new XElement("nurse", patientCharged.Nurse),
                         new XElement("daType", patientCharged.DAtype),
                         new XElement("promDate", patientCharged.Promdate),
                         new XElement("execDate", patientCharged.Execdate),
                         new XElement("endDate", patientCharged.Enddate),
                         new XElement("medSpec", patientCharged.Medspec),
                         new XElement("medUsage", patientCharged.Medusage),
                         new XElement("dose", patientCharged.Dose),
                         new XElement("frequency", patientCharged.Frequency),
                         new XElement("provide", patientCharged.Provide),
                         new XElement("checkpart", patientCharged.Checkpart),
                         new XElement("remark", patientCharged.Remark),
                         new XElement("other1", patientCharged.Other1),
                         new XElement("other2", patientCharged.Other2),
                         new XElement("other3", patientCharged.Other3),
                         new XElement("other4", patientCharged.Other4),
                         new XElement("other5", patientCharged.Other5),
                         new XElement("pid", patientCharged.PID),
                         new XElement("dzjkNo", patientCharged.DzjkNo)
                     )
                  )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public List<PatientCharged> GetPatientChargeds(Request request)
        {
            PatientChargedDal patientChargedDal = new PatientChargedDal();

            return patientChargedDal.GetPatientChargeds(request);
        }
    }
}