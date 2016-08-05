/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/5 0:01:57   N/A    初版
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
	/// 门表
	/// </summary>
	public partial class SMT_DOOR_INFO
	{
        private decimal _area_id;
        private string _area_name;

        public decimal AREA_ID//区域ID
        {
            get { return _area_id; }
            set { _area_id = value; }
        }
        public string AREA_NAME//区域名称
        {
            get { return _area_name; }
            set { _area_name = value; }
        }
	}
}

