using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//

namespace OAnew
{
 internal class Db
    {
        //public string strConn = Configuration.AppSettings["connStr"];
        public string strConn = ConfigurationManager.AppSettings["ConnectionString"];
    }
}