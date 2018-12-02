using System;
using System.Collections.Concurrent;
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
        public class MsgClass
        {
            public DateTime dateTime;
            public string msg;
            public int progress;
            public bool isRed;
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmDetailInfo));
        private static FrmDetailInfo _instance = null;
        private ConcurrentQueue<MsgClass> _currentMsgs = new ConcurrentQueue<MsgClass>();

        public static SmartAccess.Common.Datas.UploadPrivate.CancelObject CancelObj = null;
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
                    _instance.FormClosed += _instance_FormClosed;
                }));
        }
        public static bool IsClosed()
        {
            if (_instance==null)
            {
                return true;
            }
            return _instance.IsDisposed || (!_instance.Visible);
        }
        static void _instance_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance.FormClosed -= _instance_FormClosed;
            if (CancelObj != null)
            {
                CancelObj.cancel = true;
            }
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
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " => " + msg + "\r\n";
            _currentMsgs.Enqueue(new MsgClass()
            {
                 msg=msg,
                 progress=progress,
                 isRed=isRed,
                 dateTime=DateTime.Now
            });
        }

        private void DoAddMsg()
        {
            if (_currentMsgs.Count<=0)
            {
                return;
            }
            MsgClass msgClass;
            int progress = -1;
            while (_currentMsgs.TryDequeue(out msgClass))
            {
                if (msgClass.progress>=0)
                {
                    progress = msgClass.progress;
                }
                if (string.IsNullOrWhiteSpace(msgClass.msg))
                {
                    continue;
                }
                string text = msgClass.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + " => " + msgClass.msg + "\r\n";
                this.tbMsg.AppendText(text);
                if (msgClass.isRed)
                {
                    string str = text.TrimEnd('\r', '\n');
                    int index = this.tbMsg.TextLength - str.Length - 1;
                    if (index < 0)
                    {
                        index = 0;
                    }
                    this.tbMsg.Select(index, str.Length);
                    this.tbMsg.SelectionColor = Color.Red;
                    this.tbMsg.SelectionLength = 0;
                    log.Error(text);
                }
            }
            this.tbMsg.ScrollToCaret();
            if (progress >= 0)
            {
                this.progressBar.Value = progress >= 100 ? 100 : progress;
                this.progressBar.Text = "当前进度：" + this.progressBar.Value + "%";
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

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            DoAddMsg();
        }
    }

}
