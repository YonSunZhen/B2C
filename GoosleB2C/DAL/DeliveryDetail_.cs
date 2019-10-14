using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:DeliveryDetail
    /// </summary>
    public partial class DeliveryDetail_
    {
        public DeliveryDetail_()
        {

        }

        /// <summary>
		/// 根据运费模板id删除数据
		/// </summary>
		public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DeliveryDetail ");
            strSql.Append(" where tempid=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

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

        /// <summary>
		/// 通过tempId获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DeliveryDetail.id,tempId,provinceId,firstWeight,addedWeight, Regions.regionName");
            strSql.Append(" FROM DeliveryDetail LEFT JOIN Regions");
            strSql.Append(" ON  DeliveryDetail.provinceId = Regions.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
		/// 通过tempId获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" DeliveryDetail.id,tempId,provinceId,firstWeight,addedWeight, Regions.regionName ");
            strSql.Append(" FROM DeliveryDetail LEFT JOIN Regions");
            strSql.Append(" ON  DeliveryDetail.provinceId = Regions.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
