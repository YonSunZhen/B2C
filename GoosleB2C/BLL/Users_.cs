using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    public partial class Users
    {
        //private readonly GoosleB2C.DAL.Users_ dal = new GoosleB2C.DAL.Users_();

        public DataSet GetList_(string strWhere) {
            return dal.GetList_(strWhere);
        }
        public DataSet GetlevelPoint()
        {
            return dal.GetlevelPoint();
        }
        public DataSet GetList_LevelName()
        {
            return dal.GetList_LevelName();
        }
        public DataSet GetPoints()
        {
            return dal.GetPoints();
        }
        public bool WxExists(string wxid)
        {
            return dal.WxExists(wxid);
        }
    }
}
