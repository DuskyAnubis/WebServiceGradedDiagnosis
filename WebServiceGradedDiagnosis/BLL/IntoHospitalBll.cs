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
    public class IntoHospitalBll
    {
        public XmlDocument ConvertIntoHospitalToXml(IntoHospital intoHospital)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 1),
                   new XElement("resultMsg", "获取患者入院记录成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("hospitalId", intoHospital.HospitalId),
                       new XElement("hospitalName", intoHospital.HospitalName),
                       new XElement("hospitalNo", intoHospital.HospitalNo),
                       new XElement("patientName", intoHospital.PatientName),
                       new XElement("patientId", intoHospital.PatientId),
                       new XElement("patientAge", intoHospital.PatientAge),
                       new XElement("identCard", intoHospital.IdentCard),
                       new XElement("medicalCardNo", intoHospital.MedicalCardNo),
                       new XElement("genderCode", intoHospital.GenderCode),
                       new XElement("genderValue", intoHospital.GenderValue),
                       new XElement("nation", intoHospital.Nation),
                       new XElement("maritalStatus", intoHospital.MaritalStatus),
                       new XElement("address", intoHospital.Address),
                       new XElement("birthday", intoHospital.Birthday),
                       new XElement("healthFileNo", intoHospital.HealthFileNo),
                       new XElement("rcvdate", intoHospital.Rcvdate),
                       new XElement("rcvtype", intoHospital.Rcvtype),
                       new XElement("actionInChief", intoHospital.ActionInChief),
                       new XElement("allergicHistory", intoHospital.AllergicHistory),
                       new XElement("hisPresentIllness", intoHospital.HisPresentIllness),
                       new XElement("pastHistory", intoHospital.PastHistory),
                       new XElement("personalHistory", intoHospital.PersonalHistory),
                       new XElement("familyHistory", intoHospital.FamilyHistory),
                       new XElement("hisAcqudata", intoHospital.HisAcqudata),
                       new XElement("caseStatement", intoHospital.CaseStatement),
                       new XElement("greatDegree", intoHospital.GreatDegree),
                       new XElement("recordDate", intoHospital.RecordDate),
                       new XElement("bedNo", intoHospital.BedNo),
                       new XElement("rcvsection", intoHospital.Rcvsection),
                       new XElement("deptId", intoHospital.DeptId),
                       new XElement("rcvmemo", intoHospital.Rcvmemo),
                       new XElement("rcvsymptom", intoHospital.Rcvsymptom),
                       new XElement("attdoctNo", intoHospital.AttdoctNo),
                       new XElement("attdoct", intoHospital.Attdoct),
                       new XElement("houdoctNo", intoHospital.HoudoctNo),
                       new XElement("houdoct", intoHospital.Houdoct),
                       new XElement("physicalExamination", intoHospital.PhysicalExamination),
                       new XElement("assistantExamination", intoHospital.AssistantExamination),
                       new XElement("primaryDiagnosis", intoHospital.PrimaryDiagnosis),
                       new XElement("process", intoHospital.Process),
                       new XElement("bloodRoutine", intoHospital.BloodRoutine),
                       new XElement("urineRoutines", intoHospital.UrineRoutines),
                       new XElement("amylaseInUrine", intoHospital.AmylaseInUrine),
                       new XElement("bloodAmylase", intoHospital.BloodAmylase),
                       new XElement("colorUltrasound", intoHospital.ColorUltrasound),
                       new XElement("dischargeDiagnosis", intoHospital.DischargeDiagnosis),
                       new XElement("recoder", intoHospital.Recoder),
                       new XElement("recordingTime", intoHospital.RecordingTime),
                       new XElement("doctorSignature", intoHospital.DoctorSignature),
                       new XElement("t", intoHospital.T),
                       new XElement("p", intoHospital.P),
                       new XElement("r", intoHospital.R),
                       new XElement("bp", intoHospital.Bp),
                       new XElement("other1", intoHospital.Other1),
                       new XElement("other2", intoHospital.Other2),
                       new XElement("other3", intoHospital.Other3),
                       new XElement("other4", intoHospital.Other4),
                       new XElement("other5", intoHospital.Other5),
                       new XElement("PID", intoHospital.PID),
                       new XElement("outPatientNo", intoHospital.OutPatientNo),
                       new XElement("inpatientNo", intoHospital.InpatientNo),
                       new XElement("dzjkNo", intoHospital.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }
    }
}