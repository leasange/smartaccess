using DevComponents.Editors;
using Li.Access.Core;
using Li.Access.Core.BJTWHCardIssue;
using Li.Controls;
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

                if (cbStaffType.SelectedItem==null)
                {
                    _staffInfo.STAFF_TYPE = "";
                }
                else
                {
                    _staffInfo.STAFF_TYPE = Convert.ToString(((ComboItem)cbStaffType.SelectedItem).Tag);
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
                    _staffInfo.PHOTO = (byte[])ms.GetBuffer().Clone();
                    ms.Dispose();
                }
                _staffInfo.CER_PHOTO_FRONT = null;
                _staffInfo.CER_PHOTO_BACK = null;
                _staffInfo.MODIFY_TIME = DateTime.Now;

                Maticsoft.BLL.SMT_STAFF_INFO saffInfoBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        /*List<Maticsoft.Model.SMT_STAFF_INFO> staffList = saffInfoBll.GetModelList("REAL_NAME='" + _staffInfo.REAL_NAME + "' and IS_DELETE=0");
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
                        }*/
                        string strWhere = "";
                        if (_staffInfo.ID==-1)
                        {
                            strWhere = "STAFF_NO='" + _staffInfo.STAFF_NO + "' and IS_DELETE=0";
                        }
                        else
                        {
                            strWhere = "STAFF_NO='" + _staffInfo.STAFF_NO + "' and IS_DELETE=0 and ID !="+_staffInfo.ID;
                        }
                        if (Maticsoft.DBUtility.DbHelperSQL.Exists("select COUNT(*) from SMT_STAFF_INFO t where " + strWhere))
                        {
                            WinInfoHelper.ShowInfoWindow(this, "编号为" + _staffInfo.STAFF_NO + "的员工已存在！");
                            return;
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
            if (!UserInfoHelper.IsManager)
            {
                if (cbTreeDept.SelectedNode == null)
                {
                    WinInfoHelper.ShowInfoWindow(this, "部门必须选择！");
                    cbTreeDept.Focus();
                    return false;
                }
                if (cbTreeDept.SelectedNode.DataKey=="0")
                {
                    WinInfoHelper.ShowInfoWindow(this, "不可选部门，请选择授权的部门！");
                    cbTreeDept.Focus();
                    return false;
                }
            }
            return true;
        }

        private byte[] GetPicImage(PictureBox picBox)
        {
            if (picBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var bts= (byte[])ms.GetBuffer().Clone();
                ms.Dispose();
                return bts;
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
        private static decimal? lastTempId = null;
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
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "加载信息异常-模板信息：" + ex.Message);
                            log.Error("加载信息异常0：", ex);
                        }
                        try
                        {
                            cboVerTypeStyle.Items.Clear();
                            cboVerTypeStyle.Items.Add(new ComboItem("--无--"));
                            cboVerTypeStyle.SelectedIndex = 0;
                            foreach (var item in verModels)
                            {
                                ComboItem cbi = new ComboItem(item.VER_NAME);
                                cbi.Tag = item;
                                cboVerTypeStyle.Items.Add(cbi);
                                if (_staffInfo != null && _staffInfo.STAFF_NO_TEMPLET != null)
                                {
                                    if (item.ID == _staffInfo.STAFF_NO_TEMPLET)
                                    {
                                        cboVerTypeStyle.SelectedItem = cbi;
                                    }
                                }
                                else if (lastTempId != null && _staffInfo == null)
                                {
                                    if (item.ID == lastTempId)
                                    {
                                        cboVerTypeStyle.SelectedItem = cbi;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "加载信息异常-编码格式信息：" + ex.Message);
                            log.Error("加载信息异常0：", ex);
                        }
                    }));
                }
                catch (Exception exx)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载信息异常1：" + exx.Message);
                    log.Error("加载信息异常1：", exx);
                }
            }));
        }

        private void Init(bool loadDept = true)
        {
            dtValidTimeStart.Value = DateTime.Now.Date;
            dtValidTimeEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            dtTimeIn.ValueObject = null;
            dtTimeOut.ValueObject = null;
            if (loadDept)
            {
                LoadModels();
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
                    btnEditor.Visible = false;
                    picPhoto.DoubleClick -= picPhoto_DoubleClick;
                }
                else
                {
                    this.Text = "修改人员信息：" + _staffInfo.REAL_NAME;
                    btnAutoCreate.Visible = true;
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

            if (loadDept)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                        var staffTypes = dicBll.GetModelList("DATA_TYPE='STAFF_TYPE'");
                        if (staffTypes.Count > 0)
                        {
                            this.Invoke(new Action(() =>
                            {
                                cbStaffType.Items.Clear();
                                foreach (var item in staffTypes)
                                {
                                    ComboItem ci = new ComboItem(item.DATA_NAME);
                                    ci.Tag = item.DATA_KEY;
                                    cbStaffType.Items.Add(ci);
                                    if (_staffInfo != null)
                                    {
                                        if (_staffInfo.STAFF_TYPE == item.DATA_KEY)
                                        {
                                            cbStaffType.SelectedItem = ci;
                                        }
                                    }
                                    else
                                    {
                                        if (item.DATA_NAME == "内部员工")
                                        {
                                            cbStaffType.SelectedItem = ci;
                                        }
                                    }
                                    if (cbStaffType.SelectedIndex == -1)
                                    {
                                        if (cbStaffType.Items.Count > 0)
                                        {
                                            cbStaffType.SelectedIndex = 0;
                                        }
                                    }
                                }
                            }));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "加载员工类型异常：" + ex.Message);
                        log.Error("加载员工类型异常：", ex);
                    }

                }));
            }
        }
        private void SetPicImage(PictureBox picBox, byte[] bts)
        {
            if (bts != null && bts.Length>0)
            {
                MemoryStream ms = new MemoryStream(bts);
                Image image = Image.FromStream(ms);
                Bitmap bitmap = new Bitmap(image.Width,image.Height);
                Graphics g=Graphics.FromImage(bitmap);
                g.DrawImage(image, 0, 0,image.Width,image.Height);
                g.Dispose();
                image.Dispose();
                ms.Dispose();
                if (picBox.Image != null)
                {
                    picBox.Image.Dispose();
                    picBox.Image = null;
                }
                picBox.Image = bitmap;
               
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
                                log.Error("加载部门异常：", ex);
                            }
                        }));
                    }
                    catch (Exception exx)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "加载部门异常1：" + exx.Message);
                        log.Error("加载部门异常1：", exx);
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
            try
            {
                string num;
                string wgNum;
                string errorMsg;
                if (!CardIssueDeviceHelper.ReadCard(out num, out wgNum, out errorMsg))
                {
                    WinInfoHelper.ShowInfoWindow(this, "读取卡号失败：" + errorMsg);
                    return false;
                }

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
                            cardInfo.CARD_WG_NO = wgNum;
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
                        cardInfo.CARD_WG_NO = wgNum;
                        _cardInfos.Add(cardInfo);
                    }
                    return true;
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
                    HasChanged = true;
                }
            }
            lbPhotoTip.Visible = picPhoto.Image == null;
            frmGetPic.SelectImage = null;
        }

        private void FrmStaffInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _memoryReport.Close();
            _memoryReport.Dispose();
            _memoryReport = null;

            this.cbTreeDept.Nodes.Clear();
            this.cboVeMoBan.Items.Clear();
            _staffInfo = null;

            if ( picPhoto.Image!=null)
            {
                picPhoto.Image.Dispose();
                picPhoto.Image = null;
            }
            if (_report!=null)
            {
                _report.Clear();
                _report.Preview = null;
                _report.Dispose();
                _report = null;
            }

            previewControl.Clear();
            this.Controls.Remove(this.previewControl);
            this.previewControl.Dispose();
            this.previewControl = null;

            GC.Collect();
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
        private MemoryStream _memoryReport = new MemoryStream();
        private bool LoadReportData(FastReport.Report report)
        {
            report.Clear();
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
            //MemoryStream ms = new MemoryStream();
            try
            {
                _memoryReport.SetLength(0);
                _memoryReport.Write(model.VERM_CONTENT, 0, model.VERM_CONTENT.Length);
                _memoryReport.Seek(0, SeekOrigin.Begin);
                //_memoryReport = new MemoryStream(model.VERM_CONTENT);
                report.Load(_memoryReport);
                string deptName = "";
                string deptNo = "";
                string upDeptName = "";
                string upupDeptName = "";
                string topDeptName = "";
                decimal deptId = -1;
                if (cbTreeDept.SelectedNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO org = cbTreeDept.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (org != null)
                    {
                        deptName = org.ORG_NAME;
                        deptNo = org.ORG_CODE;
                        deptId = org.ID;
                    }
                    else if (_staffInfo != null)
                    {
                        deptId = _staffInfo.ORG_ID != null ? (decimal)_staffInfo.ORG_ID : -1;
                        deptName = _staffInfo.ORG_NAME;
                        deptNo = _staffInfo.ORG_CODE;
                    }
                }

                if (deptId >= 0)
                {
                    var list = DeptDataHelper.FindAllParent(deptId);
                    if (list.Count > 0)
                    {
                        upDeptName = list[0].ORG_NAME;
                        if (list.Count > 1)
                        {
                            upupDeptName = list[1].ORG_NAME;
                        }
                        topDeptName = list[list.Count - 1].ORG_NAME;
                    }
                }

                string sex = "未知";
                if (cbSex.SelectedIndex == 1)
                {
                    sex = "男";
                }
                else if (cbSex.SelectedIndex == 2)
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
                    _staffInfo != null ? _staffInfo.REG_TIME : DateTime.Now,
                    upDeptName,
                    upupDeptName,
                    topDeptName
                    );
                report.RegisterData(dt, dt.TableName);
            }
            catch (Exception ex)
            {
                log.Error("load report", ex);
            }
           // ms.Dispose();
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
                _report.Clear();
                previewControl.Clear();
                if (LoadReportData(_report))
                {
                    _report.Prepare();
                    _report.ShowPrepared();
                }
            }
            catch (OutOfMemoryException ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "预览证件异常：" + ex.Message);
                log.Error("预览证件异常：", ex);
                MessageBox.Show("软件发生不可恢复异常，需要重启，请确定后重启！");
                Application.Restart();
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
            report.Clear();
            report.Dispose();
        }

        private void biPrint_Click(object sender, EventArgs e)
        {
            //ShowSimplePreview();
            if (_report!=null)
            {
                this.BeginInvoke(new Action(() =>
                {
                    previewControl.Print();
                }));
            }

        }

        private void cboVerTypeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVerTypeStyle.SelectedItem != null && cboVerTypeStyle.SelectedIndex > 0)
            {
                ComboItem item = (ComboItem)cboVerTypeStyle.SelectedItem;
                Maticsoft.Model.SMT_VER_FORMAT verModel = (Maticsoft.Model.SMT_VER_FORMAT)item.Tag;
                tbVerNo.VerTextFormat = verModel.VER_FORMAT;
                lastTempId = verModel.ID;
                if (_staffInfo==null||_staffInfo.ID==-1)
                {
                    DoCreateNo();
                }
            }
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            if (picPhoto.Image==null)
            {
                return;
            }
            FrmImageEditor frmEditor = new FrmImageEditor();
            frmEditor.LoadImage((Bitmap)picPhoto.Image);
            if (frmEditor.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bitmap = frmEditor.ResultImage;
                if (bitmap != null)
                {
                    bitmap = (Bitmap)frmEditor.ResultImage.Clone();
                }
                picPhoto.Image = bitmap;
                HasChanged = true;
            }
        }

        private void DoCreateNo()
        {
            if (cboVerTypeStyle.SelectedItem != null && cboVerTypeStyle.SelectedIndex > 0)
            {
                var fmt = (Maticsoft.Model.SMT_VER_FORMAT)(((ComboItem)(cboVerTypeStyle.SelectedItem)).Tag);

                string str = fmt.VER_FORMAT;
                int index = -1;
                for (int i = str.Length - 3; i >= 0; i -= 3)
                {
                    string temp = str.Substring(i, 3);
                    if (temp == "[0]" || temp == "[n]" || temp == "[N]")
                    {
                        index = i;
                    }
                    else
                    {
                        break;
                    }
                }
                if (index == -1)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择尾部为数字类型的编码格式！");
                    return;
                }

                int cnt = (str.Length - index) / 3;

                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        var dt = Maticsoft.DBUtility.DbHelperSQL.Query("select STAFF_NO from SMT_STAFF_INFO where STAFF_NO_TEMPLET=" + fmt.ID).Tables[0];
                        List<string> nos = new List<string>();
                        List<decimal> decs = new List<decimal>();
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[0] == null)
                            {
                                continue;
                            }
                            string s = Convert.ToString(r[0]);
                            if (string.IsNullOrWhiteSpace(s))
                            {
                                continue;
                            }
                            decimal result;
                            try
                            {
                                string strnum = s.Substring(s.Length - cnt);
                                if (decimal.TryParse(strnum, out result))
                                {
                                    nos.Add(s);
                                    decs.Add(result);
                                }
                            }
                            catch (Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "系统存在编号错误：编号为 " + s+"，请修正此人员编号错误。");
                                log.Error("系统存在编号错误：编号为 " + s, ex);
                            }

                        }
                        decimal d = -1;
                        if (decs.Count == 0)//无合肥有效数据
                        {
                            d = 1;
                        }
                        else
                        {
                            decimal min = decs.Min();
                            decimal max = decs.Max();

                            for (decimal i = min + 1; i < max; i++)
                            {
                                if (!decs.Contains(i))
                                {
                                    d = i;
                                    break;
                                }
                            }
                            if (d == -1)
                            {
                                d = max + 1;
                            }
                        }
                        string ss = "";
                        for (int i = 0; i < cnt; i++)
                        {
                            ss += "0";
                        }
                        var nums = d.ToString(ss);
                        //var nums=  string.Format("{0:D"+cnt+"}", d);
                        string tno = nums;
                        if (nos.Count > 0)
                        {
                            tno = nos[0].Substring(0, nos[0].Length - cnt) + nums;
                        }
                        else
                        {
                            tno = tbVerNo.DefaultText;
                        }
                        this.Invoke(new Action(() =>
                        {
                            tbVerNo.Text = tno;
                        }));
                    }
                    catch (System.Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "生成编号异常：" + ex.Message);
                        log.Error("生成编号异常：", ex);
                    }

                });
                waiting.Show(this);

            }
            else
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择尾部为数字类型的编码格式！");
                return;
            }
        }

        private void btnAutoCreate_Click(object sender, EventArgs e)
        {
            DoCreateNo();
        }
    }
}
