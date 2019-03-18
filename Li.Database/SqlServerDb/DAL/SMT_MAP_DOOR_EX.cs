/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_DOOR.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_DOOR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/11 12:06:47   N/A    初版
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
	/// 数据访问类:SMT_MAP_DOOR
	/// </summary>
	public partial class SMT_MAP_DOOR
	{
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Maticsoft.Model.SMT_MAP_DOOR DataRowToModelWithDoor(DataRow row)
        {
            Maticsoft.Model.SMT_MAP_DOOR model = new Maticsoft.Model.SMT_MAP_DOOR();
            if (row != null)
            {
                if (row["MAP_ID"] != null && row["MAP_ID"].ToString() != "")
                {
                    model.MAP_ID = decimal.Parse(row["MAP_ID"].ToString());
                }
                if (row["DOOR_ID"] != null && row["DOOR_ID"].ToString() != "")
                {
                    model.DOOR_ID = decimal.Parse(row["DOOR_ID"].ToString());
                }
                if (row["LOCATION_X"] != null && row["LOCATION_X"].ToString() != "")
                {
                    model.LOCATION_X = decimal.Parse(row["LOCATION_X"].ToString());
                }
                if (row["LOCATION_Y"] != null && row["LOCATION_Y"].ToString() != "")
                {
                    model.LOCATION_Y = decimal.Parse(row["LOCATION_Y"].ToString());
                }
                if (row["WIDTH"] != null && row["WIDTH"].ToString() != "")
                {
                    model.WIDTH = decimal.Parse(row["WIDTH"].ToString());
                }
                if (row["HEIGHT"] != null && row["HEIGHT"].ToString() != "")
                {
                    model.HEIGHT = decimal.Parse(row["HEIGHT"].ToString());
                }
                if (row["DOOR_TYPE"] != null && row["DOOR_TYPE"].ToString() != "")
                {
                    model.DOOR_TYPE = int.Parse(row["DOOR_TYPE"].ToString());
                }

                if (model.DOOR_TYPE == 1)
                {
                    Maticsoft.DAL.SMT_DOOR_INFO doorDAL = new SMT_DOOR_INFO();
                    model.DOOR = doorDAL.DataRowToModel(row);
                }
                else
                {
                    Maticsoft.DAL.SMT_FACERECG_DEVICE faceDAL = new SMT_FACERECG_DEVICE();
                    model.FACE = faceDAL.DataRowToModel(row);
                }

            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListWithDoor(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select MD.*,DI.* ");
            strSql.Append("FROM SMT_MAP_DOOR MD,SMT_DOOR_INFO DI where MD.DOOR_ID=DI.ID and MD.DOOR_TYPE=1 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and ("+strWhere+") ");
			}
            strSql.Append("\r\n select MD.*,FD.* FROM SMT_MAP_DOOR MD,SMT_FACERECG_DEVICE FD where MD.DOOR_ID=FD.ID and MD.DOOR_TYPE=2");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and (" + strWhere + ") ");
            }

			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}

