/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_INFO
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
namespace Maticsoft.Model
{
	/// <summary>
	/// 电子地图
	/// </summary>
	[Serializable]
	public partial class SMT_MAP_INFO
	{
		public SMT_MAP_INFO()
		{}
		#region Model
		private decimal _id;
		private string _map_name;
		private byte[] _map_image;
		private DateTime _create_time;
		private decimal _group_id;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 地图名称
		/// </summary>
		public string MAP_NAME
		{
			set{ _map_name=value;}
			get{return _map_name;}
		}
		/// <summary>
		/// 地图底图
		/// </summary>
		public byte[] MAP_IMAGE
		{
			set{ _map_image=value;}
			get{return _map_image;}
		}
		/// <summary>
		/// 建立时间
		/// </summary>
		public DateTime CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 所属分组ID[待定]
		/// </summary>
		public decimal GROUP_ID
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		#endregion Model

	}
}

