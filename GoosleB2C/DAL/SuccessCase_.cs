using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references

namespace GoosleB2C.DAL
{
    public partial class SuccessCase
    {
        public DataSet GetList_()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe ");
            strSql.Append(" FROM SuccessCase order by orders ASC");
        
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetOneList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe ");
            strSql.Append(" FROM SuccessCase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }    
}
