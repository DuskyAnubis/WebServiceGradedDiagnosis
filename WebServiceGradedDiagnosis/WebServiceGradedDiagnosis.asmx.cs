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
        public XmlDocument TestRequest(string requestXml)
        {
            XmlDocument doc = new XmlDocument();
            //XDocument xdoc = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),
            //    new XElement("root",
            //    new XElement("item", "1"),
            //    new XElement("item", "2")
            //    ));
            //doc.LoadXml(xdoc.ToString());

            Request request = RequestHelper.GetRequest(requestXml);

            return doc;
        }

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
        public XmlDocument GetJCList(string requestXml)
        {
            JCRecordBll bll = new JCRecordBll();

            JCRecord jCRecord1 = new JCRecord
            {
                PatientName = "患者1"
            };
            JCRecord jCRecord2 = new JCRecord
            {
                PatientName = "患者2"
            };
            JCRecord jCRecord3 = new JCRecord
            {
                PatientName = "患者3"
            };
            List<JCRecord> jCRecords = new List<JCRecord>
            {
                jCRecord1,jCRecord2,jCRecord3
            };

            return bll.ConvertJCRecordToXml(jCRecords);
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
            IntoHospitalBll bll = new IntoHospitalBll();

            IntoHospital intoHospital = new IntoHospital
            {
                HospitalId = "",
                PatientName = "患者"
            };

            return bll.ConvertIntoHospitalToXml(intoHospital);
        }

        [WebMethod]
        public XmlDocument GetPatientDiseCourse(string requestXml)
        {
            PatientDiseCourseBll bll = new PatientDiseCourseBll();

            PatientDiseCourse patientDiseCourse = new PatientDiseCourse
            {
                HospitalId = "",
                PatientName = "患者"
            };

            PatientDiseCourseDetail patientDiseCourseDetail1 = new PatientDiseCourseDetail
            {
                Title = "病程1"
            };
            PatientDiseCourseDetail patientDiseCourseDetail2 = new PatientDiseCourseDetail
            {
                Title = "病程2"
            };
            List<PatientDiseCourseDetail> patientDiseCourseDetails = new List<PatientDiseCourseDetail>
            {
                patientDiseCourseDetail1,
                patientDiseCourseDetail2
            };

            return bll.ConvertPatientDiseCourseToXml(patientDiseCourse, patientDiseCourseDetails);
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
        public XmlDocument GetIOutHospitalInfo(string requestXml)
        {
            OutHospitalBll bll = new OutHospitalBll();

            OutHospital outHospital = new OutHospital
            {
                HospitalId = "",
                PatientName = "患者"
            };

            return bll.ConvertOutHospitalToXml(outHospital);
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
