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
    /// Leave
    /// </summary>
    public partial class Leave
    {
        private readonly DAL.Leave dal = new DAL.Leave();
        public Leave()
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
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Leave model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OAnew.Model.Leave model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            return dal.Delete();
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
        public OAnew.Model.Leave GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
       

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListam()
        {
            return dal.GetListam();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListpm()
        {
            return dal.GetListpm();
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
        public List<OAnew.Model.Leave> GetModelListam()
        {
            DataSet ds = dal.GetListam();
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OAnew.Model.Leave> GetModelListpm()
        {
            DataSet ds = dal.GetListpm();
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OAnew.Model.Leave> DataTableToList(DataTable dt)
        {
            List<OAnew.Model.Leave> modelList = new List<OAnew.Model.Leave>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OAnew.Model.Leave model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OAnew.Model.Leave();
                  
                    model.UserID = dt.Rows[n]["UserID"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                 
                    model.SD= Convert.ToDateTime(dt.Rows[n]["SD"]);
                 
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
            return GetListam();
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