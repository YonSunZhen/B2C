using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    public partial class Users
    {
        public DataSet GetList_(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Users.uId,Users.UserName,Users.PassWord,Users.wId,Users.wName,Users.wImg,Users.wCode,Users.realName,Users.sex,Users.phone,Users.state,Users.levelId,Users.points,Users.remak,Users.fund,Users.loginTime,Users.loginIp,Users.lastTime,Users.lastIp,UserLevel.levelName ");
            strSql.Append(" FROM Users LEFT JOIN UserLevel ON Users.levelId=UserLevel.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetlevelPoint()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,levelName,levelPiont FROM UserLevel ORDER BY levelPiont");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList_LevelName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id ,levelName FROM UserLevel");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetPoints()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select points FROM Users");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 微信ID查询是否存在该记录
        /// ADDDATE：2018.8.13
        /// </summary>
        public bool WxExists(string wxid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where wId=@wId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@wId", SqlDbType.VarChar,100)};
            parameters[0].Value = wxid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

    }
}
