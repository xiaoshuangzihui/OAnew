using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NPOI.HSSF.UserModel;

using System.IO;
using System.Data;

using System.Text;
using NPOI.HPSF;

namespace OAnew
{
    public class ToExcel
    {
        /// <summary>
        /// DataSet导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataSet</param>
        public static MemoryStream DataTableToExcel(DataTable ds, bool time)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(ds.TableName.ToString());
            //XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet(ds.TableName.ToString());

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "ArtsGroup";

                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = System.DateTime.Now;
                // workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            if (time)
            {
                dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd");
            }
            else
            {
                dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm");
            }


            //取得列宽

            int[] arrColWidth = new int[ds.Columns.Count];
            foreach (DataColumn item in ds.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                for (int j = 0; j < ds.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(ds.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }

            int rowIndex = 0;
            foreach (DataRow row in ds.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 0 || rowIndex == 65535)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet();
                    }

                    #region 表头及样式
                    /* {
                         XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                         headerRow.HeightInPoints = 25;
                       //  headerRow.CreateCell(0).SetCellValue(strHeaderText);

                         HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                         ////  headStyle.Alignment = CellHorizontalAlignment.CENTER;
                         HSSFFont font = (HSSFFont)workbook.CreateFont();
                         font.FontHeightInPoints = 20;
                         font.IsBold = true;
                         headStyle.SetFont(font);
                         headerRow.GetCell(0).CellStyle = headStyle;
                         //// sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                         ////headerRow.Dispose();
                     }*/
                    #endregion


                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.IsBold = false;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in ds.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        // headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in ds.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            System.DateTime dateV;
                            System.DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                return ms;
                ms.Position = 0;
            }
        }
        /// DataSet导出到Excel的MemoryStream
    }
}