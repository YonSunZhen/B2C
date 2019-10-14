using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Managers
    /// </summary>
    public partial class Managers_
    {
        private readonly GoosleB2C.DAL.Managers_ dal = new GoosleB2C.DAL.Managers_();
        public Managers_()
        {}
        /// <summary>
        /// 通过用户名得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.Managers GetModelByName(string userName)
        {
            return dal.GetModelByName(userName);
        }
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        public DataSet GetList_RolesName()
        {
            return dal.GetList_RolesName();
        }
    }
}
