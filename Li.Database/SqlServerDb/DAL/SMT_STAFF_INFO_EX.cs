/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/1 23:35:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:SMT_STAFF_INFO
	/// </summary>
    public partial class SMT_STAFF_INFO
	{

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByDept(decimal orgId)
        {
            if (orgId < 0)
            {
                return GetList("1=1");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("with temp ");
            strSql.Append("as ");
            strSql.Append("( ");
            strSql.Append("            select ssi1.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi1 ");
            strSql.AppendFormat("            where  ssi1.ID ={0} ", orgId);
            strSql.Append("            union all ");
            strSql.Append("            select ssi2.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi2 ");
            strSql.Append("            inner join temp on ssi2.PAR_ID = temp.ID ");
            strSql.Append(") ");
            strSql.Append("select ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,MARRIED,SKIIL_LEVEL,CER_NAME,CER_NO,TELE_PHONE,CELL_PHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ENTRY_TIME,ABORT_TIME,ADDRESS,CER_PHOTO_FRONT,CER_PHOTO_BACK,PRINT_TEMPLET_ID,IS_FORBIDDEN,IS_DELETE,REG_TIME,DEL_TIME,FORBIDDEN_TIME,ENABLE_TIME,MODIFY_TIME,STAFF_TYPE from SMT_STAFF_INFO ssc where ssc.ORG_ID in (select * from temp ) and ssc.IS_DELETE=0 order by org_id ");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCountByDept(decimal orgId)
        {
            if (orgId < 0)
            {
                return GetRecordCount("1=1");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("with temp ");
            strSql.Append("as ");
            strSql.Append("( ");
            strSql.Append("            select ssi1.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi1 ");
            strSql.AppendFormat("            where  ssi1.ID ={0} ", orgId);
            strSql.Append("            union all ");
            strSql.Append("            select ssi2.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi2 ");
            strSql.Append("            inner join temp on ssi2.PAR_ID = temp.ID ");
            strSql.Append(") ");
            strSql.Append("select count(1) from SMT_STAFF_INFO ssc where ssc.ORG_ID in (select * from temp ) and ssc.IS_DELETE=0 ");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public DataSet GetListByPageByDept(decimal orgId, int startIndex, int endIndex)
        {
            if (orgId < 0)
            {
                return GetListByPageWithDept("1=1 and IS_DELETE=0", "org_id", startIndex, endIndex);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("with temp ");
            strSql.Append("as ");
            strSql.Append("( ");
            strSql.Append("            select ssi1.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi1 ");
            strSql.AppendFormat("            where  ssi1.ID ={0} ", orgId);
            strSql.Append("            union all ");
            strSql.Append("            select ssi2.ID ");
            strSql.Append("            from SMT_ORG_INFO ssi2 ");
            strSql.Append("            inner join temp on ssi2.PAR_ID = temp.ID ");
            strSql.Append(") ");
            strSql.AppendFormat(" select top {0} res.*,org.ORG_NAME,org.ORG_CODE from ", endIndex - startIndex + 1);
            strSql.Append(" (select row_number() over(order by org_id) as rownumber,* from SMT_STAFF_INFO ssc where ssc.ORG_ID in (select * from temp )  and ssc.IS_DELETE=0) res ");
            strSql.AppendFormat(" left join SMT_ORG_INFO org on res.org_id=org.ID where res.rownumber>={0} ", startIndex);

            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListByPageWithDept(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from (");
            strSql.Append("select SI.*,OI.ORG_NAME,OI.ORG_CODE,ROW_NUMBER() over (order by ");

            if (string.IsNullOrWhiteSpace(orderby))
            {
                strSql.Append("ID");
            }
            else
            {
                strSql.Append(orderby);
            }
            strSql.Append("    ) as ROW from SMT_STAFF_INFO SI left join SMT_ORG_INFO OI on SI.ORG_ID=OI.ID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (endIndex<=-1)
            {
                strSql.Append(") TT");
            }
            else
            {
                strSql.AppendFormat(") TT WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            }
           
            return DbHelperSQL.Query(strSql.ToString());
        }
        public int GetRecordCountWithDept(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from SMT_STAFF_INFO SI left join SMT_ORG_INFO OI on SI.ORG_ID=OI.ID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public DataSet GetListByCardNum(string cardNo)
        {
            cardNo = cardNo.Substring(0, cardNo.Length - 2);
            string strSql = "select SI.*,OI.ORG_NAME,OI.ORG_CODE from SMT_STAFF_INFO SI left join SMT_ORG_INFO OI on SI.ORG_ID=OI.ID   where SI.IS_DELETE=0 and SI.ID in (select SC.STAFF_ID from SMT_CARD_INFO CI,SMT_STAFF_CARD SC where CI.CARD_NO like '" + cardNo + "%' and SC.CARD_ID=CI.ID)";
            return DbHelperSQL.Query(strSql);
        }
        public Maticsoft.Model.SMT_STAFF_INFO DataRowToModelByParOrgId(DataRow row)
        {
            Maticsoft.Model.SMT_STAFF_INFO model = new Maticsoft.Model.SMT_STAFF_INFO();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = decimal.Parse(row["ID"].ToString());
                }
                if (row["ORG_ID"] != null && row["ORG_ID"].ToString() != "")
                {
                    model.ORG_ID = decimal.Parse(row["ORG_ID"].ToString());
                }
                if (row["STAFF_NO_TEMPLET"] != null && row["STAFF_NO_TEMPLET"].ToString() != "")
                {
                    model.STAFF_NO_TEMPLET = decimal.Parse(row["STAFF_NO_TEMPLET"].ToString());
                }
                if (row["STAFF_NO"] != null)
                {
                    model.STAFF_NO = row["STAFF_NO"].ToString();
                }
                if (row["REAL_NAME"] != null)
                {
                    model.REAL_NAME = row["REAL_NAME"].ToString();
                }
                if (row["SEX"] != null && row["SEX"].ToString() != "")
                {
                    model.SEX = int.Parse(row["SEX"].ToString());
                }
                if (row["JOB"] != null)
                {
                    model.JOB = row["JOB"].ToString();
                }
                if (row["BIRTHDAY"] != null && row["BIRTHDAY"].ToString() != "")
                {
                    model.BIRTHDAY = DateTime.Parse(row["BIRTHDAY"].ToString());
                }
                if (row["POLITICS"] != null)
                {
                    model.POLITICS = row["POLITICS"].ToString();
                }
                if (row["MARRIED"] != null && row["MARRIED"].ToString() != "")
                {
                    model.MARRIED = int.Parse(row["MARRIED"].ToString());
                }
                if (row["SKIIL_LEVEL"] != null)
                {
                    model.SKIIL_LEVEL = row["SKIIL_LEVEL"].ToString();
                }
                if (row["CER_NAME"] != null)
                {
                    model.CER_NAME = row["CER_NAME"].ToString();
                }
                if (row["CER_NO"] != null)
                {
                    model.CER_NO = row["CER_NO"].ToString();
                }
                if (row["TELE_PHONE"] != null)
                {
                    model.TELE_PHONE = row["TELE_PHONE"].ToString();
                }
                if (row["CELL_PHONE"] != null)
                {
                    model.CELL_PHONE = row["CELL_PHONE"].ToString();
                }
                if (row["NATIVE"] != null)
                {
                    model.NATIVE = row["NATIVE"].ToString();
                }
                if (row["NATION"] != null)
                {
                    model.NATION = row["NATION"].ToString();
                }
                if (row["RELIGION"] != null)
                {
                    model.RELIGION = row["RELIGION"].ToString();
                }
                if (row["EDUCATIONAL"] != null)
                {
                    model.EDUCATIONAL = row["EDUCATIONAL"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["VALID_STARTTIME"] != null && row["VALID_STARTTIME"].ToString() != "")
                {
                    model.VALID_STARTTIME = DateTime.Parse(row["VALID_STARTTIME"].ToString());
                }
                if (row["VALID_ENDTIME"] != null && row["VALID_ENDTIME"].ToString() != "")
                {
                    model.VALID_ENDTIME = DateTime.Parse(row["VALID_ENDTIME"].ToString());
                }
                if (row["ENTRY_TIME"] != null && row["ENTRY_TIME"].ToString() != "")
                {
                    model.ENTRY_TIME = DateTime.Parse(row["ENTRY_TIME"].ToString());
                }
                if (row["ABORT_TIME"] != null && row["ABORT_TIME"].ToString() != "")
                {
                    model.ABORT_TIME = DateTime.Parse(row["ABORT_TIME"].ToString());
                }
                if (row["ADDRESS"] != null)
                {
                    model.ADDRESS = row["ADDRESS"].ToString();
                }
               // if (row["PHOTO"] != null && row["PHOTO"].ToString() != "")
               // {
               //     model.PHOTO = (byte[])row["PHOTO"];
               // }
                if (row["CER_PHOTO_FRONT"] != null && row["CER_PHOTO_FRONT"].ToString() != "")
                {
                    model.CER_PHOTO_FRONT = (byte[])row["CER_PHOTO_FRONT"];
                }
                if (row["CER_PHOTO_BACK"] != null && row["CER_PHOTO_BACK"].ToString() != "")
                {
                    model.CER_PHOTO_BACK = (byte[])row["CER_PHOTO_BACK"];
                }
                if (row["PRINT_TEMPLET_ID"] != null && row["PRINT_TEMPLET_ID"].ToString() != "")
                {
                    model.PRINT_TEMPLET_ID = decimal.Parse(row["PRINT_TEMPLET_ID"].ToString());
                }
                if (row["IS_FORBIDDEN"] != null && row["IS_FORBIDDEN"].ToString() != "")
                {
                    if ((row["IS_FORBIDDEN"].ToString() == "1") || (row["IS_FORBIDDEN"].ToString().ToLower() == "true"))
                    {
                        model.IS_FORBIDDEN = true;
                    }
                    else
                    {
                        model.IS_FORBIDDEN = false;
                    }
                }
                if (row["IS_DELETE"] != null && row["IS_DELETE"].ToString() != "")
                {
                    if ((row["IS_DELETE"].ToString() == "1") || (row["IS_DELETE"].ToString().ToLower() == "true"))
                    {
                        model.IS_DELETE = true;
                    }
                    else
                    {
                        model.IS_DELETE = false;
                    }
                }
                if (row["REG_TIME"] != null && row["REG_TIME"].ToString() != "")
                {
                    model.REG_TIME = DateTime.Parse(row["REG_TIME"].ToString());
                }
                if (row["DEL_TIME"] != null && row["DEL_TIME"].ToString() != "")
                {
                    model.DEL_TIME = DateTime.Parse(row["DEL_TIME"].ToString());
                }
                if (row["FORBIDDEN_TIME"] != null && row["FORBIDDEN_TIME"].ToString() != "")
                {
                    model.FORBIDDEN_TIME = DateTime.Parse(row["FORBIDDEN_TIME"].ToString());
                }
                if (row["ENABLE_TIME"] != null && row["ENABLE_TIME"].ToString() != "")
                {
                    model.ENABLE_TIME = DateTime.Parse(row["ENABLE_TIME"].ToString());
                }
                if (row["MODIFY_TIME"] != null && row["MODIFY_TIME"].ToString() != "")
                {
                    model.MODIFY_TIME = DateTime.Parse(row["MODIFY_TIME"].ToString());
                }
                if (row["STAFF_TYPE"] != null)
                {
                    model.STAFF_TYPE = row["STAFF_TYPE"].ToString();
                }
            }
            return model;
        }
	}
}

