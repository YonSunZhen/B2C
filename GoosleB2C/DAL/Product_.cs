using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references

namespace GoosleB2C.DAL
{
    public partial class Product
    {
        public DataSet QueryDeliveryTemp()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, tempName");
            strSql.Append(" FROM DeliveryTemplate ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
