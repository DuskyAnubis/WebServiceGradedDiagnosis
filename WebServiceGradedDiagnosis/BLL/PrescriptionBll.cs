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
    public class PrescriptionBll
    {
        public XmlDocument ConvertPrescriptionToXml(Prescription prescription, List<PrescriptionDetail> prescriptionDetails)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 1),
                   new XElement("resultMsg", "获取患者门诊处方成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("medicalCardNo", prescription.MedicalCardNo),
                       new XElement("outPatientNo", prescription.OutPatientNo),
                       new XElement("patientId", prescription.PatientId),
                       new XElement("patientName", prescription.PatientName),
                       new XElement("patientAge", prescription.PatientAge),
                       new XElement("identCard", prescription.IdentCard),
                       new XElement("genderCode", prescription.GenderCode),
                       new XElement("genderValue", prescription.GenderValue),
                       new XElement("phone", prescription.Phone),
                       new XElement("clinicalDiagnosis", prescription.ClinicalDiagnosis),
                       new XElement("hospitalId", prescription.HospitalId),
                       new XElement("hospitalName", prescription.HospitalName),
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
                       new XElement("orderDate", prescription.OrderDate),
                       new XElement("doctorDiagnosis", prescription.DoctorDiagnosis),
                       new XElement("prescripTid", prescription.PrescripTid),
                       new XElement("prescripTname", prescription.PrescripTname),
                       new XElement("prescripId", prescription.PrescripId),
                       new XElement("prescripName", prescription.PrescripName),
                       new XElement("prescripTypeId", prescription.PrescripTypeId),
                       new XElement("prescripTypeName", prescription.PrescripTypeName),
                       new XElement("deptId", prescription.DeptId),
                       new XElement("deptName", prescription.DeptName),
                       new XElement("doctorId", prescription.DoctorId),
                       new XElement("doctorName", prescription.DoctorName),
                       new XElement("doctorId", prescription.DoctorId),
                       new XElement("doctorName", prescription.DoctorName),
                       new XElement("other1", prescription.Other1),
                       new XElement("other2", prescription.Other2),
                       new XElement("other3", prescription.Other3),
                       new XElement("other4", prescription.Other4),
                       new XElement("other5", prescription.Other5),
                       new XElement("hospitalId", prescription.HospitalId),
                       new XElement("PID", prescription.PID),
                       new XElement("inpatientNo", prescription.IdentCard),
                       new XElement("dzjkNo", prescription.DzjkNo)
                   )
                )
            );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public Prescription GetPrescription(Request request)
        {
            PrescriptionDal prescriptionDal = new PrescriptionDal();

            return prescriptionDal.GetPrescription(request);
        }
    }
}