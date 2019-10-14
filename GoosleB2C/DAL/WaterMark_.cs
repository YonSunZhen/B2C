using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references

namespace GoosleB2C.DAL
{
    public partial class WaterMark
    {
        public bool Update_State(GoosleB2C.Model.WaterMark model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WaterMark set ");
            strSql.Append("state=@state");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.state;
            parameters[1].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
