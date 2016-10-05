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
using Li.Controls.Excel;

namespace SmartAccess.StatisticsMgr
{
    public partial class AccessInOutRecordsStatistics : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccessInOutRecordsStatistics));
        public AccessInOutRecordsStatistics()
        {
            InitializeComponent();
        }

        private void AccessInOutRecordsStatistics_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            dtpStart.Value = DateTime.Now.Date;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var doors = DoorDataHelper.GetDoors();
                var areas = AreaDataHelper.GetAreas();

                this.Invoke(new Action(() =>
                {
                    var doorNodes = DoorDataHelper.ToTree(areas, doors);
                    //cboDoorTree.Nodes.Add(new Node("--所有门禁--"));
                    cboDoorTree.Nodes.AddRange(doorNodes.ToArray());
                    if (cboDoorTree.Nodes.Count>0)
                    {
                        cboDoorTree.SelectedNode = cboDoorTree.Nodes[0];
                    }
                   
                    foreach (Node item in cboDoorTree.Nodes)
                    {
                        item.ExpandAll();
                    }
                }));


            });
            waiting.Show(this, 300);
        }
        class SimpleRecord
        {
            public decimal DOOR_ID;
            public string DOOR_NAME;
            public DateTime RECORD_DATE;
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (cboDoorTree.SelectedNode == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            if (DateTime.Parse(dtpStart.Value.Date.ToString("yyyy-MM-01 00:00:00")) > DateTime.Parse(dtpEnd.Value.Date.ToString("yyyy-MM-01 00:00:00")))
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string doorIds = "";
            if (cboDoorTree.SelectedNode != cboDoorTree.Nodes[0])//跟节点
            {
                var doors = GetSelectDoors();
                if (doors.Count>0)
	            {
                    foreach (var item in doors)
	                {
                        doorIds+=item.ID+",";
                    }
                    doorIds=doorIds.TrimEnd(',');
	            }
            }
            string doorName = "所有门禁";
            if (cboDoorTree.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
            {
                doorName = ((Maticsoft.Model.SMT_CONTROLLER_ZONE)cboDoorTree.SelectedNode.Tag).ZONE_NAME;
            }
            else if (cboDoorTree.SelectedNode.Tag is Maticsoft.Model.SMT_DOOR_INFO)
            {
                doorName = ((Maticsoft.Model.SMT_DOOR_INFO)cboDoorTree.SelectedNode.Tag).DOOR_NAME;
            }
           
            string str = string.Format("select T1.DOOR_NAME,T2.DOOR_ID,T2.RECORD_DATE from SMT_DOOR_INFO T1,SMT_CARD_RECORDS T2 where T1.ID =T2.DOOR_ID and T1.ID in ({0})", doorIds);
           
            if (string.IsNullOrWhiteSpace(doorIds))
            {
                str = "select T1.DOOR_NAME,T2.DOOR_ID,T2.RECORD_DATE from SMT_DOOR_INFO T1,SMT_CARD_RECORDS T2 where T1.ID =T2.DOOR_ID";
                doorName="所有门禁";
            }
            str += string.Format(" and T2.RECORD_DATE>='{0}' and T2.RECORD_DATE<'{1}' order by T2.RECORD_DATE", dtpStart.Value.ToString("yyyy-MM-01 00:00:00"), dtpEnd.Value.Date.AddMonths(1).ToString("yyyy-MM-01 00:00:00"));
            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(str);
                    DataTable dt = ds.Tables[0];
                    List<SimpleRecord> records = new List<SimpleRecord>();
                    foreach (DataRow row in dt.Rows)
                    {
                        records.Add(new SimpleRecord()
                            {
                                DOOR_ID = (decimal)row["DOOR_ID"],
                                DOOR_NAME = Convert.ToString(row["DOOR_NAME"]),
                                RECORD_DATE = (DateTime)row["RECORD_DATE"]
                            });
                    }
                    string start = dtpStart.Value.Date.ToString("yyyy-MM-01 00:00:00");
                    DateTime dtStart = DateTime.Parse(start);
                    string end = dtpEnd.Value.Date.ToString("yyyy-MM-01 00:00:00");
                    DateTime dtEnd = DateTime.Parse(end).AddMonths(1);
                    if (dtpEnd.Value.Date.ToString("yyyy-MM") == dtpStart.Value.Date.ToString("yyyy-MM"))//同一个月
                    {
                        int dayCount = (int)((dtEnd - dtStart).TotalDays);
                        this.Invoke(new Action(() =>
                        {
                            DoCreateColumns(dayCount, dtStart);
                        }));
                        int[,] vals = new int[12, dayCount];
                        for (int i = 0; i < dayCount; i++)
                        { 
                            DateTime t= dtStart.AddDays(i+1);
                            if (records.Count==0)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    vals[j, i] = 0;
                                }
                                continue;
                            }
                            int index = records.FindIndex(m => m.RECORD_DATE >= t) - 1;
                            if (index==-1)//全部都不是
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    vals[j, i] = 0;
                                }
                            }
                            else//存在
                            {
                                if (index==-2)//全部都是
                                {
                                    index = records.Count - 1;
                                }
                                var temp = records.GetRange(0, index + 1);
                                var st= dtStart.AddDays(i);
                                for (int j = 0; j < 12; j++)
                                {
                                    var h = st.AddHours(2 * (j + 1));
                                    if (temp.Count==0)
                                    {
                                        vals[j, i] = 0;
                                        continue;
                                    }
                                    int tindex = temp.FindIndex(m => m.RECORD_DATE >= h)-1;
                                    if (tindex == -1)//全部都不是
                                    {
                                        vals[j, i] = 0;
                                    }
                                    else
                                    {
                                        if (tindex==-2)//全部都是
                                        {
                                            tindex = temp.Count - 1;
                                        }
                                        vals[j, i] = tindex + 1;
                                        temp.RemoveRange(0, tindex + 1);
                                    }
                                }
                                records.RemoveRange(0, index + 1);
                            }
                        }
                        this.Invoke(new Action(() =>
                        {
                            
                            for (int i = 0; i < 12; i++)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dgvData,
                                    dtStart.AddHours(2 * i).ToString("HH:mm:ss") + "-" + dtStart.AddHours(2 * (i+1)).ToString("HH:mm:ss"),
                                    doorName
                                    );
                                int total = 0;
                                for (int j = 0; j < dayCount; j++)
                                {
                                    row.Cells[j + 3].Value = vals[i, j];
                                    total += vals[i, j];
                                }
                                row.Cells[2].Value = total;
                                dgvData.Rows.Add(row);
                            }

                            int[] totals = new int[dayCount + 1];
                            for (int i = 0; i < dayCount+1; i++)
                            {
                                int t = 0;
                                for (int j = 0; j < 12; j++)
                                {
                                    t += (int)dgvData.Rows[j].Cells[i + 2].Value;
                                }
                                totals[i] = t;
                            }
                            DataGridViewRow trow = new DataGridViewRow();
                            trow.CreateCells(dgvData,
                                "总计",
                                ""
                                );
                            for (int i = 0; i < dayCount+1; i++)
                            {
                                trow.Cells[i + 2].Value = totals[i];
                            }
                            dgvData.Rows.Add(trow);
                        }));  
                    }
                    else
                    {
                        int monthCount = (dtEnd.Year - dtStart.Year) * 12 + (dtEnd.Month - dtStart.Month);
                        
                        this.Invoke(new Action(() =>
                        {
                            DoCreateColumns(monthCount, dtStart,false);
                        }));

                        int[,] vals = new int[12, monthCount];
                        for (int i = 0; i < monthCount; i++)
                        {
                            DateTime t = dtStart.AddMonths(i + 1);
                            if (records.Count == 0)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    vals[j, i] = 0;
                                }
                                continue;
                            }
                            int index = records.FindIndex(m => m.RECORD_DATE >= t) - 1;
                            if (index == -1)//全部都不是
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    vals[j, i] = 0;
                                }
                            }
                            else//存在
                            {
                                if (index == -2)//全部都是
                                {
                                    index = records.Count - 1;
                                }
                                var temp = records.GetRange(0, index + 1);//当月数据

                                var st = dtStart.AddMonths(i);//当月
                                int days = (int)(t - st).TotalDays;//下一月与当月天数
                                int[,] dvals = new int[12, days];//当月统计值
                                for (int a = 0; a < days; a++)
                                {
                                    var std = st.AddDays(a);
                                    for (int b = 0; b < 12; b++)
                                    {
                                        var h = std.AddHours(2 * (b + 1));
                                        if (temp.Count == 0)
                                        {
                                            dvals[b, a] = 0;
                                            continue;
                                        }
                                        int tindex = temp.FindIndex(m => m.RECORD_DATE >= h) - 1;
                                        if (tindex == -1)//全部都不是
                                        {
                                            dvals[b, a] = 0;
                                        }
                                        else
                                        {
                                            if (tindex == -2)//全部都是
                                            {
                                                tindex = temp.Count - 1;
                                            }
                                            dvals[b, a] = tindex + 1;
                                            temp.RemoveRange(0, tindex + 1);
                                        }
                                    }
                                }
                                for (int m = 0; m < 12; m++)
                                {
                                    int tt = 0;
                                    for (int n = 0; n < days; n++)
                                    {
                                        tt += dvals[m, n];
                                    }
                                    vals[m, i] = tt;
                                }

                                records.RemoveRange(0, index + 1);
                            }
                        }
                        this.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dgvData,
                                    dtStart.AddHours(2 * i).ToString("HH:mm:ss") + "-" + dtStart.AddHours(2 * (i + 1)).ToString("HH:mm:ss"),
                                    doorName
                                    );
                                int total = 0;
                                for (int j = 0; j < monthCount; j++)
                                {
                                    row.Cells[j + 3].Value = vals[i, j];
                                    total += vals[i, j];
                                }
                                row.Cells[2].Value = total;
                                dgvData.Rows.Add(row);
                            }

                            int[] totals = new int[monthCount + 1];
                            for (int i = 0; i < monthCount + 1; i++)
                            {
                                int t = 0;
                                for (int j = 0; j < 12; j++)
                                {
                                    t += (int)dgvData.Rows[j].Cells[i + 2].Value;
                                }
                                totals[i] = t;
                            }
                            DataGridViewRow trow = new DataGridViewRow();
                            trow.CreateCells(dgvData,
                                "总计",
                                ""
                                );
                            for (int i = 0; i < monthCount + 1; i++)
                            {
                                trow.Cells[i + 2].Value = totals[i];
                            }
                            dgvData.Rows.Add(trow);
                        }));  
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "查询统计异常！"+ex.Message);
                    log.Error("查询统计异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void DoSummarise(List<SimpleRecord> records)
        {

        }

        private void DoCreateColumns(int count,DateTime start, bool isdays=true)
        {
            while (dgvData.Columns.Count>3)
	        {
                dgvData.Columns.RemoveAt(3);
	        }
           
            if (isdays)
            {
                for (int i = 0; i < count; i++)
                {
                    DataGridViewColumn col = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    col.Name = start.AddDays(i).ToString("yyyy-MM-dd");
                    dgvData.Columns.Add(col);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    DataGridViewColumn col = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    col.Name = start.AddMonths(i).ToString("yyyy-MM");
                    dgvData.Columns.Add(col);
                }
            }
        }


        private List<Maticsoft.Model.SMT_DOOR_INFO> GetSelectDoors()
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> list = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            if (cboDoorTree.SelectedNode == null)
            {
                return list;
            }
            if (cboDoorTree.SelectedNode.Tag==null)
            {
                return list;
            }
            list.AddRange(GetSelectDoors(cboDoorTree.SelectedNode));
            return list;
        }
        private List<Maticsoft.Model.SMT_DOOR_INFO> GetSelectDoors(Node node)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> list = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            if (node.Tag is Maticsoft.Model.SMT_DOOR_INFO)
            {
                list.Add((Maticsoft.Model.SMT_DOOR_INFO)node.Tag);
            }
            else
            {
                foreach (Node item in node.Nodes)
                {
                    list.AddRange(GetSelectDoors(item));
                }
            }
            return list;
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string timeString = dtpStart.Value.Date.ToString("yyyy_MM_") + dtpEnd.Value.Date.ToString("yyyy_MM");
            ExportHelper.ExportEx(dgvData, "门禁统计_" + timeString + ".xls", "门禁统计_" + timeString);
        }
    }
}
