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
    public class PatientDiseCourseBll
    {
        public XmlDocument ConvertPatientDiseCourseToXml(PatientDiseCourse patientDiseCourse, List<PatientDiseCourseDetail> patientDiseCourseDetails)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 0),
                   new XElement("resultMsg", "获取患者病程记录成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("hospitalId", patientDiseCourse.HospitalId),
                       new XElement("hospitalName", patientDiseCourse.HospitalName),
                       new XElement("patientName", patientDiseCourse.PatientName),
                       new XElement("patientId", patientDiseCourse.PatientId),
                       new XElement("patientAge", patientDiseCourse.PatientAge),
                       new XElement("medicalCardNo", patientDiseCourse.MedicalCardNo),
                       new XElement("outPatientNo", patientDiseCourse.OutPatientNo),
                       new XElement("genderCode", patientDiseCourse.GenderCode),
                       new XElement("genderValue", patientDiseCourse.GenderValue),
                       new XElement("diseCourseNo", patientDiseCourse.DiseCourseNo),
                       new XElement("departments", patientDiseCourse.Departments),
                       from patientDiseCourseDetail in patientDiseCourseDetails
                       select new XElement
                       (
                           "dataList",
                           new XElement("title", patientDiseCourseDetail.Title),
                           new XElement("doctor", patientDiseCourseDetail.Doctor),
                           new XElement("diseCourseTit", patientDiseCourseDetail.DiseCourseTit),
                           new XElement("recordTime", patientDiseCourseDetail.RecordTime),
                           new XElement("recordUserNo", patientDiseCourseDetail.RecordUserNo),
                           new XElement("recordUserName", patientDiseCourseDetail.RecordUserName)
                       ),
                       new XElement("other1", patientDiseCourse.Other1),
                       new XElement("other2", patientDiseCourse.Other2),
                       new XElement("other3", patientDiseCourse.Other3),
                       new XElement("other4", patientDiseCourse.Other4),
                       new XElement("other5", patientDiseCourse.Other5),
                       new XElement("PID", patientDiseCourse.PID),
                       new XElement("identCard", patientDiseCourse.IdentCard),
                       new XElement("inpatientNo", patientDiseCourse.IdentCard),
                       new XElement("dzjkNo", patientDiseCourse.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }
    }
}