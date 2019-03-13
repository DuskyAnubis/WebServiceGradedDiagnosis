using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;
using WebServiceGradedDiagnosis.BLL;


namespace WebServiceGradedDiagnosis
{
    /// <summary>
    /// WebServiceGradedDiagnosis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://yksoft.com/gradeddiagnosis")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGradedDiagnosis : System.Web.Services.WebService
    {
        [WebMethod]
        public XmlDocument GetPatientInfoBySeachType(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                PatientBll patientBll = new PatientBll();
                Patient patient = patientBll.GetPatient(request);

                if (patient is null)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者基本信息!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = patientBll.ConvertPatientToXml(patient);
                }

            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                   (
                     new XDeclaration("1.0", "utf-8", "yes"),
                     new XElement
                     (
                      "response",
                      new XElement("resultCode", 0),
                      new XElement("resultMsg", "系统出现内部错误!"),
                      new XElement("resultContent")
                     )
                   );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetJCList(string requestXml)
        {
            XmlDocument doc;
            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                    new XElement("resultCode", 0),
                    new XElement("resultMsg", "系统未能查询到患者检查记录!"),
                    new XElement("resultContent")
                 )
            );
            doc = new XmlDocument();
            doc.LoadXml(xDoc.ToString());

            return doc;
        }

        [WebMethod]
        public XmlDocument GetJYList(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                JYRecordBll jYRecordBll = new JYRecordBll();
                List<JYRecord> jYRecords = jYRecordBll.GetJYRecords(request);

                if (jYRecords == null || jYRecords.Count == 0)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到检验报告信息!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = jYRecordBll.ConvertJYRecordToXml(jYRecords);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetJYDetail(string requestXml)
        {
            XmlDocument doc;
            try
            {
                JYDetailRequest request = RequestHelper.GetJYDetailRequest(requestXml);
                JYDetailBll jYDetailBll = new JYDetailBll();
                List<JYDetail> jYDetails = jYDetailBll.GetJYDetails(request);

                if (jYDetails == null || jYDetails.Count == 0)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到检验报告详情!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = jYDetailBll.ConvertJYDetailToXml(jYDetails);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetIntoHospitalList(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                IntoHospitalBll intoHospitalBll = new IntoHospitalBll();
                IntoHospital intoHospital = intoHospitalBll.GetIntoHospital(request);

                if (intoHospital is null)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者入院记录!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = intoHospitalBll.ConvertIntoHospitalToXml(intoHospital);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetPatientDiseCourse(string requestXml)
        {
            XmlDocument doc;
            XDocument xDoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                   "response",
                    new XElement("resultCode", 0),
                    new XElement("resultMsg", "系统未能查询到患者病程记录!"),
                    new XElement("resultContent")
                )
            );
            doc = new XmlDocument();
            doc.LoadXml(xDoc.ToString());

            return doc;
        }

        [WebMethod]
        public XmlDocument GetIPatientCharged(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                PatientChargedBll patientChargedBll = new PatientChargedBll();
                List<PatientCharged> patientChargeds = patientChargedBll.GetPatientChargeds(request);

                if (patientChargeds == null || patientChargeds.Count == 0)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者医嘱信息!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = patientChargedBll.ConvertPatientChargedToXml(patientChargeds);
                }
            }
            catch (Exception ex)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetOutHospitalInfo(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                OutHospitalBll outHospitalBll = new OutHospitalBll();
                OutHospital outHospital = outHospitalBll.GetOutHospital(request);

                if (outHospital is null)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者出院小结!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    doc = outHospitalBll.ConvertOutHospitalToXml(outHospital);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetPrescriptionInfo(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                PrescriptionBll prescriptionBll = new PrescriptionBll();
                Prescription prescription = prescriptionBll.GetPrescription(request);

                if (prescription is null)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者门诊处方!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    string startDate = prescription.OrderDate + " 00:00:00";
                    string endDate = prescription.OrderDate + " 23:59:59";

                    PrescriptionDetailBll prescriptionDetailBll = new PrescriptionDetailBll();
                    List<PrescriptionDetail> prescriptionDetails = prescriptionDetailBll.GetPrescriptionDetails(prescription.MedicalCardNo, startDate, endDate);

                    doc = prescriptionBll.ConvertPrescriptionToXml(prescription, prescriptionDetails);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }

        [WebMethod]
        public XmlDocument GetPatientMedicalRecords(string requestXml)
        {
            XmlDocument doc;
            try
            {
                Request request = RequestHelper.GetRequest(requestXml);
                PatientMedicalRecordBll patientMedicalRecordBll = new PatientMedicalRecordBll();
                PatientMedicalRecord patientMedicalRecord = patientMedicalRecordBll.GetPatientMedicalRecord(request);

                if (patientMedicalRecord is null)
                {
                    XDocument xDoc = new XDocument
                    (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement
                      (
                       "response",
                       new XElement("resultCode", 0),
                       new XElement("resultMsg", "未能查询到患者门诊病历!"),
                       new XElement("resultContent")
                      )
                    );
                    doc = new XmlDocument();
                    doc.LoadXml(xDoc.ToString());
                }
                else
                {
                    string startDate = patientMedicalRecord.ClinicTime + " 00:00:00";
                    string endDate = patientMedicalRecord.ClinicTime + " 23:59:59";

                    PrescriptionDetailBll prescriptionDetailBll = new PrescriptionDetailBll();
                    List<PrescriptionDetail> prescriptionDetails = prescriptionDetailBll.GetPrescriptionDetails(patientMedicalRecord.MedicalCardNo, startDate, endDate);

                    doc = patientMedicalRecordBll.ConvertPatientMedicalRecordToXml(patientMedicalRecord, prescriptionDetails);
                }
            }
            catch (Exception)
            {
                XDocument xDoc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement
                    (
                     "response",
                     new XElement("resultCode", 0),
                     new XElement("resultMsg", "系统出现内部错误!"),
                     new XElement("resultContent")
                    )
                  );
                doc = new XmlDocument();
                doc.LoadXml(xDoc.ToString());
                return doc;
            }
            return doc;
        }
    }
}
