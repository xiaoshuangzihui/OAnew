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
using System;

namespace OAnew
{
	public partial class inbusiness : System.Web.UI.Page
	{
        DataTable t3 = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {


            /* if (Session["User"] == null)
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
                dt.Columns.Add("工号", typeof(String));

                dt.Columns.Add("出差类别", typeof(String));
                dt.Columns.Add("开始时间", typeof(DateTime));
                dt.Columns.Add("截止时间", typeof(DateTime));


                string ext = System.IO.Path.GetExtension(myUpLoadFile).ToString();
                string filename = "Trip_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string realPath = Server.MapPath("~/Upload/" + filename);//虚拟路径转换成实际路径
                if (ext == ".xls" || ext == ".xlsx" || ext == ".XLS" || ext == ".XLSX")//判断某一文件类型
                {

                    FileUpload1.PostedFile.SaveAs(realPath);
                    
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
                    // TextBox1.Text = "1";

                    ISheet sheet = workbook.GetSheetAt(0);
                    int ii = 1;
                    //r = 1,剔除表头1行
                    string riqi = null;

                    string user = null;
                    try
                    {
                        for (int r = 1; r < sheet.LastRowNum + 1; r++)
                        {
                            //定义参数数组para

                            //创建一行获取sheet行数据
                            IRow row = sheet.GetRow(r);

                            string name = row.GetCell(2).ToString();//姓名

                            string userid = row.GetCell(3).ToString();//人员编码


                            string type = "本地公出";//请假类别

                            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                            dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm";
                            string timestart = null;
                            string timeend = null;
                            if (row.GetCell(8).ToString().Trim() == "上午")
                            {
                                timestart = "08:00";
                            }
                            else if (row.GetCell(8).ToString().Trim() == "下午")
                            {
                                timestart = "12:30";
                            }
                            if (row.GetCell(11).ToString().Trim() == "上午")
                            {
                                timeend = "12:30";
                            }
                            else if (row.GetCell(11).ToString().Trim() == "下午")
                            {
                                timeend = "17:00";
                            }



                            DateTime sd = Convert.ToDateTime(string.Concat(row.GetCell(6).ToString(), " ", timestart), dtFormat);
                            DateTime ed = Convert.ToDateTime(string.Concat(row.GetCell(9).ToString(), " ", timeend), dtFormat);


                            if (row.GetCell(15).ToString() == "归档")
                            {

                                if (user != userid || row.GetCell(13).ToString() == "" || row.GetCell(6).ToString() != riqi)
                                {
                                    DataRow rr = dt.NewRow();
                                    rr[0] = name; rr[1] = userid; rr[2] = userid;
                                    rr[3] = type; rr[4] = sd; rr[5] = ed;
                                    dt.Rows.Add(rr);//向DataTable增加第一行记录
                                }
                                if (row.GetCell(13).ToString() != "" && row.GetCell(14).ToString() != userid)
                                {
                                    string companyid = row.GetCell(14).ToString();
                                    string companyname = row.GetCell(13).ToString();
                                    DataRow rr1 = dt.NewRow();
                                    rr1[0] = companyname; rr1[1] = companyid; rr1[2] = companyid;
                                    rr1[3] = type; rr1[4] = sd; rr1[5] = ed;
                                    dt.Rows.Add(rr1);//向DataTable增加第一行记录
                                }
                            }


                            user = row.GetCell(3).ToString();//员工号
                            riqi = row.GetCell(6).ToString();


                            ii++;
                        }
                        fileStream.Close();//关闭流


                        string saveFileName = "本地公出_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

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
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('转换失败!')", true);
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