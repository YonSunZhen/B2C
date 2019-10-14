using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:DeliveryTemplate
    /// </summary>
    public partial class DeliveryTemplate_
    {
        public DeliveryTemplate_()
        { }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DeliveryTemplate ");
            strSql.Append(" where id=@id ");
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
		/// 得到一个对象实体
		/// </summary>
		public GoosleB2C.Model.DeliveryTemplate GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tempName,isChoose from DeliveryTemplate ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            GoosleB2C.Model.DeliveryTemplate model = new GoosleB2C.Model.DeliveryTemplate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tempName"] != null && ds.Tables[0].Rows[0]["tempName"].ToString() != "")
                {
                    model.tempName = ds.Tables[0].Rows[0]["tempName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isChoose"] != null && ds.Tables[0].Rows[0]["isChoose"].ToString() != "")
                {
                    model.isChoose = int.Parse(ds.Tables[0].Rows[0]["isChoose"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.DeliveryTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DeliveryTemplate set ");
            strSql.Append("id=@id,");
            strSql.Append("tempName=@tempName,");
            strSql.Append("isChoose=@isChoose");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36),
                    new SqlParameter("@tempName", SqlDbType.VarChar,30),
                    new SqlParameter("@isChoose", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.tempName;
            parameters[2].Value = model.isChoose;

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
		/// 根据是否选中查找是否存在该记录
		/// </summary>
		public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DeliveryTemplate");
            strSql.Append(" where isChoose=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
