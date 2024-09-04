using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAnew.Model
{
    /// <summary>
    /// Userinfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Userinfo
    {
        public Userinfo()
        { }
        #region Model
        private int _ID;
        private string _UserName;
        private string _UserPwd;
        
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPwd
        {
            set { _UserPwd = value; }
            get { return _UserPwd; }
        }
       
       
        #endregion Model

    }
}