/**  版本信息模板在安装目录下，可自行修改。
* SMT_FACERECG_DEVICE.cs
*
* 功 能： N/A
* 类 名： SMT_FACERECG_DEVICE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 20:58:09   N/A    初版
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
	/// 人脸识别设备
	/// </summary>
	[Serializable]
	public partial class SMT_FACERECG_DEVICE
	{
		public SMT_FACERECG_DEVICE()
		{}
		#region Model
		private decimal _id;
		private string _facedev_sn;
		private string _facedev_name;
		private string _facedev_ip;
		private int _facedev_ctrl_port;
		private string _facedev_user;
		private string _facedev_pwd;
		private string _facedev_db_name;
		private int _facedev_db_port;
		private string _facedev_db_user;
		private string _facedev_db_pwd;
		private decimal _area_id;
		private bool _facedev_is_enable;
		private int _facedev_heart_port;
		private string _facedev_mode;
		private string _fvideo_rtsp;
		private string _fvideo_rtsp2;
		private string _fvideo_rtsp3;
		private int? _fvideo_rtsp_count;
		private decimal? _fvideo_face_level;
		private decimal? _fvideo_rio_x;
		private decimal? _fvideo_rio_y;
		private decimal? _fvideo_rio_h;
		private decimal? _fvideo_rio_w;
		private string _fvideo_single;
		private string _fvideo_title1;
		private string _fvideo_title2;
		/// <summary>
		/// 设备ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备序列号
		/// </summary>
		public string FACEDEV_SN
		{
			set{ _facedev_sn=value;}
			get{return _facedev_sn;}
		}
		/// <summary>
		/// 设备名称
		/// </summary>
		public string FACEDEV_NAME
		{
			set{ _facedev_name=value;}
			get{return _facedev_name;}
		}
		/// <summary>
		/// 设备IP
		/// </summary>
		public string FACEDEV_IP
		{
			set{ _facedev_ip=value;}
			get{return _facedev_ip;}
		}
		/// <summary>
		/// 设备控制端口
		/// </summary>
		public int FACEDEV_CTRL_PORT
		{
			set{ _facedev_ctrl_port=value;}
			get{return _facedev_ctrl_port;}
		}
		/// <summary>
		/// 设备用户名
		/// </summary>
		public string FACEDEV_USER
		{
			set{ _facedev_user=value;}
			get{return _facedev_user;}
		}
		/// <summary>
		/// 设备密码
		/// </summary>
		public string FACEDEV_PWD
		{
			set{ _facedev_pwd=value;}
			get{return _facedev_pwd;}
		}
		/// <summary>
		/// 数据库名称
		/// </summary>
		public string FACEDEV_DB_NAME
		{
			set{ _facedev_db_name=value;}
			get{return _facedev_db_name;}
		}
		/// <summary>
		/// 数据库端口
		/// </summary>
		public int FACEDEV_DB_PORT
		{
			set{ _facedev_db_port=value;}
			get{return _facedev_db_port;}
		}
		/// <summary>
		/// 数据库用户名
		/// </summary>
		public string FACEDEV_DB_USER
		{
			set{ _facedev_db_user=value;}
			get{return _facedev_db_user;}
		}
		/// <summary>
		/// 数据库密码
		/// </summary>
		public string FACEDEV_DB_PWD
		{
			set{ _facedev_db_pwd=value;}
			get{return _facedev_db_pwd;}
		}
		/// <summary>
		/// 所属区域ID
		/// </summary>
		public decimal AREA_ID
		{
			set{ _area_id=value;}
			get{return _area_id;}
		}
		/// <summary>
		/// 启用状态
		/// </summary>
		public bool FACEDEV_IS_ENABLE
		{
			set{ _facedev_is_enable=value;}
			get{return _facedev_is_enable;}
		}
		/// <summary>
		/// 心跳端口
		/// </summary>
		public int FACEDEV_HEART_PORT
		{
			set{ _facedev_heart_port=value;}
			get{return _facedev_heart_port;}
		}
		/// <summary>
		/// 设备型号
		/// </summary>
		public string FACEDEV_MODE
		{
			set{ _facedev_mode=value;}
			get{return _facedev_mode;}
		}
		/// <summary>
		/// 是否已上传
		/// </summary>
		public string FVIDEO_RTSP
		{
			set{ _fvideo_rtsp=value;}
			get{return _fvideo_rtsp;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public string FVIDEO_RTSP2
		{
			set{ _fvideo_rtsp2=value;}
			get{return _fvideo_rtsp2;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public string FVIDEO_RTSP3
		{
			set{ _fvideo_rtsp3=value;}
			get{return _fvideo_rtsp3;}
		}
		/// <summary>
		/// 视频路数1或3
		/// </summary>
		public int? FVIDEO_RTSP_COUNT
		{
			set{ _fvideo_rtsp_count=value;}
			get{return _fvideo_rtsp_count;}
		}
		/// <summary>
		/// 分数阈值（0~1）
		/// </summary>
		public decimal? FVIDEO_FACE_LEVEL
		{
			set{ _fvideo_face_level=value;}
			get{return _fvideo_face_level;}
		}
		/// <summary>
		/// 检测区域左上角横坐标（0~1）
		/// </summary>
		public decimal? FVIDEO_RIO_X
		{
			set{ _fvideo_rio_x=value;}
			get{return _fvideo_rio_x;}
		}
		/// <summary>
		/// 检测区域左上角纵坐标（0~1）
		/// </summary>
		public decimal? FVIDEO_RIO_Y
		{
			set{ _fvideo_rio_y=value;}
			get{return _fvideo_rio_y;}
		}
		/// <summary>
		/// 检测区域高度（0~1）
		/// </summary>
		public decimal? FVIDEO_RIO_H
		{
			set{ _fvideo_rio_h=value;}
			get{return _fvideo_rio_h;}
		}
		/// <summary>
		/// 检测区域宽度（0~1）
		/// </summary>
		public decimal? FVIDEO_RIO_W
		{
			set{ _fvideo_rio_w=value;}
			get{return _fvideo_rio_w;}
		}
		/// <summary>
		/// 模式选择（Y为单人，N为多人）
		/// </summary>
		public string FVIDEO_SINGLE
		{
			set{ _fvideo_single=value;}
			get{return _fvideo_single;}
		}
		/// <summary>
		/// 标题1
		/// </summary>
		public string FVIDEO_TITLE1
		{
			set{ _fvideo_title1=value;}
			get{return _fvideo_title1;}
		}
		/// <summary>
		/// 标题2
		/// </summary>
		public string FVIDEO_TITLE2
		{
			set{ _fvideo_title2=value;}
			get{return _fvideo_title2;}
		}
		#endregion Model

	}
}

