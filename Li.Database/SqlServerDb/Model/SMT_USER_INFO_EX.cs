/**  版本信息模板在安装目录下，可自行修改。
* SMT_USER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_USER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/9 20:03:26   N/A    初版
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
	/// 系统用户表
	/// </summary>
	public partial class SMT_USER_INFO
	{
        private string _dept_name;//部门名称
        private string _role_name;//角色名称

        public string DEPT_NAME
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }
        public string ROLE_NAME
        {
            get { return _role_name; }
            set { _role_name = value; }
        }
	}
}

