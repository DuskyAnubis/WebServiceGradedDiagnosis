using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;

namespace WebServiceGradedDiagnosis.BLL
{
    public class PatientChargedBll
    {
        public XmlDocument ConvertPatientChargedToXml(PatientCharged patientCharged)
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
                       new XElement("hospitalId", patientCharged.HospitalId),
                       new XElement("hospitalName", patientCharged.HospitalName),
                       new XElement("inpatientNo", patientCharged.InpatientNo),
                       new XElement("patientName", patientCharged.PatientName),
                       new XElement("patientId", patientCharged.PatientId),
                       new XElement("patientAge", patientCharged.PatientAge),
                       new XElement("identCard", patientCharged.IdentCard),
                       new XElement("medicalCardNo", patientCharged.MedicalCardNo),
                       new XElement("seachType", patientCharged.SeachType),
                       new XElement("outPatientNo", patientCharged.OutPatientNo),
                       new XElement("genderCode", patientCharged.GenderCode),
                       new XElement("genderValue", patientCharged.GenderValue),
                       new XElement("departments", patientCharged.Departments),
                       new XElement("promdate", patientCharged.Promdate),
                       new XElement("dAmemo", patientCharged.DAmemo),
                       new XElement("doctor", patientCharged.Doctor),
                       new XElement("nurse", patientCharged.Nurse),
                       new XElement("medID", patientCharged.MedID),
                       new XElement("promdepNo", patientCharged.PromdepNo),
                       new XElement("sickWordName", patientCharged.SickWordName),
                       new XElement("execdepNo", patientCharged.ExecdepNo),
                       new XElement("promdoct", patientCharged.Promdoct),
                       new XElement("execdoctNo", patientCharged.ExecdoctNo),
                       new XElement("dAtype", patientCharged.DAtype),
                       new XElement("execdate", patientCharged.Execdate),
                       new XElement("enddate", patientCharged.Enddate),
                       new XElement("medspec", patientCharged.Medspec),
                       new XElement("medusage", patientCharged.Medusage),
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
                       new XElement("PID", patientCharged.PID),
                       new XElement("dzjkNo", patientCharged.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }
    }
}