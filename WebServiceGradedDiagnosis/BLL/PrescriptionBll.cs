﻿using System;
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
        public string ConvertPrescriptionToXml(Prescription prescription, List<PrescriptionDetail> prescriptionDetails)
        {
            //XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                   new XElement("resultCode", 0),
                   new XElement("resultMsg", "获取患者门诊处方成功!"),
                   new XElement
                   (
                       "resultContent",
                       new XElement("medicalCardNo", prescription.MedicalCardNo),
                       new XElement("outPatientNo", prescription.OutPatientNo),
                       new XElement("patientName", prescription.PatientName),
                       new XElement("patientAge", prescription.PatientAge),
                       new XElement("identCard", prescription.IdentCard),
                       new XElement("genderValue", prescription.GenderValue),
                       new XElement("clinicalDiagnosis", prescription.ClinicalDiagnosis),
                       new XElement("hospitalName", prescription.HospitalName),
                       from prescriptionDetail in prescriptionDetails
                       select new XElement
                       (
                           "prescriptionList",
                           new XElement("medicineNo", prescriptionDetail.MedicineNO),
                           new XElement("medicineName", prescriptionDetail.MedicineName),
                           new XElement("medicineCount", prescriptionDetail.MedicineCount),
                           new XElement("medicineUnit", prescriptionDetail.MedicineUnit),
                           new XElement("usageSum", prescriptionDetail.Usage)
                       ),
                       new XElement("orderDate", prescription.OrderDate),
                       new XElement("doctorDiagnosis", prescription.DoctorDiagnosis),
                       new XElement("prescripName", prescription.PrescripName),
                       new XElement("prescripTypeId", prescription.PrescripTypeId),
                       new XElement("prescripTypeName", prescription.PrescripTypeName),
                       new XElement("other1", prescription.Other1),
                       new XElement("other2", prescription.Other2),
                       new XElement("other3", prescription.Other3),
                       new XElement("other4", prescription.Other4),
                       new XElement("other5", prescription.Other5),
                       new XElement("hospitalId", prescription.HospitalId),
                       new XElement("pid", prescription.PID),
                       new XElement("dzjkNo", prescription.DzjkNo)
                   )
                )
            );

            //xmlDoc.LoadXml(xDoc.ToString());

            return xDoc.ToString();
        }

        public Prescription GetPrescription(Request request)
        {
            PrescriptionDal prescriptionDal = new PrescriptionDal();

            return prescriptionDal.GetPrescription(request);
        }
    }
}