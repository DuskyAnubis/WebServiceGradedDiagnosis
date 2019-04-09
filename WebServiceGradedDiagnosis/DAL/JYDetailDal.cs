using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;
using System.Text;


namespace WebServiceGradedDiagnosis.DAL
{
    public class JYDetailDal
    {
        public List<JYDetail> GetJYDetails(JYDetailRequest request)
        {
            string sqlJyDetail = $"select testno,itemno,itemname,testresult,isnull(resultflag,'') as resultflag,isnull(units,'') as units,isnull(ranges,'') as ranges from lis_reqresult where testno='{request.ReqId}' order by seqno";
            DataTable dtJyDetail = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HosdataConnectionString"), sqlJyDetail).Tables[0];

            if (dtJyDetail != null && dtJyDetail.Rows.Count > 0)
            {
                List<JYDetail> jYDetails = new List<JYDetail>();

                for (int i = 0; i < dtJyDetail.Rows.Count; i++)
                {
                    JYDetail jYDetail = new JYDetail
                    {
                        ItemName = dtJyDetail.Rows[i]["itemname"].ToString(),
                        Result = dtJyDetail.Rows[i]["testresult"].ToString(),
                        Units = dtJyDetail.Rows[i]["units"].ToString(),
                        ResultRange = dtJyDetail.Rows[i]["ranges"].ToString(),
                        Code = dtJyDetail.Rows[i]["itemno"].ToString(),
                        Other1 = null,
                        Other2 = null,
                        Other3 = null,
                        Other4 = null,
                        Other5 = null,
                        HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                        ReqId = request.ReqId
                    };
                    switch (dtJyDetail.Rows[i]["resultflag"].ToString())
                    {
                        case "M":
                            jYDetail.Indicator = "0";
                            break;
                        case "L":
                            jYDetail.Indicator = "1";
                            break;
                        case "H":
                            jYDetail.Indicator = "2";
                            break;
                        default:
                            jYDetail.Indicator = "3";
                            break;
                    }

                    jYDetails.Add(jYDetail);
                }

                return jYDetails;
            }
            else
            {
                return null;
            }
        }
    }
}