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
	public partial class SMT_AUTO_ACCESS_RECORD
	{
        private string _staff_real_name;
        public string STAFF_REAL_NAME
        {
            get { return _staff_real_name; }
            set { _staff_real_name = value; }
        }
        private string _door_name;
        public string DOOR_NAME
        {
            get { return _door_name; }
            set { _door_name = value; }
        }

        private string _org_name;
        public string ORG_NAME
        {
            get { return _org_name; }
            set { _org_name = value; }
        }
        private string _card_no;
        public string CARD_NO
        {
            get { return _card_no; }
            set { _card_no = value; }
        }
	}
}

