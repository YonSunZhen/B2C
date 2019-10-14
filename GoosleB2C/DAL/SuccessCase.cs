using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:SuccessCase
	/// </summary>
	public partial class SuccessCase
	{
		public SuccessCase()
		{}
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SuccessCase");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,36)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.SuccessCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SuccessCase(");
            strSql.Append("Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe)");
            strSql.Append(" values (");
            strSql.Append("@Id,@state,@title,@orders,@mainImg,@summay,@webContent,@content,@imgs,@readCount,@remark,@creator,@createTime,@modifier,@modifyDate,@seoTitle,@seoKey,@seoDescribe)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,36),
                    new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@title", SqlDbType.VarChar,200),
                    new SqlParameter("@orders", SqlDbType.Int,4),
                    new SqlParameter("@mainImg", SqlDbType.VarChar,200),
                    new SqlParameter("@summay", SqlDbType.VarChar,2000),
                    new SqlParameter("@webContent", SqlDbType.VarChar),
                    new SqlParameter("@content", SqlDbType.VarChar),
                    new SqlParameter("@imgs", SqlDbType.VarChar),
                    new SqlParameter("@readCount", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@creator", SqlDbType.VarChar,20),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@modifier", SqlDbType.VarChar,20),
                    new SqlParameter("@modifyDate", SqlDbType.DateTime),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoDescribe", SqlDbType.VarChar,500)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.state;
            parameters[2].Value = model.title;
            parameters[3].Value = model.orders;
            parameters[4].Value = model.mainImg;
            parameters[5].Value = model.summay;
            parameters[6].Value = model.webContent;
            parameters[7].Value = model.content;
            parameters[8].Value = model.imgs;
            parameters[9].Value = model.readCount;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.creator;
            parameters[12].Value = model.createTime;
            parameters[13].Value = model.modifier;
            parameters[14].Value = model.modifyDate;
            parameters[15].Value = model.seoTitle;
            parameters[16].Value = model.seoKey;
            parameters[17].Value = model.seoDescribe;

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
        public bool Update(GoosleB2C.Model.SuccessCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SuccessCase set ");
            strSql.Append("state=@state,");
            strSql.Append("title=@title,");
            strSql.Append("orders=@orders,");
            strSql.Append("mainImg=@mainImg,");
            strSql.Append("summay=@summay,");
            strSql.Append("webContent=@webContent,");
            strSql.Append("content=@content,");
            strSql.Append("imgs=@imgs,");
            strSql.Append("readCount=@readCount,");
            strSql.Append("remark=@remark,");
            strSql.Append("creator=@creator,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("modifier=@modifier,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("seoKey=@seoKey,");
            strSql.Append("seoDescribe=@seoDescribe");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@title", SqlDbType.VarChar,200),
                    new SqlParameter("@orders", SqlDbType.Int,4),
                    new SqlParameter("@mainImg", SqlDbType.VarChar,200),
                    new SqlParameter("@summay", SqlDbType.VarChar,2000),
                    new SqlParameter("@webContent", SqlDbType.VarChar),
                    new SqlParameter("@content", SqlDbType.VarChar),
                    new SqlParameter("@imgs", SqlDbType.VarChar),
                    new SqlParameter("@readCount", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@creator", SqlDbType.VarChar,20),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@modifier", SqlDbType.VarChar,20),
                    new SqlParameter("@modifyDate", SqlDbType.DateTime),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoDescribe", SqlDbType.VarChar,500),
                    new SqlParameter("@Id", SqlDbType.VarChar,36)};
            parameters[0].Value = model.state;
            parameters[1].Value = model.title;
            parameters[2].Value = model.orders;
            parameters[3].Value = model.mainImg;
            parameters[4].Value = model.summay;
            parameters[5].Value = model.webContent;
            parameters[6].Value = model.content;
            parameters[7].Value = model.imgs;
            parameters[8].Value = model.readCount;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.creator;
            parameters[11].Value = model.createTime;
            parameters[12].Value = model.modifier;
            parameters[13].Value = model.modifyDate;
            parameters[14].Value = model.seoTitle;
            parameters[15].Value = model.seoKey;
            parameters[16].Value = model.seoDescribe;
            parameters[17].Value = model.Id;

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
        public bool Delete(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SuccessCase ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,36)};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SuccessCase ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public GoosleB2C.Model.SuccessCase GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe from SuccessCase ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,36)};
            parameters[0].Value = Id;

            GoosleB2C.Model.SuccessCase model = new GoosleB2C.Model.SuccessCase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["orders"] != null && ds.Tables[0].Rows[0]["orders"].ToString() != "")
                {
                    model.orders = int.Parse(ds.Tables[0].Rows[0]["orders"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mainImg"] != null && ds.Tables[0].Rows[0]["mainImg"].ToString() != "")
                {
                    model.mainImg = ds.Tables[0].Rows[0]["mainImg"].ToString();
                }
                if (ds.Tables[0].Rows[0]["summay"] != null && ds.Tables[0].Rows[0]["summay"].ToString() != "")
                {
                    model.summay = ds.Tables[0].Rows[0]["summay"].ToString();
                }
                if (ds.Tables[0].Rows[0]["webContent"] != null && ds.Tables[0].Rows[0]["webContent"].ToString() != "")
                {
                    model.webContent = ds.Tables[0].Rows[0]["webContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["imgs"] != null && ds.Tables[0].Rows[0]["imgs"].ToString() != "")
                {
                    model.imgs = ds.Tables[0].Rows[0]["imgs"].ToString();
                }
                if (ds.Tables[0].Rows[0]["readCount"] != null && ds.Tables[0].Rows[0]["readCount"].ToString() != "")
                {
                    model.readCount = int.Parse(ds.Tables[0].Rows[0]["readCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["creator"] != null && ds.Tables[0].Rows[0]["creator"].ToString() != "")
                {
                    model.creator = ds.Tables[0].Rows[0]["creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["createTime"] != null && ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["modifier"] != null && ds.Tables[0].Rows[0]["modifier"].ToString() != "")
                {
                    model.modifier = ds.Tables[0].Rows[0]["modifier"].ToString();
                }
                if (ds.Tables[0].Rows[0]["modifyDate"] != null && ds.Tables[0].Rows[0]["modifyDate"].ToString() != "")
                {
                    model.modifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["modifyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["seoTitle"] != null && ds.Tables[0].Rows[0]["seoTitle"].ToString() != "")
                {
                    model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoKey"] != null && ds.Tables[0].Rows[0]["seoKey"].ToString() != "")
                {
                    model.seoKey = ds.Tables[0].Rows[0]["seoKey"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoDescribe"] != null && ds.Tables[0].Rows[0]["seoDescribe"].ToString() != "")
                {
                    model.seoDescribe = ds.Tables[0].Rows[0]["seoDescribe"].ToString();
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
            strSql.Append("select Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe ");
            strSql.Append(" FROM SuccessCase ");
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
            strSql.Append(" Id,state,title,orders,mainImg,summay,webContent,content,imgs,readCount,remark,creator,createTime,modifier,modifyDate,seoTitle,seoKey,seoDescribe ");
            strSql.Append(" FROM SuccessCase ");
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
            strSql.Append("select count(1) FROM SuccessCase ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from SuccessCase T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 分页&自定义字段获取数据列表
        /// </summary>
        public DataSet GetListByPageColumn(string strWhere, string orderby, int startIndex, int endIndex,string column)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(column + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from SuccessCase T ");
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
			parameters[0].Value = "SuccessCase";
			parameters[1].Value = "Id";
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

