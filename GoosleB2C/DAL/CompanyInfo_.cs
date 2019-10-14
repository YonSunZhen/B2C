using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:CompanyInfo
    /// </summary>
    public partial class CompanyInfo
    {
        /// <summary>
		/// 根据id获得公司简介的备注和主图
		/// </summary>
		public DataSet GetDetails()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select details, mainImg, webDetails");
            strSql.Append(" FROM CompanyInfo ");
            strSql.Append(" where id = 1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool Update_one(GoosleB2C.Model.CompanyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyInfo set ");            
            strSql.Append("mainImg=@mainImg");           
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {                  
                    new SqlParameter("@mainImg", SqlDbType.VarChar,200),                    
                    new SqlParameter("@id", SqlDbType.Int,4)};          
            parameters[0].Value = model.mainImg;          
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

        public bool Update_imgs(GoosleB2C.Model.CompanyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyInfo set ");
            strSql.Append("imgs=@imgs");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@imgs", SqlDbType.VarChar,200),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.imgs;
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

        public bool Update_Other(GoosleB2C.Model.CompanyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyInfo set ");
            strSql.Append("name=@name,");
            strSql.Append("name2=@name2,");            
            strSql.Append("webDetails=@webDetails,");
            strSql.Append("details=@details,");            
            strSql.Append("remarks=@remarks");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.VarChar,50),
                    new SqlParameter("@name2", SqlDbType.VarChar,200),                    
                    new SqlParameter("@webDetails", SqlDbType.VarChar),
                    new SqlParameter("@details", SqlDbType.VarChar),                    
                    new SqlParameter("@remarks", SqlDbType.VarChar,300),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.name2;            
            parameters[2].Value = model.webDetails;
            parameters[3].Value = model.details;           
            parameters[4].Value = model.remarks;
            parameters[5].Value = model.id;
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

