using DevComponents.AdvTree;
using NT.Net.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartKey
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmMain));
        private string keyValue = "@Sxjfi890376$%^&lz!!lfdsjiQQXXif&*()+!~";
        private DogClass _selectedDogClass = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            LoadKeys();
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            SunCreate.Common.ConfigHelper.SetConfigValue("AppID", tbAppID.Text.Trim());
            SunCreate.Common.ConfigHelper.SetConfigValue("Pin1", tbPin1.Text.Trim());
            SunCreate.Common.ConfigHelper.SetConfigValue("Pin2", tbPin2.Text.Trim());
            SunCreate.Common.ConfigHelper.SetConfigValue("Pin3", tbPin3.Text.Trim());
            SunCreate.Common.ConfigHelper.SetConfigValue("Pin4", tbPin4.Text.Trim());
            SunCreate.Common.ConfigHelper.SetConfigValue("Seed", tbSeed.Text.Trim());
            base.OnHandleDestroyed(e);
        }
        private string GetError(long ret)
        {
            string str = "成功";
            switch (ret)
            {
                case 0: ; str = "成功"; break;
                case 1: ; str = "指定应用程序ID的锁未找到"; break;

                case 2: ; str = "参数不合法"; break;

                case 3: ; str = "未找到加密锁"; break;

                case 4: ; str = "未找到加密锁HANDLE"; break;

                case 5: ; str = "权限不足"; break;

                case 6: ; str = "驱动未打开"; break;

                case 7: ; str = "不支持该特性"; break;

                case 8: ; str = "内部错误"; break;

                case 20: ; str = "HID读操作错误"; break;

                case 21: ; str = "HID读操作错误 - 数据不足"; break;

                case 22: ; str = "HID写操作错误"; break;

                case 23: ; str = "HID写操作错误 - 数据不足"; break;

                case 24: ; str = "HID读操作错误 - 超时"; break;

                case 25: ; str = "HID读操作错误 - 未定义错误"; break;

                case 26: ; str = "HID读操作错误 - 超时"; break;

                case 27: ; str = "HID读操作错误 - 未定义错误"; break;

                case 28: ; str = "设备未连接或半途拔掉"; break;

                case 50: ; str = "内部错误"; break;

                case 51: ; str = "内部错误"; break;

                case 52: ; str = "内部错误"; break;

                case 102: ; str = "内部错误"; break;

                case 103: ; str = "内部错误"; break;

                case 104: ; str = "内部错误"; break;

                case 105: ; str = "内部错误"; break;

                case 106: ; str = "内部错误"; break;

                case 107: ; str = "内部错误"; break;

                case 108: ; str = "内部错误"; break;

                case 109: ; str = "内部错误"; break;

                case 110: ; str = "内部错误"; break;

                case 111: ; str = "内部错误"; break;

                case 112: ; str = "内部错误"; break;

                case 113: ; str = "内部错误"; break;

                case 114: ; str = "内部错误"; break;

                case 115: ; str = "文件大小必须为8的倍数"; break;

                case 116: ; str = "文件系统未加载"; break;

                case 202: ; str = "文件系统未初始化"; break;

                case 203: ; str = "文件系统格式错误"; break;

                case 204: ; str = "不支持的文件系统类型"; break;

                case 205: ; str = "不存在此文件"; break;

                case 206: ; str = "数据文件大小不一致"; break;

                case 207: ; str = "没有更多的文件了"; break;

                case 208: ; str = "文件系统空间不足"; break;

                case 209: ; str = "已达到最大文件数限制"; break;

                case 500: ; str = "内部错误"; break;

                case 501: ; str = "权限不足"; break;

                case 502: ; str = "内部错误"; break;

                case 503: ; str = "内部错误"; break;

                case 504: ; str = "内部错误"; break;

                case 505: ; str = "内部错误"; break;

                case 506: ; str = "内部错误"; break;

                case 507: ; str = "登录密码错误"; break;

                case 508: ; str = "数据写失败"; break;

                case 509: ; str = "此ID可执行文件不存在"; break;

                case 510: ; str = "文件系统不存在"; break;

                case 511: ; str = "升级错误"; break;

                case 512: ; str = "设备已进入安全模式"; break;

                case 513: ; str = "BS模式用户登录失败"; break;

                case 514: ; str = "未知错误"; break;
                default:
                    break;
            }
            if (ret != 0)
            {
                return str;
            }
            return "";
        }

        private void LoadKeys()
        {
            try
            {
                _selectedDogClass = null;
                panelPrivate.Enabled = false;
                dogListTree.Nodes[0].Nodes.Clear();
                string appId = this.tbAppID.Text.Trim();
                long[] keyHandles;
                long keyNum = 0;
                long ret = NT158App.NT158Find(appId, out keyHandles, ref keyNum);
                if (ret == 0)//成功
                {
                    for (int i = 0; i < keyNum; i++)
                    {
                        try
                        {
                            DogClass dogobj = new DogClass();
                            dogobj.appId = appId;
                            dogobj.keyHandle = keyHandles[i];
                            string uid = "";
                            ret = NT158App.NT158GetUid(keyHandles[i], ref uid);
                            if (ret!=0)
                            {
                                uid = "获取失败：" + GetError(ret);
                            }
                            dogobj.uid = uid;

                            Node node = new Node("NT158_" + (i + 1));
                            node.Tag = dogobj;
                            Node appIdNode = new Node("识别码：" + dogobj.appId);
                            node.Nodes.Add(appIdNode);
                            Node uidNode = new Node("硬件序列号：" + dogobj.uid);
                            node.Nodes.Add(uidNode);
                            dogListTree.Nodes[0].Nodes.Add(node);
                        }
                        catch (Exception ex)
                        {
                            log.Error(keyHandles[i] + "加载异常：", ex);
                            MessageBox.Show(keyHandles[i] + "加载异常：" + ex.Message);
                        }
                    }
                    dogListTree.Nodes[0].Expand();
                }
                else//失败，或未找到
                {
                    MessageBox.Show("未找到任何加密狗设备，错误：" + GetError(ret));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找设备异常：" + ex.Message);
                log.Error("查找设备异常：", ex);
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string appId = SunCreate.Common.ConfigHelper.GetConfigString("AppID");
            long pin1 = 0;
            long pin2 = 0;
            long pin3 = 0;
            long pin4 = 0;
            pin1 = (long)SunCreate.Common.ConfigHelper.GetConfigDouble("Pin1");
            pin2 = (long)SunCreate.Common.ConfigHelper.GetConfigDouble("Pin2");
            pin3 = (long)SunCreate.Common.ConfigHelper.GetConfigDouble("Pin3");
            pin4 = (long)SunCreate.Common.ConfigHelper.GetConfigDouble("Pin4");
            tbPin1.Text = pin1.ToString();
            tbPin2.Text = pin2.ToString();
            tbPin3.Text = pin3.ToString();
            tbPin4.Text = pin4.ToString();
            tbAppID.Text = appId;
            tbSeed.Text = SunCreate.Common.ConfigHelper.GetConfigString("Seed");
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddMonths(1);
            LoadKeys();
        }

        private void biNT158Tool_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.Start(Application.StartupPath + "\\nt158tool\\NT158AdminEditor.exe");
                process.WaitForExit();
                LoadKeys();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开官方工具失败：", ex.Message);
                log.Error("打开官方工具失败：", ex);
            }
        }

        private void biResetAppID_Click(object sender, EventArgs e)
        {
            tbAppID.Text = "1234567890ABCDEF";
        }

        private void biExportKeyFile_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendFormat("APPID=" + tbAppID.Text.Trim());
                builder.AppendLine();
                builder.AppendFormat("PIN1=" + tbPin1.Text.Trim());
                builder.AppendLine();
                builder.AppendFormat("PIN2=" + tbPin2.Text.Trim());
                builder.AppendLine();
                builder.AppendFormat("PIN3=" + tbPin3.Text.Trim());
                builder.AppendLine();
                builder.AppendFormat("PIN4=" + tbPin4.Text.Trim());
                string encString = EncryptUtils.DESEncrypt(builder.ToString(), keyValue.Substring(0, 8), keyValue.Substring(8, 8));
                //string encString = EncryptUtils.DES3Encrypt(builder.ToString(), keyValue.Substring(0, 24));
                if (sfdKeyDialog.ShowDialog(this) == DialogResult.OK)
                {
                    FileStream fs = File.Open(sfdKeyDialog.FileName, FileMode.Create);
                    byte[] bts = Encoding.UTF8.GetBytes(encString);
                    fs.Write(bts, 0, bts.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                    MessageBox.Show("导出成功！");
                }
            }
            catch (Exception ex)
            {
                log.Error("导出密钥文件异常：", ex);
                MessageBox.Show("导出密钥文件异常：" + ex.Message);
            }
        }

        private void dogListTree_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                if (e.Node.Tag is DogClass)
                {
                    DogClass dc = (DogClass)e.Node.Tag;
                    long pin1, pin2, pin3, pin4;
                    if (long.TryParse(tbPin1.Text.Trim(), out pin1) &&
                        long.TryParse(tbPin2.Text.Trim(), out pin2) &&
                        long.TryParse(tbPin3.Text.Trim(), out pin3) &&
                        long.TryParse(tbPin4.Text.Trim(), out pin4))
                    {
                        long ret = NT158App.NT158Login(dc.keyHandle, pin1, pin2, pin3, pin4);
                        if (ret != 0)
                        {
                            log.Error("登陆加密狗异常：" + GetError(ret));
                            MessageBox.Show("登陆加密狗异常：" + GetError(ret));
                            return;
                        }
                        panelPrivate.Enabled = true;
                        _selectedDogClass = dc;
                        lbDevNo.Text = _selectedDogClass.uid;
                        DoReadPrivate();
                    }
                    else
                    {
                        MessageBox.Show("密钥格式必须为long数据！");
                    }
                }
                else
                {
                    panelPrivate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("执行操作异常：", ex);
                MessageBox.Show("执行操作异常："+ex.Message);
            }
        }
        //读取权限
        private void DoReadPrivate()
        {
            byte[] nameBuffer = new byte[128];
            //读取加密狗身份名称
            long ret = NT158App.NT158ReadFile(_selectedDogClass.keyHandle, 0, 0, nameBuffer);
            if (ret != 0)
            {
                log.Error("读取加密狗身份名称异常：" + GetError(ret));
                MessageBox.Show("读取加密狗身份名称异常：" + GetError(ret));
                // return;
            }
            try
            {
                string str = Encoding.UTF8.GetString(nameBuffer).TrimEnd('\0');
                tbDogName.Text = str;
            }
            catch (Exception ex)
            { }

            byte[] setTimeBuffer = new byte[19];
            ret = NT158App.NT158ReadFile(_selectedDogClass.keyHandle, 0, 128, setTimeBuffer);//读取授权时间
            if (ret != 0)
            {
                log.Error("读取最后一次授权时间异常：" + GetError(ret));
                MessageBox.Show("读取最后一次授权时间异常：" + GetError(ret));
                // return;
            }
            try
            {
                string str = Encoding.UTF8.GetString(setTimeBuffer).TrimEnd('\0');
                lbTimePrivate.Text = str;
            }
            catch (Exception ex)
            { }

            byte[] starttime = new byte[19];
            ret = NT158App.NT158ReadFile(_selectedDogClass.keyHandle, 0, 128 + 19, starttime);//读取有效开始时间
            if (ret != 0)
            {
                log.Error("读取有效开始时间异常：" + GetError(ret));
                MessageBox.Show("读取有效开始时间异常：" + GetError(ret));
                // return;
            }
            try
            {
                string str = Encoding.UTF8.GetString(starttime).TrimEnd('\0');
                DateTime dt = DateTime.Now;
                DateTime.TryParse(str, out dt);
                dtiStartTime.Value = dt;
            }
            catch (Exception ex)
            { }

            byte[] endtime = new byte[19];
            ret = NT158App.NT158ReadFile(_selectedDogClass.keyHandle, 0, 128 + 19 * 2, endtime);//读取有效结束时间
            if (ret != 0)
            {
                log.Error("读取有效结束时间异常：" + GetError(ret));
                MessageBox.Show("读取结束开始时间异常：" + GetError(ret));
                // return;
            }
            try
            {
                string str = Encoding.UTF8.GetString(endtime).TrimEnd('\0');
                DateTime dt = DateTime.Now;
                DateTime.TryParse(str, out dt);
                dtiEndTime.Value = dt;
            }
            catch (Exception ex)
            { }
        }
        private void DoCopyArray(byte[] src,byte[] dst)
        {
            for (int i = 0; i < src.Length; i++)
            {
                if (i >= dst.Length)
                {
                    break;
                }
                dst[i] = src[i];
            }
            for (int i = src.Length; i < dst.Length; i++)
            {
                dst[i] = 0;
            }
        }
        //写入权限
        private bool DoWritePrivate(bool isclear=false)
        {
            //设置加密狗身份名称
            byte[] nameBuffer = new byte[128];
            string str = tbDogName.Text.Trim();
            if (isclear)
            {
                str = "";
            }
            var t = Encoding.UTF8.GetBytes(str);
            DoCopyArray(t, nameBuffer);
            long ret = NT158App.NT158WriteFile(_selectedDogClass.keyHandle, 0, 0, nameBuffer);
            if (ret != 0)
            {
                if (isclear)
                {
                    log.Error("清除名称异常：" + GetError(ret));
                    MessageBox.Show("清除名称异常：" + GetError(ret));
                }
                else
                {
                    log.Error("设置加密狗身份名称异常：" + GetError(ret));
                    MessageBox.Show("设置加密狗身份名称异常：" + GetError(ret));
                }
            }

            byte[] setTimeBuffer = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ret = NT158App.NT158WriteFile(_selectedDogClass.keyHandle, 0, 128, setTimeBuffer);//设置授权时间
            if (ret != 0)
            {
                if (isclear)
                {
                    log.Error("设置最后一次清除时间异常：" + GetError(ret));
                    MessageBox.Show("设置最后一次清除时间异常：" + GetError(ret));
                }
                else
                {
                    log.Error("设置最后一次授权时间异常：" + GetError(ret));
                    MessageBox.Show("设置最后一次授权时间异常：" + GetError(ret));
                }
            }
            DateTime dtStart = dtiStartTime.Value;
            if (isclear)
            {
                dtStart = DateTime.MinValue;
            }
            byte[] starttime = Encoding.UTF8.GetBytes(dtStart.ToString("yyyy-MM-dd HH:mm:ss"));
            ret = NT158App.NT158WriteFile(_selectedDogClass.keyHandle, 0, 128 + 19, starttime);//设置有效开始时间
            if (ret != 0)
            {
                if (isclear)
                {
                    log.Error("清除有效开始时间异常：" + GetError(ret));
                    MessageBox.Show("清除有效开始时间异常：" + GetError(ret));
                    return false;
                }
                else
                {
                    log.Error("设置有效开始时间异常：" + GetError(ret));
                    MessageBox.Show("设置有效开始时间异常：" + GetError(ret));
                    return false;
                }
            }
            DateTime dtEnd = dtiEndTime.Value;
            if (isclear)
            {
                dtEnd = DateTime.MinValue;
            }
            byte[] endtime = Encoding.UTF8.GetBytes(dtEnd.ToString("yyyy-MM-dd HH:mm:ss"));
            ret = NT158App.NT158WriteFile(_selectedDogClass.keyHandle, 0, 128 + 19 * 2, endtime);//设置有效开始时间
            if (ret != 0)
            {
                if (isclear)
                {
                    log.Error("清除有效结束时间异常：" + GetError(ret));
                    MessageBox.Show("清除有效结束时间异常：" + GetError(ret));
                    return false;
                }
                else
                {
                    log.Error("设置有效结束时间异常：" + GetError(ret));
                    MessageBox.Show("设置结束开始时间异常：" + GetError(ret));
                    return false;
                }
            }
            return true;
        }

        private void btnSetOneMonth_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddMonths(1);
        }

        private void btnSet3Month_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddMonths(3);
        }

        private void btnSetHalfYear_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddMonths(6);
        }

        private void btnSetOneYear_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddYears(1);
        }

        private void btnSet3Year_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddYears(3);
        }

        private void btnSet5Year_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddYears(5);
        }

        private void btnSet10Year_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddYears(10);
        }

        private void btnSet30Year_Click(object sender, EventArgs e)
        {
            dtiStartTime.Value = DateTime.Now;
            dtiEndTime.Value = dtiStartTime.Value.AddYears(30);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtiStartTime.Value>=dtiEndTime.Value)
            {
                MessageBox.Show("有效开始时间应该小于结束时间！");
                return;
            }
            if (DoWritePrivate())
            {
                MessageBox.Show("授权写入成功！");
            }
            else
            {
                MessageBox.Show("授权写入失败！");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(DoWritePrivate(true))
            {
                MessageBox.Show("清除权限成功！");
                tbDogName.Text = "";
            }
            else
            {
                MessageBox.Show("清除权限异常！");
                dtiStartTime.Value = DateTime.MinValue;
                dtiEndTime.Value = DateTime.MinValue;
            }
        }
    }
}
