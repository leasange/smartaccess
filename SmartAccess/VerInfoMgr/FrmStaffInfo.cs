using Li.Access.Core;
using Li.Access.Core.BJTWHCardIssue;
using SmartAccess.Common.Config;
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
        public Maticsoft.Model.SMT_STAFF_INFO StaffInfo
        {
            get { return _staffInfo; }
        }
        private List<Maticsoft.Model.SMT_CARD_INFO> _cardInfos = new List<Maticsoft.Model.SMT_CARD_INFO>();
        public bool HasChanged = false;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmStaffInfo));
        private bool _view = false;
        public FrmStaffInfo()
        {
            InitializeComponent();
        }
        public FrmStaffInfo(Maticsoft.Model.SMT_STAFF_INFO staffInfo,bool view=false)
        {
            InitializeComponent();
            _staffInfo = staffInfo;
            if (_staffInfo.CARDS!=null)
            {
                _cardInfos.AddRange(_staffInfo.CARDS);
            }

            _view = view;
        }

        private void biNew_Click(object sender, EventArgs e)
        {
            _staffInfo = null;
            _cardInfos.Clear();
            this.Text = "添加人员";
            Init(false);
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!CheckInput())
                {
                    return;
                }
                if (_staffInfo == null || _staffInfo.ID==-1)
                {
                    _staffInfo = new Maticsoft.Model.SMT_STAFF_INFO();
                    _staffInfo.REG_TIME = DateTime.Now;
                    _staffInfo.ID = -1;
                }
                _staffInfo.REAL_NAME = tbStaffName.Text;
                if (cbTreeDept.SelectedNode!=null)
                {
                    Maticsoft.Model.SMT_ORG_INFO info = cbTreeDept.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (info!=null)
                    {
                        _staffInfo.ORG_ID = info.ID;
                    }
                }
                
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

                Maticsoft.BLL.SMT_STAFF_INFO saffInfoBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        List<Maticsoft.Model.SMT_STAFF_INFO> staffList= saffInfoBll.GetModelList("REAL_NAME='" + _staffInfo.REAL_NAME + "' and IS_DELETE=0");
                        if (staffList.Count>0)
                        {
                            if (_staffInfo.ID==-1)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "保存失败，人员姓名已存在！");
                                return;
                            }
                            else
                            {
                                if(staffList[0].ID != _staffInfo.ID)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "保存失败，人员姓名已存在！");
                                    return;
                                }
                            }
                        }
                        if (_staffInfo.ID == -1)
                        {
                            _staffInfo.ID = saffInfoBll.Add(_staffInfo);
                        }
                        else
                        {
                            saffInfoBll.Update(_staffInfo);
                        }
                        this.Invoke(new Action(() =>
                            {
                                this.Text = "修改人员：" + _staffInfo.REAL_NAME;
                            }));
                        HasChanged = true;
                        if (_cardInfos!=null&&_cardInfos.Count>0)
                        {
                            foreach (var item in _cardInfos)//生成卡片信息
                            {
                                Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                                Maticsoft.BLL.SMT_CARD_INFO bll = new Maticsoft.BLL.SMT_CARD_INFO();//卡
                                List<Maticsoft.Model.SMT_CARD_INFO> list = bll.GetModelList("CARD_NO='" + item.CARD_NO + "'");
                                if (list.Count>0)
                                {
                                    item.ID = list[0].ID;
                                }
                                else
                                {
                                    item.ID = bll.Add(item);
                                }
                                if (!sbll.Exists(_staffInfo.ID, item.ID))
                                {
                                    sbll.Add(new Maticsoft.Model.SMT_STAFF_CARD() { STAFF_ID = _staffInfo.ID, CARD_ID = item.ID, ACCESS_STARTTIME = DateTime.Parse("2016-01-01 00:00:00"), ACCESS_ENDTIME = DateTime.Parse("2099-01-01 00:00:00") });
                                }
                            }
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
        //检测输入有效性
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(tbStaffName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "人员名称不能为空！");
                tbStaffName.Focus();
                return false;
            }
            return true;
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

        private void Init(bool loadDept = true)
        {
            dtValidTimeStart.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtValidTimeEnd.Value = DateTime.Parse("2099-01-01 00:00:00");
            dtTimeIn.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtTimeOut.Value = DateTime.Parse("2099-01-01 00:00:00");

            if (loadDept)
            {
                LoadDeptsTree();
            }


            if (_staffInfo == null)
            {
                this.Text = "添加人员";
                tbStaffName.Text = "";
                tbVerNo.Text = "";
                tbJob.Text = "";
                dtBirthday.ValueObject = null;
                tbPublic.Text = null;
                cbMarry.SelectedIndex = 0;
                tbSkillLevel.Text = "";
                tbPrivateVerName.Text = "";
                tbPrivateVerNo.Text = "";
                tbCellPhone.Text = "";
                tbTelphone.Text = "";
                tbEmail.Text = "";
                tbAddress.Text = "";
                tbJiGuan.Text = "";
                tbMinZu.Text = "";
                tbZonJiao.Text = "";
                tbXueLi.Text = "";
                if (picPhoto.Image != null)
                {
                    picPhoto.Image.Dispose();
                    picPhoto.Image = null;
                }
                if (picVerFront.Image != null)
                {
                    picVerFront.Image.Dispose();
                    picVerFront.Image = null;
                }
                if (picVerBack.Image != null)
                {
                    picVerBack.Image.Dispose();
                    picVerBack.Image = null;
                }
            }
            else
            {
                if (_view)
                {
                    this.Text = "查看人员信息：" + _staffInfo.REAL_NAME;
                    foreach (Control item in this.Controls)
                    {
                        if (item is DevComponents.DotNetBar.Controls.TextBoxX)
                        {
                            ((DevComponents.DotNetBar.Controls.TextBoxX)item).ReadOnly = true;
                        }
                    }
                    bar1.Enabled = false;
                    picPhoto.DoubleClick -= picPhoto_DoubleClick;
                }
                else
                {
                    this.Text = "修改人员信息：" + _staffInfo.REAL_NAME;
                }
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
                    if (_staffInfo.PRINT_TEMPLET_ID != null)
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
                                if (_staffInfo!=null&&_staffInfo.ORG_ID!=null)
                                {
                                   var node=  FindNode((decimal)_staffInfo.ORG_ID);
                                   
                                   if (node!=null)
                                   {
                                       cbTreeDept.SelectedNode = node;
                                       node.EnsureVisible();
                                   }
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

        public DevComponents.AdvTree.Node FindNode(decimal id)
        {
            return DoFindNode(cbTreeDept.Nodes, id);
        }
        private DevComponents.AdvTree.Node DoFindNode(DevComponents.AdvTree.NodeCollection nodes, decimal id)
        {
            foreach (DevComponents.AdvTree.Node item in nodes)
            {
                var dept = (Maticsoft.Model.SMT_ORG_INFO)item.Tag;
                if (dept.ID == id)
                {
                    return item;
                }
                else
                {
                    var nn = DoFindNode(item.Nodes, id);
                    if (nn != null)
                    {
                        return nn;
                    }
                }
            }
            return null;
        }

        private void biSetCard_Click(object sender, EventArgs e)
        {
            ICardIssueDevice issDevice = new MF800ACardIssueDevice();
            DevMF800AConfig config= SysConfig.GetDevMF800AConfig();
            try
            {
                issDevice.OpenCom(config.comPort, config.comBuad);
                string num = issDevice.ReadCardX();
                issDevice.Close();
                if (num==null)
                {
                    WinInfoHelper.ShowInfoWindow(this, "未读取到卡号！");
                }
                else
                {
                    
                    CtrlWaiting ctrWaiting = new CtrlWaiting(() =>
                    {
                         Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                         var cards= sbll.GetModelListByCardNo(num);
                         if (cards.Count>0)
                         {
                             bool delete = false;
                             this.Invoke(new Action(() =>
                                 {
                                     if (MessageBox.Show("该卡已绑定人员，是否强制解绑？","提示",MessageBoxButtons.YesNo)== DialogResult.Yes)
                                     {
                                         delete = true;
                                     }
                                 }));
                             if (delete)
                             {
                                 HasChanged = true;
                                 foreach (var item in cards)
                                 {
                                     sbll.Delete(item.STAFF_ID, item.CARD_ID);
                                 }
                                 if (!_cardInfos.Exists(m => m.CARD_NO == num))
                                 {
                                     Maticsoft.Model.SMT_CARD_INFO cardInfo = new Maticsoft.Model.SMT_CARD_INFO();
                                     cardInfo.CARD_NO = num;
                                     cardInfo.CARD_TYPE = 0;
                                     cardInfo.CARD_DESC = num;
                                     _cardInfos.Add(cardInfo);
                                 }
                                 WinInfoHelper.ShowInfoWindow(this, "发卡成功！注意保存。");
                             }
                         }
                         else
                         {
                             if (!_cardInfos.Exists(m => m.CARD_NO == num))
                             {
                                 Maticsoft.Model.SMT_CARD_INFO cardInfo = new Maticsoft.Model.SMT_CARD_INFO();
                                 cardInfo.CARD_NO = num;
                                 cardInfo.CARD_TYPE = 0;
                                 cardInfo.CARD_DESC = num;
                                 _cardInfos.Add(cardInfo);
                             }
                             WinInfoHelper.ShowInfoWindow(this, "发卡成功！注意保存。");
                         }
                    });
                    ctrWaiting.Show(this);
                }
            }
            catch (Exception ex)
            {
                log.Error("发卡器操作异常：", ex);
                WinInfoHelper.ShowInfoWindow(this, "读卡失败：" + ex.Message);
            }
        }

        private void biSetPrivate_Click(object sender, EventArgs e)
        {

        }

        private void biSelectPic_Click(object sender, EventArgs e)
        {
            FrmGetPicture frmGetPic = new FrmGetPicture();
            frmGetPic.SelectImage = picPhoto.Image;
            frmGetPic.ShowDialog(this);
            if (frmGetPic.HasChanged)
            {
                picPhoto.Image = frmGetPic.SelectImage;
            }
        }

        private void FrmStaffInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( picPhoto.Image!=null)
            {
                picPhoto.Image.Dispose();
                picPhoto.Image = null;
            }
            if (picVerFront.Image != null)
            {
                picVerFront.Image.Dispose();
                picVerFront.Image = null;
            }
            if (picVerBack.Image != null)
            {
                picVerBack.Image.Dispose();
                picVerFront.Image = null;
            }
        }

        private void picPhoto_DoubleClick(object sender, EventArgs e)
        {
            biSelectPic_Click(sender, e);
        }

    }
}
