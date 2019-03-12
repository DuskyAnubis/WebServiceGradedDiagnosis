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
    public class JYRecordDal
    {
        public List<JYRecord> GetJYRecords(Request request)
        {
            if (string.IsNullOrEmpty(request.OutPatientNo))
            {
                string sqlBak = "";
                if (string.IsNullOrEmpty(request.IdentCard))
                {
                    sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' order by 入院日期 desc";
                }
                else
                {
                    sqlBak = $"select top 1 * from(select 病人编号,住院号,姓名,入院日期,医保类型,性别,身份证号,年龄,出生日期,民族,婚否,职业,电话,家庭住址,联系人,联系人地址,联系电话,关系,入院诊断,确诊诊断,出院日期,医师代码,科室,病室,床位 from ZY_病案库 where 住院号<>'0') as BAK where  病人编号='{request.PID}' or 住院号='{request.InPatientNo}' or 身份证号='{request.IdentCard}' order by 入院日期 desc";
                }

                DataTable dtBak = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlBak).Tables[0];

                if (dtBak != null && dtBak.Rows.Count > 0)
                {
                    string sqlJy = $"select main.sqh,main.ksdh,main.sqys,detail.xh,detail.sqxmmc,main.brdh,main.brxm,main.sqsj,main.zxsj,main.yblx from Lis_reqdetail as detail left join lis_reqmain as main on detail.sqh=main.sqh where main.brdh = '{dtBak.Rows[0]["住院号"].ToString()}' order by detail.sqh,detail.xh";
                    string sqlDep = $"select 科室Id, 科室代码,科室名称 from 科室 where 科室名称='{dtBak.Rows[0]["科室"].ToString()}'";
                    string sqlDoc = $"select id,医师代码,医师姓名,所在科室,挂号科室,划价号 from 医师代码 where 医师姓名='{dtBak.Rows[0]["医师代码"].ToString()}'";
                    string sqlPatBaseInf = $"select top 1 * from (select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInf union select patId,PatName,MainNarrative,InDate,Diagnosis1 from EH_PatBasInfOut) as EH_PatBasInf where PatId='{dtBak.Rows[0]["住院号"].ToString()}' order by InDate desc";

                    DataTable dtJy = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HosdataConnectionString"), sqlJy).Tables[0];
                    DataTable dtDep = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDep).Tables[0];
                    DataTable dtDoc = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlDoc).Tables[0];
                    DataTable dtPatBaseInf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("DzblConnectionString"), sqlPatBaseInf).Tables[0];

                    if (dtJy != null && dtJy.Rows.Count > 0)
                    {
                        List<JYRecord> jYRecords = new List<JYRecord>();

                        for (int i = 0; i < dtJy.Rows.Count; i++)
                        {
                            JYRecord jYRecord = new JYRecord
                            {
                                ReqId = dtJy.Rows[i]["sqh"].ToString(),
                                ItemClass = dtJy.Rows[i]["yblx"].ToString(),
                                ItemSubClass = null,
                                DiagnoseDoc = dtJy.Rows[i]["sqys"].ToString(),
                                SendDoc = dtJy.Rows[i]["sqys"].ToString(),
                                AuditDoc = dtJy.Rows[i]["sqys"].ToString(),
                                DeptCode = dtDep != null && dtDep.Rows.Count > 0 ? dtDep.Rows[0]["科室代码"].ToString() : null,
                                Dept = dtJy.Rows[i]["ksdh"].ToString(),
                                HosName = ConfigurationManager.AppSettings["HospitalName"],
                                IsKey = "0",
                                CheckTime = Convert.ToDateTime(dtJy.Rows[i]["zxsj"]).ToString("yyyy-MM-dd"),
                                ReportTime = Convert.ToDateTime(dtJy.Rows[i]["zxsj"]).ToString("yyyy-MM-dd"),
                                ReceiveTime = Convert.ToDateTime(dtJy.Rows[i]["sqsj"]).ToString("yyyy-MM-dd"),
                                CollectTime = Convert.ToDateTime(dtJy.Rows[i]["sqsj"]).ToString("yyyy-MM-dd"),
                                Diagnostic = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["Diagnosis1"].ToString() : null,
                                State = 0,
                                PatientName = dtBak.Rows[0]["姓名"].ToString(),
                                GenderValue = dtBak.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                                PatientAge = DateTime.Now.Year - Convert.ToDateTime(dtBak.Rows[0]["出生日期"]).Year,
                                AppDiagonse = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["Diagnosis1"].ToString() : null,
                                ChiefComplaint = dtPatBaseInf != null && dtPatBaseInf.Rows.Count > 0 ? dtPatBaseInf.Rows[0]["MainNarrative"].ToString() : null,
                                MedicalHistory = null,
                                CheckPurpose = dtJy.Rows[i]["sqxmmc"].ToString(),
                                Other1 = null,
                                Other2 = null,
                                Other3 = null,
                                Other4 = null,
                                Other5 = null,
                                HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                                IdentCard = dtBak.Rows[0]["身份证号"].ToString(),
                                OutPatientNo = null,
                                InpatientNo = dtBak.Rows[0]["住院号"].ToString(),
                                DzjkNo = null
                            };
                            jYRecords.Add(jYRecord);
                        }

                        return jYRecords;
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
            else
            {
                string sqlMzsf = $"select top 1 * from (select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费流水帐 union select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费) as MZSF where 卡号='{request.OutPatientNo}' order by 日期 desc";
                DataTable dtMzsf = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzsf).Tables[0];
                if (dtMzsf != null && dtMzsf.Rows.Count > 0)
                {
                    string startDate = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd") + " 00:00:00";
                    string endDate = Convert.ToDateTime(dtMzsf.Rows[0]["日期"]).ToString("yyyy-MM-dd") + " 23:59:59";

                    string sqlJy = $"select main.sqh,main.ksdh,main.sqys,detail.xh,detail.sqxmmc,main.brdh,main.brxm,main.sqsj,main.zxsj,main.yblx from Lis_reqdetail as detail left join lis_reqmain as main on detail.sqh=main.sqh where main.brdh = '{request.OutPatientNo}' and sqsj between '{startDate}' and '{endDate}'  order by detail.sqh,detail.xh";
                    DataTable dtJy = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HosdataConnectionString"), sqlJy).Tables[0];

                    if (dtJy != null && dtJy.Rows.Count > 0)
                    {
                        string sqlGh = $"select * from (select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号流水帐 union select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号) as GH where 卡号={request.OutPatientNo}";
                        DataTable dtGh = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("GHConnectionString"), sqlGh).Tables[0];

                        string sqlMzbl = $"select top 1 卡号,门诊号,时间,过敏史,主诉,现病史,既往史,望闻问切,西医诊断,中医诊断,处理,体检,病程,建议 from MZ_BL where 卡号={request.OutPatientNo} order by 时间 desc";
                        DataTable dtMzbl = SqlCommon.ExecuteSqlToDataSet(SqlCommon.GetConnectionStringFromConnectionStrings("HisConnectionString"), sqlMzbl).Tables[0];

                        List<JYRecord> jYRecords = new List<JYRecord>();

                        for (int i = 0; i < dtJy.Rows.Count; i++)
                        {
                            JYRecord jYRecord = new JYRecord
                            {
                                ReqId = dtJy.Rows[i]["sqh"].ToString(),
                                ItemClass = dtJy.Rows[i]["yblx"].ToString(),
                                ItemSubClass = null,
                                DiagnoseDoc = dtJy.Rows[i]["sqys"].ToString(),
                                SendDoc = dtJy.Rows[i]["sqys"].ToString(),
                                AuditDoc = dtJy.Rows[i]["sqys"].ToString(),
                                DeptCode = dtJy.Rows[i]["ksdh"].ToString(),
                                Dept = dtJy.Rows[i]["ksdh"].ToString(),
                                HosName = ConfigurationManager.AppSettings["HospitalName"],
                                IsKey = "0",
                                CheckTime = Convert.ToDateTime(dtJy.Rows[i]["zxsj"]).ToString("yyyy-MM-dd"),
                                ReportTime = Convert.ToDateTime(dtJy.Rows[i]["zxsj"]).ToString("yyyy-MM-dd"),
                                ReceiveTime = Convert.ToDateTime(dtJy.Rows[i]["sqsj"]).ToString("yyyy-MM-dd"),
                                CollectTime = Convert.ToDateTime(dtJy.Rows[i]["sqsj"]).ToString("yyyy-MM-dd"),
                                Diagnostic = dtMzbl != null && dtMzbl.Rows.Count > 0 ? dtMzbl.Rows[0]["西医诊断"].ToString() : null,
                                State = 0,
                                PatientName = dtGh.Rows[0]["姓名"].ToString(),
                                GenderValue = dtGh.Rows[0]["性别"].ToString() == "男" ? "0" : "1",
                                PatientAge = Convert.ToInt32(dtGh.Rows[0]["年龄"]),
                                AppDiagonse = dtMzbl != null && dtMzbl.Rows.Count > 0 ? dtMzbl.Rows[0]["西医诊断"].ToString() : null,
                                ChiefComplaint = dtMzbl != null && dtMzbl.Rows.Count > 0 ? dtMzbl.Rows[0]["主诉"].ToString() : null,
                                MedicalHistory = null,
                                CheckPurpose = dtJy.Rows[i]["sqxmmc"].ToString(),
                                Other1 = null,
                                Other2 = null,
                                Other3 = null,
                                Other4 = null,
                                Other5 = null,
                                HospitalId = ConfigurationManager.AppSettings["HospitalId"],
                                IdentCard = null,
                                OutPatientNo = dtMzsf.Rows[0]["卡号"].ToString(),
                                InpatientNo = null,
                                DzjkNo = null
                            };
                            jYRecords.Add(jYRecord);
                        }
                        return jYRecords;
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
}