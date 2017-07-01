using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ControlDevMgr
{
    public partial class FrmAddOrModifyCtrlr : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_CONTROLLER_INFO _ctrlr;
        public Maticsoft.Model.SMT_CONTROLLER_INFO Controller
        {
            get { return _ctrlr; }
            set { _ctrlr = value; }
        }
        private ControllerDoorType? _lastType = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddOrModifyCtrlr));
        public FrmAddOrModifyCtrlr()
        {
            InitializeComponent();
        }

        public FrmAddOrModifyCtrlr(Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr)
        {
            InitializeComponent();
            this._ctrlr = ctrlr;
            if (this._ctrlr!=null)
            {
                this.Text = "修改控制器";
            }
            else
            {
                this.Text = "添加控制器";
            }
        }

        private void FrmAddOrModifyCtrlr_Load(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItemBase;
            if (_ctrlr != null)
            {
                tbCtrlName.Text = _ctrlr.NAME;
                tbCtrlrSn.Text = _ctrlr.SN_NO;
                cbCtrlrEnable.Checked = _ctrlr.IS_ENABLE;
                ipCtrlr.Value = _ctrlr.IP;
                ipCtrlr.Enabled = false;
                iiPort.Value = _ctrlr.PORT == null ? 60000 : (int)_ctrlr.PORT;
                tbDesc.Text = _ctrlr.CTRLR_DESC;
                if ((tbCtrlrSn.Text.Trim().Length == 0) || (_ctrlr.CTRLR_MODEL != "WGACCESS"))
                {
                    if (_ctrlr.CTRLR_TYPE == null)
                    {
                        SetAccessExAttribute(ControllerDoorType.TwoDoorsTwoDirections);
                    }
                    else
                    {
                        ControllerDoorType type = ControllerDoorType.TwoDoorsTwoDirections;
                        Enum.TryParse<ControllerDoorType>(_ctrlr.CTRLR_TYPE.ToString(), out type);
                        if (type== ControllerDoorType.Elevator)
                        {
                            cbIsElevator.Checked = true;
                            cbIsElevator.Visible = true;
                        }
                        else
                        {
                            SetAccessExAttribute(type);
                        }
                    }
                }
                else if (_lastType==null)
                {
                    SetAccessExAttribute(ControllerDoorType.TwoDoorsTwoDirections);
                }
            }
            else
            {
                SetAccessExAttribute(ControllerDoorType.TwoDoorsTwoDirections);
            }
            DoLoadArea();
        }

        private void DoLoadArea()
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                var areas = AreaDataHelper.GetAreas();
                if (areas.Count>0)
                {
                    this.Invoke(new Action(() =>
                    {
                        var nodes = AreaDataHelper.ToTree(areas);
                        nodes.Insert(0, new DevComponents.AdvTree.Node("--无--"));
                        cboTreeArea.Nodes.AddRange(nodes.ToArray());
                        foreach (var item in nodes)
                        {
                            item.Expand();
                        }
                        if (_ctrlr!=null&&_ctrlr.AREA_ID!=null&&_ctrlr.AREA_ID>=0)
                        {
                            DevComponents.AdvTree.Node node = FindNode((decimal)_ctrlr.AREA_ID);
                            if (node!=null)
                            {
                                cboTreeArea.SelectedNode = node;
                            }
                        }
                    }));
                }
            });
            ctrlWaiting.Show(this,300);
        }

        public DevComponents.AdvTree.Node FindNode(decimal id)
        {
            return DoFindNode(cboTreeArea.Nodes, id);
        }
        private DevComponents.AdvTree.Node DoFindNode(DevComponents.AdvTree.NodeCollection nodes, decimal id)
        {
            foreach (DevComponents.AdvTree.Node item in nodes)
            {
                var area = item.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
                if (area!=null&&area.ID == id)
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

        private void tbCtrlrSn_TextChanged(object sender, EventArgs e)
        {
            if ((tbCtrlrSn.Text.Trim().Length > 0) && (_ctrlr == null || _ctrlr.CTRLR_MODEL == "WGACCESS"))
            {
                string sn = tbCtrlrSn.Text.Trim();
                if (sn[0] == '1')
                {
                    cbIsElevator.Visible = true;
                }
                else
                {
                    cbIsElevator.Visible = false;
                    cbIsElevator.Checked = false;
                }
                tabItemDoor.Visible = !cbIsElevator.Checked;
                SetWGAccessExAttribute();
            }
        }
        private void SetWGAccessExAttribute()
        {
            string sn = tbCtrlrSn.Text.Trim();
            if (sn.Length > 0)
            {
                if (sn[0] == '1')
                {
                    if (cbIsElevator.Checked)
                    {
                        SetAccessExAttribute(ControllerDoorType.Elevator);
                    }
                    else
                    {
                        SetAccessExAttribute(ControllerDoorType.OneDoorTwoDirections);
                    }
                }
                else if (sn[0] == '2')
                {
                    SetAccessExAttribute(ControllerDoorType.TwoDoorsTwoDirections);
                }
                else if (sn[0] == '4')
                {
                    SetAccessExAttribute(ControllerDoorType.FourDoorsOneDirection);
                }
            }
        }
        private void SetAccessExAttribute(ControllerDoorType doorType)
        {
            if (_lastType==null)
            {
                _lastType = doorType;
            }
            else
            {
                if (_lastType==doorType)
                {
                    return;
                }
            }
            _lastType = doorType;
            int doorCount = 1;
            int directionCount = 1;
            switch (doorType)
            {
                case ControllerDoorType.OneDoorTwoDirections:
                    {
                        this.tabItemDoor. Text = "【单门双向控制器】属性";
                        doorCount = 1;
                        directionCount = 2;
                    }
                    break;
                case ControllerDoorType.TwoDoorsTwoDirections:
                    {
                        this.tabItemDoor.Text = "【双门双向控制器】属性";
                        doorCount = 2;
                        directionCount = 2;
                    }
                    break;
                case ControllerDoorType.FourDoorsOneDirection:
                    {
                        this.tabItemDoor.Text = "【四门单向控制器】属性";
                        doorCount = 4;
                        directionCount = 1;
                    }
                    break;
                case ControllerDoorType.Elevator:
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }
            List<DoorNameAttriData> doorNameDatas = new List<DoorNameAttriData>();
            List<DoorReaderAttriData> doorReaderDatas = new List<DoorReaderAttriData>();
            for (int i = 0; i < doorCount; i++)
            {
                DoorNameAttriData data = new DoorNameAttriData();
                data.doorNo = i + 1;
                data.doorCtrlType = 0;
                data.doorEnable = true;
                data.doorName = "门_" + tbCtrlrSn.Text.Trim() + "_" + data.doorNo;
                data.doorSecond = 3;
                Maticsoft.Model.SMT_DOOR_INFO doorInfo = null;
                if (_ctrlr != null)
                {
                    if (_ctrlr.DOOR_INFOS != null)
                    {
                        doorInfo = _ctrlr.DOOR_INFOS.Find(m => m.CTRL_ID == _ctrlr.ID && (m.CTRL_DOOR_INDEX == data.doorNo));
                        if (doorInfo != null)
                        {
                            if (!string.IsNullOrWhiteSpace(doorInfo.DOOR_NAME))
                            {
                                data.doorName = doorInfo.DOOR_NAME;
                            }
                            data.doorCtrlType = doorInfo.CTRL_STYLE;
                            data.doorEnable = doorInfo.IS_ENABLE;
                            data.doorSecond = doorInfo.CTRL_DELAY_TIME;
                            data.visitor = doorInfo.IS_ALLOW_VISITOR;
                        }
                    }
                }
                doorNameDatas.Add(data);
                for (int j = 0; j < directionCount; j++)
                {
                    DoorReaderAttriData rdata = new DoorReaderAttriData();
                    rdata.doorNo = data.doorNo;
                    rdata.isEnter = rdata.isNoEnter = j == 0;
                    rdata.isAttend = false;
                    rdata.isEnter1 = j == 0;
                    if (doorInfo != null)
                    {
                        rdata.isEnter = j == 0 ? doorInfo.IS_ENTER1 : doorInfo.IS_ENTER2;
                        rdata.isAttend = j == 0 ? doorInfo.IS_ATTENDANCE1 : doorInfo.IS_ATTENDANCE2;
                    }
                    doorReaderDatas.Add(rdata);
                }
            }

            doorNameAttriGroup.SetDatas(doorNameDatas);
            doorReaderAttriGroup.SetDatas(doorReaderDatas);
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(tbCtrlrSn.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "控制器序列号不能为空！");
                tbCtrlrSn.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ipCtrlr.Value))
            {
                WinInfoHelper.ShowInfoWindow(this, "控制器IP地址不能为空！");
                ipCtrlr.Focus();
                return false;
            }
            return true;
        }
        private void DoSave(bool upload)
        {
            try
            {
                if (!CheckInput())
                {
                    return;
                }
                Maticsoft.Model.SMT_CONTROLLER_INFO ctrlInfo = new Maticsoft.Model.SMT_CONTROLLER_INFO();
                if (_ctrlr != null)
                {
                    ctrlInfo.MAC = _ctrlr.MAC;
                    ctrlInfo.ID = _ctrlr.ID;
                    ctrlInfo.MASK = _ctrlr.MASK;
                    ctrlInfo.ORG_ID = _ctrlr.ORG_ID;
                    ctrlInfo.ORDER_VALUE = _ctrlr.ORDER_VALUE;
                    ctrlInfo.CTRLR_MODEL = _ctrlr.CTRLR_MODEL;
                    ctrlInfo.DRIVER_DATE = _ctrlr.DRIVER_DATE;
                    ctrlInfo.DRIVER_VERSION = _ctrlr.DRIVER_VERSION;
                    ctrlInfo.GATEWAY = _ctrlr.GATEWAY;
                }
                else
                {
                    ctrlInfo.ID = -1;
                }
                ctrlInfo.SN_NO = tbCtrlrSn.Text.Trim();
                ctrlInfo.IS_ENABLE = cbCtrlrEnable.Checked;
                string name = tbCtrlName.Text.Trim();
                if (name == "")
                {
                    name = ctrlInfo.SN_NO;
                }
                ctrlInfo.NAME = name;
                ctrlInfo.IP = ipCtrlr.Value;
                ctrlInfo.PORT = iiPort.Value;
                ctrlInfo.CTRLR_DESC = tbDesc.Text.Trim();
                ctrlInfo.CTRLR_TYPE = (int)_lastType;
                ctrlInfo.AREA_ID = -1;
                if (cboTreeArea.SelectedNode != null && cboTreeArea.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
                {
                    var area = cboTreeArea.SelectedNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
                    ctrlInfo.AREA_ID = area.ID;
                    ctrlInfo.AREA_NAME = area.ZONE_NAME;
                }

                List<DoorNameAttriData> doorNameDatas = doorNameAttriGroup.GetDatas();
                List<DoorReaderAttriData> doorReaderDatas = doorReaderAttriGroup.GetDatas();
                List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
                foreach (var item in doorNameDatas)
                {
                    Maticsoft.Model.SMT_DOOR_INFO door = new Maticsoft.Model.SMT_DOOR_INFO();
                    door.CTRL_ID = ctrlInfo.ID;
                    door.CTRL_DELAY_TIME = item.doorSecond;
                    door.CTRL_DOOR_INDEX = item.doorNo;
                    door.CTRL_STYLE = item.doorCtrlType;
                    door.IS_ALLOW_VISITOR = item.visitor;
                    if (_ctrlr != null)
                    {
                        var old = _ctrlr.DOOR_INFOS.Find(m => m.CTRL_DOOR_INDEX == item.doorNo);
                        if (old != null)
                        {
                            door.ID = old.ID;
                            door.DOOR_DESC = old.DOOR_DESC;
                        }
                    }
                    else
                    {
                        door.ID = -1;
                        door.DOOR_DESC = "";
                    }
                    door.DOOR_NAME = item.doorName;
                    DoorReaderAttriData reader1 = doorReaderDatas.Find(m => m.doorNo == item.doorNo && m.isEnter1);
                    DoorReaderAttriData reader2 = doorReaderDatas.Find(m => m.doorNo == item.doorNo && !m.isEnter1);
                    door.IS_ATTENDANCE1 = reader1 == null ? false : reader1.isAttend;
                    door.IS_ATTENDANCE2 = reader2 == null ? false : reader2.isAttend;
                    door.IS_ENABLE = item.doorEnable;
                    door.IS_ENTER1 = reader1 == null ? false : reader1.isEnter;
                    door.IS_ENTER2 = reader2 == null ? false : reader2.isEnter;
                    doors.Add(door);
                }
                CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                        var exists = ctrlBll.GetModelList("SN_NO='" + ctrlInfo.SN_NO + "'");

                        if (ctrlInfo.ID != -1)
                        {
                            if (exists.Count > 0)
                            {
                                if (exists[0].ID != ctrlInfo.ID)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "已存在控制器序列号：" + ctrlInfo.SN_NO);
                                    return;
                                }
                            }
                            ctrlBll.Update(ctrlInfo);
                            ctrlInfo.DOOR_INFOS = _ctrlr.DOOR_INFOS;
                            _ctrlr = ctrlInfo;
                        }
                        else
                        {
                            if (exists.Count > 0)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "已存在控制器序列号：" + ctrlInfo.SN_NO);
                                return;
                            }
                            ctrlInfo.ID = ctrlBll.Add(ctrlInfo);
                            _ctrlr = ctrlInfo;
                        }

                        if (_lastType != ControllerDoorType.Elevator)//非电梯控制器
                        {
                            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();

                            foreach (var item in doors)
                            {
                                var edoors = doorBll.GetModelList("CTRL_ID=" + ctrlInfo.ID + " and " + " CTRL_DOOR_INDEX=" + item.CTRL_DOOR_INDEX);
                                if (edoors.Count > 0)
                                {
                                    item.ID = edoors[0].ID;
                                    doorBll.Update(item);
                                }
                                else
                                {
                                    item.CTRL_ID = ctrlInfo.ID;
                                    item.ID = doorBll.Add(item);
                                }
                            }
                            _ctrlr.DOOR_INFOS = doors;

                            if (upload)
                            {
                                string errMsg = null;
                                if (UploadPrivate.UploadByCtrlr(_ctrlr, out errMsg, doors, true))
                                {
                                    if (errMsg != "")
                                    {
                                        WinInfoHelper.ShowInfoWindow(this, "设置控制器" + (_ctrlr.IS_ENABLE ? "启用" : "禁用") + "异常：" + errMsg);
                                        return;
                                    }
                                }
                                else
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "设置控制器" + (_ctrlr.IS_ENABLE ? "启用" : "禁用") + "异常：" + errMsg);
                                    return;
                                }
                                Controller c = ControllerHelper.ToController(_ctrlr);
                                //设置门控制方式
                                foreach (var item in doors)
                                {
                                    using (IAccessCore access = new WGAccess())
                                    {
                                        bool ret = access.SetDoorControlStyle(c, (int)item.CTRL_DOOR_INDEX, (DoorControlStyle)item.CTRL_STYLE, item.CTRL_DELAY_TIME);
                                        if (!ret)
                                        {
                                            WinInfoHelper.ShowInfoWindow(this, "上传门控制方式失败！");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        this.Invoke(new Action(() =>
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }));
                    }
                    catch (Exception ex)
                    {
                        log.Error("保存异常：" + ex.Message, ex);
                        WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                    }
                });
                ctrlWaiting.Show(this);
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                log.Error("保存异常：" + ex.Message, ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoSave(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOkAndUpload_Click(object sender, EventArgs e)
        {
            DoSave(true);
        }

        private void cbIsElevator_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsElevator.Checked)
            {
                tabItemDoor.Visible = false;
            }
            else
            {
                tabItemDoor.Visible = true;
            }
            SetWGAccessExAttribute();
        }
    }
}
