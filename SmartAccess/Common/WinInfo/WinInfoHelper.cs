using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.Common.WinInfo
{
    /// <summary>
    /// 通用窗口提示
    /// </summary>
    public class WinInfoHelper
    {
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest,    //目标DC的句柄
            int nXDest,        //目标DC的矩形区域的左上角的x坐标
            int nYDest,        //目标DC的矩形区域的左上角的y坐标
            int nWidth,        //目标DC的句型区域的宽度值
            int nHeight,       //目标DC的句型区域的高度值
            IntPtr hdcSrc,     //源DC的句柄
            int nXSrc,         //源DC的矩形区域的左上角的x坐标
            int nYSrc,         //源DC的矩形区域的左上角的y坐标
            System.Int32 dwRo  //光栅的处理数值
        );

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr GetDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public static void ShowInfoWindow(IWin32Window owner, string text, float timeclose = 3.5f)
        {
            FrmInfo.ShowInfo(owner, text, timeclose);
        }

        public static Bitmap GetWindowCapture(Control control)
        {
            IntPtr hwnd1 = control.Handle;
            if (!hwnd1.Equals(IntPtr.Zero))
            {
               // Rectangle rect;
               // GetWindowRect(hwnd1, out rect);  //获得目标窗体的大小
                Bitmap pic = new Bitmap(control.ClientSize.Width, control.ClientSize.Height);
                Graphics g1 = Graphics.FromImage(pic);
                IntPtr hdc1 = GetDC(hwnd1);
                IntPtr hdc2 = g1.GetHdc();  //得到Bitmap的DC
                BitBlt(hdc2, 0, 0, control.ClientSize.Width, control.ClientSize.Height, hdc1, 0, 0, 13369376);
                g1.ReleaseHdc(hdc2);  //释放掉Bitmap的DC
                ReleaseDC(hwnd1, hdc1);
                return pic;
            }
            return null;
        }
    }
}
