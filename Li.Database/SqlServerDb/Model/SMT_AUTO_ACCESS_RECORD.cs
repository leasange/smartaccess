/**  版本信息模板在安装目录下，可自行修改。
* SMT_AUTO_ACCESS_RECORD.cs
*
* 功 能： N/A
* 类 名： SMT_AUTO_ACCESS_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/9 16:02:25   N/A    初版
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
	/// SMT_AUTO_ACCESS_RECORD:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SMT_AUTO_ACCESS_RECORD
	{
		public SMT_AUTO_ACCESS_RECORD()
		{}
		#region Model
		private decimal _id;
		private string _acc_from_sys="PUBLISH_SYS";
		private string _acc_app_id;
        private string _acc_app_name;
		private decimal _acc_staff_id;
		private decimal _acc_door_id;
		private DateTime _acc_start_time;
		private DateTime _acc_end_time;
		private DateTime _acc_add_time;
		private DateTime _acc_state_time;
		private int _acc_state=0;
		/// <summary>
		/// 自增编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设置来源： PUBLISH_SYS 信息发布系统
		/// </summary>
		public string ACC_FROM_SYS
		{
			set{ _acc_from_sys=value;}
			get{return _acc_from_sys;}
		}
		/// <summary>
		/// 记录所属的原始系统表单ID（审批单号），同一表单可以有多条记录，取消授权可以根据单号批量更改状态为9
		/// </summary>
		public string ACC_APP_ID
		{
			set{ _acc_app_id=value;}
			get{return _acc_app_id;}
		}
        public string ACC_APP_NAME
        {
            set { _acc_app_name = value; }
            get { return _acc_app_name; }
        }
		/// <summary>
		/// 待授权的人员ID
		/// </summary>
		public decimal ACC_STAFF_ID
		{
			set{ _acc_staff_id=value;}
			get{return _acc_staff_id;}
		}
		/// <summary>
		/// 待授权的门禁
		/// </summary>
		public decimal ACC_DOOR_ID
		{
			set{ _acc_door_id=value;}
			get{return _acc_door_id;}
		}
		/// <summary>
		/// 门禁授权开始时间
		/// </summary>
		public DateTime ACC_START_TIME
		{
			set{ _acc_start_time=value;}
			get{return _acc_start_time;}
		}
		/// <summary>
		/// 门禁授权结束时间
		/// </summary>
		public DateTime ACC_END_TIME
		{
			set{ _acc_end_time=value;}
			get{return _acc_end_time;}
		}
		/// <summary>
		/// 记录生成时间
		/// </summary>
		public DateTime ACC_ADD_TIME
		{
			set{ _acc_add_time=value;}
			get{return _acc_add_time;}
		}
		/// <summary>
		/// 记录状态最后更改时间
		/// </summary>
		public DateTime ACC_STATE_TIME
		{
			set{ _acc_state_time=value;}
			get{return _acc_state_time;}
		}
		/// <summary>
		/// 记录状态：0 初始未授权状态，1已授权状态，2授权失败，9取消授权
		/// </summary>
		public int ACC_STATE
		{
			set{ _acc_state=value;}
			get{return _acc_state;}
		}
		#endregion Model

	}
}

