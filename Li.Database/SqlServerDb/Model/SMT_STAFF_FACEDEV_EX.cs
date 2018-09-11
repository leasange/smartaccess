/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_FACEDEV.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_FACEDEV
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 15:10:17   N/A    初版
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
	/// 员工人脸识别设备权限表
	/// </summary>
	public partial class SMT_STAFF_FACEDEV
	{
        public string REAL_NAME { get; set; }
        public string STAFF_NO { get; set; }
        public string STAFF_TYPE { get; set; }
        public decimal ORG_ID { get; set; }
        public string ORG_NAME { get; set; }

        public byte[] PHOTO { get; set; }

        public bool IS_FORBIDDEN { get; set; }

        public string FACEDEV_NAME { get; set; }
        public SMT_STAFF_INFO STAFF_INFO { get; set; }
        public SMT_FACERECG_DEVICE FACERECG_DEVICE { get; set; }
	}
}

