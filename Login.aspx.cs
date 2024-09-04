using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OAnew
{
	public partial class Login : System.Web.UI.Page
	{
		Db user = new Db();
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void Button1_Click(object sender, EventArgs e)
		{


			string userName = Request["username"].ToString();
			string userPwd = Request["password"].ToString();
			/* SqlConnection Conn = new SqlConnection(user.strConn);
			 SqlCommand Cmd = new SqlCommand("select * from Users where UserName='" + userName + "' and UserPwd = '" + userPwd + "' ", Conn);
			 Conn.Open();
			 SqlDataReader Dr = Cmd.ExecuteReader();*/
			//if (Dr.Read())
			if (userName == "admin" && userPwd == "admin")
			{
				Session["User"] = userName;
				Response.Redirect("index.aspx");
			}
			else
			{
				Response.Write("<script>alert('用户名或密码错误！');history.go(-1);</script>");
			}


		}
	}
}