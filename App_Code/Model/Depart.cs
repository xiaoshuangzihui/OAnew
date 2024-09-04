using System;
using System.Collections.Generic;

using System.Web;

namespace OAnew.Model
{
    /// <summary>
    /// Depart:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Depart
    { 
        public Depart ()
        { }
        #region Model
        private int _id;
        private string _dept_id;
        private string _dept_OA;
       

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dept_id
        {
            set { _dept_id = value; }
            get { return _dept_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dept_OA
        {
            set { _dept_OA = value; }
            get { return _dept_OA; }
        }
       
        #endregion Model

    }
}