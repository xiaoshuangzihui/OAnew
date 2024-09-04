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
	public partial class add : System.Web.UI.Page
	{
        DataTable t3 = new DataTable();
       BLL.Leave bll = new BLL.Leave();
        protected void Page_Load(object sender, EventArgs e)
        {


           /*if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }*/

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

                dt.Columns.Add("刷卡时间", typeof(DateTime));
                dt.Columns.Add("补刷原因", typeof(String));

                string ext = System.IO.Path.GetExtension(myUpLoadFile).ToString();
                string filename = "Leave_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string realPath = Server.MapPath("~/Upload/" + filename);//虚拟路径转换成实际路径
                                                                         // string realPath = @"E:\\考勤系统\\资料文件\\02.26.xlsx";//虚拟路径转换成实际路径
                if (ext == ".xls" || ext == ".xlsx" || ext == ".XLS" || ext == ".XLSX")//判断某一文件类型
                {

                    FileUpload1.PostedFile.SaveAs(realPath);
                   // DataTable dataTable = null;
                   // dataTable = ExcelToDataTable.ExcelDataTable(realPath, true);



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
                  
                    try
                    {
                        DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                        dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
                        int w = sheet.LastRowNum + 1;
                        for (int r = 2; r < sheet.LastRowNum + 1; r++)
                        {
                            //定义参数数组para

                            //创建一行获取sheet行数据
                            IRow row = sheet.GetRow(r);


                            string name = row.GetCell(1).ToString();//姓名

                            string userid = row.GetCell(4).ToString();//人员编码
                            string state = row.GetCell(8).ToString();//打卡状态
                            if (state != "未打卡" && state != "" && state != "--")
                            {


                                string dataday = row.GetCell(0).ToString().Split(' ')[0];//日期
                                DateTime date = DateTime.Parse(dataday);

                                string time = row.GetCell(8).ToString();//时间
                                if (time.Contains("次日"))
                                {
                                    time = time.Substring(2);
                                    date = date.AddDays(+1);
                                }

                                // DateTime time = Convert.ToDateTime(row.GetCell(3).ToString(), dtFormat);
                                DataRow rr = dt.NewRow();
                                rr[0] = name;
                                rr[1] = userid;
                                //rr[2] = Convert.ToDateTime(string.Concat(date.ToString(), " ", time), dtFormat);
                                rr[2] = Convert.ToDateTime(string.Concat(date.ToShortDateString(), " ", time), dtFormat);

                                rr[3] = "企业微信导入";
                                dt.Rows.Add(rr);
                            }

                        }
                        fileStream.Close();//关闭流


                        string saveFileName = "补卡信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('转换失败!请检查表格')", true);
                    }


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请上传正确的文件!')", true);
                }

            }









        }
    }

}