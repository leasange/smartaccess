using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.Common.WinInfo
{
    public partial class CtrlWaiting : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(CtrlWaiting));
        private Action _action = null;
        public CtrlWaiting(Action action = null)
        {
            InitializeComponent();
            _action = action;
        }
        public CtrlWaiting(string text,Action action=null)
        {
            InitializeComponent();
            this.lbText.Text = text;
            _action = action;
        }
        private void CtrlWaiting_Load(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private void CtrlWaiting_SizeChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            plLoading.SetBounds(this.Width / 2 - this.plLoading.Width / 2, this.Height / 2 - this.plLoading.Height / 2, this.plLoading.Width, this.plLoading.Height);
        }

        public new void Show()
        {

        }
        private Control father = null;
        public void Show(Control control,int delayMiniseconds=100)
        {
            try
            {
                if (_action == null)
                {
                    this.Dispose();
                }
                if (control != null)
                {
                    father = control;
                    if (delayMiniseconds > 0)
                    {
                        timerShowBack.Interval = delayMiniseconds;
                        timerShowBack.Start();
                    }
                    else
                    {
                        ShowBackground(control);
                    }
                    DoAction(control);
                }
            }
            catch (Exception ex)
            {
                log.Error("显示异常：", ex);
            }
        }
        private FrmWaiting waiting = null;
        public void ShowDialog(Control control)
        {
            try
            {
                if (_action == null)
                {
                    this.Dispose();
                }
                if (control != null)
                {
                    father = control;
                    waiting = new FrmWaiting();
                    waiting.Tip = this.lbText.Text;
                    DoAction(control);
                    waiting.ShowDialog(control);
                }
            }
            catch (Exception ex)
            {
                log.Error("显示异常：", ex);
            }
        }

        private void ShowBackground(Control control)
        {
            if (!this.IsDisposed)
            {
                Bitmap bitmap = WinInfoHelper.GetWindowCapture(control);
                this.BackgroundImage = bitmap;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                
                control.Controls.Add(this);
                this.SetBounds(0, 0, control.ClientSize.Width, control.ClientSize.Height);
                this.BringToFront();
            }
        }

        private void timerShowBack_Tick(object sender, EventArgs e)
        {
            timerShowBack.Stop();
            if (father != null&&!father.IsDisposed)
            {
                ShowBackground(father);
            }
        }

        private void DoAction(Control control)
        {
            try
            {
                _action.BeginInvoke(new AsyncCallback((o) =>
                {
                    try
                    {
                        _action.EndInvoke(o);
                    }
                    catch (Exception ex)
                    {
                        log.Error("执行异常2：", ex);
                        WinInfoHelper.ShowInfoWindow(null, "执行异常：" + ex.Message);
                    }
                    try
                    {
                        if (father!=null)
                        {
                            father.Invoke(new Action(() =>
                            {
                                father = null;
                                timerShowBack.Stop();
                                control.Controls.Remove(this);
                                if (waiting!=null)
                                {
                                    waiting.Close();
                                }
                                this.Dispose();
                                if (this.BackgroundImage != null)
                                {
                                    this.BackgroundImage.Dispose();
                                }
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("销毁异常：", ex);
                    }
                }), null);
            }
            catch (Exception ex)
            {
                log.Error("执行异常1：", ex);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 0x006;
        private const int WM_ACTIVATEAPP = 0x01C;
        private const int WM_NCACTIVATE = 0x086;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE);
                return;
            }
            else if (m.Msg == WM_NCACTIVATE)
            {
                if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }

    }
}
