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
    public class JCRecordBll
    {
        public XmlDocument ConvertJCRecordToXml(List<JCRecord> jCRecords)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
               new XDeclaration("1.0", "utf-8", "yes"),
               new XElement
               (
                  "response",
                  new XElement("resultCode", 0),
                  new XElement("resultMsg", "获取患者检查记录成功!"),
                  new XElement
                  (
                      "resultContent",
                      from jcRecord in jCRecords
                      select new XElement
                      (
                          "jcList",
                          new XElement("patientName", jcRecord.PatientName),
                          new XElement("genderValue", jcRecord.GenderValue),
                          new XElement("patientAge", jcRecord.PatientAge),
                          new XElement("appDiagonse", jcRecord.AppDiagonse),
                          new XElement("chiefComplaint", jcRecord.ChiefComplaint),
                          new XElement("medicalHistory", jcRecord.MedicalHistory),
                          new XElement("checkPurpose", jcRecord.CheckPurpose),
                          new XElement("reqId", jcRecord.ReqId),
                          new XElement("itemClass", jcRecord.ItemClass),
                          new XElement("itemSubClass", jcRecord.ItemSubClass),
                          new XElement("diagnoseDoc", jcRecord.DiagnoseDoc),
                          new XElement("sendDoc", jcRecord.SendDoc),
                          new XElement("auditDoc", jcRecord.AuditDoc),
                          new XElement("dept", jcRecord.Dept),
                          new XElement("deptCode", jcRecord.DeptCode),
                          new XElement("checkTime", jcRecord.CheckTime),
                          new XElement("reportTime", jcRecord.ReportTime),
                          new XElement("receiveTime", jcRecord.ReceiveTime),
                          new XElement("collectTime", jcRecord.CollectTime),
                          new XElement("examView", jcRecord.ExamView),
                          new XElement("impression", jcRecord.Impression),
                          new XElement("examResult", jcRecord.ExamResult),
                          new XElement("state", jcRecord.State),
                          new XElement("hosName", jcRecord.HosName),
                          new XElement("isKey", jcRecord.IsKey),
                          new XElement("other1", jcRecord.Other1),
                          new XElement("other2", jcRecord.Other2),
                          new XElement("other3", jcRecord.Other3),
                          new XElement("other4", jcRecord.Other4),
                          new XElement("other5", jcRecord.Other5),
                          new XElement("hospitalId", jcRecord.HospitalId),
                          new XElement("PID", jcRecord.PID),
                          new XElement("identCard", jcRecord.IdentCard),
                          new XElement("inPatientNo", jcRecord.InpatientNo),
                          new XElement("outPatientNo", jcRecord.OutPatientNo),
                          new XElement("dzjkNo", jcRecord.DzjkNo)
                      )
                  )
               )
           );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }
    }
}