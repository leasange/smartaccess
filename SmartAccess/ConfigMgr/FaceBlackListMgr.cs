using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using Li.Controls;
///
///黑名单管理
///
namespace SmartAccess.ConfigMgr
{
    public partial class FaceBlackListMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceBlackListMgr));
        public FaceBlackListMgr()
        {
            InitializeComponent();
        }

        private void FaceBlackListMgr_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.IMS_FACE_BLACKLIST blBll = new Maticsoft.BLL.IMS_FACE_BLACKLIST();
                    var models = blBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        listFaces.Items.Clear();
                        foreach (var item in models)
                        {
                            AddFace(item);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸黑名单异常：" + ex.Message);
                    log.Error("加载人脸黑名单异常", ex);
                }
            });
            waiting.Show(this);
        }

        private void AddFace(Maticsoft.Model.IMS_FACE_BLACKLIST bl,ListViewItem item=null)
        {
            ListViewItem lvi = null;
            if (item != null)
            {
                lvi = item;
            }
            else
            {
                lvi = new ListViewItem(bl.Name);
                listFaces.Items.Add(lvi);
            }
            lvi.Tag = bl;
            if (lvi.ImageKey == null || lvi.ImageKey == "")
            {
                lvi.ImageKey = "loading";
            }
            if(lvi.ImageKey != "loading")
            {
                Image image = imageList.Images[lvi.ImageKey];
                imageList.Images.RemoveByKey(lvi.ImageKey);
                image.Dispose();
            }
            WebImageReader.ReadImageAsync(bl.FacePic, new WebImageReader.ReadImageCallBack((i, e) =>
                {
                    if (i != null)
                    {
                        lock (this)
                        {
                            this.Invoke(new Action(() =>
                            {
                                string k = Guid.NewGuid().ToString("N");
                                imageList.Images.Add(k, i);
                                lvi.ImageKey = k;
                            }));
                        }
                    }
                }));
        }
        private void biAdd_Click(object sender, EventArgs e)
        {
            FrmEditorFaceBackList frmlist = new FrmEditorFaceBackList();
            if (frmlist.ShowDialog(this)==DialogResult.OK)
            {
                AddFace(frmlist.FACE);
            }
        }

        private void biModify_Click(object sender, EventArgs e)
        {
            FrmEditorFaceBackList frmlist = new FrmEditorFaceBackList();
            if(listFaces.SelectedItems.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择修改的人脸！");
                return;
            }
            Maticsoft.Model.IMS_FACE_BLACKLIST bl = (Maticsoft.Model.IMS_FACE_BLACKLIST)listFaces.SelectedItems[0].Tag;
            frmlist.FACE = bl;
            if (frmlist.ShowDialog(this) == DialogResult.OK)
            {
                AddFace(frmlist.FACE, listFaces.SelectedItems[0]);
            }
        }

        private void listFaces_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listFaces.SelectedItems.Count>0)
            {
                Maticsoft.Model.IMS_FACE_BLACKLIST bl = (Maticsoft.Model.IMS_FACE_BLACKLIST)listFaces.SelectedItems[0].Tag;
                tbName.Text = bl.Name;
                try
                {
                    tbDesc.Text = Encoding.UTF8.GetString(bl.Description);
                }
                catch (Exception)
                {
                     
                }
                if (bl.Sex==null)
                {
                    bl.Sex = 0;
                }
                if (bl.Sex==0)
                {
                    tbSex.Text = "未知";
                }
                else if (bl.Sex==1)
                {
                    tbSex.Text = "男";
                }
                else
                {
                    tbSex.Text = "女";
                }
                if (picBox.Image!=null)
                {
                    picBox.Image.Dispose();
                    picBox.Image = null;
                }
                WebImageReader.ReadImageAsync(bl.FacePic, new WebImageReader.ReadImageCallBack((i, ee) =>
                {
                    if (i != null)
                    {
                        lock (this)
                        {
                            this.Invoke(new Action(() =>
                            {
                                picBox.Image = i;
                            }));
                        }
                    }
                }));
            }
        }

        private void biDelete_Click(object sender, EventArgs e)
        {
            if (listFaces.SelectedItems.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择删除的人脸！");
                return;
            }
            if (MessageBox.Show("确定删除选择项？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (ListViewItem item in listFaces.SelectedItems)
                {
                    items.Add(item);
                }
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        List<decimal> ids = new List<decimal>();
                        
                        foreach (var item in items)
                        {
                            Maticsoft.Model.IMS_FACE_BLACKLIST bl = (Maticsoft.Model.IMS_FACE_BLACKLIST)item.Tag;
                            ids.Add(bl.ID);
                        }

                        Maticsoft.BLL.IMS_FACE_BLACKLIST blBll = new Maticsoft.BLL.IMS_FACE_BLACKLIST();
                        blBll.DeleteList(string.Join(",", ids));

                        this.Invoke(new Action(() =>
                        {
                            foreach (var lvi in items)
                            {
                                if (lvi.ImageKey == null || lvi.ImageKey == ""|| lvi.ImageKey == "loading")
                                {
                                    listFaces.Items.Remove(lvi);
                                }
                                else
                                {
                                    Image image = imageList.Images[lvi.ImageKey];
                                    imageList.Images.RemoveByKey(lvi.ImageKey);
                                    image.Dispose();
                                    listFaces.Items.Remove(lvi);
                                }
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "删除人脸黑名单异常：" + ex.Message);
                        log.Error("删除人脸黑名单异常", ex);
                    }
                });
                waiting.Show(this);
            }
        }

    }
}
