using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 通用操作
    /// </summary>
    public class CommonClass
    {

        public delegate void FuntionHandle(params object[] objs);
        /// <summary> 
        /// 把汉字转换成拼音第一个字母 
        /// </summary> 
        /// <param name="ChineseStr">中文字符串 </param> 
        /// <returns>返回首拼音字母 </returns> 
        public static string ChineseCap(string ChineseStr)
        {
            string Capstr = "";
            byte[] ZW = new byte[2];
            long ChineseStr_int;
            string CharStr, ChinaStr = "";
            for (int i = 0; i <= ChineseStr.Length - 1; i++)
            {
                CharStr = ChineseStr.Substring(i, 1).ToString();
                ZW = System.Text.Encoding.Default.GetBytes(CharStr);
                // 得到汉字符的字节数组 
                if (ZW.Length == 2)
                {
                    int i1 = (short)(ZW[0]);
                    int i2 = (short)(ZW[1]);
                    ChineseStr_int = i1 * 256 + i2;

                    #region 参数
                    //table of the constant list 
                    // 'A';      //45217..45252 
                    // 'B';      //45253..45760 
                    // 'C';      //45761..46317 
                    // 'D';      //46318..46825 
                    // 'E';      //46826..47009 
                    // 'F';      //47010..47296 
                    // 'G';      //47297..47613 

                    // 'H';      //47614..48118 
                    // 'J';      //48119..49061 
                    // 'K';      //49062..49323 
                    // 'L';      //49324..49895 
                    // 'M';      //49896..50370 
                    // 'N';      //50371..50613 
                    // 'O';      //50614..50621 
                    // 'P';      //50622..50905 
                    // 'Q';      //50906..51386 

                    // 'R';      //51387..51445 
                    // 'S';      //51446..52217 
                    // 'T';      //52218..52697 
                    //没有U,V 
                    // 'W';      //52698..52979 
                    // 'X';      //52980..53640 
                    // 'Y';      //53689..54480 
                    // 'Z';      //54481..55289 

                    #endregion

                    #region 判断
                    if ((ChineseStr_int >= 45217) && (ChineseStr_int <= 45252))
                    {
                        ChinaStr = "A";
                    }
                    else if ((ChineseStr_int >= 45253) && (ChineseStr_int <= 45760))
                    {
                        ChinaStr = "B";
                    }
                    else if ((ChineseStr_int >= 45761) && (ChineseStr_int <= 46317))
                    {
                        ChinaStr = "C";

                    }
                    else if ((ChineseStr_int >= 46318) && (ChineseStr_int <= 46825))
                    {
                        ChinaStr = "D";
                    }
                    else if ((ChineseStr_int >= 46826) && (ChineseStr_int <= 47009))
                    {
                        ChinaStr = "E";
                    }
                    else if ((ChineseStr_int >= 47010) && (ChineseStr_int <= 47296))
                    {
                        ChinaStr = "F";
                    }
                    else if ((ChineseStr_int >= 47297) && (ChineseStr_int <= 47613))
                    {
                        ChinaStr = "G";
                    }
                    else if ((ChineseStr_int >= 47614) && (ChineseStr_int <= 48118))
                    {

                        ChinaStr = "H";
                    }

                    else if ((ChineseStr_int >= 48119) && (ChineseStr_int <= 49061))
                    {
                        ChinaStr = "J";
                    }
                    else if ((ChineseStr_int >= 49062) && (ChineseStr_int <= 49323))
                    {
                        ChinaStr = "K";
                    }
                    else if ((ChineseStr_int >= 49324) && (ChineseStr_int <= 49895))
                    {
                        ChinaStr = "L";
                    }
                    else if ((ChineseStr_int >= 49896) && (ChineseStr_int <= 50370))
                    {
                        ChinaStr = "M";
                    }

                    else if ((ChineseStr_int >= 50371) && (ChineseStr_int <= 50613))
                    {
                        ChinaStr = "N";

                    }
                    else if ((ChineseStr_int >= 50614) && (ChineseStr_int <= 50621))
                    {
                        ChinaStr = "O";
                    }
                    else if ((ChineseStr_int >= 50622) && (ChineseStr_int <= 50905))
                    {
                        ChinaStr = "P";

                    }
                    else if ((ChineseStr_int >= 50906) && (ChineseStr_int <= 51386))
                    {
                        ChinaStr = "Q";

                    }

                    else if ((ChineseStr_int >= 51387) && (ChineseStr_int <= 51445))
                    {
                        ChinaStr = "R";
                    }
                    else if ((ChineseStr_int >= 51446) && (ChineseStr_int <= 52217))
                    {
                        ChinaStr = "S";
                    }
                    else if ((ChineseStr_int >= 52218) && (ChineseStr_int <= 52697))
                    {
                        ChinaStr = "T";
                    }
                    else if ((ChineseStr_int >= 52698) && (ChineseStr_int <= 52979))
                    {
                        ChinaStr = "W";
                    }
                    else if ((ChineseStr_int >= 52980) && (ChineseStr_int <= 53640))
                    {
                        ChinaStr = "X";
                    }
                    else if ((ChineseStr_int >= 53689) && (ChineseStr_int <= 54480))
                    {
                        ChinaStr = "Y";
                    }
                    else if ((ChineseStr_int >= 54481) && (ChineseStr_int <= 55289))
                    {
                        ChinaStr = "Z";
                    }

                    #endregion

                }
                Capstr = Capstr + ChinaStr;
            }


            return Capstr;

        }
        public static void FilterTree(DevComponents.AdvTree.AdvTree advTree, string filterText)
        {
            if (advTree == null) return;
            if (filterText != null) filterText = filterText.Trim();
            foreach (DevComponents.AdvTree.Node node in advTree.Nodes)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    SetNodeVisible(node,true);
                }
            }

            List<DevComponents.AdvTree.Node> findNodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in advTree.Nodes)
            {
                FindFilterNodes(node, filterText, findNodes);
            }
            foreach (DevComponents.AdvTree.Node node in advTree.Nodes)
            {
                SetNodeVisible(node, false);
            }
            foreach (DevComponents.AdvTree.Node node in findNodes)
            {
                SetParentNodeVisible(node, true);
                SetNodeVisible(node, true);
            }
            advTree.RecalcLayout();
        }
        private static void FindFilterNodes(DevComponents.AdvTree.Node node, string filterText, List<DevComponents.AdvTree.Node> findNodes)
        {
            string nodeText = node.Text;
            string nodeFpy = CommonClass.ChineseCap(nodeText).ToLower();
            if (nodeText.Contains(filterText) || nodeFpy.Contains(filterText.ToLower()))//根节点符合条件
            {
                findNodes.Add(node);
            }
            else
            {
                if (node.Nodes.Count == 0) return;
                foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
                {
                    FindFilterNodes(chNode, filterText, findNodes);
                }
            }
        }
        public static void SetNodeVisible(DevComponents.AdvTree.Node node,bool visible)
        {
            node.Visible = visible;
            if (visible) node.Expanded = true;
            if (node.Nodes.Count == 0) return;
            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                SetNodeVisible(chNode,visible);
            }
        }
        private static void SetParentNodeVisible(DevComponents.AdvTree.Node node, bool visible)
        {
            if (node.Parent == null) return;
            node.Parent.Visible = visible;
            if (visible) node.Parent.Expanded = true;
            SetParentNodeVisible(node.Parent, visible);
        }
        /// <summary>
        /// 在指定控件右下角显示提示窗体
        /// </summary>
        /// <param name="control">控件，当控件为null指屏幕右下角</param>
        /// <param name="captiontext">主标题（窗体）</param>
        /// <param name="text">提示文字</param>
        public static void ShowTips(System.Windows.Forms.Control control,string captiontext,string text)
        {
            DevComponents.DotNetBar.Balloon balloon = new DevComponents.DotNetBar.Balloon();
            balloon.ShowInTaskbar = false;
            balloon.Style = eBallonStyle.Alert;
            balloon.CaptionText = captiontext;
            balloon.Text = text;
            balloon.AlertAnimation = eAlertAnimation.BottomToTop;
            balloon.AutoResize();
            balloon.AutoClose = true;
            balloon.AutoCloseTimeOut = 50;
            balloon.TopLevel = true;
            //balloon.Owner = FrmMain.Instance;
            Rectangle rect;

            if (control == null || control.IsDisposed)
            {
                rect = Screen.PrimaryScreen.WorkingArea;
            }
            else
            {
                rect = Screen.GetWorkingArea(control);
            }
            balloon.Location = new System.Drawing.Point(rect.Right - balloon.Width, rect.Bottom - balloon.Height);
            balloon.Show(false);
        }

        public static Image Get2InchPhoto(Image oldImage)
        {
            //626*413 2寸
            if (oldImage.Width > 413 || oldImage.Height > 626)
            {
                double ratio = oldImage.Width / (double)oldImage.Height;
                double oratio = 413 / 626d;
                double w = 413;
                double h = 626;
                if (ratio > oratio)
                {
                    h = w / ratio;
                }
                else
                {
                    w = h * ratio;
                }
                Bitmap bitmap = new Bitmap((int)w, (int)h);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(oldImage, 0, 0, bitmap.Width, bitmap.Height);
                g.Dispose();
                return bitmap;
            }
            return null;
        }
    }
}
