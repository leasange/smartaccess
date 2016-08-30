/**  版本信息模板在安装目录下，可自行修改。
* SMT_ORG_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_ORG_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 20:12:29   N/A    初版
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
	/// 组织机构部门表
	/// </summary>
	public partial class SMT_ORG_INFO
	{
        private string _par_org_code="";//上级部门CODE
        public string PAR_ORG_CODE
        {
            get { return _par_org_code; }
            set { _par_org_code = value; }
        }
	}
}

