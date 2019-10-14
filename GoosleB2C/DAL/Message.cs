using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Message
	/// </summary>
	public partial class Message
	{
		public Message()
		{}
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Message");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Message(");
            strSql.Append("id,vId,[to],name,sex,phone,weixin,content,createTime,ip,isShow,isRead,readTime,isAnswer)");
            strSql.Append(" values (");
            strSql.Append("@id,@vId,@to,@name,@sex,@phone,@weixin,@content,@createTime,@ip,@isShow,@isRead,@readTime,@isAnswer)");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36),
                    new SqlParameter("@vId", SqlDbType.VarChar,100),
                    new SqlParameter("@to", SqlDbType.VarChar,100),
                    new SqlParameter("@name", SqlDbType.VarChar,50),
                    new SqlParameter("@sex", SqlDbType.Int,4),
                    new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@weixin", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,2000),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@ip", SqlDbType.VarChar,64),
                    new SqlParameter("@isShow", SqlDbType.Int,4),
                    new SqlParameter("@isRead", SqlDbType.Int,4),
                    new SqlParameter("@readTime", SqlDbType.DateTime),
                    new SqlParameter("@isAnswer", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.vId;
            parameters[2].Value = model.to;
            parameters[3].Value = model.name;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.phone;
            parameters[6].Value = model.weixin;
            parameters[7].Value = model.content;
            parameters[8].Value = model.createTime;
            parameters[9].Value = model.ip;
            parameters[10].Value = model.isShow;
            parameters[11].Value = model.isRead;
            parameters[12].Value = model.readTime;
            parameters[13].Value = model.isAnswer;

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
        public bool Update(GoosleB2C.Model.Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Message set ");
            strSql.Append("vId=@vId,");
            strSql.Append("to=@to,");
            strSql.Append("name=@name,");
            strSql.Append("sex=@sex,");
            strSql.Append("phone=@phone,");
            strSql.Append("weixin=@weixin,");
            strSql.Append("content=@content,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("ip=@ip,");
            strSql.Append("isShow=@isShow,");
            strSql.Append("isRead=@isRead,");
            strSql.Append("readTime=@readTime,");
            strSql.Append("isAnswer=@isAnswer");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@vId", SqlDbType.VarChar,100),
                    new SqlParameter("@to", SqlDbType.VarChar,100),
                    new SqlParameter("@name", SqlDbType.VarChar,50),
                    new SqlParameter("@sex", SqlDbType.Int,4),
                    new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@weixin", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,2000),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@ip", SqlDbType.VarChar,64),
                    new SqlParameter("@isShow", SqlDbType.Int,4),
                    new SqlParameter("@isRead", SqlDbType.Int,4),
                    new SqlParameter("@readTime", SqlDbType.DateTime),
                    new SqlParameter("@isAnswer", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = model.vId;
            parameters[1].Value = model.to;
            parameters[2].Value = model.name;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.weixin;
            parameters[6].Value = model.content;
            parameters[7].Value = model.createTime;
            parameters[8].Value = model.ip;
            parameters[9].Value = model.isShow;
            parameters[10].Value = model.isRead;
            parameters[11].Value = model.readTime;
            parameters[12].Value = model.isAnswer;
            parameters[13].Value = model.id;

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
            strSql.Append("delete from Message ");
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
            strSql.Append("delete from Message ");
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
        public GoosleB2C.Model.Message GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,vId,to,name,sex,phone,weixin,content,createTime,ip,isShow,isRead,readTime,isAnswer from Message ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            GoosleB2C.Model.Message model = new GoosleB2C.Model.Message();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["vId"] != null && ds.Tables[0].Rows[0]["vId"].ToString() != "")
                {
                    model.vId = ds.Tables[0].Rows[0]["vId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["to"] != null && ds.Tables[0].Rows[0]["to"].ToString() != "")
                {
                    model.to = ds.Tables[0].Rows[0]["to"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = int.Parse(ds.Tables[0].Rows[0]["sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["phone"] != null && ds.Tables[0].Rows[0]["phone"].ToString() != "")
                {
                    model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["weixin"] != null && ds.Tables[0].Rows[0]["weixin"].ToString() != "")
                {
                    model.weixin = ds.Tables[0].Rows[0]["weixin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["createTime"] != null && ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ip"] != null && ds.Tables[0].Rows[0]["ip"].ToString() != "")
                {
                    model.ip = ds.Tables[0].Rows[0]["ip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isShow"] != null && ds.Tables[0].Rows[0]["isShow"].ToString() != "")
                {
                    model.isShow = int.Parse(ds.Tables[0].Rows[0]["isShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isRead"] != null && ds.Tables[0].Rows[0]["isRead"].ToString() != "")
                {
                    model.isRead = int.Parse(ds.Tables[0].Rows[0]["isRead"].ToString());
                }
                if (ds.Tables[0].Rows[0]["readTime"] != null && ds.Tables[0].Rows[0]["readTime"].ToString() != "")
                {
                    model.readTime = DateTime.Parse(ds.Tables[0].Rows[0]["readTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isAnswer"] != null && ds.Tables[0].Rows[0]["isAnswer"].ToString() != "")
                {
                    model.isAnswer = int.Parse(ds.Tables[0].Rows[0]["isAnswer"].ToString());
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
            strSql.Append("select id,vId,[to],name,sex,phone,weixin,content,createTime,ip,isShow,isRead,readTime,isAnswer ");
            strSql.Append(" FROM Message ");
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
            strSql.Append(" id,vId,to,name,sex,phone,weixin,content,createTime,ip,isShow,isRead,readTime,isAnswer ");
            strSql.Append(" FROM Message ");
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
            strSql.Append("select count(1) FROM Message ");
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
            strSql.Append(")AS Row, T.*  from Message T ");
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
			parameters[0].Value = "Message";
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

