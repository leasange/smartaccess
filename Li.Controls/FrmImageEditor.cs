using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls
{
    public partial class FrmImageEditor : DevComponents.DotNetBar.Office2007Form
    {
        public Bitmap ResultImage
        {
            get
            {
                return this.imageEditor.ResultImage;
            }
        }
        public FrmImageEditor()
        {
            InitializeComponent();
        }
        public void LoadImage(Bitmap image)
        {
            imageEditor.BaseImage = image;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
