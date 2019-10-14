using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:IndexContent
	/// </summary>
	public partial class IndexContent
	{
		public IndexContent()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IndexContent");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.IndexContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IndexContent(");
			strSql.Append("id,isShowSuccess,successTotal,isShowProduct,productTotal,isShowArticle,articleTotal,isShowVideo,isRun,videoPath,videoTitle)");
			strSql.Append(" values (");
			strSql.Append("@id,@isShowSuccess,@successTotal,@isShowProduct,@productTotal,@isShowArticle,@articleTotal,@isShowVideo,@isRun,@videoPath,@videoTitle)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@isShowSuccess", SqlDbType.Int,4),
					new SqlParameter("@successTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowProduct", SqlDbType.Int,4),
					new SqlParameter("@productTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowArticle", SqlDbType.Int,4),
					new SqlParameter("@articleTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowVideo", SqlDbType.Int,4),
					new SqlParameter("@isRun", SqlDbType.Int,4),
					new SqlParameter("@videoPath", SqlDbType.VarChar,300),
					new SqlParameter("@videoTitle", SqlDbType.VarChar,30)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.isShowSuccess;
			parameters[2].Value = model.successTotal;
			parameters[3].Value = model.isShowProduct;
			parameters[4].Value = model.productTotal;
			parameters[5].Value = model.isShowArticle;
			parameters[6].Value = model.articleTotal;
			parameters[7].Value = model.isShowVideo;
			parameters[8].Value = model.isRun;
			parameters[9].Value = model.videoPath;
			parameters[10].Value = model.videoTitle;

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
		public bool Update(GoosleB2C.Model.IndexContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IndexContent set ");
			strSql.Append("isShowSuccess=@isShowSuccess,");
			strSql.Append("successTotal=@successTotal,");
			strSql.Append("isShowProduct=@isShowProduct,");
			strSql.Append("productTotal=@productTotal,");
			strSql.Append("isShowArticle=@isShowArticle,");
			strSql.Append("articleTotal=@articleTotal,");
			strSql.Append("isShowVideo=@isShowVideo,");
			strSql.Append("isRun=@isRun,");
			strSql.Append("videoPath=@videoPath,");
			strSql.Append("videoTitle=@videoTitle");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@isShowSuccess", SqlDbType.Int,4),
					new SqlParameter("@successTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowProduct", SqlDbType.Int,4),
					new SqlParameter("@productTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowArticle", SqlDbType.Int,4),
					new SqlParameter("@articleTotal", SqlDbType.Int,4),
					new SqlParameter("@isShowVideo", SqlDbType.Int,4),
					new SqlParameter("@isRun", SqlDbType.Int,4),
					new SqlParameter("@videoPath", SqlDbType.VarChar,300),
					new SqlParameter("@videoTitle", SqlDbType.VarChar,30),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.isShowSuccess;
			parameters[1].Value = model.successTotal;
			parameters[2].Value = model.isShowProduct;
			parameters[3].Value = model.productTotal;
			parameters[4].Value = model.isShowArticle;
			parameters[5].Value = model.articleTotal;
			parameters[6].Value = model.isShowVideo;
			parameters[7].Value = model.isRun;
			parameters[8].Value = model.videoPath;
			parameters[9].Value = model.videoTitle;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from IndexContent ");
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
			strSql.Append("delete from IndexContent ");
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
		public GoosleB2C.Model.IndexContent GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,isShowSuccess,successTotal,isShowProduct,productTotal,isShowArticle,articleTotal,isShowVideo,isRun,videoPath,videoTitle from IndexContent ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.IndexContent model=new GoosleB2C.Model.IndexContent();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isShowSuccess"]!=null && ds.Tables[0].Rows[0]["isShowSuccess"].ToString()!="")
				{
					model.isShowSuccess=int.Parse(ds.Tables[0].Rows[0]["isShowSuccess"].ToString());
				}
				if(ds.Tables[0].Rows[0]["successTotal"]!=null && ds.Tables[0].Rows[0]["successTotal"].ToString()!="")
				{
					model.successTotal=int.Parse(ds.Tables[0].Rows[0]["successTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isShowProduct"]!=null && ds.Tables[0].Rows[0]["isShowProduct"].ToString()!="")
				{
					model.isShowProduct=int.Parse(ds.Tables[0].Rows[0]["isShowProduct"].ToString());
				}
				if(ds.Tables[0].Rows[0]["productTotal"]!=null && ds.Tables[0].Rows[0]["productTotal"].ToString()!="")
				{
					model.productTotal=int.Parse(ds.Tables[0].Rows[0]["productTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isShowArticle"]!=null && ds.Tables[0].Rows[0]["isShowArticle"].ToString()!="")
				{
					model.isShowArticle=int.Parse(ds.Tables[0].Rows[0]["isShowArticle"].ToString());
				}
				if(ds.Tables[0].Rows[0]["articleTotal"]!=null && ds.Tables[0].Rows[0]["articleTotal"].ToString()!="")
				{
					model.articleTotal=int.Parse(ds.Tables[0].Rows[0]["articleTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isShowVideo"]!=null && ds.Tables[0].Rows[0]["isShowVideo"].ToString()!="")
				{
					model.isShowVideo=int.Parse(ds.Tables[0].Rows[0]["isShowVideo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isRun"]!=null && ds.Tables[0].Rows[0]["isRun"].ToString()!="")
				{
					model.isRun=int.Parse(ds.Tables[0].Rows[0]["isRun"].ToString());
				}
				if(ds.Tables[0].Rows[0]["videoPath"]!=null && ds.Tables[0].Rows[0]["videoPath"].ToString()!="")
				{
					model.videoPath=ds.Tables[0].Rows[0]["videoPath"].ToString();
				}
				if(ds.Tables[0].Rows[0]["videoTitle"]!=null && ds.Tables[0].Rows[0]["videoTitle"].ToString()!="")
				{
					model.videoTitle=ds.Tables[0].Rows[0]["videoTitle"].ToString();
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
			strSql.Append("select id,isShowSuccess,successTotal,isShowProduct,productTotal,isShowArticle,articleTotal,isShowVideo,isRun,videoPath,videoTitle ");
			strSql.Append(" FROM IndexContent ");
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
			strSql.Append(" id,isShowSuccess,successTotal,isShowProduct,productTotal,isShowArticle,articleTotal,isShowVideo,isRun,videoPath,videoTitle ");
			strSql.Append(" FROM IndexContent ");
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
			strSql.Append("select count(1) FROM IndexContent ");
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
			strSql.Append(")AS Row, T.*  from IndexContent T ");
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
			parameters[0].Value = "IndexContent";
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

