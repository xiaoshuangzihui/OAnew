using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using System.Web.DynamicData;
using System.Globalization;
using System.Text;

namespace OAnew
{
	public partial class education : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)//判断是否有文件
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请选择上传文件!')", true);
            }
            else
            {
                string myUpLoadFile = FileUpload1.FileName.ToString();//获得文件名

                DataTable dt = new DataTable("Sheet1");//DataTable对象，表名为Student
                dt.Columns.Add("人员姓名", typeof(String));
                dt.Columns.Add("人员编码", typeof(String));
                dt.Columns.Add("工号", typeof(String));
                dt.Columns.Add("出差类别", typeof(String));
                dt.Columns.Add("开始时间", typeof(DateTime));
                dt.Columns.Add("截止时间", typeof(DateTime));


                string ext = System.IO.Path.GetExtension(myUpLoadFile).ToString();
                string filename = "edu_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string realPath = Server.MapPath("~/Upload/" + filename);//虚拟路径转换成实际路径
                                                                         // string realPath = @"E:\\考勤系统\\资料文件\\02.26.xlsx";//虚拟路径转换成实际路径

                if (ext == ".xls" || ext == ".xlsx" || ext == ".XLS" || ext == ".XLSX")//判断某一文件类型
                {

                    FileUpload1.PostedFile.SaveAs(realPath);
                    //DataTable dataTable = null;
                  //  dataTable = ExcelToDataTable.ExcelDataTable(realPath, true);



                    IWorkbook workbook = null;
                    FileStream fileStream = new FileStream(realPath, FileMode.Open, FileAccess.Read);

                    if (ext == ".xls" || ext == ".XLS")
                    {
                        workbook = new HSSFWorkbook(fileStream);
                    }
                    if (ext == ".xlsx" || ext == ".XLSX")
                    {
                        workbook = new XSSFWorkbook(fileStream);
                    }


                    ISheet sheet = workbook.GetSheetAt(0);
                    int m = sheet.LastRowNum;
                    int ii = 1;
                    // r = 1,剔除表头1行
                    //  try
                    // {
                    DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                    // dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
                    dtFormat.ShortDatePattern = "yyyy/MM/dd";
                    int w = sheet.LastRowNum + 1;
                    for (int r = 1; r < sheet.LastRowNum + 1; r++)
                    {
                        //定义参数数组para

                        //创建一行获取sheet行数据
                        IRow row = sheet.GetRow(r);


                        string name = row.GetCell(9).ToString();//姓名

                        string userid = row.GetCell(10).ToString();//人员编码
                        DateTime data1;
                        DateTime data2;
                        string wq;

                        if (name != "")
                        {

                            if (row.GetCell(6).ToString() == "上午")
                            {
                               

                                data1 = Convert.ToDateTime(string.Concat(row.GetCell(4).ToString(), " ", "08:00"), dtFormat);
                            }
                            else
                            {
                                data1 = Convert.ToDateTime(string.Concat(row.GetCell(5).ToString(), " ", "12:00"), dtFormat);
                            }
                            if (row.GetCell(8).ToString() == "上午")
                            {
                                data2 = Convert.ToDateTime(string.Concat(row.GetCell(7).ToString(), " ", "12:00"), dtFormat);
                            }
                            else
                            {
                                data2 = Convert.ToDateTime(string.Concat(row.GetCell(7).ToString(), " ", "17:00"), dtFormat);
                            }





                            DataRow rr = dt.NewRow();
                            rr[0] = name;
                            rr[1] = userid;
                            rr[2] = userid;
                            rr[3] = "外出培训";
                            rr[4] = data1;
                            rr[5] = data2;
                            dt.Rows.Add(rr);
                        }

                    }
                    fileStream.Close();//关闭流


                    string saveFileName = "培训信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(saveFileName));
                    Response.ContentType = "application/vnd.ms-excel";

                    string path = Server.MapPath("~/Upload/" + saveFileName);
                    FileInfo file = new System.IO.FileInfo(path);
                    using (MemoryStream ms = ToExcel.DataTableToExcel(dt, false))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            byte[] data = ms.ToArray();
                            fs.Write(data, 0, data.Length);
                            fs.Flush();
                            data = null;

                        }

                    }
                    Response.WriteFile(file.FullName);
                    Response.End();
                    // }
                    //  catch
                    //  {
                 //   Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('转换失败!请检查表格')", true);
                    //  }


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请上传正确的文件!')", true);
                }
            }
        }
    }
}