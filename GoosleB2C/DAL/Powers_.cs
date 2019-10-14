using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:Powers
    /// </summary>
    public partial class Powers
    {
        /// <summary>
        /// 获得角色权限数据列表
        /// </summary>
        public DataSet GetPowerList(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Functions.*,Powers.* from Functions left join (select * from Powers where roleId = '");
            strSql.Append(roleid);
            strSql.Append("') as Powers on Functions.id=Powers.funId");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public Boolean DeletePowerByRoleId(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Powers where roleId = '");
            strSql.Append(roleid);
            strSql.Append("'");
            DbHelperSQL.Query(strSql.ToString());
            return true;
        }
    }
}
