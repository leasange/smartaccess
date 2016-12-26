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
    public partial class FrmZoomImage : DevComponents.DotNetBar.Office2007Form
    {
        private int _srcWidth=1, _srcHeigth=1;
        private static bool _fixedRatio = true;
        private bool _isLoading = false;
        public Size ZoomSize = Size.Empty;
        public FrmZoomImage(int width,int height)
        {
            InitializeComponent();
            this._srcWidth = width;
            this._srcHeigth = height;
            if (_srcWidth<1)
            {
                _srcWidth = 1;
            }
            if (_srcHeigth<1)
            {
                _srcHeigth = 1;
            }
            gpGroup.Text = "原始图片大小:" + _srcWidth + "x" + _srcHeigth;
        }

        private void FrmZoomImage_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            iiWidth.Value = _srcWidth;
            iiHeight.Value = _srcHeigth;
            this.cbFixedRatio.Checked = _fixedRatio;
            _isLoading = false;
        }

        private void cbFixedRatio_CheckedChanged(object sender, EventArgs e)
        {
            _fixedRatio = cbFixedRatio.Checked;
            _isLoading = true;
            int h = (int)(_srcHeigth / (float)_srcWidth * iiWidth.Value);
            if (h < 1)
            {
                h = 1;
            }
            iiHeight.Value = h;
            _isLoading = false;
        }

        private void iiWidth_ValueChanged(object sender, EventArgs e)
        {
            if (cbFixedRatio.Checked)
            {
                if (!_isLoading)
                {
                    _isLoading = true;
                    int h = (int)(_srcHeigth / (float)_srcWidth * iiWidth.Value);
                    if (h < 1)
                    {
                        h = 1;
                    }
                    iiHeight.Value = h;
                    _isLoading = false;
                }
            }
        }

        private void iiHeight_ValueChanged(object sender, EventArgs e)
        {
            if (cbFixedRatio.Checked)
            {
                if (!_isLoading)
                {
                    _isLoading = true;
                    int w = (int)(_srcWidth / (float)_srcHeigth * iiHeight.Value);
                    if (w < 1)
                    {
                        w = 1;
                    }
                    iiWidth.Value = w;
                    _isLoading = false;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ZoomSize = new Size(iiWidth.Value, iiHeight.Value);
            this.DialogResult = DialogResult.OK;
        }
    }
}
