using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Functions
	/// </summary>
	public partial class Functions
	{
		public Functions()
		{}
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Functions");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.Functions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Functions(");
            strSql.Append("id,functionName,url,father,funLevel,funOrder,funType,img1,img2,intro,remark)");
            strSql.Append(" values (");
            strSql.Append("@id,@functionName,@url,@father,@funLevel,@funOrder,@funType,@img1,@img2,@intro,@remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36),
                    new SqlParameter("@functionName", SqlDbType.VarChar,30),
                    new SqlParameter("@url", SqlDbType.VarChar,120),
                    new SqlParameter("@father", SqlDbType.VarChar,36),
                    new SqlParameter("@funLevel", SqlDbType.SmallInt,2),
                    new SqlParameter("@funOrder", SqlDbType.SmallInt,2),
                    new SqlParameter("@funType", SqlDbType.SmallInt,2),
                    new SqlParameter("@img1", SqlDbType.VarChar,120),
                    new SqlParameter("@img2", SqlDbType.VarChar,120),
                    new SqlParameter("@intro", SqlDbType.VarChar,200),
                    new SqlParameter("@remark", SqlDbType.VarChar,300)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.functionName;
            parameters[2].Value = model.url;
            parameters[3].Value = model.father;
            parameters[4].Value = model.funLevel;
            parameters[5].Value = model.funOrder;
            parameters[6].Value = model.funType;
            parameters[7].Value = model.img1;
            parameters[8].Value = model.img2;
            parameters[9].Value = model.intro;
            parameters[10].Value = model.remark;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(GoosleB2C.Model.Functions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Functions set ");
            strSql.Append("functionName=@functionName,");
            strSql.Append("url=@url,");
            strSql.Append("father=@father,");
            strSql.Append("funLevel=@funLevel,");
            strSql.Append("funOrder=@funOrder,");
            strSql.Append("funType=@funType,");
            strSql.Append("img1=@img1,");
            strSql.Append("img2=@img2,");
            strSql.Append("intro=@intro,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@functionName", SqlDbType.VarChar,30),
                    new SqlParameter("@url", SqlDbType.VarChar,120),
                    new SqlParameter("@father", SqlDbType.VarChar,36),
                    new SqlParameter("@funLevel", SqlDbType.SmallInt,2),
                    new SqlParameter("@funOrder", SqlDbType.SmallInt,2),
                    new SqlParameter("@funType", SqlDbType.SmallInt,2),
                    new SqlParameter("@img1", SqlDbType.VarChar,120),
                    new SqlParameter("@img2", SqlDbType.VarChar,120),
                    new SqlParameter("@intro", SqlDbType.VarChar,200),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = model.functionName;
            parameters[1].Value = model.url;
            parameters[2].Value = model.father;
            parameters[3].Value = model.funLevel;
            parameters[4].Value = model.funOrder;
            parameters[5].Value = model.funType;
            parameters[6].Value = model.img1;
            parameters[7].Value = model.img2;
            parameters[8].Value = model.intro;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Functions ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Functions ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public GoosleB2C.Model.Functions GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,functionName,url,father,funLevel,funOrder,funType,img1,img2,intro,remark from Functions ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            GoosleB2C.Model.Functions model = new GoosleB2C.Model.Functions();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["functionName"] != null && ds.Tables[0].Rows[0]["functionName"].ToString() != "")
                {
                    model.functionName = ds.Tables[0].Rows[0]["functionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["url"] != null && ds.Tables[0].Rows[0]["url"].ToString() != "")
                {
                    model.url = ds.Tables[0].Rows[0]["url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["father"] != null && ds.Tables[0].Rows[0]["father"].ToString() != "")
                {
                    model.father = ds.Tables[0].Rows[0]["father"].ToString();
                }
                if (ds.Tables[0].Rows[0]["funLevel"] != null && ds.Tables[0].Rows[0]["funLevel"].ToString() != "")
                {
                    model.funLevel = int.Parse(ds.Tables[0].Rows[0]["funLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["funOrder"] != null && ds.Tables[0].Rows[0]["funOrder"].ToString() != "")
                {
                    model.funOrder = int.Parse(ds.Tables[0].Rows[0]["funOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["funType"] != null && ds.Tables[0].Rows[0]["funType"].ToString() != "")
                {
                    model.funType = int.Parse(ds.Tables[0].Rows[0]["funType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img1"] != null && ds.Tables[0].Rows[0]["img1"].ToString() != "")
                {
                    model.img1 = ds.Tables[0].Rows[0]["img1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img2"] != null && ds.Tables[0].Rows[0]["img2"].ToString() != "")
                {
                    model.img2 = ds.Tables[0].Rows[0]["img2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["intro"] != null && ds.Tables[0].Rows[0]["intro"].ToString() != "")
                {
                    model.intro = ds.Tables[0].Rows[0]["intro"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,functionName,url,father,funLevel,funOrder,funType,img1,img2,intro,remark ");
            strSql.Append(" FROM Functions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,functionName,url,father,funLevel,funOrder,funType,img1,img2,intro,remark ");
            strSql.Append(" FROM Functions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Functions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Functions T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Functions";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  Method
    }
}

