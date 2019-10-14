using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    public partial class Links
    {
        public DataSet GetListByorders()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,linkName,url,orders,tags,state,createDate,creator,remarks ");
            strSql.Append(" FROM Links order by orders ASC");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
