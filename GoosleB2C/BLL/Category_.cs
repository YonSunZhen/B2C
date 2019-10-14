using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Category
    /// </summary>
    public partial class Category
    {
        private readonly GoosleB2C.DAL.Category dal2 = new GoosleB2C.DAL.Category();

        #region  Method
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTree()
        {
            return GetLists("");
        }
        public DataSet GetLists(string strWhere)
        {
            return dal2.GetLists(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Adds(GoosleB2C.Model.Category model)
        {
            return dal2.Adds(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Updates(GoosleB2C.Model.Category model)
        {
            return dal2.Updates(model);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetLists(int Top, string strWhere, string filedOrder)
        {
            return dal2.GetLists(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.Category GetModels(int id)
        {
            return dal2.GetModels(id);
        }

        /// <summary>
        /// 获得自增ID
        /// </summary>
        public DataSet GetID()
        {
            return dal2.GetID();
        }

        public DataSet GetList_()
        {
            return dal.GetList_();
        }

        #endregion  Method
    }
}
