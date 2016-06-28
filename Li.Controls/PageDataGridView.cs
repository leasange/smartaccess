using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Li.Controls
{
    /// <summary>
    /// 分页类控件
    /// </summary>
    [DesignerAttribute(typeof(PageDataGridViewDesigner))]
    [Docking(DockingBehavior.Ask)]
    public partial class PageDataGridView : UserControl
    {
        #region 属性
//         [Description("获取DataGridView控件")]
//         [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
//         public DevComponents.DotNetBar.Controls.DataGridViewX DataGridViewX
//         {
//             get { return dataGridViewX; }
//         }
        private string mSqlWhere = null;
        public string SqlWhere
        {
            get { return mSqlWhere; }
            set { mSqlWhere = value; }
        }
        private DataGridViewEx mDataGridView = null;
        public Li.Controls.DataGridViewEx DataGridView
        {
            get { return mDataGridView; }
            set { mDataGridView = value; }
        }

        [Description("获取分页控件")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PageCtrl PageControl
        {
            get { return pageCtrl; }
        }
        [Description("获取DataGridPanel控件")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel DataGridPanel
        {
            get { return dataGridPanel; }
        }

        #endregion

        public PageDataGridView()
        {
            InitializeComponent();
        }
        //复位
        public void Reset()
        {
            mSqlWhere = null;
            if (mDataGridView != null)
            {
                this.mDataGridView.Rows.Clear();
                pageCtrl.TotalRecords = 0;
            }
        }
        private void pageCtrl_PageChanged(object sender, PageEventArgs args)
        {
            if (mDataGridView!=null)
            {
                this.mDataGridView.OffsetIndex = args.StartIndex;
                this.mDataGridView.Rows.Clear();
            }
        }

        private void dataGridPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is DataGridViewEx)
            {
                this.mDataGridView = (DataGridViewEx)e.Control;
                this.mDataGridView.Dock = DockStyle.Fill;
            }
        }

    }

    public class PageDataGridViewDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        private PageDataGridView mPageDataGridView;
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            mPageDataGridView = (PageDataGridView)component;
            this.EnableDesignMode(mPageDataGridView.PageControl, "PageControl");
            this.EnableDesignMode(mPageDataGridView.DataGridPanel, "DataGridPanel");
            
        }
    }
}
