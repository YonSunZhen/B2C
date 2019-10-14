using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:Functions
    /// </summary>
    public partial class Functions
    {

        public DataSet GetList_FunctionName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,functionName");
            strSql.Append(" FROM Functions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList_father(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select father");
            strSql.Append(" FROM Functions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }




    }
}
