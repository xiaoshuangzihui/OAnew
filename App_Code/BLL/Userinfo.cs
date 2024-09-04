using System;
using System.Collections.Generic;

using System.Web;

using OAnew.Model;

using OAnew.DAL;
using System.Text;
using System.Data;

namespace OAnew.BLL
{
    /// <summary>
    /// Userinfo
    /// </summary>
    public partial class Userinfo
    {
        private readonly DAL.Userinfo dal=new DAL.Userinfo();
        public Userinfo()
        { }
        #region  Method
        
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Userinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OAnew.Model.Userinfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OAnew.Model.Userinfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
      

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OAnew.Model.Userinfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OAnew.Model.Userinfo> DataTableToList(DataTable dt)
        {
            List<OAnew.Model.Userinfo> modelList = new List<OAnew.Model.Userinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OAnew.Model.Userinfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OAnew.Model.Userinfo();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.UserPwd = dt.Rows[n]["UserPwd"].ToString();
                 
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}