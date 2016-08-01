using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmStaffInfo : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_STAFF_INFO _staffInfo = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmStaffInfo));
        public FrmStaffInfo()
        {
            InitializeComponent();
        }
        public FrmStaffInfo(Maticsoft.Model.SMT_STAFF_INFO staffInfo)
        {
            InitializeComponent();
            _staffInfo = staffInfo;
        }
        private void biSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (_staffInfo == null || _staffInfo.ID==-1)
                {
                    _staffInfo = new Maticsoft.Model.SMT_STAFF_INFO();
                    _staffInfo.REG_TIME = DateTime.Now;
                    _staffInfo.ID = -1;
                }
                _staffInfo.REAL_NAME = tbStaffName.Text;
                try
                {
                    cboVerTypeStyle.SelectedValue = _staffInfo.STAFF_NO_TEMPLET;//证件编号模板
                }
                catch (Exception ex)
                {
                    log.Error("证件编号模板设置异常：", ex);
                }
                _staffInfo.STAFF_NO = tbVerNo.Text;
                _staffInfo.SEX = cbSex.SelectedIndex < 0 ? 0 : cbSex.SelectedIndex;
                _staffInfo.JOB = tbJob.Text;
                if (dtBirthday.ValueObject == null)
                {
                    _staffInfo.BIRTHDAY = null;
                }
                else
                {
                    _staffInfo.BIRTHDAY = dtBirthday.Value;
                }
                _staffInfo.POLITICS = tbPublic.Text;
                _staffInfo.MARRIED = cbMarry.SelectedIndex < 0 ? 0 : cbMarry.SelectedIndex;
                _staffInfo.SKIIL_LEVEL = tbSkillLevel.Text;
                _staffInfo.CER_NAME = tbPrivateVerName.Text;
                _staffInfo.CER_NO = tbPrivateVerNo.Text;
                _staffInfo.CELL_PHONE = tbCellPhone.Text;
                _staffInfo.TELE_PHONE = tbTelphone.Text;
                _staffInfo.EMAIL = tbEmail.Text;
                _staffInfo.VALID_STARTTIME = dtValidTimeStart.Value;
                _staffInfo.VALID_ENDTIME = dtValidTimeEnd.Value;
                _staffInfo.ADDRESS = tbAddress.Text;
                _staffInfo.NATIVE = tbJiGuan.Text;
                _staffInfo.NATION = tbMinZu.Text;
                _staffInfo.RELIGION = tbZonJiao.Text;
                _staffInfo.EDUCATIONAL = tbXueLi.Text;
                if (dtTimeIn.ValueObject == null)
                {
                    _staffInfo.ENTRY_TIME = null;
                }
                else
                {
                    _staffInfo.ENTRY_TIME = dtTimeIn.Value;
                }
                if (dtTimeOut.ValueObject == null)
                {
                    _staffInfo.ABORT_TIME = null;
                }
                else
                {
                    _staffInfo.ABORT_TIME = dtTimeOut.Value;
                }

                try
                {
                    _staffInfo.PRINT_TEMPLET_ID = cboVeMoBan.SelectedValue == null ? -1 : (decimal)cboVeMoBan.SelectedValue;
                }
                catch (Exception ex)
                {
                    log.Error("无此证件模板：" + _staffInfo.PRINT_TEMPLET_ID + ",ex=" + ex.Message);
                }
                if (picPhoto.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _staffInfo.PHOTO = ms.GetBuffer();
                }
                _staffInfo.PHOTO = GetPicImage(picPhoto);
                _staffInfo.CER_PHOTO_FRONT = GetPicImage(picVerFront);
                _staffInfo.CER_PHOTO_BACK = GetPicImage(picVerBack);
                _staffInfo.MODIFY_TIME = DateTime.Now;

                Maticsoft.BLL.SMT_STAFF_INFO saffInfo = new Maticsoft.BLL.SMT_STAFF_INFO();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        if (_staffInfo.ID == -1)
                        {
                            _staffInfo.ID = saffInfo.Add(_staffInfo);
                        }
                        else
                        {
                            saffInfo.Update(_staffInfo);
                        }
                        WinInfoHelper.ShowInfoWindow(this, "保存信息成功！");
                        log.Error("保存人员信息成功！staff id="+_staffInfo.ID);
                    }
                    catch (Exception ex)
                    {
                        log.Error("保存人员信息异常11：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "保存信息失败！" + ex.Message);
                    }

                });
                waiting.Show(this);
            }
            catch (Exception ex)
            {
                log.Error("保存人员信息异常：", ex);
                WinInfoHelper.ShowInfoWindow(this, "保存信息失败！" + ex.Message);
            }
        }

        private byte[] GetPicImage(PictureBox picBox)
        {
            if (picBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.GetBuffer();
            }
            return null;
        }

        private void biClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStaffInfo_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            dtValidTimeStart.Value = DateTime.Now.AddYears(-10);
            dtValidTimeEnd.Value = DateTime.Now.AddYears(100);
            dtTimeIn.Value = DateTime.Now.AddYears(-100);
            dtTimeOut.Value = DateTime.Now.AddYears(100);

            LoadDeptsTree();

            if (_staffInfo == null)
            {
                this.Text = "注册人员";
            }
            else
            {
                this.Text = "修改人员信息";
                tbStaffName.Text = _staffInfo.REAL_NAME;
                try
                {
                    cboVerTypeStyle.SelectedValue = _staffInfo.STAFF_NO_TEMPLET;//证件编号模板
                }
                catch (Exception ex)
                {
                    log.Error("证件编号模板设置异常：", ex);
                }
                tbVerNo.Text = _staffInfo.STAFF_NO;
                cbSex.SelectedIndex = _staffInfo.SEX == null ? 0 : (int)_staffInfo.SEX;
                tbJob.Text = _staffInfo.JOB;
                dtBirthday.ValueObject = _staffInfo.BIRTHDAY;
                tbPublic.Text = _staffInfo.POLITICS;
                cbMarry.SelectedIndex = _staffInfo.MARRIED == null ? 0 : (int)_staffInfo.MARRIED;
                tbSkillLevel.Text = _staffInfo.SKIIL_LEVEL;
                tbPrivateVerName.Text = _staffInfo.CER_NAME;
                tbPrivateVerNo.Text = _staffInfo.CER_NO;
                tbCellPhone.Text = _staffInfo.CELL_PHONE;
                tbTelphone.Text = _staffInfo.TELE_PHONE;
                tbEmail.Text = _staffInfo.EMAIL;
                dtValidTimeStart.Value = _staffInfo.VALID_STARTTIME;
                dtValidTimeEnd.Value = _staffInfo.VALID_ENDTIME;
                tbAddress.Text = _staffInfo.ADDRESS;
                tbJiGuan.Text = _staffInfo.NATIVE;
                tbMinZu.Text = _staffInfo.NATION;
                tbZonJiao.Text = _staffInfo.RELIGION;
                tbXueLi.Text = _staffInfo.EDUCATIONAL;
                dtTimeIn.ValueObject = _staffInfo.ENTRY_TIME;
                dtTimeOut.ValueObject = _staffInfo.ABORT_TIME;
                try
                {
                    if (_staffInfo.PRINT_TEMPLET_ID!=null)
                    {
                        cboVeMoBan.SelectedValue = _staffInfo.PRINT_TEMPLET_ID;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("无此证件模板：" + _staffInfo.PRINT_TEMPLET_ID + ",ex=" + ex.Message);
                }
                SetPicImage(picPhoto, _staffInfo.PHOTO);
                SetPicImage(picVerFront, _staffInfo.CER_PHOTO_FRONT);
                SetPicImage(picVerBack, _staffInfo.CER_PHOTO_BACK);
            }
        }
        private void SetPicImage(PictureBox picBox, byte[] bts)
        {
            if (bts != null)
            {
                MemoryStream ms = new MemoryStream(bts);
                Image image = Image.FromStream(ms);
                if (picBox.Image != null)
                {
                    picBox.Image.Dispose();
                    picBox.Image = null;
                }
                picBox.Image = image;
            }
        }
        private void LoadDeptsTree()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        var depts = DeptDataHelper.GetDepts(true);
                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                this.cbTreeDept.Nodes.Clear();
                                var nodes = DeptDataHelper.ToTree(depts);
                                this.cbTreeDept.Nodes.AddRange(nodes.ToArray());
                                foreach (DevComponents.AdvTree.Node item in this.cbTreeDept.Nodes)
                                {
                                    item.Expand();
                                }
                            }
                            catch (Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "加载部门异常：" + ex.Message);
                            }
                        }));
                    }
                    catch (Exception exx)
                    {
                         
                    }
                }));
        }
    }
}
