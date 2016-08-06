/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_CARD.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_CARD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/24 22:45:06   N/A    初版
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
	/// 数据访问类:SMT_STAFF_CARD
	/// </summary>
	public partial class SMT_STAFF_CARD
	{
		#region  ExtensionMethod

        public DataSet GetListByCardNo(string cardNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*,t2.CARD_NO,t2.CARD_WG_NO,t2.CARD_TYPE from SMT_STAFF_CARD t1,SMT_CARD_INFO t2 where t1.CARD_ID=t2.ID and t2.CARD_NO='" + cardNo + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListByWGCardNo(string wgCardNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*,t2.CARD_NO,t2.CARD_WG_NO,t2.CARD_TYPE from SMT_STAFF_CARD t1,SMT_CARD_INFO t2 where t1.CARD_ID=t2.ID and t2.CARD_WG_NO='" + wgCardNo + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithCardNo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SC.*,CI.CARD_NO,CI.CARD_TYPE,CI.CARD_WG_NO from SMT_STAFF_CARD SC,SMT_CARD_INFO CI where SC.CARD_ID=CI.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and (" + strWhere+")");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

