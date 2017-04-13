using Li.Controls;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmEditorFaceBackList : DevComponents.DotNetBar.Office2007Form
    {
        public Maticsoft.Model.IMS_FACE_BLACKLIST FACE = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmEditorFaceBackList));
        public FrmEditorFaceBackList()
        {
            InitializeComponent();
        }

        private void FrmEditorFaceBackList_Load(object sender, EventArgs e)
        {
            cbSex.SelectedIndex = 0;
            if (FACE!=null)
            {
                this.Text = "修改人脸黑名单";
                tbName.Text = FACE.Name;
                int sex=FACE.Sex==null?0:(int)FACE.Sex;
                if (sex<0||sex>2)
                {
                    sex = 0;
                }
                cbSex.SelectedIndex = sex;
                tbPicPath.Text = FACE.FacePic;
                if (FACE.Description!=null)
                {
                    tbDesc.Text = Encoding.UTF8.GetString(FACE.Description);
                }
                if (!string.IsNullOrWhiteSpace(FACE.FacePic))
                {
                    WebImageReader.ReadImageAsync(FACE.FacePic, new WebImageReader.ReadImageCallBack((i, ee) =>
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                 {
                                     if (picBox.Image != null)
                                     {
                                         picBox.Image.Dispose();
                                         picBox.Image = null;
                                     }
                                     if (i != null)
                                     {
                                         picBox.Image = i;
                                     }
                                     else if (ee != null)
                                     {
                                         throw ee;
                                     }
                                 }));
                            }
                            catch (Exception ex)
                            {
                                log.Error("加载人脸失败：", ex);
                                WinInfoHelper.ShowInfoWindow(this, "加载人脸失败:" + ex.Message);
                            }
                        }));
                }
            }
            else
            {
                this.Text = "添加人脸黑名单";
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbPicPath.Text = openFileDialog.FileName;
                    if (picBox.Image != null)
                    {
                        picBox.Image.Dispose();
                        picBox.Image = null;
                    }
                    picBox.Image = Image.FromFile(tbPicPath.Text);
                }
            }
            catch (System.Exception ex)
            {
                log.Error("读取人脸异常：", ex);
                WinInfoHelper.ShowInfoWindow(this, "读取人脸异常:" + ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "名称不能为空！");
                tbName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPicPath.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "人脸照片不能为空！");
                return;
            }
            if (FACE==null)
            {
                FACE = new Maticsoft.Model.IMS_FACE_BLACKLIST();
                FACE.ID = -1;
            }
            FACE.FacePic = tbPicPath.Text;
            FACE.Name = tbName.Text.Trim();
            FACE.Description = Encoding.UTF8.GetBytes(tbDesc.Text);
            FACE.Sex = cbSex.SelectedIndex;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.IMS_FACE_BLACKLIST flBll = new Maticsoft.BLL.IMS_FACE_BLACKLIST();
                    if (FACE.ID==-1)
                    {
                        FACE.ID = flBll.Add(FACE);
                    }
                    else
                    {
                        flBll.Update(FACE);
                    }
                    this.BeginInvoke(new Action(() =>
                    {
                        if (picBox.Image != null)
                        {
                            picBox.Image.Dispose();
                            picBox.Image = null;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("保存人脸异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "保存人脸异常:" + ex.Message);
                }
            });
            waiting.Show(this);
        }

    }
}
