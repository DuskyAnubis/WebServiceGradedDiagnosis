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
    public class PatientMedicalRecordBll
    {
        public XmlDocument ConvertPatientMedicalRecordToXml(PatientMedicalRecord patientMedicalRecord, List<PrescriptionDetail> prescriptionDetails)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 1),
                   new XElement("resultMsg", "获取患者门诊病历成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("hospitalId", patientMedicalRecord.HospitalId),
                       new XElement("hospitalName", patientMedicalRecord.HospitalName),
                       new XElement("medicalCardNo", patientMedicalRecord.MedicalCardNo),
                       new XElement("outPatientNo", patientMedicalRecord.OutPatientNo),
                       new XElement("healthFileNo", patientMedicalRecord.HealthFileNo),
                       new XElement("patientId", patientMedicalRecord.PatientId),
                       new XElement("patientName", patientMedicalRecord.PatientName),
                       new XElement("identCard", patientMedicalRecord.IdentCard),
                       new XElement("genderCode", patientMedicalRecord.GenderCode),
                       new XElement("genderValue", patientMedicalRecord.GenderValue),
                       new XElement("patientAge", patientMedicalRecord.PatientAge),
                       new XElement("nation", patientMedicalRecord.Nation),
                       new XElement("profession", patientMedicalRecord.Profession),
                       new XElement("maritalStatus", patientMedicalRecord.MaritalStatus),
                       new XElement("phone", patientMedicalRecord.Phone),
                       new XElement("address", patientMedicalRecord.Address),
                       new XElement("clinicTime", patientMedicalRecord.ClinicTime),
                       new XElement("clinicDepartments", patientMedicalRecord.ClinicDepartments),
                       new XElement("actionInChief", patientMedicalRecord.ActionInChief),
                       new XElement("hisPresentIllness", patientMedicalRecord.HisPresentIllness),
                       new XElement("pastHistory", patientMedicalRecord.PastHistory),
                       new XElement("personalHistory", patientMedicalRecord.PersonalHistory),
                       new XElement("allergicHistory", patientMedicalRecord.AllergicHistory),
                       new XElement("familyHistory", patientMedicalRecord.FamilyHistory),
                       new XElement("physicalExamination", patientMedicalRecord.PhysicalExamination),
                       new XElement("auxiliaryExaminations", patientMedicalRecord.AuxiliaryExaminations),
                       new XElement("preliminaryJudgment", patientMedicalRecord.PreliminaryJudgment),
                       new XElement("process", patientMedicalRecord.Process),
                       new XElement("direction", patientMedicalRecord.Direction),
                       new XElement("departureTime", patientMedicalRecord.DepartureTime),
                       new XElement("doctor", patientMedicalRecord.Doctor),
                       from prescriptionDetail in prescriptionDetails
                       select new XElement
                       (
                           "prescriptionList",
                           new XElement("medicineNO", prescriptionDetail.MedicineNO),
                           new XElement("medicineName", prescriptionDetail.MedicineName),
                           new XElement("medicineCount", prescriptionDetail.MedicineCount),
                           new XElement("medicineUnit", prescriptionDetail.MedicineUnit),
                           new XElement("usage", prescriptionDetail.Usage)
                       ),
                       new XElement("other1", patientMedicalRecord.Other1),
                       new XElement("other2", patientMedicalRecord.Other2),
                       new XElement("other3", patientMedicalRecord.Other3),
                       new XElement("other4", patientMedicalRecord.Other4),
                       new XElement("other5", patientMedicalRecord.Other5),
                       new XElement("hospitalId", patientMedicalRecord.HospitalId),
                       new XElement("PID", patientMedicalRecord.PID),
                       new XElement("inpatientNo", patientMedicalRecord.IdentCard),
                       new XElement("dzjkNo", patientMedicalRecord.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public PatientMedicalRecord GetPatientMedicalRecord(Request request)
        {
            PatientMedicalRecordDal patientMedicalRecordDal = new PatientMedicalRecordDal();

            return patientMedicalRecordDal.GetPatientMedicalRecord(request);
        }
    }
}