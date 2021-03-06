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
    public class JYDetailBll
    {
        public string ConvertJYDetailToXml(List<JYDetail> jYDetails)
        {
            //XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = new XDocument
            (
             new XDeclaration("1.0", "utf-8", "yes"),
             new XElement
             (
                 "response",
                 new XElement("resultCode", 0),
                 new XElement("resultMsg", "获取患者检验记录详情成功!"),
                 new XElement
                 (
                     "resultContent",
                     from jyDetail in jYDetails
                     select new XElement
                     (
                         "infos",
                         new XElement("itemName", jyDetail.ItemName),
                         new XElement("result", jyDetail.Result),
                         new XElement("units", jyDetail.Units),
                         new XElement("indicator", jyDetail.Indicator),
                         new XElement("resultRange", jyDetail.ResultRange),
                         new XElement("code", jyDetail.Code),
                         new XElement("other1", jyDetail.Other1),
                         new XElement("other2", jyDetail.Other2),
                         new XElement("other3", jyDetail.Other3),
                         new XElement("other4", jyDetail.Other4),
                         new XElement("other5", jyDetail.Other5),
                         new XElement("hospitalId", jyDetail.HospitalId),
                         new XElement("reqId", jyDetail.ReqId)
                     )
                 )
             )
           );

            //xmlDoc.LoadXml(xDoc.ToString());

            return xDoc.ToString();
        }

        public List<JYDetail> GetJYDetails(JYDetailRequest request)
        {
            JYDetailDal jYDetailDal = new JYDetailDal();

            return jYDetailDal.GetJYDetails(request);
        }
    }
}