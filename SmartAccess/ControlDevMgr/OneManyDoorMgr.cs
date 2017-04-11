using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Access.Core;
using DevComponents.DotNetBar;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.ControlDevMgr
{
    /// <summary>
    /// 电梯门管理
    /// </summary>
    public partial class OneManyDoorMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(OneManyDoorMgr));
        public OneManyDoorMgr()
        {
            InitializeComponent();
        }

        private void OneManyDoorMgr_Load(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void LoadDatas()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                List<decimal> ids = new List<decimal>();
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrlModels = null;
                try
                {
                    Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                    ctrlModels = ctrlBll.GetModelList("CTRLR_TYPE=" + (int)ControllerDoorType.Elevator);
                    this.Invoke(new Action(() =>
                        {
                            foreach (var item in ctrlModels)
                            {
                                ComboBoxItem cbi = new ComboBoxItem(item.NAME, item.NAME);
                                cbi.Tag = item;
                                cbCtrler.Items.Add(cbi);
                                ids.Add(item.ID);
                            }
                            if (ctrlModels.Count > 0)
                            {
                                cbCtrler.SelectedIndex = 0;
                            }
                        }));
                }
                catch (System.Exception ex)
                {
                    log.Error("加载电梯控制器错误！", ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载电梯控制器错误：" + ex.Message);
                }
                if (ids.Count == 0)
                {
                    return;
                }
                try
                {
                    Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                    var doors = doorBll.GetModelList("CTRL_ID in (" + string.Join(",", ids.ToArray()) + ")");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in doors)
                        {
                            var ctrl = ctrlModels.Find(m => m.ID == item.CTRL_ID);
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dgvData,
                                ctrl.ID,
                                ctrl.NAME,
                                (int)item.CTRL_DOOR_INDEX,
                                item.DOOR_NAME,
                                "删除"
                                );
                            row.Tag = item;
                            dgvData.Rows.Add(row);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("加载电梯控制器门错误！", ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载电梯控制器门错误：" + ex.Message);
                }
            });
            waiting.Show(this);
        }
        private string _ctrlerName = null;
        private void cbCtrler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var info = (Maticsoft.Model.SMT_CONTROLLER_INFO)((ComboBoxItem)cbCtrler.SelectedItem).Tag;
            var ctrlId = info.ID;
            _ctrlerName = info.NAME;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {

                    DataTable dt = Maticsoft.DBUtility.DbHelperSQL.Query("select CTRL_DOOR_INDEX from SMT_DOOR_INFO where CTRL_ID=" + ctrlId).Tables[0];
                    List<int> indexs = new List<int>();
                    foreach (DataRow item in dt.Rows)
                    {
                        int i = (int)(byte)item[0];
                        if (!indexs.Contains(i))
                        {
                            indexs.Add(i);
                        }
                    }
                    this.Invoke(new Action(() =>
                    {
                        cbDoorIndex.Items.Clear();
                        for (int i = 1; i <= 32; i++)
                        {
                            if (!indexs.Contains(i))
                            {
                                cbDoorIndex.Items.Add(i);
                            }
                        }
                        if (cbDoorIndex.Items.Count>0)
                        {
                            cbDoorIndex.SelectedIndex = 0;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("加载继电器编号错误！", ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载继电器编号错误：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void cbDoorIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDoorIndex.SelectedItem == null)
            {
                return;
            }
            tbDoorName.Text = _ctrlerName + "_门_" + cbDoorIndex.SelectedItem;
        }

        private void biAdd_Click(object sender, EventArgs e)
        {
            if (cbCtrler.SelectedItem == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择电梯控制器！");
                return;
            }
            if (cbDoorIndex.SelectedItem == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择继电器序号！");
                return;
            }
            if (tbDoorName.Text.Trim() == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "梯门名称不能为空！");
                return;
            }
            var info = (Maticsoft.Model.SMT_CONTROLLER_INFO)((ComboBoxItem)cbCtrler.SelectedItem).Tag;
            int index = (int)cbDoorIndex.SelectedItem;
            Maticsoft.Model.SMT_DOOR_INFO door = new Maticsoft.Model.SMT_DOOR_INFO();
            door.CTRL_ID = info.ID;
            door.CTRL_DOOR_INDEX = index;
            door.DOOR_NAME = tbDoorName.Text.Trim();
            door.ID = -1;
            door.IS_ENABLE = true;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                    var doors= doorBll.GetModelList("CTRL_ID=" + info.ID + " and CTRL_DOOR_INDEX=" + index);
                    if (doors.Count > 0)
                    {
                        doors[0].DOOR_NAME = door.DOOR_NAME;
                        doorBll.Update(doors[0]);
                        door.ID = doors[0].ID;
                    }
                    else
                    {
                        door.ID = doorBll.Add(door);
                    }
                    this.Invoke(new Action(() =>
                    {
                        DataGridViewRow row = null;
                        foreach (DataGridViewRow item in dgvData.Rows)
                        {
                            if ((decimal)item.Cells[0].Value == info.ID &&
                                (int)item.Cells[2].Value == index
                                )
                            {
                                row = item;

                                break;
                            }
                        }
                        if (row != null)
                        {
                            row.Cells[3].Value = door.DOOR_NAME;
                            row.Tag = door;
                        }
                        else
                        {
                            row = new DataGridViewRow();
                            row.CreateCells(dgvData,
                                info.ID,
                                info.NAME,
                                index,
                                door.DOOR_NAME,
                                "删除"
                                );
                            row.Tag = door;
                            dgvData.Rows.Add(row);
                        }
                        if (cbDoorIndex.SelectedIndex<cbDoorIndex.Items.Count-1)
                        {
                            cbDoorIndex.SelectedIndex += 1;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("添加梯控门失败：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "添加梯控门失败：" + ex.Message);
                    return;
                }
            });
            waiting.Show(this);
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if(dgvData.Columns[e.ColumnIndex].Name=="Col_Delete")
                {
                    if (MessageBox.Show(this,"确定删除该梯门？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
                    {
                        return;
                    }
                    DataGridViewRow row = dgvData.Rows[e.RowIndex];
                    var door = (Maticsoft.Model.SMT_DOOR_INFO)row.Tag;
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                            doorBll.Delete(door.ID);
                            this.Invoke(new Action(() =>
                            {
                                dgvData.Rows.Remove(row);
                                cbCtrler_SelectedIndexChanged(null, null);
                            }));
                            WinInfoHelper.ShowInfoWindow(this, "删除梯门成功！");
                        }
                        catch (Exception ex)
                        {
                            log.Error("删除梯门失败：", ex);
                            WinInfoHelper.ShowInfoWindow(this, "删除梯门失败：" + ex.Message);
                        }
                    });
                    waiting.Show(this);
                }
            }
        }
    }
}
