using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;
using DevComponents.AdvTree;
using Li.Controls;

namespace SmartAccess.VerInfoMgr
{
    public partial class DoorTree : UserControl
    {
        public bool CheckBoxVisible
        {
            get
            {
                return this.advDoorTree.CheckBoxVisible;
            }
            set
            {
                this.advDoorTree.CheckBoxVisible = value;
            }
        }
        public AdvTreeEx Tree
        {
            get
            {
                return this.advDoorTree;
            }
        }
        private event EventHandler _loadEnded= null;
        private bool _isloaded = false;

        public bool IsLoaded
        {
            get
            {
                return _isloaded;
            }
        }

        public event EventHandler LoadEnded
        {
            add
            {
                lock (this)
                {
                    _loadEnded += value;
                    if (_isloaded)
                    {
                        _loadEnded(this, new EventArgs());
                    }
                }
            }
            remove
            {
                _loadEnded -= value;
            }
        }

        public DoorTree()
        {
            InitializeComponent();
        }
        public static bool IsDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnFlag = true;
            }
#endif
            return returnFlag;
        }

        private void DoorTree_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode())
            {
                CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        var doors = DoorDataHelper.GetDoors();
                        var areas = AreaDataHelper.GetAreas();
                        this.Invoke(new Action(() =>
                            {
                                var nodes = DoorDataHelper.ToTree(areas, doors);
                                advDoorTree.Nodes.Clear();
                                advDoorTree.Nodes.AddRange(nodes.ToArray());
                                advDoorTree.ExpandAll();
                                lock (this)
                                {
                                    _isloaded = true;
                                    if (_loadEnded != null)
                                    {
                                        _loadEnded(this, e);
                                    }
                                }
                            }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "门禁列表加载异常：" + ex.Message);
                        this.Invoke(new Action(() =>
                        {
                            lock (this)
                            {
                                _isloaded = true;
                                if (_loadEnded != null)
                                {
                                    _loadEnded(this, e);
                                }
                            }
                        }));
                    }
                });
                ctrlWaiting.Show(this, 300);
            }
        }
        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advDoorTree, tbFilter.Text.Trim());
        }
    }
}
