﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using WebServiceGradedDiagnosis.Models;

namespace WebServiceGradedDiagnosis.Common
{
    public static class RequestHelper
    {
        public static Request GetRequest(string requestXml)
        {
            XmlReader xmlReader = XmlReader.Create(new StringReader(requestXml));
            XDocument xdoc = XDocument.Load(xmlReader);
            Request request = new Request
            {
                HospitalId = xdoc.Element("request").Element("hospitalId").Value,
                IdentCard = xdoc.Element("request").Element("identCard").Value,
                InPatientNo = xdoc.Element("request").Element("inpatientNo").Value,
                OutPatientNo = xdoc.Element("request").Element("outPatientNo").Value,
                PID = xdoc.Element("request").Element("PID").Value,
                DzjkNo = xdoc.Element("request").Element("dzjkNo").Value,
                Other1 = xdoc.Element("request").Element("other1").Value,
                Other2 = xdoc.Element("request").Element("other2").Value
            };

            return request;
        }

        private static string CleanStringEmpty(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sb = new StringBuilder();
                string[] newStr = str.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < newStr.Length; i++)
                {
                    sb.Append(newStr[i].Trim());
                }
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}