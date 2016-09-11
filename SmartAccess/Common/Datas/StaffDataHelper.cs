using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    public class StaffDataHelper
    {
        private static DataTable CreateReportTable()
        {
            DataTable dt = new DataTable("人员信息");
            dt.Columns.Add("部门名称", typeof(string));
            dt.Columns.Add("部门编号", typeof(string));
            dt.Columns.Add("人员编号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));//姓名
            dt.Columns.Add("性别", typeof(string));//sex
            dt.Columns.Add("职位", typeof(string));//job
            dt.Columns.Add("生日", typeof(DateTime));
            dt.Columns.Add("政治面貌", typeof(string));//_politics
            dt.Columns.Add("婚姻状态", typeof(string));
            dt.Columns.Add("技术等级", typeof(string));
            dt.Columns.Add("有效证件名称", typeof(string));
            dt.Columns.Add("有效证件号码", typeof(string));
            dt.Columns.Add("电话", typeof(string));
            dt.Columns.Add("手机", typeof(string));
            dt.Columns.Add("籍贯", typeof(string));
            dt.Columns.Add("民族", typeof(string));
            dt.Columns.Add("宗教", typeof(string));
            dt.Columns.Add("学历", typeof(string));
            dt.Columns.Add("电子邮箱", typeof(string));
            dt.Columns.Add("有效开始时间", typeof(DateTime));
            dt.Columns.Add("有效结束时间", typeof(DateTime));
            dt.Columns.Add("入职时间", typeof(DateTime));
            dt.Columns.Add("离职时间", typeof(DateTime));
            dt.Columns.Add("联系地址", typeof(string));
            dt.Columns.Add("照片", typeof(Image));
            dt.Columns.Add("注册时间", typeof(DateTime));
            return dt;
        }
        private static DataRow CreateReportTableRow
            (
             DataTable table,
             string orgName,
             string orgNo,
             string staffNo,
             string realname,
             string sex,
             string job,
             DateTime birthday,
             string politics,
             string married,
             string skiillevel,
             string cername,
             string cerno,
             string telephone,
             string cellphone,
             string native,
             string nation,
             string religion,
             string educational,
             string email,
             DateTime validstarttime,
             DateTime validendtime,
             DateTime entrytime,
             DateTime aborttime,
             string address,
             Image photo,
             DateTime regtime
            )
        {
            DataRow row = table.NewRow();
            row[0] = orgName;
            row[1] = orgNo;
            row[2] = staffNo;
            row[3] = realname;
            row[4] = sex;
            row[5] = job;
            row[6] = birthday;
            row[7] = politics;
            row[8] = married;
            row[9] = skiillevel;
            row[10] = cername;
            row[11] = cerno;
            row[12] = telephone;
            row[13] = cellphone;
            row[14] = native;
            row[15] = nation;
            row[16] = religion;
            row[17] = educational;
            row[18] = email;
            row[19] = validstarttime;
            row[20] = validendtime;
            row[21] = entrytime;
            row[22] = aborttime;
            row[23] = address;
            row[24] = photo;
            row[25] = regtime;
            return row;
        }
        /// <summary>
        /// 获取Report测试数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTestReportDataTable()
        {
            DataTable dt = CreateReportTable();
            DataRow dr = CreateReportTableRow(dt,
                 "财务部",
                 "A090901",
                 "2373802",
                 "张小美",
                 "女",
                 "财务主管",
                 DateTime.Now.Date,
                 "党员",
                 "未婚",
                 "高级主管",
                 "身份证",
                 "340000000000000000",
                 "0210-0000000",
                 "15000000000",
                 "中国",
                 "汉",
                 "无",
                 "硕士",
                 "zhangxiaomei@qq.com",
                 DateTime.Now.Date,
                 DateTime.Now.Date.AddDays(1),
                 DateTime.Now.Date,
                 DateTime.Now.Date,
                 "北京市XXX区XXX街道100号",
                 Properties.Resources.示例证件,
                 DateTime.Now.Date);
            dt.Rows.Add(dr);
            return dt;
        }

        public static DataTable GetReportDataTable(string orgName,
             string orgNo,
             string staffNo,
             string realname,
             string sex,
             string job,
             DateTime birthday,
             string politics,
             string married,
             string skiillevel,
             string cername,
             string cerno,
             string telephone,
             string cellphone,
             string native,
             string nation,
             string religion,
             string educational,
             string email,
             DateTime validstarttime,
             DateTime validendtime,
             DateTime entrytime,
             DateTime aborttime,
             string address,
             Image photo,
             DateTime regtime)
        {
            DataTable dt = CreateReportTable();
            DataRow dr = CreateReportTableRow(dt,
                orgName,
               orgNo,
               staffNo,
               realname,
               sex,
               job,
               birthday,
               politics,
               married,
               skiillevel,
               cername,
               cerno,
               telephone,
               cellphone,
               native,
               nation,
               religion,
               educational,
               email,
               validstarttime,
               validendtime,
               entrytime,
               aborttime,
               address,
              photo,
               regtime);
            dt.Rows.Add(dr);
            return dt;
        }
    }
}
