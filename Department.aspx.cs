using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace OAnew
{
	public partial class Department : System.Web.UI.Page
	{
       BLL.Depart bll = new BLL.Depart();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["User"] == null)
            //{
            // Response.Redirect("Login.aspx");
            //}
            if (!Page.IsPostBack)
            {
                //第一次加载进行的操作
                BindData();
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
            }


        }
        public void BindData()
        {


            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (user.Value.Trim() != "")
            {
                strWhere.AppendFormat("dept_OA  like '%{0}%' ", user.Value.Trim());
            }

            ds = bll.GetList(strWhere.ToString());
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                int id = Convert.ToInt32(this.GridView1.DataKeys[i].Value);

                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked == true)
                {

                    bll.Delete(id);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('删除成功!')", true);
                }
            }

            BindData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "background:#FFF");

            try
            {
                e.Row.Cells[4].ToolTip = e.Row.Cells[4].Text;
                if (e.Row.Cells[4].Text.Length > 8)
                {
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text.Substring(0, 8) + "...";
                }
            }
            catch { }

        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();

        }
    }
}