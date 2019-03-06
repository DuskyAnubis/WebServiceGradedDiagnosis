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
            JYRecordBll bll = new JYRecordBll();

            JYRecord jYRecord1 = new JYRecord
            {
                PatientName = "患者1"
            };
            JYRecord jYRecord2 = new JYRecord
            {
                PatientName = "患者2"
            };
            JYRecord jYRecord3 = new JYRecord
            {
                PatientName = "患者3"
            };
            List<JYRecord> jCRecords = new List<JYRecord>
            {
                jYRecord1,jYRecord2,jYRecord3
            };

            return bll.ConvertJYRecordToXml(jCRecords);
        }

        [WebMethod]
        public XmlDocument GetJYDetail(string requestXml)
        {
            JYDetailBll bll = new JYDetailBll();

            JYDetail jYDetail1 = new JYDetail
            {
                ItemName = "项目1"
            };
            JYDetail jYDetail2 = new JYDetail
            {
                ItemName = "项目2"
            };
            JYDetail jYDetail3 = new JYDetail
            {
                ItemName = "项目3"
            };
            List<JYDetail> jYDetails = new List<JYDetail>
            {
                jYDetail1,jYDetail2,jYDetail3
            };

            return bll.ConvertJYDetailToXml(jYDetails);
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
            PatientChargedBll bll = new PatientChargedBll();

            PatientCharged patientCharged = new PatientCharged
            {
                HospitalId = "",
                PatientName = "患者"
            };

            return bll.ConvertPatientChargedToXml(patientCharged);
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
            PrescriptionBll bll = new PrescriptionBll();

            Prescription prescription = new Prescription
            {
                HospitalId = "",
                PatientName = "患者"
            };

            PrescriptionDetail prescriptionDetail1 = new PrescriptionDetail
            {
                MedicineName = "药品1"
            };
            PrescriptionDetail PrescriptionDetail2 = new PrescriptionDetail
            {
                MedicineName = "药品2"
            };
            List<PrescriptionDetail> prescriptionDetails = new List<PrescriptionDetail>
            {
                prescriptionDetail1,
                PrescriptionDetail2
            };

            return bll.ConvertPrescriptionToXml(prescription, prescriptionDetails);
        }

        [WebMethod]
        public XmlDocument GetPatientMedicalRecords(string requestXml)
        {
            PatientMedicalRecordBll bll = new PatientMedicalRecordBll();

            PatientMedicalRecord patientMedicalRecord = new PatientMedicalRecord
            {
                HospitalId = "",
                PatientName = "患者"
            };

            PrescriptionDetail prescriptionDetail1 = new PrescriptionDetail
            {
                MedicineName = "药品1"
            };
            PrescriptionDetail PrescriptionDetail2 = new PrescriptionDetail
            {
                MedicineName = "药品2"
            };
            List<PrescriptionDetail> prescriptionDetails = new List<PrescriptionDetail>
            {
                prescriptionDetail1,
                PrescriptionDetail2
            };

            return bll.ConvertPatientMedicalRecordToXml(patientMedicalRecord, prescriptionDetails);
        }
    }
}
