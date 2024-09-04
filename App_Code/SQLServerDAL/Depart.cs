using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using OAnew.DBUtility;


namespace OAnew.DAL
{
    /// <summary>
    /// 数据访问类:Depart
    /// </summary>
    public partial class Depart 
    {
        public Depart()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Depart");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string dept_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Department");
            strSql.Append(" where dept_id=@dept_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@dept_id", SqlDbType.VarChar,20),
                    
};
            parameters[0].Value = dept_id;
           
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Depart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into department(");
            strSql.Append("dept_id,dept_OA)");
            strSql.Append(" values (");
            strSql.Append("@dept_id,@dept_OA)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@dept_id", SqlDbType.VarChar,20),
                    new SqlParameter("@dept_OA", SqlDbType.NVarChar,50)};

          
           
            parameters[0].Value = model.dept_id;
            parameters[1].Value = model.dept_OA;
           

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
        public bool Update(OAnew.Model.Depart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update department set ");
          
            strSql.Append("dept_id=@dept_id,");
            strSql.Append("dept_OA=@dept_OA ");	
			strSql.Append(" where id = @id");
			SqlParameter[] parameters = {
                    new SqlParameter("@dept_id", SqlDbType.VarChar,20),
                 
                    new SqlParameter("@dept_OA", SqlDbType.NVarChar,50),
                   
                    new SqlParameter("@id", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = model.dept_id;
            parameters[1].Value = model.dept_OA;


			parameters[2].Value = model.id.ToString() ;


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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from department ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from department ");
            strSql.Append(" where id in (" + IDlist + ")  ");
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
        public OAnew.Model.Depart GetModel(string dept_OA)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 id,dept_id,dept_OA from department ");
                strSql.Append("where dept_OA = @dept_OA");
                SqlParameter[] parameters = {
                    new SqlParameter("@dept_OA", SqlDbType.NVarChar,50)
};
                parameters[0].Value = dept_OA;

                OAnew.Model.Depart model = new OAnew.Model.Depart();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                    {
                        model.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                    }
                    if (ds.Tables[0].Rows[0]["dept_id"].ToString() != "")
                    {
                        model.dept_id = ds.Tables[0].Rows[0]["dept_id"].ToString().Trim(); ;
                    }
                    if (ds.Tables[0].Rows[0]["dept_OA"].ToString() != "")
                    {
                        model.dept_OA = ds.Tables[0].Rows[0]["dept_OA"].ToString().Trim();
                    }


                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
           
        }
       

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OAnew.Model.Depart GetModelid(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dept_id,dept_OA from department ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.NVarChar)
};
            parameters[0].Value = id;

            OAnew.Model.Depart model = new OAnew.Model.Depart();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
					model.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                }
                if (ds.Tables[0].Rows[0]["dept_id"].ToString() != "")
                {
                    model.dept_id = ds.Tables[0].Rows[0]["dept_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["dept_OA"].ToString() != "")
                {
                    model.dept_OA = ds.Tables[0].Rows[0]["dept_OA"].ToString();
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct id, dept_id,dept_OA  ");
            strSql.Append(" FROM department where dept_U8='1' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere+"");
            }
            strSql.Append("Order by dept_id");
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
            strSql.Append("id, dept_id,dept_OA");
            strSql.Append(" FROM department ");
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
			parameters[0].Value = "Depart";
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