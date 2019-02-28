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

            Request request= RequestHelper.GetRequest(requestXml);

            return doc;
        }

        [WebMethod]
        public XmlDocument GetPatientInfoBySeachType(string requestXml)
        {
            XmlDocument doc = new XmlDocument();

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
    }
}
