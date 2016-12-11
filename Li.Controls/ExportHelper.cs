using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using org.in2bits.MyXls;
using System.IO;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Li.Controls.Excel
{
    public delegate void ImportDataHandle(string[] datas,bool isError,int errorRow,string error);
    public class ExportHelper
    {
        /// <summary>
        /// 直接导出Excel
        /// </summary>
        /// <param name="dataTable">数据</param>
        /// <param name="filePathName">文件保存路径（E:\\excelname.xls）</param>
        /// <param name="sheetName">表单名称（表单1）</param>
        /// <param name="headers">头部显示的文字（编号，名称，...），如果为空则取dataTable的头</param>
        /// <returns>返回成功与否</returns>
        public static bool Export(DataTable dataTable, string filePathName, string sheetName, params string[] headers)
        {
            try
            {
                if (dataTable == null) return false;
                if (filePathName == null) return false;
                if (sheetName == null || sheetName.Trim() == "") sheetName = "Sheet";
                if (headers == null) headers = new string[0];
                string path = Path.GetDirectoryName(filePathName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> headerList = headers.ToList();
                if (headers.Length < dataTable.Columns.Count)
                {
                    for (int i = headers.Length; i < dataTable.Columns.Count; i++)
                    {
                        headerList.Add(dataTable.Columns[i].ColumnName);
                    }
                }
                XlsDocument xls = new XlsDocument();//新建Excel
                int startIndex = 0;
                int endIndex = startIndex + 65533;
                if (dataTable.Rows.Count < endIndex + 1)
                {
                    endIndex = dataTable.Rows.Count - 1;
                }
                string sheetText = sheetName;
                int count = 0;
                do
                {
                    //新建一个表单
                    Worksheet ws = xls.Workbook.Worksheets.Add(sheetText);
                    //开始到出数据
                    ColumnInfo columnInfo = new ColumnInfo(xls, ws);//头
                    columnInfo.ColumnIndexStart = 0;
                    columnInfo.ColumnIndexEnd = (ushort)(headerList.Count - 1);
                    columnInfo.Width = 21 * 256;
                    ws.AddColumnInfo(columnInfo);
                    for (ushort i = 1; i <= headerList.Count; i++)
                    {
                        ws.Cells.Add((ushort)1, i, headerList[i - 1]);
                        ws.Rows[1].GetCell(i).Font.Bold = true;
                        ws.Rows[1].GetCell(i).Font.Height = 13 * 20;
                        ws.Rows[1].GetCell(i).TopLineStyle = 1;
                        ws.Rows[1].GetCell(i).BottomLineStyle = 2;
                        ws.Rows[1].GetCell(i).LeftLineStyle = 1;
                        ws.Rows[1].GetCell(i).RightLineStyle = 1;
                        ws.Rows[1].GetCell(i).Pattern = 1;
                        ws.Rows[1].GetCell(i).PatternColor = org.in2bits.MyXls.Colors.Default1F;
                    }
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        object[] objs = dataTable.Rows[i].ItemArray;
                        for (ushort j = 1; j <= objs.Length; j++)
                        {
                            if (objs[j - 1] == DBNull.Value)
                            {
                                objs[j - 1] = "";
                            }
                            else if (objs[j - 1].GetType().Equals(typeof(DateTime)))
                            {
                                objs[j - 1] = ((DateTime)objs[j - 1]).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                Type type = objs[j - 1].GetType();
                                if (type.Equals(typeof(int)) || type.Equals(typeof(Int64)) || type.Equals(typeof(float)) || type.Equals(typeof(double)) || type.Equals(typeof(decimal)) || type.Equals(typeof(byte)) || type.Equals(typeof(ushort)) || type.Equals(typeof(uint)) || type.Equals(typeof(ulong)))
                                {
                                    objs[j - 1] = "'"+objs[j - 1];
                                }
                            }
                            ws.Cells.Add((ushort)(i + 2 - startIndex), j, objs[j - 1]);
                            ws.Rows[(ushort)(i + 2 - startIndex)].GetCell(j).Font.Height = 13 * 20;
                            ws.Rows[(ushort)(i + 2 - startIndex)].GetCell(j).TopLineStyle = 1;
                            ws.Rows[(ushort)(i + 2 - startIndex)].GetCell(j).BottomLineStyle = 1;
                            ws.Rows[(ushort)(i + 2 - startIndex)].GetCell(j).LeftLineStyle = 1;
                            ws.Rows[(ushort)(i + 2 - startIndex)].GetCell(j).RightLineStyle = 1;
                        }
                    }
                    //--结束导出数据

                    //下一个表单计算
                    startIndex = endIndex + 1;
                    if (startIndex >= dataTable.Rows.Count)
                    {
                        break;
                    }
                    else
                    {
                        endIndex = startIndex + 65533;
                        if (dataTable.Rows.Count < endIndex + 1)
                        {
                            endIndex = dataTable.Rows.Count - 1;
                        }
                        sheetText = sheetName + "-" + (++count);
                    }
                } while (true);
                xls.Save(filePathName, true);
                xls = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Export(DataGridView dataGridView, string filePathName, string sheetName)
        {
            DataTable dataTable=DataGridViewToDataTable(dataGridView);
            return Export(dataTable, filePathName, sheetName);
        }
        /// <summary>
        /// 弹出保存提示对话框并导出Excel
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="fileName">文件名称：（fileName.xls 或 fileName）</param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static void ExportEx(DataTable dataTable,string fileName, string sheetName, params string[] headers)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            sfd.FileName = fileName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bool ret= Export(dataTable, sfd.FileName, sheetName, headers);
                if (ret)
                {
                    MessageBox.Show("导出成功！");
                } 
                else
                {
                    MessageBox.Show("导出失败!");
                }

            }
        }
        /// <summary>
        /// 弹出保存提示对话框并导出Excel
        /// </summary>
        public static void ExportEx(DataGridView dataGridView, string fileName, string sheetName)
        {
            DataTable dataTable = DataGridViewToDataTable(dataGridView);
            ExportEx(dataTable, fileName, sheetName);
        }
        public static DataTable DataGridViewToDataTable(DataGridView dataGridView)
        {
            try
            {
                DataTable dt = new DataTable();
                List<DataColumn> dataColumns = new List<DataColumn>();

                List<Type> types = new List<Type>();
                if (dataGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        Type type = typeof(string);
                        if (dataGridView.Rows[0].Cells[i].Value != null)
                        {
                            type = dataGridView.Rows[0].Cells[i].Value.GetType();
                        }
                        if (type == typeof(DBNull))
                        {
                            type = typeof(string);
                        }
                        types.Add(type);
                    }
                }
                if (types.Count == 0)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        types.Add(typeof(string));
                    }
                }
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    DataColumn dc = new DataColumn(dataGridView.Columns[i].HeaderText, types[i]);
                    dataColumns.Add(dc);
                }
                dt.Columns.AddRange(dataColumns.ToArray());
                foreach (DataGridViewRow dgvr in dataGridView.Rows)
                {
                    List<object> objs = new List<object>();
                    foreach (DataGridViewCell dgvc in dgvr.Cells)
                    {
                        if (dgvc.Value==DBNull.Value)
                        {
                            objs.Add("");
                        }
                        else objs.Add(dgvc.Value);
                    }
                    dt.Rows.Add(objs.ToArray());
                }
                return dt;
            }
            catch 
            {
                return null;
            }
        }
    }
    public class ImportHelper
    {
        public static void Import(string fileName, ushort startRow = 2, ushort startCol = 1, int colCount = 4, ImportDataHandle callback = null)
        {
            try
            {
                XlsDocument xls = new XlsDocument(fileName);//新建Excel
                if (xls.Workbook.Worksheets.Count > 0)
                {
                    Worksheet ws = xls.Workbook.Worksheets[0];
                    for (ushort i = startRow; i < ws.Rows.Count; i++)
                    {
                        string[] strs = new string[colCount];
                        bool isnull = true;
                        bool iserror = false;
                        int errorRow = 0;
                        string msg = "";
                        int end = colCount + startCol;
//                         if (end > ws.Rows[i].CellCount)
//                         {
//                             end = ws.Rows[i].CellCount;
//                         }

                        for (ushort j = startCol; j < end; j++)
                        {
                            try
                            {
                                if (ws.Rows[i].CellExists(j))
                                {
                                    string str = Convert.ToString(ws.Rows[i].CellAtCol(j).Value);
                                    strs[j - startCol] = str;
                                    if (!string.IsNullOrWhiteSpace(str))
                                    {
                                        isnull = false;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                iserror = true;
                                msg = ex.Message;
                                errorRow = i+1;
                                //throw;
                            }
                        }


                        if (isnull)
                        {
                            continue;
                        }
                        if (callback != null)
                        {
                            callback(strs, iserror,errorRow,msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public static void ImportEx(out bool iscancel, ushort startRow = 2, ushort startCol = 1, int colCount = 4, ImportDataHandle callback = null)
        {
            try
            {
                string fileName = null;
                Exception ex1 = null;
                iscancel = false;
                Application.OpenForms[0].Invoke(new Action(() =>
                    {
                        try
                        {
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                fileName = ofd.FileName;
                            }
                        }
                        catch (Exception ex)
                        {
                            ex1 = ex;
                        }
                    }));
                if (ex1!=null)
                {
                    throw ex1;
                }
                if (fileName==null)
                {
                    iscancel = true;
                    return;
                }
                Import(fileName, startRow, startCol, colCount, callback);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class ImportHelper2
    {

        public static void Import(string fileName, ushort startRow = 2, ushort startCol = 1, int colCount = 4, ImportDataHandle callback = null)
        {
            try
            {
                //XlsDocument xls = new XlsDocument(fileName);//新建Excel
                IWorkbook xls = null;
                IFormulaEvaluator formula=null;
                var  fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                {
                    xls = new XSSFWorkbook(fs);
                    formula=new XSSFFormulaEvaluator(xls);
                }
                    
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                {
                     xls = new HSSFWorkbook(fs);
                    formula=new HSSFFormulaEvaluator(xls);
                }
                   

                if (xls.NumberOfSheets > 0)
                {
                    ISheet ws = xls.GetSheetAt(0);
                    for (ushort i = (ushort)(startRow-1); i <= ws.LastRowNum; i++)
                    {
                        string[] strs = new string[colCount];
                        bool isnull = true;
                        bool iserror = false;
                        int errorRow = 0;
                        string msg = "";
                        int end = colCount + startCol;
                        //                         if (end > ws.Rows[i].CellCount)
                        //                         {
                        //                             end = ws.Rows[i].CellCount;
                        //                         }
                       IRow row= ws.GetRow(i);
                       if (row==null)
                       {
                           continue;
                       }
                        for (ushort j = (ushort)(startCol - 1); j < end - 1; j++)
                        {
                            try
                            {
                                var cell = row.GetCell(j);
                                if (cell==null)
                                {
                                    continue;
                                }
                                string str = cell.ToString();
                                switch (cell.CellType)
                                {
                                    case CellType.Formula:
                                        {
                                            cell = formula.EvaluateInCell(cell);
                                            str = cell.ToString();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                
                                strs[j+1 - startCol] = str;
                                if (!string.IsNullOrWhiteSpace(str))
                                {
                                    isnull = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                iserror = true;
                                msg = ex.Message;
                                errorRow = i + 1;
                                //throw;
                            }
                        }


                        if (isnull)
                        {
                            continue;
                        }
                        if (callback != null)
                        {
                            callback(strs, iserror, errorRow, msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ImportEx(out bool iscancel, ushort startRow = 2, ushort startCol = 1, int colCount = 4, ImportDataHandle callback = null)
        {
            try
            {
                string fileName = null;
                Exception ex1 = null;
                iscancel = false;
                Application.OpenForms[0].Invoke(new Action(() =>
                {
                    try
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            fileName = ofd.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        ex1 = ex;
                    }
                }));
                if (ex1 != null)
                {
                    throw ex1;
                }
                if (fileName == null)
                {
                    iscancel = true;
                    return;
                }
                Import(fileName, startRow, startCol, colCount, callback);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
