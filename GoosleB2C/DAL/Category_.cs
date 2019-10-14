using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:Category
    /// </summary>
    public partial class Category
    {
        #region  Method
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetLists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,categoryName,father,level,path,[order],seoTitle,seoKey,seoRemark");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by" + " "+"[order]" + " "+"ASC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得自增ID
        /// </summary>
        public DataSet GetID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT IDENT_CURRENT('Category') + IDENT_INCR('Category')");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetLists(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,categoryName,father,level,path,[order],seoTitle,seoKey,seoRemark,remark,updater,updateTime ");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + "[order]"+ "ASC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Adds(GoosleB2C.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Category(");
            strSql.Append("categoryName,father,level,path,img,[order],seoTitle,seoKey,seoRemark,remark,updater,updateTime)");
            strSql.Append(" values (");
            strSql.Append("@categoryName,@father,@level,@path,@img,@order,@seoTitle,@seoKey,@seoRemark,@remark,@updater,@updateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@categoryName", SqlDbType.VarChar,50),
                    new SqlParameter("@father", SqlDbType.Int,4),
                    new SqlParameter("@level", SqlDbType.Int,4),
                    new SqlParameter("@path", SqlDbType.VarChar,100),
                    new SqlParameter("@img", SqlDbType.VarChar,200),
                    new SqlParameter("@order", SqlDbType.Int,4),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoRemark", SqlDbType.VarChar,300),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@updater", SqlDbType.VarChar,30),
                    new SqlParameter("@updateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.categoryName;
            parameters[1].Value = model.father;
            parameters[2].Value = model.level;
            parameters[3].Value = model.path;
            parameters[4].Value = model.img;
            parameters[5].Value = model.order;
            parameters[6].Value = model.seoTitle;
            parameters[7].Value = model.seoKey;
            parameters[8].Value = model.seoRemark;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.updater;
            parameters[11].Value = model.updateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Updates(GoosleB2C.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Category set ");
            strSql.Append("categoryName=@categoryName,");
            strSql.Append("father=@father,");
            strSql.Append("level=@level,");
            strSql.Append("path=@path,");
            strSql.Append("img=@img,");
            strSql.Append("[order]=@order,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("seoKey=@seoKey,");
            strSql.Append("seoRemark=@seoRemark,");
            strSql.Append("remark=@remark,");
            strSql.Append("updater=@updater,");
            strSql.Append("updateTime=@updateTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@categoryName", SqlDbType.VarChar,50),
                    new SqlParameter("@father", SqlDbType.Int,4),
                    new SqlParameter("@level", SqlDbType.Int,4),
                    new SqlParameter("@path", SqlDbType.VarChar,100),
                    new SqlParameter("@img", SqlDbType.VarChar,200),
                    new SqlParameter("@order", SqlDbType.Int,4),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoRemark", SqlDbType.VarChar,300),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@updater", SqlDbType.VarChar,30),
                    new SqlParameter("@updateTime", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.categoryName;
            parameters[1].Value = model.father;
            parameters[2].Value = model.level;
            parameters[3].Value = model.path;
            parameters[4].Value = model.img;
            parameters[5].Value = model.order;
            parameters[6].Value = model.seoTitle;
            parameters[7].Value = model.seoKey;
            parameters[8].Value = model.seoRemark;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.updater;
            parameters[11].Value = model.updateTime;
            parameters[12].Value = model.id;

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
        public GoosleB2C.Model.Category GetModels(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,categoryName,father,level,path,img,[order],seoTitle,seoKey,seoRemark,remark,updater,updateTime from Category ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GoosleB2C.Model.Category model = new GoosleB2C.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["categoryName"] != null && ds.Tables[0].Rows[0]["categoryName"].ToString() != "")
                {
                    model.categoryName = ds.Tables[0].Rows[0]["categoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["father"] != null && ds.Tables[0].Rows[0]["father"].ToString() != "")
                {
                    model.father = int.Parse(ds.Tables[0].Rows[0]["father"].ToString());
                }
                if (ds.Tables[0].Rows[0]["level"] != null && ds.Tables[0].Rows[0]["level"].ToString() != "")
                {
                    model.level = int.Parse(ds.Tables[0].Rows[0]["level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["path"] != null && ds.Tables[0].Rows[0]["path"].ToString() != "")
                {
                    model.path = ds.Tables[0].Rows[0]["path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img"] != null && ds.Tables[0].Rows[0]["img"].ToString() != "")
                {
                    model.img = ds.Tables[0].Rows[0]["img"].ToString();
                }
                if (ds.Tables[0].Rows[0]["order"] != null && ds.Tables[0].Rows[0]["order"].ToString() != "")
                {
                    model.order = int.Parse(ds.Tables[0].Rows[0]["order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["seoTitle"] != null && ds.Tables[0].Rows[0]["seoTitle"].ToString() != "")
                {
                    model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoKey"] != null && ds.Tables[0].Rows[0]["seoKey"].ToString() != "")
                {
                    model.seoKey = ds.Tables[0].Rows[0]["seoKey"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoRemark"] != null && ds.Tables[0].Rows[0]["seoRemark"].ToString() != "")
                {
                    model.seoRemark = ds.Tables[0].Rows[0]["seoRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updater"] != null && ds.Tables[0].Rows[0]["updater"].ToString() != "")
                {
                    model.updater = ds.Tables[0].Rows[0]["updater"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updateTime"] != null && ds.Tables[0].Rows[0]["updateTime"].ToString() != "")
                {
                    model.updateTime = DateTime.Parse(ds.Tables[0].Rows[0]["updateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList_()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,categoryName,father,level,path,[order],seoTitle,seoKey,seoRemark");
            strSql.Append(" FROM Category ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
