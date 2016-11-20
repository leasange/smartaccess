using DevComponents.Editors;
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
            DoShowCardNum();
            _view = view;
        }

        private void biNew_Click(object sender, EventArgs e)
        {
            _staffInfo = null;
            _cardInfos.Clear();
            this.Text = "添加人员";
            Init(false);
        }

        private void DoSave(bool addprivate = false)
        {
            if (!CheckInput())
            {
                return;
            }
            InternalSave(addprivate);
        }

        private void InternalSave(bool addprivate,bool setcard=false)
        {
            try
            {
                if (_staffInfo == null || _staffInfo.ID == -1)
                {
                    _staffInfo = new Maticsoft.Model.SMT_STAFF_INFO();
                    _staffInfo.REG_TIME = DateTime.Now;
                    _staffInfo.ID = -1;
                }
                _staffInfo.REAL_NAME = tbStaffName.Text;
                if (cbTreeDept.SelectedNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO info = cbTreeDept.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (info != null)
                    {
                        _staffInfo.ORG_ID = info.ID;
                    }
                }

                try
                {
                    if (cboVerTypeStyle.SelectedItem!=null&&cboVerTypeStyle.SelectedIndex>0)
                    {
                        _staffInfo.STAFF_NO_TEMPLET = ((Maticsoft.Model.SMT_VER_FORMAT)(((ComboItem)(cboVerTypeStyle.SelectedItem)).Tag)).ID;
                    }
                    else _staffInfo.STAFF_NO_TEMPLET=-1;//证件编号模板
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
                _staffInfo.VALID_STARTTIME = dtValidTimeStart.Value.Date;
                _staffInfo.VALID_ENDTIME = new DateTime(dtValidTimeEnd.Value.Year, dtValidTimeEnd.Value.Month, dtValidTimeEnd.Value.Day, 23, 59, 59);
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
                    _staffInfo.ENTRY_TIME = dtTimeIn.Value.Date;
                }
                if (dtTimeOut.ValueObject == null)
                {
                    _staffInfo.ABORT_TIME = null;
                }
                else
                {
                    _staffInfo.ABORT_TIME = new DateTime(dtTimeOut.Value.Year, dtTimeOut.Value.Month, dtTimeOut.Value.Day, 23, 59, 59);
                }

                try
                {
                    _staffInfo.PRINT_TEMPLET_ID = cboVeMoBan.SelectedItem == null ? -1 : ((Maticsoft.Model.SMT_VERMODEL_INFO)(((ComboItem)cboVeMoBan.SelectedItem).Tag)).ID;
                }
                catch (Exception ex)
                {
                    log.Error("无此证件模板：" + _staffInfo.PRINT_TEMPLET_ID + ",ex=" + ex.Message);
                }
                if (picPhoto.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    Image newImage= CommonClass.Get2InchPhoto(picPhoto.Image);
                    if (newImage!=null)
                    {
                        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        newImage.Dispose();
                    }
                    else
                    {
                        picPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    _staffInfo.PHOTO = ms.GetBuffer();
                }
               // _staffInfo.PHOTO = GetPicImage(picPhoto);
                _staffInfo.CER_PHOTO_FRONT = null;
                _staffInfo.CER_PHOTO_BACK = null;
                _staffInfo.MODIFY_TIME = DateTime.Now;

                Maticsoft.BLL.SMT_STAFF_INFO saffInfoBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        List<Maticsoft.Model.SMT_STAFF_INFO> staffList = saffInfoBll.GetModelList("REAL_NAME='" + _staffInfo.REAL_NAME + "' and IS_DELETE=0");
                        if (staffList.Count > 0)
                        {
                            if (_staffInfo.ID == -1)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "保存失败，人员姓名已存在！");
                                return;
                            }
                            else
                            {
                                if (staffList[0].ID != _staffInfo.ID)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "保存失败，人员姓名已存在！");
                                    return;
                                }
                            }
                        }
                        if (_staffInfo.ID == -1)
                        {
                            if (Maticsoft.DBUtility.DbHelperSQL.Exists("select COUNT(*) from SMT_STAFF_INFO t where t.STAFF_NO='" + _staffInfo.STAFF_NO + "'"))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "编号为"+_staffInfo.STAFF_NO+"已存在！");
                                return;
                            }
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
                        bool bsetcardret = false;
                        if (setcard)
                        {
                            bsetcardret = DoSetCard();
                        }
                        if (_cardInfos != null && _cardInfos.Count > 0)
                        {
                            foreach (var item in _cardInfos)//生成卡片信息
                            {
                                Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                                Maticsoft.BLL.SMT_CARD_INFO bll = new Maticsoft.BLL.SMT_CARD_INFO();//卡
                                List<Maticsoft.Model.SMT_CARD_INFO> list = bll.GetModelList("CARD_NO='" + item.CARD_NO + "'");
                                if (list.Count > 0)
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

                        if (setcard)
                        {
                            if (bsetcardret)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "保存并发卡成功！");
                                log.Error("保存并发卡成功！staff id=" + _staffInfo.ID);
                                this.Invoke(new Action(() =>
                                {
                                    DoShowCardNum();
                                }));
                            }
                            else
                            {
                                WinInfoHelper.ShowInfoWindow(this, "发卡失败！");
                                log.Error("发卡失败！staff id=" + _staffInfo.ID);
                            }
                        }
                        else
                        {
                            if (setcard)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "保存信息成功！");
                                log.Info("保存人员信息成功！staff id=" + _staffInfo.ID);
                            }
                        }

                        if (addprivate)
                        {
                            if (_staffInfo != null)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    FrmAddOrModifyStaffPrivate frmStaffInfo = new FrmAddOrModifyStaffPrivate(_staffInfo);
                                    frmStaffInfo.ShowDialog(this);
                                }));
                            }
                        }
                        else if (!setcard)
                        {
                            this.BeginInvoke(new Action(() =>
                                {
                                    WinInfoHelper.ShowInfoWindow(FrmMain.Instance, "保存信息成功！");
                                    log.Info("保存人员信息成功！staff id=" + _staffInfo.ID);
                                    this.Close();
                                }));
                        }
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

        private void DoShowCardNum()
        {
            if (_cardInfos==null||_cardInfos.Count==0)
            {
                tbCardNums.Text = "未发卡";
            }
            else
            {
                string str = "";
                foreach (var item in _cardInfos)
                {
                    str += item.CARD_NO + "；";
                }
                str = str.TrimEnd('；');
                tbCardNums.Text = str;
            }
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            DoSave(false);
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
            if (tbVerNo.Text.Trim()=="")
            {
                WinInfoHelper.ShowInfoWindow(this, "编码不能为空！");
                tbVerNo.Focus();
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

        private void LoadModels()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                try
                {
                    Maticsoft.BLL.SMT_VERMODEL_INFO bll = new Maticsoft.BLL.SMT_VERMODEL_INFO();
                    var models= bll.GetModelList("");
                    Maticsoft.BLL.SMT_VER_FORMAT verBll = new Maticsoft.BLL.SMT_VER_FORMAT();
                    var verModels = verBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            cboVeMoBan.Items.Clear();
                            decimal id = -1;
                            if (_staffInfo != null && _staffInfo.PRINT_TEMPLET_ID != null)
                            {
                                id = (decimal)_staffInfo.PRINT_TEMPLET_ID;
                            }

                            foreach (var item in models)
                            {
                                ComboItem ci = new ComboItem(item.VERM_NAME);
                                ci.Tag = item;
                                cboVeMoBan.Items.Add(ci);
                                if (id==item.ID)
                                {
                                    cboVeMoBan.SelectedItem = ci;
                                }
                            }

                            cboVerTypeStyle.Items.Clear();
                            cboVerTypeStyle.Items.Add(new ComboItem("--无--"));
                            cboVerTypeStyle.SelectedIndex = 0;
                            foreach (var item in verModels)
                            {
                                ComboItem cbi = new ComboItem(item.VER_NAME);
                                cbi.Tag = item;
                                cboVerTypeStyle.Items.Add(cbi);
                                if (_staffInfo!=null&&_staffInfo.STAFF_NO_TEMPLET!=null)
                                {
                                    if (item.ID==_staffInfo.STAFF_NO_TEMPLET)
                                    {
                                        cboVerTypeStyle.SelectedItem = cbi;
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "加载信息异常：" + ex.Message);
                        }
                    }));
                }
                catch (Exception exx)
                {

                }
            }));
        }

        private void Init(bool loadDept = true)
        {
            dtValidTimeStart.Value = DateTime.Now.Date;
            dtValidTimeEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            dtTimeIn.ValueObject = null;
            dtTimeOut.ValueObject = null;
            LoadModels();
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
                    lbPhotoTip.Visible = true;
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
                    biNew.Visible = false;
                    btnSetCard.Visible = false;
                    btnSave.Visible = false;
                    btnSaveAndUpload.Visible = false;
                    btnSelectPic.Visible = false;
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

                if (_view)
                {
                    cbSex.Enabled = false;
                    cbMarry.Enabled = false;
                    dtBirthday.Enabled = false;
                    dtValidTimeStart.Enabled = false;
                    dtValidTimeEnd.Enabled = false;
                    dtTimeIn.Enabled = false;
                    dtTimeOut.Enabled = false;
                }

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
                lbPhotoTip.Visible = picPhoto.Image == null;
            }
        }
        private void SetPicImage(PictureBox picBox, byte[] bts)
        {
            if (bts != null && bts.Length>0)
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
                                       ShowSimplePreview();
                                   }
                                }
                                if (_view)
                                {
                                    cbTreeDept.Enabled = false;
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

        private bool DoSetCard()
        {
            using (ICardIssueDevice issDevice = new MF800ACardIssueDevice())
            {
                CardIssueConfig config = SysConfig.GetCardIssueConfig();
                try
                {
                    issDevice.OpenCom(config.comPort, config.comBuad);
                    string num = issDevice.ReadCardX();
                    issDevice.Close();
                    if (num == null)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "未读取到卡号！");
                        return false;
                    }
                    else
                    {
                        Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                        var cards = sbll.GetModelListByCardNo(num);
                        if (cards.Count > 0)
                        {
                            bool delete = false;
                            this.Invoke(new Action(() =>
                            {
                                if (MessageBox.Show("该卡已绑定人员，是否强制解绑？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    delete = true;
                                }
                            }));
                            if (delete)
                            {
                                string errMsg = "";
                                bool ret = UploadPrivate.DeletePrivateByCardNum(num, out errMsg, cards);
                                if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "卡片解绑异常：" + errMsg);
                                    return false;
                                }
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
                                    cardInfo.CARD_WG_NO = DataHelper.ToWGAccessCardNo(num);
                                    _cardInfos.Add(cardInfo);
                                }
                                //WinInfoHelper.ShowInfoWindow(this, "发卡成功。");
                                return true;
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
                                cardInfo.CARD_WG_NO = DataHelper.ToWGAccessCardNo(num);
                                _cardInfos.Add(cardInfo);
                            }
                            //WinInfoHelper.ShowInfoWindow(this, "发卡成功。");
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("发卡器操作异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "读卡失败：" + ex.Message);
                    return false;
                }
                return false;
            }
        }

        private void biSetPrivate_Click(object sender, EventArgs e)
        {
            DoSave(true);
        }

        private void biSelectPic_Click(object sender, EventArgs e)
        {
            FrmGetPicture frmGetPic = new FrmGetPicture();
            frmGetPic.SelectImage = picPhoto.Image;
            if(frmGetPic.ShowDialog(this)==DialogResult.OK)
            {
                if (frmGetPic.HasChanged)
                {
                    if (picPhoto.Image!=null)
                    {
                        picPhoto.Image.Dispose();
                        picPhoto.Image = null;
                    }
                    picPhoto.Image = (Image)frmGetPic.SelectImage.Clone();
                }
            }
            lbPhotoTip.Visible = picPhoto.Image == null;
            frmGetPic.SelectImage = null;
        }

        private void FrmStaffInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( picPhoto.Image!=null)
            {
                picPhoto.Image.Dispose();
                picPhoto.Image = null;
            }
        }

        private void picPhoto_DoubleClick(object sender, EventArgs e)
        {
            biSelectPic_Click(sender, e);
        }

        private void btnSetCard_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            InternalSave(false, true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave(false);
        }

        private void btnSaveAndUpload_Click(object sender, EventArgs e)
        {
            DoSave(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private FastReport.Report _report = null;
        private void cboVeMoBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSimplePreview();
        }

        private bool LoadReportData(FastReport.Report report)
        {
            ComboItem item = cboVeMoBan.SelectedItem as ComboItem;
            if (item == null)
            {
                return false;
            }
            Maticsoft.Model.SMT_VERMODEL_INFO model = item.Tag as Maticsoft.Model.SMT_VERMODEL_INFO;
            if (model == null)
            {
                return false;
            }
            MemoryStream ms = new MemoryStream(model.VERM_CONTENT);
            report.Load(ms);
            string deptName = "";
            string deptNo = "";
            if (cbTreeDept.SelectedNode != null)
            {
                Maticsoft.Model.SMT_ORG_INFO org = cbTreeDept.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                if (org != null)
                {
                    deptName = org.ORG_NAME;
                    deptNo = org.ORG_CODE;
                }
                else if (_staffInfo != null)
                {
                    deptName = _staffInfo.ORG_NAME;
                    deptNo = _staffInfo.ORG_CODE;
                }
            }
            string sex = "未知";
            if (cbSex.SelectedIndex==1)
            {
                sex = "男";
            }
            else if (cbSex.SelectedIndex==2)
            {
                sex = "女";
            }
            string marry = "未知";
            if (cbMarry.SelectedIndex == 1)
            {
                marry = "已婚";
            }
            else if (cbMarry.SelectedIndex == 2)
            {
                marry = "未婚";
            }
            var dt = StaffDataHelper.GetReportDataTable(
                deptName,
                deptNo,
                tbVerNo.Text.Trim(),
                tbStaffName.Text.Trim(),
                sex,
                tbJob.Text.Trim(),
                dtBirthday.Value.Date,
                tbPublic.Text.Trim(),
                marry,
                tbSkillLevel.Text.Trim(),
                tbPrivateVerName.Text.Trim(),
                tbPrivateVerNo.Text.Trim(),
                tbTelphone.Text.Trim(),
                tbCellPhone.Text.Trim(),
                tbJiGuan.Text.Trim(),
                tbMinZu.Text.Trim(),
                tbZonJiao.Text.Trim(),
                tbXueLi.Text.Trim(),
                tbEmail.Text.Trim(),
                dtValidTimeStart.Value.Date,
                dtValidTimeEnd.Value.Date.Add(new TimeSpan(23, 59, 59)),
                dtTimeIn.Value.Date,
                dtTimeOut.Value.Date,
                tbAddress.Text.Trim(),
                picPhoto.Image,
                _staffInfo != null ? _staffInfo.REG_TIME : DateTime.Now
                );
            report.RegisterData(dt, dt.TableName);
            //ModelMgr.VerModelMgr.BindingDataSet(_report);
            ms.Dispose();
            return true;
        }

        private void ShowSimplePreview()
        {
            try
            {
                if (_report == null)
                {
                    _report = new FastReport.Report();
                    _report.Preview = previewControl;
                }
                if (LoadReportData(_report))
                {
                    _report.Prepare();
                    _report.ShowPrepared();
                }
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "预览证件异常：" + ex.Message);
                log.Error("预览证件异常：", ex);
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowSimplePreview();
        }

        private void biPreView_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (LoadReportData(report))
            {
                report.Prepare();
                report.ShowPrepared();
            }
        }

        private void biPrint_Click(object sender, EventArgs e)
        {
            ShowSimplePreview();
            this.BeginInvoke(new Action(() =>
                {
                    previewControl.Print();
                }));
        }

        private void cboVerTypeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVerTypeStyle.SelectedItem != null && cboVerTypeStyle.SelectedIndex > 0)
            {
                ComboItem item = (ComboItem)cboVerTypeStyle.SelectedItem;
                Maticsoft.Model.SMT_VER_FORMAT verModel = (Maticsoft.Model.SMT_VER_FORMAT)item.Tag;
                tbVerNo.VerTextFormat = verModel.VER_FORMAT;
            }
        }
    }
}
