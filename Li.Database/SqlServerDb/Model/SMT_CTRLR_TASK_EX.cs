/**  版本信息模板在安装目录下，可自行修改。
* SMT_CTRLR_TASK.cs
*
* 功 能： N/A
* 类 名： SMT_CTRLR_TASK
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/7 22:17:03   N/A    初版
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
	/// 控制定时任务表
	/// </summary>
	public partial class SMT_CTRLR_TASK
	{
        public string DOOR_NAMES = "";
        public string STR_CTRL_STYLE
        {
            get
            {
                string str=_ctrl_style.ToString();
                switch (_ctrl_style)
                {
                    case 0:
                       str="0. 在线";
                       break;
                    case 1:
                        str="1. 常开";
                        break;
                    case 2:
                        str="2. 常闭";
                        break;
                    case 3:
                        str="3. 禁止 2以上时段的用户开门(包括2时段)";
                        break;
                    case 4:
                        str="4. 取消禁止 2以上时段的用户开门(包括2时段)";
                        break;
                    case 5:
                        str="5. 刷卡-无密码";
                        break;
                    case 6:
                        str="6. (进门) 刷卡 + 密码";
                        break;
                    case 7:
                        str="7. (进出门) 刷卡 + 密码";
                        break;
                    case 8:
                        str="8. 多卡开门生效";
                        break;
                    case 9:
                        str="9. 单卡开门, 不要求多卡";
                        break;
                    case 10:
                        str="10. 动作一次";
                        break;
                    case 11:
                        str="11. 禁用按钮";
                        break;
                    case 12:
                        str = "12. 启用按钮";
                        break;
                    default:
                        break;
                }
                return str;
            }
        }
	}
}

