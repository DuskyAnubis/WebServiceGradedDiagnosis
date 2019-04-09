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
    public class JYRecordBll
    {
        public XmlDocument ConvertJYRecordToXml(List<JYRecord> jYRecords)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
              new XDeclaration("1.0", "utf-8", "yes"),
              new XElement
              (
                 "response",
                 new XElement("resultCode", 1),
                 new XElement("resultMsg", "获取患者检验记录成功!"),
                 new XElement
                 (
                     "resultContent",
                     from jyRecord in jYRecords
                     select new XElement
                     (
                         "jyList",
                         new XElement("reqId", jyRecord.ReqId),
                         new XElement("itemClass", jyRecord.ItemClass),
                         new XElement("itemSubClass", jyRecord.ItemSubClass),
                         new XElement("dept", jyRecord.Dept),
                         new XElement("checkType", jyRecord.CheckType),
                         new XElement("checkTime", jyRecord.CheckTime),
                         new XElement("reportTime", jyRecord.ReportTime),
                         new XElement("receiveTime", jyRecord.ReceiveTime),
                         new XElement("collectTime", jyRecord.CollectTime),
                         new XElement("diagnostic", jyRecord.Diagnostic),
                         new XElement("state", jyRecord.State),
                         new XElement("patientName", jyRecord.PatientName),
                         new XElement("genderValue", jyRecord.GenderValue),
                         new XElement("patientAge", jyRecord.PatientAge),
                         new XElement("appDiagonse", jyRecord.AppDiagonse),
                         new XElement("chiefComplaint", jyRecord.ChiefComplaint),
                         new XElement("medicalHistory", jyRecord.MedicalHistory),
                         new XElement("checkPurpose", jyRecord.CheckPurpose),
                         new XElement("hosName", jyRecord.HosName),
                         new XElement("isKey", jyRecord.IsKey),
                         new XElement("deptCode", jyRecord.DeptCode),
                         new XElement("other1", jyRecord.Other1),
                         new XElement("other2", jyRecord.Other2),
                         new XElement("other3", jyRecord.Other3),
                         new XElement("other4", jyRecord.Other4),
                         new XElement("other5", jyRecord.Other5),
                         new XElement("hospitalId", jyRecord.HospitalId),
                         new XElement("pid", jyRecord.PID),
                         new XElement("identCard", jyRecord.IdentCard),
                         new XElement("inpatientNo", jyRecord.InpatientNo),
                         new XElement("outPatientNo", jyRecord.OutPatientNo),
                         new XElement("dzjkNo", jyRecord.DzjkNo)
                     )
                 )
              )
           );

            xmlDoc.LoadXml(xDoc.ToString());

            return xmlDoc;
        }

        public List<JYRecord> GetJYRecords(Request request)
        {
            JYRecordDal jYRecordDal = new JYRecordDal();

            return jYRecordDal.GetJYRecords(request);
        }

    }
}