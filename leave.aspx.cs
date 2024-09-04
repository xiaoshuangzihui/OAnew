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
	public partial class WebForm3 : System.Web.UI.Page
	{
		DataTable t3 = new DataTable();
		BLL.Depart bll = new BLL.Depart();
		protected void Page_Load(object sender, EventArgs e)
		{


			//  if (Session["User"] == null)
			// {
			// Response.Redirect("Login.aspx");
			//  }

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
				dt.Columns.Add("部门", typeof(String));
				dt.Columns.Add("请假类别", typeof(String));
				dt.Columns.Add("开始时间", typeof(DateTime));
				dt.Columns.Add("截止时间", typeof(DateTime));
				dt.Columns.Add("请假时间类型", typeof(String));

				string ext = System.IO.Path.GetExtension(myUpLoadFile).ToString();
				string filename = "Leave_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
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


					ISheet sheet = workbook.GetSheetAt(0);
					int ii = 1;

					//	try
					//{

					for (int r = 1; r < sheet.LastRowNum; r++)
					{
						//定义参数数组para
						IRow row = sheet.GetRow(r);
						if (row.GetCell(2).ToString() != " ")
						{
							//创建一行获取sheet行数据

							string name = row.GetCell(3).ToString();//姓名

							string userid = row.GetCell(2).ToString();//人员编码

							string dept = row.GetCell(4).ToString().Trim();//部门
							string type = row.GetCell(6).ToString();//请假类别
							if (type == "男方护理假")
							{
								type = "护理假";
							}
						//	string deptu8 = "1001";
							string deptu8 = null;
							try
							{
								deptu8 = bll.GetModel(dept).dept_id;

							}
							catch
							{
								//Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('转换失败!')", true);
							}


							DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
							dtFormat.ShortDatePattern = "yyyy/MM/dd";

							string timetype = null;


							DateTime sd = Convert.ToDateTime(row.GetCell(7).ToString(), dtFormat);
							DateTime ed = Convert.ToDateTime(row.GetCell(10).ToString(), dtFormat);
							double daysum = 0;
							//try
							//{
								 
							//}
							//catch
							//{
								
								//Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert("+ name + ")", true);
						//	}


							if (sd <= ed && row.GetCell(14).ToString() == "归档")
							{
								daysum = Convert.ToDouble(row.GetCell(13).ToString());
								DataRow rr = dt.NewRow();
								rr[0] = name;
								rr[1] = userid;
								rr[2] = userid;
								rr[3] = deptu8;
								rr[4] = type;
								if (daysum % 1 == 0)
								{
									if (row.GetCell(9).ToString() == "上午")
									{
										timetype = "整天";
										rr[5] = sd;
										rr[6] = ed;
										rr[7] = timetype;
										dt.Rows.Add(rr);//向DataTable增加第一行记录
									}
									else if (row.GetCell(9).ToString() == "下午")
									{
										if (daysum > 1)
										{
											timetype = "下午假";

											rr[5] = sd;
											rr[6] = sd;
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录
											DataRow rrr = dt.NewRow();
											rrr[0] = name;
											rrr[1] = userid;
											rrr[2] = userid;
											rrr[3] = deptu8;
											rrr[4] = type;
											timetype = "整天";
											rrr[5] = sd.AddDays(1);
											rrr[6] = ed.AddDays(-1);
											rrr[7] = timetype;
											dt.Rows.Add(rrr);//向DataTable增加第一行记录
											DataRow r1 = dt.NewRow();
											r1[0] = name;
											r1[1] = userid;
											r1[2] = userid;
											r1[3] = deptu8;
											r1[4] = type;
											timetype = "上午假";
											r1[5] = ed;
											r1[6] = ed;
											r1[7] = timetype;
											dt.Rows.Add(r1);//向DataTable增加第一行记录
										}
										else
										{
											timetype = "下午假";

											rr[5] = sd;
											rr[6] = sd;
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录

											DataRow r1 = dt.NewRow();
											r1[0] = name;
											r1[1] = userid;
											r1[2] = userid;
											r1[3] = deptu8;
											r1[4] = type;
											timetype = "上午假";
											r1[5] = ed;
											r1[6] = ed;
											r1[7] = timetype;
											dt.Rows.Add(r1);//向DataTable增加第一行记录
										}
									}
								}
								else
								{
									if (daysum > 1)
									{
										if (row.GetCell(9).ToString() == "下午")
										{
											timetype = "下午假";

											rr[5] = sd;
											rr[6] = sd;
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录

											DataRow rrr = dt.NewRow();
											rrr[0] = name;
											rrr[1] = userid;
											rrr[2] = userid;
											rrr[3] = deptu8;
											rrr[4] = type;
											timetype = "整天";
											rrr[5] = sd.AddDays(1);
											rrr[6] = ed;
											rrr[7] = timetype;
											dt.Rows.Add(rrr);//向DataTable增加第一行记录

										}
										else
										{
											timetype = "整天";

											rr[5] = sd;
											rr[6] = ed.AddDays(-1);
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录

											DataRow rrr = dt.NewRow();
											rrr[0] = name;
											rrr[1] = userid;
											rrr[2] = userid;
											rrr[3] = deptu8;
											rrr[4] = type;
											timetype = "上午假";
											rrr[5] = ed;
											rrr[6] = ed;
											rrr[7] = timetype;
											dt.Rows.Add(rrr);//向DataTable增加第一行记录
										}

									}
									else
									{
										if (row.GetCell(9).ToString() == "上午" && row.GetCell(12).ToString() == "上午")
										{
											timetype = "上午假";
											rr[5] = sd;
											rr[6] = ed;
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录
										}
										if (row.GetCell(9).ToString() == "下午" && row.GetCell(12).ToString() == "下午")
										{
											timetype = "下午假";
											rr[5] = sd;
											rr[6] = ed;
											rr[7] = timetype;
											dt.Rows.Add(rr);//向DataTable增加第一行记录
										}
									}

								}




							}
							ii++;
						}
					}
					fileStream.Close();//关闭流


					string saveFileName = "请假信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
					Response.Clear();
					Response.BufferOutput = false;
					Response.ContentEncoding = System.Text.Encoding.UTF8;
					Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(saveFileName));
					Response.ContentType = "application/vnd.ms-excel";

					string path = Server.MapPath("~/Upload/" + saveFileName);
					FileInfo file = new System.IO.FileInfo(path);
					using (MemoryStream ms = ToExcel.DataTableToExcel(dt, true))
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
					//}
					// catch
					// {
					//  Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('转换失败!')", true);
					// }


				}
				else
				{
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请上传正确的文件!')", true);
				}
			}
		}
	}
}