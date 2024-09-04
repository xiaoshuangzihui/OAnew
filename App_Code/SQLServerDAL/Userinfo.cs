﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using OAnew.DBUtility;

namespace OAnew.DAL
{
    /// <summary>
    /// 数据访问类:Userinfo
    /// </summary>
    public partial class Userinfo 
    {
        public Userinfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50)
};
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("UserName,UserPwd)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            

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
        public bool Update(OAnew.Model.Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPwd=@UserPwd,");
            
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                  
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
                    
                    new SqlParameter("@ID", SqlDbType.Int)};
           
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            
            parameters[2].Value = model.ID;

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
            strSql.Append("delete from Users ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
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
            strSql.Append("delete from Users ");
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
        public OAnew.Model.Userinfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,UserPwd from Users ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            OAnew.Model.Userinfo model = new OAnew.Model.Userinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null)
                {
                    model.UserName= ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserPwd"] != null)
                {
                    model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
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
            strSql.Append("select ID,UserName,UserPwd ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere );
            }
            strSql.Append("Order by ID");
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
            strSql.Append(" ID,UserName,UserPwd ");
            strSql.Append(" FROM Users ");
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
			parameters[0].Value = "Userinfo";
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