using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Functions
    /// </summary>
    public partial class Functions
    {
        
        public DataSet GetList_FunctionName(string strWhere)
        {
            return dal.GetList_FunctionName(strWhere);
        }

        public DataSet GetList_father(string strWhere)
        {
            return dal.GetList_father(strWhere);
        }
    }
}
