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
namespace Maticsoft.Model
{
	/// <summary>
	/// 员工职员表
	/// </summary>
	[Serializable]
	public partial class SMT_STAFF_INFO
	{
		public SMT_STAFF_INFO()
		{}
		#region Model
		private decimal _id;
		private decimal? _org_id;
		private decimal? _staff_no_templet;
		private string _staff_no;
		private string _real_name;
		private int? _sex;
		private string _job;
		private DateTime? _birthday;
		private string _politics;
		private int? _married;
		private string _skiil_level;
		private string _cer_name;
		private string _cer_no;
		private string _tele_phone;
		private string _cell_phone;
		private string _native;
		private string _nation;
		private string _religion;
		private string _educational;
		private string _email;
		private DateTime _valid_starttime;
		private DateTime _valid_endtime;
		private DateTime? _entry_time;
		private DateTime? _abort_time;
		private string _address;
		private byte[] _photo;
		private byte[] _cer_photo_front;
		private byte[] _cer_photo_back;
		private decimal? _print_templet_id;
		private bool _is_forbidden;
		private bool _is_delete;
		private DateTime _reg_time;
		private DateTime? _del_time;
		private DateTime? _forbidden_time;
		private DateTime? _enable_time;
        private DateTime? _modify_time;

		/// <summary>
		/// 职员ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 部门组织ID
		/// </summary>
		public decimal? ORG_ID
		{
			set{ _org_id=value;}
			get{return _org_id;}
		}
		/// <summary>
		/// 职员证件编号模板ID
		/// </summary>
		public decimal? STAFF_NO_TEMPLET
		{
			set{ _staff_no_templet=value;}
			get{return _staff_no_templet;}
		}
		/// <summary>
		/// 职员/证件编号
		/// </summary>
		public string STAFF_NO
		{
			set{ _staff_no=value;}
			get{return _staff_no;}
		}
		/// <summary>
		/// 职员姓名
		/// </summary>
		public string REAL_NAME
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 性别，0 未知 1 男 2 女
		/// </summary>
		public int? SEX
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string JOB
		{
			set{ _job=value;}
			get{return _job;}
		}
		/// <summary>
		/// 出身年月日
		/// </summary>
		public DateTime? BIRTHDAY
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 政治面貌
		/// </summary>
		public string POLITICS
		{
			set{ _politics=value;}
			get{return _politics;}
		}
		/// <summary>
		/// MARRIED
		/// </summary>
		public int? MARRIED
		{
			set{ _married=value;}
			get{return _married;}
		}
		/// <summary>
		/// 技术等级
		/// </summary>
		public string SKIIL_LEVEL
		{
			set{ _skiil_level=value;}
			get{return _skiil_level;}
		}
		/// <summary>
		/// 有效证件名称
		/// </summary>
		public string CER_NAME
		{
			set{ _cer_name=value;}
			get{return _cer_name;}
		}
		/// <summary>
		/// 有效证件号码
		/// </summary>
		public string CER_NO
		{
			set{ _cer_no=value;}
			get{return _cer_no;}
		}
		/// <summary>
		/// 办公电话
		/// </summary>
		public string TELE_PHONE
		{
			set{ _tele_phone=value;}
			get{return _tele_phone;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string CELL_PHONE
		{
			set{ _cell_phone=value;}
			get{return _cell_phone;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string NATIVE
		{
			set{ _native=value;}
			get{return _native;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string NATION
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 宗教
		/// </summary>
		public string RELIGION
		{
			set{ _religion=value;}
			get{return _religion;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string EDUCATIONAL
		{
			set{ _educational=value;}
			get{return _educational;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 有效开始时间
		/// </summary>
		public DateTime VALID_STARTTIME
		{
			set{ _valid_starttime=value;}
			get{return _valid_starttime;}
		}
		/// <summary>
		/// 有效结束时间
		/// </summary>
		public DateTime VALID_ENDTIME
		{
			set{ _valid_endtime=value;}
			get{return _valid_endtime;}
		}
		/// <summary>
		/// 入职时间
		/// </summary>
		public DateTime? ENTRY_TIME
		{
			set{ _entry_time=value;}
			get{return _entry_time;}
		}
		/// <summary>
		/// 离职时间
		/// </summary>
		public DateTime? ABORT_TIME
		{
			set{ _abort_time=value;}
			get{return _abort_time;}
		}
		/// <summary>
		/// 通信地址
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public byte[] PHOTO
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 有效证件正面照片
		/// </summary>
		public byte[] CER_PHOTO_FRONT
		{
			set{ _cer_photo_front=value;}
			get{return _cer_photo_front;}
		}
		/// <summary>
		/// 有效证件背面照片
		/// </summary>
		public byte[] CER_PHOTO_BACK
		{
			set{ _cer_photo_back=value;}
			get{return _cer_photo_back;}
		}
		/// <summary>
		/// 使用的打印证件模板ID
		/// </summary>
		public decimal? PRINT_TEMPLET_ID
		{
			set{ _print_templet_id=value;}
			get{return _print_templet_id;}
		}
		/// <summary>
		/// 是否被禁用/挂失
		/// </summary>
		public bool IS_FORBIDDEN
		{
			set{ _is_forbidden=value;}
			get{return _is_forbidden;}
		}
		/// <summary>
		/// 是否被删除/注销
		/// </summary>
		public bool IS_DELETE
		{
			set{ _is_delete=value;}
			get{return _is_delete;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime REG_TIME
		{
			set{ _reg_time=value;}
			get{return _reg_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DEL_TIME
		{
			set{ _del_time=value;}
			get{return _del_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FORBIDDEN_TIME
		{
			set{ _forbidden_time=value;}
			get{return _forbidden_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ENABLE_TIME
		{
			set{ _enable_time=value;}
			get{return _enable_time;}
		}
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime? MODIFY_TIME
        {
            get { return _modify_time; }
            set { _modify_time = value; }
        }
		#endregion Model

	}
}

