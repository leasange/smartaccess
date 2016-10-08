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
            strSql.Append("select * from SMT_STAFF_INFO ssc where ssc.ORG_ID in (select * from temp ) order by org_id ");

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
            string strSql = "select SI.*,OI.ORG_NAME from SMT_STAFF_INFO SI left join SMT_ORG_INFO OI on SI.ORG_ID=OI.ID   where SI.IS_DELETE=0 and SI.ID in (select SC.STAFF_ID from SMT_CARD_INFO CI,SMT_STAFF_CARD SC where CI.CARD_NO='" + cardNo + "' and SC.CARD_ID=CI.ID)";
            return DbHelperSQL.Query(strSql);
        }
	}
}

