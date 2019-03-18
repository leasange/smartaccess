/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_DOOR.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_DOOR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/11 12:06:47   N/A    初版
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
	/// 电子地图门关联表
	/// </summary>
	public partial class SMT_MAP_DOOR
	{
        public SMT_DOOR_INFO DOOR { get; set; }
        public SMT_FACERECG_DEVICE FACE { get; set; }
	}
}

