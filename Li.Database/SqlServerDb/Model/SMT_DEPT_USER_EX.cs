/**  版本信息模板在安装目录下，可自行修改。
* SMT_DEPT_USER.cs
*
* 功 能： N/A
* 类 名： SMT_DEPT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/28 23:27:37   N/A    初版
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
	/// 部门用户权限表
	/// </summary>
	[Serializable]
	public partial class SMT_DEPT_USER
	{
        public SMT_USER_INFO USER_INFO;
	}
}

