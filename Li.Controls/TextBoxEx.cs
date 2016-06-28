using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls
{
    public partial class TextBoxEx : DevComponents.DotNetBar.Controls.TextBoxX
    {
        private bool mNumberOnly = false;
        public bool NumberOnly
        {
            get { return mNumberOnly; }
            set { 
                mNumberOnly = value; 
            }
        }
        public TextBoxEx()
        {
            InitializeComponent();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.ReadOnly)  // 只读, 不处理   
            {
                return;
            }
            if (mNumberOnly)
            {




                if ((int)e.KeyChar <= 32)  // 特殊键(含空格), 不处理 
                {
                    return;
                }
                if (!char.IsDigit(e.KeyChar))  // 非数字键, 放弃该输入   
                {
                    e.Handled = true;
                    return;
                }
            }

        }


        //protected void Restricted(KeyPressEventArgs e, params int[] permitted)
        //{
        //    if ((int)e.KeyChar in permitted)//如果是在允许的范围内
        //    {

        //    }
        //}
    }
}
