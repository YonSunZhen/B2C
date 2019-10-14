using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Roles
    /// </summary>
    public partial class Roles
    {
        public DataSet GetManagerListByRoleId(string roleid)
        {
            return dal.GetManagerListByRoleId(roleid);
        }
    }
}
