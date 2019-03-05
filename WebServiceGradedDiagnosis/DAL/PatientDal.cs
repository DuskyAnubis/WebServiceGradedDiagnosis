using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceGradedDiagnosis.Common;
using WebServiceGradedDiagnosis.Models;

namespace WebServiceGradedDiagnosis.DAL
{
    public class PatientDal
    {
        public Patient GetPatient(Request request)
        {
            string sqlGh = "select * from (select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号流水帐 union select 卡号,门诊号,姓名,出生日期,年龄,性别,民族,身份证,婚姻,职业,通信地址,电话 from 门诊挂号) as GH where  卡号 is not null and 卡号<>''";
            string sqlMzsf = "select * from (select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费流水帐 union select 病人姓名,门诊号,卡号,日期,医疗保险号,医保 from 门诊收费) as MZSF";
            string sqlMzbl = "select 卡号,门诊号,时间,过敏史,主诉,现病史,既往史,望闻问切,西医诊断,中医诊断,处理,体检,病程,建议 from MZ_BL";



            return null;
        }
    }
}