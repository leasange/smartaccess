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
    public partial class DataGridViewEx : DevComponents.DotNetBar.Controls.DataGridViewX 
    {
        public int OffsetIndex = 0;
        public DataGridViewEx()
        {
            InitializeComponent();
        }
        public new void StyleManagerStyleChanged(DevComponents.DotNetBar.eDotNetBarStyle newStyle)
        {
            try
            {
                base.StyleManagerStyleChanged(newStyle);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
          
        }
        

        private void DataGridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = 
                new System.Drawing.Rectangle(
                    e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    this.RowHeadersWidth - 4,
                    e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1 + OffsetIndex).ToString(),
                this.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        
    }
}
