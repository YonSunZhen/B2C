using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Powers
    /// </summary>
    public partial class Powers
    {
        /// <summary>
        /// 获得角色权限数据列表
        /// </summary>
        public DataSet GetPowerList(string roleid)
        {
            return dal.GetPowerList(roleid);
        }

        public Boolean DeletePowerByRoleId(string roleid)
        {
            return dal.DeletePowerByRoleId(roleid);
        }
    }
}
