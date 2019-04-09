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
    public class OutHospitalDal
    {
        public OutHospital GetOutHospital(Request request)
        {
            string sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,病情,确诊诊断,出院日期,治疗情况,住院天数,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where 出院日期 is not null and 住院号='{request.InPatientNo}' and 身份证号='{request.IdentCard}' order by 入院日期 desc";

            DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];

            if (dtBak != null && dtBak.Rows.Count > 0)
            {
                string sqlDoc = $"select id,医师代码,医师姓名,所在科室,挂号科室,划价号 from 医师代码 where 医师姓名='{dtBak.Rows[0]["医师代码"].ToString()}'";
                DataTable dtDoc = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDoc).Tables[0];

                OutHospital outHospital = new OutHospital
                {
                    PatientName = dtBak.Rows[0]["姓名"].ToString(),
                    HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                    HospitalName = ConfigurationManager.AppSettings["HospitalName"],
                    GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "1" : "0",
                    PatientAge = dtBak.Rows[0]["年龄"].ToString(),
                    IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                    InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                    InTime = Convert.ToDateTime(dtBak.Rows[0]["入院日期"]).ToString("yyyy-MM-dd hh:mm:ss"),
                    OutTime = dtBak.Rows[0]["出院日期"] is DBNull ? null : Convert.ToDateTime(dtBak.Rows[0]["出院日期"]).ToString("yyyy-MM-dd hh:mm:ss"),
                    Rcvdiag = dtBak.Rows[0]["入院诊断"].ToString(),
                    Lvediag = dtBak.Rows[0]["确诊诊断"].ToString(),
                    Rcvsymptom = dtBak.Rows[0]["入院诊断"].ToString(),
                    MainChecked = "暂无",
                    DiagCourse = "暂无",
                    Lvesymptom = dtBak.Rows[0]["治疗情况"].ToString(),
                    Lveda = "暂无",
                    Diagresult = dtBak.Rows[0]["治疗情况"].ToString(),
                    AttdoctNo = dtDoc != null && dtDoc.Rows.Count > 0 ? dtDoc.Rows[0]["医师代码"].ToString() : "暂无",
                    Attdoct = dtBak.Rows[0]["医师代码"].ToString(),
                    PathologyNo = null,
                    FillingData = dtBak.Rows[0]["出院日期"] is DBNull ? null : Convert.ToDateTime(dtBak.Rows[0]["出院日期"]).ToString("yyyy-MM-dd hh:mm:ss"),
                    Other1 = null,
                    Other2 = null,
                    Other3 = null,
                    Other4 = null,
                    Other5 = null,
                    PID = dtBak.Rows[0]["病人编号"].ToString(),
                    DzjkNo = null
                };

                return outHospital;
            }
            else
            {
                return null;
            }
        }
    }
}