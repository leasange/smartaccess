/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_FACEDEV.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_FACEDEV
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 15:10:17   N/A    初版
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
	/// 员工人脸识别设备权限表
	/// </summary>
	[Serializable]
	public partial class SMT_STAFF_FACEDEV
	{
		public SMT_STAFF_FACEDEV()
		{}
		#region Model
		private decimal _staff_id;
		private decimal _facedev_id;
		private bool _is_upload;
		private DateTime _upload_time;
		private DateTime _add_time;
		private DateTime _start_valid_time;
		private DateTime _end_valid_time;
		private string _staff_dev_id;
		/// <summary>
		/// 员工ID
		/// </summary>
		public decimal STAFF_ID
		{
			set{ _staff_id=value;}
			get{return _staff_id;}
		}
		/// <summary>
		/// 人脸识别设备ID
		/// </summary>
		public decimal FACEDEV_ID
		{
			set{ _facedev_id=value;}
			get{return _facedev_id;}
		}
		/// <summary>
		/// 是否已上传
		/// </summary>
		public bool IS_UPLOAD
		{
			set{ _is_upload=value;}
			get{return _is_upload;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime UPLOAD_TIME
		{
			set{ _upload_time=value;}
			get{return _upload_time;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 有效开始时间，该时间在员工有效期范围内
		/// </summary>
		public DateTime START_VALID_TIME
		{
			set{ _start_valid_time=value;}
			get{return _start_valid_time;}
		}
		/// <summary>
		/// 有效结束时间，该时间在员工有效期范围内
		/// </summary>
		public DateTime END_VALID_TIME
		{
			set{ _end_valid_time=value;}
			get{return _end_valid_time;}
		}
		/// <summary>
		/// 上传设备中编号
		/// </summary>
		public string STAFF_DEV_ID
		{
			set{ _staff_dev_id=value;}
			get{return _staff_dev_id;}
		}
		#endregion Model

	}
}

