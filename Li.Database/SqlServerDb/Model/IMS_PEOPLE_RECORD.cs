/**  版本信息模板在安装目录下，可自行修改。
* IMS_PEOPLE_RECORD.cs
*
* 功 能： N/A
* 类 名： IMS_PEOPLE_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/16 23:12:00   N/A    初版
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
	/// IMS_PEOPLE_RECORD:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IMS_PEOPLE_RECORD
	{
		public IMS_PEOPLE_RECORD()
		{}
		#region Model
		private decimal _id;
		private int? _cardtype;
		private string _cardno;
		private string _name;
		private string _depart;
		private string _accesschannel;
		private int? _throughforward;
		private DateTime? _throughtime;
		private int? _throughresult;
		private string _capturepic;
		private string _originpic;
		private int? _compareresult;
		private decimal? _similarity;
		private string _faceposition;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Depart
		{
			set{ _depart=value;}
			get{return _depart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccessChannel
		{
			set{ _accesschannel=value;}
			get{return _accesschannel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ThroughForward
		{
			set{ _throughforward=value;}
			get{return _throughforward;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ThroughTime
		{
			set{ _throughtime=value;}
			get{return _throughtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ThroughResult
		{
			set{ _throughresult=value;}
			get{return _throughresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CapturePic
		{
			set{ _capturepic=value;}
			get{return _capturepic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginPic
		{
			set{ _originpic=value;}
			get{return _originpic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompareResult
		{
			set{ _compareresult=value;}
			get{return _compareresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Similarity
		{
			set{ _similarity=value;}
			get{return _similarity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FacePosition
		{
			set{ _faceposition=value;}
			get{return _faceposition;}
		}
		#endregion Model

	}
}

