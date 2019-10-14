using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references

namespace GoosleB2C.DAL
{
    public partial class Message
    {
        //修改阅读时间，是否已读
        public bool Update_readTime_isRead(GoosleB2C.Model.Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Message set ");          
            strSql.Append("isRead=@isRead,");
            strSql.Append("readTime=@readTime");            
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {                    
                    new SqlParameter("@isRead", SqlDbType.Int,4),
                    new SqlParameter("@readTime", SqlDbType.DateTime),                    
                    new SqlParameter("@id", SqlDbType.VarChar,36)};           
            parameters[0].Value = model.isRead;
            parameters[1].Value = model.readTime;            
            parameters[2].Value = model.id;

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
        //修改是否已回复
        public bool isAnswer(GoosleB2C.Model.Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Message set ");
            strSql.Append("isAnswer=@isAnswer");           
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@isAnswer", SqlDbType.Int,4),                    
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = model.isAnswer;
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
