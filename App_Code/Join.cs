using System;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;

using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace OAnew
{
    public class DataTableJoin
    {

        /// <summary>
        /// 建立两内存表的链接
        /// </summary>
        /// <param name="dt1">左表（主表）</param>
        /// <param name="dt2">右表</param>
        /// <param name="FJC">左表中关联的字段名（字符串）</param>
        /// <param name="SJC">右表中关联的字段名（字符串）</param>
        /// <returns></returns>
        public static DataTable Join(DataTable dt1, DataTable dt2, DataColumn[] FJC, DataColumn[] SJC)
        {
            //创建一个新的DataTable
            DataTable table = new DataTable("Join");

            // Use a DataSet to leverage DataRelation
            using (DataSet datads = new DataSet())
            {
                //把DataTable Copy到DataSet中
                dt1.TableName = "table";dt2.TableName = "table1";//没有这一步会报错”ds已在dataset中“
                datads.Tables.AddRange(new DataTable[] { dt1.Copy(), dt2.Copy() });

                DataColumn[] First_columns = new DataColumn[FJC.Length];
                for (int i = 0; i < First_columns.Length; i++)
                {
                    First_columns[i] = datads.Tables[0].Columns[FJC[i].ColumnName];
                }

                DataColumn[] Second_columns = new DataColumn[SJC.Length];
                for (int i = 0; i < Second_columns.Length; i++)
                {
                    Second_columns[i] = datads.Tables[1].Columns[SJC[i].ColumnName];
                }

                //创建关联
                DataRelation r = new DataRelation(string.Empty, First_columns, Second_columns, false);
                datads.Relations.Add(r);

                //为关联表创建列
                for (int i = 0; i < dt1.Columns.Count; i++)
                {
                    table.Columns.Add(dt1.Columns[i].ColumnName, dt1.Columns[i].DataType);
                }

                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    //看看有没有重复的列，如果有在第二个DataTable的Column的列明后加_Second
                    if (!table.Columns.Contains(dt2.Columns[i].ColumnName))
                        table.Columns.Add(dt2.Columns[i].ColumnName, dt2.Columns[i].DataType);
                    else
                        table.Columns.Add(dt2.Columns[i].ColumnName + "_Second", dt2.Columns[i].DataType);
                }

                table.BeginLoadData();
                int itable2Colomns = datads.Tables[1].Rows[0].ItemArray.Length;
                foreach (DataRow firstrow in datads.Tables[0].Rows)
                {
                    //得到行的数据
                    DataRow[] childrows = firstrow.GetChildRows(r);//第二个表关联的行
                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;
                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;
                            object[] joinarray = new object[parentarray.Length + secondarray.Length];
                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                            table.LoadDataRow(joinarray, true);
                        }

                    }
                    else//如果有外连接(Left Join)添加这部分代码
                    {
                        object[] table1array = firstrow.ItemArray;//Table1
                        object[] table2array = new object[itable2Colomns];
                        object[] joinarray = new object[table1array.Length + itable2Colomns];
                        Array.Copy(table1array, 0, joinarray, 0, table1array.Length);
                        Array.Copy(table2array, 0, joinarray, table1array.Length, itable2Colomns);
                        table.LoadDataRow(joinarray, true);
                        DataColumn[] dc = new DataColumn[2];
                        dc[0] = new DataColumn("");
                    }
                }
                table.EndLoadData();
            }
            return table;//***在此处打断点，程序运行后点击查看即可观察到结果
        }
        /// <summary>
        /// 重载1
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="FJC"></param>
        /// <param name="SJC"></param>
        /// <returns></returns>
        public static DataTable Join(DataTable dt1, DataTable dt2, DataColumn FJC, DataColumn SJC)
        {
            return Join(dt1, dt2, new DataColumn[] { FJC }, new DataColumn[] { SJC });
        }

        /// <summary>
        /// 重载2
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="FJC"></param>
        /// <param name="SJC"></param>
        /// <returns></returns>
        public static DataTable Join(DataTable dt1, DataTable dt2, string FJC, string SJC)
        {
            return Join(dt1, dt2, new DataColumn[] { dt1.Columns[FJC] }, new DataColumn[] { dt1.Columns[SJC] });
        }

    }
}