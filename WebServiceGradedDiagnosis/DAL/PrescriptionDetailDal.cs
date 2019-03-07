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
    public class PrescriptionDetailDal
    {
        public List<PrescriptionDetail> GetPrescriptionDetails(string cardNo, string startDate, string endDate)
        {
            string sqlMzhj = $"select * from (select 发票流水号,日期,卡号,病人姓名,科室ID,医师,YF_ID,名称,单位,数量,用法,用量 from 划价临时库 where 材质分类 in ('西药','中成药','中草药','中药颗粒','中药饮片') and 科室ID<>0 and 发票流水号<>'-1' union select 发票流水号,日期,卡号,病人姓名,科室ID,医师,YF_ID,名称,单位,数量,用法,用量 from 划价流水帐 where 材质分类 in ('西药','中成药','中草药','中药颗粒','中药饮片') and 科室ID<>0 and 发票流水号<>'-1') as Mzhj where 卡号='{cardNo}' and 日期 between '{startDate}' and '{endDate}'";
            DataTable dtMzhj = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzhj).Tables[0];

            List<PrescriptionDetail> prescriptionDetails = new List<PrescriptionDetail>();


            if (dtMzhj != null && dtMzhj.Rows.Count > 0)
            {

                for (int i = 0; i < dtMzhj.Rows.Count; i++)
                {
                    PrescriptionDetail prescriptionDetail = new PrescriptionDetail
                    {
                        MedicineNO = dtMzhj.Rows[i]["YF_ID"].ToString(),
                        MedicineName = dtMzhj.Rows[i]["名称"].ToString(),
                        MedicineCount = dtMzhj.Rows[i]["数量"].ToString(),
                        MedicineUnit = dtMzhj.Rows[i]["单位"].ToString(),
                        Usage = dtMzhj.Rows[i]["用法"].ToString() + dtMzhj.Rows[i]["用量"].ToString(),
                    };
                    prescriptionDetails.Add(prescriptionDetail);
                }
            }

            return prescriptionDetails;
        }
    }
}