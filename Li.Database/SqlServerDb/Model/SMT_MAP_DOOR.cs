/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_DOOR.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_DOOR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/3/18 23:15:19   N/A    初版
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
	/// 电子地图门关联表
	/// </summary>
	[Serializable]
	public partial class SMT_MAP_DOOR
	{
		public SMT_MAP_DOOR()
		{}
		#region Model
		private decimal _map_id;
		private decimal _door_id;
		private decimal _location_x;
		private decimal _location_y;
		private decimal _width;
		private decimal _height;
		private int _door_type=1;
		/// <summary>
		/// 地图ID
		/// </summary>
		public decimal MAP_ID
		{
			set{ _map_id=value;}
			get{return _map_id;}
		}
		/// <summary>
		/// 门ID
		/// </summary>
		public decimal DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		/// <summary>
		/// 比例位置X
		/// </summary>
		public decimal LOCATION_X
		{
			set{ _location_x=value;}
			get{return _location_x;}
		}
		/// <summary>
		/// 比例位置Y
		/// </summary>
		public decimal LOCATION_Y
		{
			set{ _location_y=value;}
			get{return _location_y;}
		}
		/// <summary>
		/// 绝对宽度
		/// </summary>
		public decimal WIDTH
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 绝对高度
		/// </summary>
		public decimal HEIGHT
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 1是门禁（默认），2是人脸设备
		/// </summary>
		public int DOOR_TYPE
		{
			set{ _door_type=value;}
			get{return _door_type;}
		}
		#endregion Model

	}
}

