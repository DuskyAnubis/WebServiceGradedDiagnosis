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
    public class PatientChargedDal
    {
        public List<PatientCharged> GetPatientChargeds(Request request)
        {
            string sqlYz = $"select * from (select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_长期医嘱 union select 病人编号,科室,医师,医嘱类别,日期,名称,规格,单位,单价,数量,用法,用量,执行频率,开始时间,执行人,执行时间,停止时间 from ZY_临时医嘱) as YZ where 病人编号='' order by 开始时间";

            return null;
        }
    }
}