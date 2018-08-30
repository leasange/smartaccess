/**  版本信息模板在安装目录下，可自行修改。
* SMT_FACE_RECORD.cs
*
* 功 能： N/A
* 类 名： SMT_FACE_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/30 23:24:54   N/A    初版
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
	/// 人脸识别记录表
	/// </summary>
	[Serializable]
	public partial class SMT_FACE_RECORD
	{
		public SMT_FACE_RECORD()
		{}
		#region Model
		private decimal _id;
		private decimal _facedev_id;
		private string _frec_src_id;
		private DateTime _frec_time;
		private string _frec_staff_name;
		private byte[] _frec_video_image;
		private byte[] _frec_face_image;
		private decimal _frec_face_level;
		private string _frec_authority;
		private string _frec_staff_no;
		private string _frec_staff_type;
		private string _frec_param3;
		private string _frec_param4;
		private decimal? _frec_staff_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 人脸设备ID
		/// </summary>
		public decimal FACEDEV_ID
		{
			set{ _facedev_id=value;}
			get{return _facedev_id;}
		}
		/// <summary>
		/// 原始记录ID
		/// </summary>
		public string FREC_SRC_ID
		{
			set{ _frec_src_id=value;}
			get{return _frec_src_id;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime FREC_TIME
		{
			set{ _frec_time=value;}
			get{return _frec_time;}
		}
		/// <summary>
		/// 人员姓名
		/// </summary>
		public string FREC_STAFF_NAME
		{
			set{ _frec_staff_name=value;}
			get{return _frec_staff_name;}
		}
		/// <summary>
		/// 视频图像
		/// </summary>
		public byte[] FREC_VIDEO_IMAGE
		{
			set{ _frec_video_image=value;}
			get{return _frec_video_image;}
		}
		/// <summary>
		/// 人脸图像
		/// </summary>
		public byte[] FREC_FACE_IMAGE
		{
			set{ _frec_face_image=value;}
			get{return _frec_face_image;}
		}
		/// <summary>
		/// 相似度(0-1)
		/// </summary>
		public decimal FREC_FACE_LEVEL
		{
			set{ _frec_face_level=value;}
			get{return _frec_face_level;}
		}
		/// <summary>
		/// 权限
		/// </summary>
		public string FREC_AUTHORITY
		{
			set{ _frec_authority=value;}
			get{return _frec_authority;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string FREC_STAFF_NO
		{
			set{ _frec_staff_no=value;}
			get{return _frec_staff_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FREC_STAFF_TYPE
		{
			set{ _frec_staff_type=value;}
			get{return _frec_staff_type;}
		}
		/// <summary>
		/// 人员ID（系统使用，参数3）
		/// </summary>
		public string FREC_PARAM3
		{
			set{ _frec_param3=value;}
			get{return _frec_param3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FREC_PARAM4
		{
			set{ _frec_param4=value;}
			get{return _frec_param4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FREC_STAFF_ID
		{
			set{ _frec_staff_id=value;}
			get{return _frec_staff_id;}
		}
		#endregion Model

	}
}

