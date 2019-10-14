using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:IndexImg
	/// </summary>
	public partial class IndexImg
	{
		public IndexImg()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IndexImg");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.IndexImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IndexImg(");
			strSql.Append("id,img,url,orders,position,urlType,toId,updateTime,updatePeople)");
			strSql.Append(" values (");
			strSql.Append("@id,@img,@url,@orders,@position,@urlType,@toId,@updateTime,@updatePeople)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@img", SqlDbType.VarChar,200),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@orders", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@urlType", SqlDbType.Int,4),
					new SqlParameter("@toId", SqlDbType.VarChar,36),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@updatePeople", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.img;
			parameters[2].Value = model.url;
			parameters[3].Value = model.orders;
			parameters[4].Value = model.position;
			parameters[5].Value = model.urlType;
			parameters[6].Value = model.toId;
			parameters[7].Value = model.updateTime;
			parameters[8].Value = model.updatePeople;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(GoosleB2C.Model.IndexImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IndexImg set ");
			strSql.Append("img=@img,");
			strSql.Append("url=@url,");
			strSql.Append("orders=@orders,");
			strSql.Append("position=@position,");
			strSql.Append("urlType=@urlType,");
			strSql.Append("toId=@toId,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("updatePeople=@updatePeople");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@img", SqlDbType.VarChar,200),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@orders", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@urlType", SqlDbType.Int,4),
					new SqlParameter("@toId", SqlDbType.VarChar,36),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@updatePeople", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.img;
			parameters[1].Value = model.url;
			parameters[2].Value = model.orders;
			parameters[3].Value = model.position;
			parameters[4].Value = model.urlType;
			parameters[5].Value = model.toId;
			parameters[6].Value = model.updateTime;
			parameters[7].Value = model.updatePeople;
			parameters[8].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IndexImg ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IndexImg ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public GoosleB2C.Model.IndexImg GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,img,url,orders,position,urlType,toId,updateTime,updatePeople from IndexImg ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.IndexImg model=new GoosleB2C.Model.IndexImg();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img"]!=null && ds.Tables[0].Rows[0]["img"].ToString()!="")
				{
					model.img=ds.Tables[0].Rows[0]["img"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url"]!=null && ds.Tables[0].Rows[0]["url"].ToString()!="")
				{
					model.url=ds.Tables[0].Rows[0]["url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["orders"]!=null && ds.Tables[0].Rows[0]["orders"].ToString()!="")
				{
					model.orders=int.Parse(ds.Tables[0].Rows[0]["orders"].ToString());
				}
				if(ds.Tables[0].Rows[0]["position"]!=null && ds.Tables[0].Rows[0]["position"].ToString()!="")
				{
					model.position=int.Parse(ds.Tables[0].Rows[0]["position"].ToString());
				}
				if(ds.Tables[0].Rows[0]["urlType"]!=null && ds.Tables[0].Rows[0]["urlType"].ToString()!="")
				{
					model.urlType=int.Parse(ds.Tables[0].Rows[0]["urlType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["toId"]!=null && ds.Tables[0].Rows[0]["toId"].ToString()!="")
				{
					model.toId=ds.Tables[0].Rows[0]["toId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["updateTime"]!=null && ds.Tables[0].Rows[0]["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(ds.Tables[0].Rows[0]["updateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["updatePeople"]!=null && ds.Tables[0].Rows[0]["updatePeople"].ToString()!="")
				{
					model.updatePeople=ds.Tables[0].Rows[0]["updatePeople"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,img,url,orders,position,urlType,toId,updateTime,updatePeople ");
			strSql.Append(" FROM IndexImg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,img,url,orders,position,urlType,toId,updateTime,updatePeople ");
			strSql.Append(" FROM IndexImg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM IndexImg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from IndexImg T ");
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
			parameters[0].Value = "IndexImg";
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

