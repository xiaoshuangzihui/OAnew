using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using OAnew.DBUtility;


namespace OAnew.DAL
{
    /// <summary>
    /// 数据访问类:Leave
    /// </summary>
    public partial class Leave 
    {
        public Leave()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Leave");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Leave");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Leave model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Leave(");
            strSql.Append("ID,UserID,UserName,SD)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UserID,@UserName,@SD)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@UserID", SqlDbType.NVarChar,20),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                   
                    new SqlParameter("@SD", SqlDbType.DateTime)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.SD;
            

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OAnew.Model.Leave model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Leave set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
        
            strSql.Append("ED=@ED,");
          
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.NVarChar,20),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                
                    new SqlParameter("@SD", SqlDbType.Date),
                
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
           
            parameters[2].Value = model.SD;
         
            parameters[3].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除表格数据
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Leave ");
            strSql.Append(" where 1=1");
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Leave ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OAnew.Model.Leave GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,UserName,SD from Leave ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            OAnew.Model.Leave model = new OAnew.Model.Leave();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null)
                {
                    model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null)
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
               
                if (ds.Tables[0].Rows[0]["SD"] != null)
                {
                    //Convert.ToDateTime(dt.Rows[n]["SD"]);
                    model.SD = Convert.ToDateTime(ds.Tables[0].Rows[0]["SD"]);
                }
               
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListam()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,SD from Leave a where SD = (select min(SD) from Leave where UserID = a.UserID)group by a.UserID,a.UserName,a.SD");
            
           
            //strSql.Append("Order by ID");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListpm()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,SD from Leave a where SD = (select max(SD) from Leave where UserID = a.UserID)group by a.UserID,a.UserName,a.SD");


            //strSql.Append("Order by ID");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UserID,UserName,SD");
            strSql.Append(" FROM Leave ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Leave";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  Method
    }
}