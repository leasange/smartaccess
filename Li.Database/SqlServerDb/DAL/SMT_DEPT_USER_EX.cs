/**  版本信息模板在安装目录下，可自行修改。
* SMT_DEPT_USER.cs
*
* 功 能： N/A
* 类 名： SMT_DEPT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/28 23:27:37   N/A    初版
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
	/// 数据访问类:SMT_DEPT_USER
	/// </summary>
	public partial class SMT_DEPT_USER
	{
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.SMT_DEPT_USER DataRowToModelEx(DataRow row)
		{
			Maticsoft.Model.SMT_DEPT_USER model=new Maticsoft.Model.SMT_DEPT_USER();
			if (row != null)
			{
				if(row["DEPT_ID"]!=null && row["DEPT_ID"].ToString()!="")
				{
					model.DEPT_ID=decimal.Parse(row["DEPT_ID"].ToString());
				}
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=decimal.Parse(row["USER_ID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListEx(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select DU.DEPT_ID,DU.USER_ID,UI.* ");
            strSql.Append(" FROM SMT_DEPT_USER DU, SMT_USER_INFO UI where DU.USER_ID=UI.ID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and ("+strWhere+")");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}

