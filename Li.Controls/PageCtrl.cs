using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Li.Controls
{
    public partial class PageCtrl : UserControl
    {
        private int mTotalRecords = 0;
        public int TotalRecords
        {
            get { return mTotalRecords; }
            set
            {
                mTotalRecords = value;
                if (mTotalRecords<=0)
                {
                    mCurrentPage = 1;
                }
                UpdateState();
            }
        }
        private int mRecordsPerPage = 50;
        public int RecordsPerPage
        {
            get { return mRecordsPerPage; }
            set
            {
                mRecordsPerPage = value;
                UpdateState();
            }
        }


        private int mCurrentPage = 1;
        public int CurrentPage
        {
            get { return mCurrentPage; }
            set
            {
                if (mTotalPage >= value)
                {
                    mCurrentPage = value;
                    tbPage.Text = mCurrentPage.ToString();
                    UpdateState();
                }
            }
        }
        private int mTotalPage = 0;
        public int TotalPage
        {
            get { return mTotalPage; }
        }
        public int StartIndex
        {
            get {
                return mRecordsPerPage * (mCurrentPage - 1) + 1;
            }
        }
        public int EndIndex
        {
            get { 
                return mRecordsPerPage * mCurrentPage;
            }
        }
       
        public PageCtrl()
        {
            InitializeComponent();
        }
        public delegate void PageEventHandle(object sender, PageEventArgs args);
        private event PageEventHandle mPageChanged = null;
        public event PageEventHandle PageChanged
        {
            add { mPageChanged += value; }
            remove { mPageChanged -= value; }
        }
        private event PageEventHandle mExportCurrent = null;
        public event PageEventHandle ExportCurrent
        {
            add { mExportCurrent += value; }
            remove { mExportCurrent -= value; }
        }
        private event PageEventHandle mExportAll = null;
        public event PageEventHandle ExportAll
        {
            add { mExportAll += value; }
            remove { mExportAll -= value; }
        }
        private bool mExportButtonVisible = true;
        public bool ExportButtonVisible
        {
            get { return mExportButtonVisible; }
            set
            {
                mExportButtonVisible = value;
                btnExportCur.Visible = value;
                btnExportAll.Visible = value;
            }
        }

        private void PageCtrl_Resize(object sender, EventArgs e)
        {
            plPage.Location = new Point(this.Width / 2 - plPage.Width / 2, 0);
        }

        private void UpdateState()
        {
            if (mTotalRecords % mRecordsPerPage == 0)
            {
                mTotalPage = mTotalRecords / mRecordsPerPage;
            }
            else
            {
                mTotalPage = mTotalRecords / mRecordsPerPage + 1;
            }

            lbMsg.Text = "共 " + mTotalRecords + " 条，每页 " + mRecordsPerPage + " 条，共 " + mTotalPage + " 页";

            if (mTotalPage <= 1)
            {
                btnFirstPage.Enabled = false;
                btnPrePage.Enabled = false;
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            }
            else
            {
                if (mCurrentPage <= 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                else if (mCurrentPage >= mTotalPage)
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
            }
            tbPage.Text = mCurrentPage.ToString();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (mCurrentPage <= 1)
            {
                mCurrentPage = 1;
                return;
            }
            mCurrentPage = 1;
            UpdateState();
            DoPageChanged();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            if (mCurrentPage <= 1)
            {
                mCurrentPage = 1;
                return;
            }
            mCurrentPage--;
            UpdateState();
            DoPageChanged();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (mCurrentPage >= mTotalPage)
            {
                mCurrentPage = mTotalPage;
                return;
            }
            mCurrentPage++;
            UpdateState();
            DoPageChanged();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (mCurrentPage >= mTotalPage)
            {
                mCurrentPage = mTotalPage;
                return;
            }
            mCurrentPage = mTotalPage;
            UpdateState();
            DoPageChanged();
        }

        private void btnSetPage_Click(object sender, EventArgs e)
        {
            int page = mCurrentPage;
            try
            {
                page = int.Parse(tbPage.Text);
            }
            catch
            {
                page = mCurrentPage;
            }
            if (page > mTotalPage) page = mTotalPage;
            if (mCurrentPage != page)
            {
                mCurrentPage = page;
                UpdateState();
                DoPageChanged();
            }
        }
        protected void OnPageChanged(PageEventArgs e)
        {
            if (mPageChanged != null)
            {
                mPageChanged(this, e);
            }
        }
        private void DoPageChanged()
        {
            PageEventArgs args = new PageEventArgs(mCurrentPage, mTotalRecords, mRecordsPerPage, mTotalPage);
            OnPageChanged(args);
        }
        protected void OnExportCurrent(PageEventArgs args)
        {
            if (mExportCurrent != null)
            {
                mExportCurrent(this, args);
            }
        }
        private void btnExportCur_Click(object sender, EventArgs e)
        {
            PageEventArgs args = new PageEventArgs(mCurrentPage, mTotalRecords, mRecordsPerPage, mTotalPage);
            OnExportCurrent(args);

        }
        protected void OnExportAll(PageEventArgs args)
        {
            if (mExportAll != null)
            {
                mExportAll(this, args);
            }
        }
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            PageEventArgs args = new PageEventArgs(mCurrentPage, mTotalRecords, mRecordsPerPage, mTotalPage);
            OnExportAll(args);

        }
    }



    public class PageEventArgs : EventArgs
    {
        private int mCurrentPage = 1;
        public int CurrentPage
        {
            get { return mCurrentPage; }
        }
        private int mTotalRecords = 0;
        public int TotalRecords
        {
            get { return mTotalRecords; }
        }
        private int mRecordsPerPage = 50;
        public int RecordsPerPage
        {
            get { return mRecordsPerPage; }
        }
        private int mTotalPage = 0;
        public int TotalPage
        {
            get { return mTotalPage; }
        }
        private int mStartIndex = 0;
        public int StartIndex
        {
            get { return mStartIndex; }
        }
        private int mEndIndex = 0;
        public int EndIndex
        {
            get { return mEndIndex; }
        }
        public PageEventArgs(int currentPage, int totalRecords, int recordsPerPage, int totalPage)
        {
            mCurrentPage = currentPage;
            mTotalRecords = totalRecords;
            mRecordsPerPage = recordsPerPage;
            mTotalPage = totalPage;

            mStartIndex = mRecordsPerPage * (mCurrentPage - 1) + 1;

            mEndIndex = mRecordsPerPage * mCurrentPage;

        }
    }
}
