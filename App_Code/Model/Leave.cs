using System;
using System.Collections.Generic;

using System.Web;

namespace OAnew.Model
{
    /// <summary>
    /// Leave:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Leave
    {
        public Leave()
        { }
        #region Model
        private int _ID;
        private string _UserID;
        private string _UserName;
       
        private DateTime _SD;
       
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
        public string UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
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
        public DateTime SD
        {
            set { _SD = value; }
            get { return _SD; }
        }
        /// <summary>
        /// 
        /// </summary>
       
        #endregion Model

    }
}