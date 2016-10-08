using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.Common.WinInfo
{
    public partial class FrmDetailInfo : DevComponents.DotNetBar.Office2007Form
    {
        private static FrmDetailInfo _instance = null;

        public static void Show(bool progress = true)
        {
            Form frm = FrmMain.Instance;
            frm.Invoke(new Action(() =>
                {
                    if (_instance == null || _instance.IsDisposed)
                    {
                        _instance = new FrmDetailInfo(progress);
                        _instance.CreateControl();
                    }
                    if (!_instance.Visible)
                    {
                        Point p = frm.Location;
                        int x = p.X + frm.Width / 2 - _instance.Width / 2;
                        int y = p.Y + frm.Height / 2 - _instance.Height / 2;
                        _instance.Show(frm);
                        _instance.Location = new Point(x, y);
                    }
                    _instance.Clear();
                    _instance.SetProgressVisible(progress);
                }));
        }
        public static void Close()
        {
            if (_instance != null && !_instance.IsDisposed)
            {
                Form frm = Application.OpenForms[0];
                frm.Invoke(new Action(() =>
                {
                    _instance.Dispose();
                }));
            }
        }
        public static void AddOneMsg(string msg, int progress = -1, bool isRed = false)
        {
            if (_instance != null && !_instance.IsDisposed)
            {
                _instance.AddMsg(msg, progress, isRed);
            }
        }
        public static void SetActionProgress(int progress = -1)
        {
            if (_instance != null && !_instance.IsDisposed)
            {
                _instance.SetProgress(progress);
            }
        }

        public FrmDetailInfo(bool progress=true)
        {
            InitializeComponent();
            this.progressBar.Visible = progress;
        }
        public void SetProgressVisible(bool progress=true)
        {
            this.progressBar.Visible = progress;
        }
        public void Clear()
        {
            this.Invoke(new Action(() =>
            {
                this.tbMsg.Text = "";
                this.progressBar.Value = 0;
            }));
        }
        public void AddMsg(string msg, int progress = -1, bool isRed = false)
        {
            lock (this)
            {
                this.Invoke(new Action(() =>
                    {
                        string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " => " + msg + "\r\n";
                        this.tbMsg.AppendText(text);
                        if (isRed)
                        {
                            string str = text.TrimEnd('\r', '\n');
                            int index = this.tbMsg.TextLength - str.Length-1;
                            if (index<0)
                            {
                                index = 0;
                            }
                            this.tbMsg.Select(index, str.Length);
                            this.tbMsg.SelectionColor = Color.Red;
                            this.tbMsg.SelectionLength = 0;
                        }
                        this.tbMsg.ScrollToCaret();
                        if (progress>=0)
	                    {
                            this.progressBar.Value = progress >= 100 ? 100 : progress;
                            this.progressBar.Text = "当前进度：" + this.progressBar.Value + "%";
	                    }
                    }));
            }
        }
        
        public void SetProgress(int progress = -1)
        {
            lock (this)
            {
                this.Invoke(new Action(() =>
                {
                    if (progress >= 0)
                    {
                        this.progressBar.Value = progress >= 100 ? 100 : progress;
                        this.progressBar.Text = "当前进度：" + this.progressBar.Value + "%";
                    }
                }));
            }
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            tbMsg.Copy();
        }
    }
}
