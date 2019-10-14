using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:Roles
    /// </summary>
    public partial class Roles
    {
        public DataSet GetManagerListByRoleId(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,userName,cnName,state,userType,roleId,mobile,creator,cteateDate,remark from Managers where roleId = '");
            strSql.Append(roleid);
            strSql.Append("'");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
