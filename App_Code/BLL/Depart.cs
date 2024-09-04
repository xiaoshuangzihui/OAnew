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
    /// Depart
    /// </summary>
    public partial class Depart
    {
       // private readonly IDepart dal = DataAccess.CreateDepart();
        private readonly DAL.Depart dal = new DAL.Depart();
        public Depart()
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
        public bool Exists(string dept_id)
        {
            return dal.Exists(dept_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OAnew.Model.Depart model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OAnew.Model.Depart model)
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
        public OAnew.Model.Depart GetModel(string id)
        {

            return dal.GetModel(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OAnew.Model.Depart GetModelid(int id)
        {

            return dal.GetModelid(id);
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
        public List<OAnew.Model.Depart> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OAnew.Model.Depart> DataTableToList(DataTable dt)
        {
            List<OAnew.Model.Depart> modelList = new List<OAnew.Model.Depart>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OAnew.Model.Depart model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OAnew.Model.Depart();
                    //if (dt.Rows[n]["id"].ToString() != "")
                   // {
                        model.id = Convert.ToInt32(dt.Rows[n]["id"]);
                   // }
                    model.dept_id =dt.Rows[n]["dept_id"].ToString();
                    model.dept_OA  = dt.Rows[n]["dept_OA"].ToString();
                   
                  
                  
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