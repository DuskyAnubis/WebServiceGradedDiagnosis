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
    public class PrescriptionDal
    {
        public Prescription GetPrescription(Request request)
        {
            string sqlMzsf = $"select top 1 * from (select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费流水帐 union select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费) as MZSF where 卡号='{request.OutPatientNo}' order by 日期 desc";
            string sqlGh = $"select * from (select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号流水帐 union select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号) as GH where 卡号='{request.OutPatientNo}'";
            string sqlMzbl = $"select top 1  卡号,门诊号,时间,过敏史,主诉,现病史,既往史,望闻问切,西医诊断,中医诊断,处理,体检,病程,建议 from MZ_BL where 卡号='{request.OutPatientNo}' order by 时间 desc";

            DataTable dtMzsf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzsf).Tables[0];
            DataTable dtGh = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("GHConnectionString"), sqlGh).Tables[0];
            DataTable dtMzbl = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzbl).Tables[0];

            if (dtMzsf != null && dtMzsf.Rows.Count > 0 && dtGh != null && dtGh.Rows.Count > 0)
            {
                string startDate = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd") + " 00:00:00";
                string endDate = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd") + " 23:59:59";

                string sqlMzhj = $"select * from (select 发票流水号,日期,卡号,病人姓名,科室ID,医师,YF_ID,名称,单位,数量,用法,用量,材质分类 from 划价临时库 where 材质分类 in ('西药','中成药','中草药','中药颗粒','中药饮片') and 科室ID<>0 and 发票流水号<>'-1' union select 发票流水号,日期,卡号,病人姓名,科室ID,医师,YF_ID,名称,单位,数量,用法,用量,材质分类 from 划价流水帐 where 材质分类 in ('西药','中成药','中草药','中药颗粒','中药饮片') and 科室ID<>0 and 发票流水号<>'-1') as Mzhj where 卡号='{dtMzsf.Rows[0]["卡号"].ToString()}' and 日期 between '{startDate}' and '{endDate}'";
                DataTable dtMzhj = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzhj).Tables[0];

                if (dtMzhj != null && dtMzhj.Rows.Count > 0)
                {
                    Prescription prescription = new Prescription
                    {
                        MedicalCardNo = dtMzsf.Rows[0]["卡号"].ToString(),
                        OutPatientNo = dtMzsf.Rows[0]["卡号"].ToString(),
                        PatientName = dtGh.Rows[0]["姓名"].ToString(),
                        PatientAge = dtGh.Rows[0]["年龄"].ToString(),
                        IdentCard = dtGh.Rows[0]["身份证"].ToString(),
                        GenderValue = dtGh.Rows[0]["性别"].ToString() == "男" ? "1" : "0",
                        ClinicalDiagnosis = dtMzbl != null && dtMzbl.Rows.Count > 0 && dtMzbl.Rows[0]["西医诊断"].ToString() != "" ? dtMzbl.Rows[0]["西医诊断"].ToString() : "暂无",
                        HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                        HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                        OrderDate = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd"),
                        DoctorDiagnosis = dtMzbl != null && dtMzbl.Rows.Count > 0 && dtMzbl.Rows[0]["西医诊断"].ToString() != "" ? dtMzbl.Rows[0]["西医诊断"].ToString() : null,
                        PrescripName = "门诊处方",
                        PrescripTypeId = dtMzhj.Rows[0]["材质分类"].ToString() == "西药" ? "2" : "1",
                        PrescripTypeName = dtMzhj.Rows[0]["材质分类"].ToString() == "西药" ? "2" : "1",
                        Other1 = null,
                        Other2 = null,
                        Other3 = null,
                        Other4 = null,
                        Other5 = null,
                        PID = dtMzsf.Rows[0]["卡号"].ToString(),
                        DzjkNo = null
                    };
                    return prescription;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}