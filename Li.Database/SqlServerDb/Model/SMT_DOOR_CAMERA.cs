/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_CAMERA.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_CAMERA
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/19 21:03:01   N/A    初版
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
	/// 门禁摄像头表
	/// </summary>
	[Serializable]
	public partial class SMT_DOOR_CAMERA
	{
		public SMT_DOOR_CAMERA()
		{}
		#region Model
		private decimal _door_id;
		private decimal _camera_id;
		private bool _enable_cap;
		/// <summary>
		/// 门禁ID
		/// </summary>
		public decimal DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		/// <summary>
		/// 摄像头ID
		/// </summary>
		public decimal CAMERA_ID
		{
			set{ _camera_id=value;}
			get{return _camera_id;}
		}
		/// <summary>
		/// 是否启动抓拍
		/// </summary>
		public bool ENABLE_CAP
		{
			set{ _enable_cap=value;}
			get{return _enable_cap;}
		}
		#endregion Model

	}
}

