using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:WebInfo
	/// </summary>
	public partial class WebInfo
	{
		public WebInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WebInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WebInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.WebInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebInfo(");
			strSql.Append("id,webName,title,logo,vLogo,vName,vCode,records,bottomInfo,vBottom,seoKey,seoDescribe)");
			strSql.Append(" values (");
			strSql.Append("@id,@webName,@title,@logo,@vLogo,@vName,@vCode,@records,@bottomInfo,@vBottom,@seoKey,@seoDescribe)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@webName", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,300),
					new SqlParameter("@logo", SqlDbType.VarChar,300),
					new SqlParameter("@vLogo", SqlDbType.VarChar,300),
					new SqlParameter("@vName", SqlDbType.VarChar,200),
					new SqlParameter("@vCode", SqlDbType.VarChar,300),
					new SqlParameter("@records", SqlDbType.VarChar,200),
					new SqlParameter("@bottomInfo", SqlDbType.VarChar,2000),
					new SqlParameter("@vBottom", SqlDbType.VarChar,500),
					new SqlParameter("@seoKey", SqlDbType.VarChar,100),
					new SqlParameter("@seoDescribe", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.webName;
			parameters[2].Value = model.title;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.vLogo;
			parameters[5].Value = model.vName;
			parameters[6].Value = model.vCode;
			parameters[7].Value = model.records;
			parameters[8].Value = model.bottomInfo;
			parameters[9].Value = model.vBottom;
			parameters[10].Value = model.seoKey;
			parameters[11].Value = model.seoDescribe;

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
		public bool Update(GoosleB2C.Model.WebInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebInfo set ");
			strSql.Append("webName=@webName,");
			strSql.Append("title=@title,");
			strSql.Append("logo=@logo,");
			strSql.Append("vLogo=@vLogo,");
			strSql.Append("vName=@vName,");
			strSql.Append("vCode=@vCode,");
			strSql.Append("records=@records,");
			strSql.Append("bottomInfo=@bottomInfo,");
			strSql.Append("vBottom=@vBottom,");
			strSql.Append("seoKey=@seoKey,");
			strSql.Append("seoDescribe=@seoDescribe");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@webName", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,300),
					new SqlParameter("@logo", SqlDbType.VarChar,300),
					new SqlParameter("@vLogo", SqlDbType.VarChar,300),
					new SqlParameter("@vName", SqlDbType.VarChar,200),
					new SqlParameter("@vCode", SqlDbType.VarChar,300),
					new SqlParameter("@records", SqlDbType.VarChar,200),
					new SqlParameter("@bottomInfo", SqlDbType.VarChar,2000),
					new SqlParameter("@vBottom", SqlDbType.VarChar,500),
					new SqlParameter("@seoKey", SqlDbType.VarChar,100),
					new SqlParameter("@seoDescribe", SqlDbType.VarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.webName;
			parameters[1].Value = model.title;
			parameters[2].Value = model.logo;
			parameters[3].Value = model.vLogo;
			parameters[4].Value = model.vName;
			parameters[5].Value = model.vCode;
			parameters[6].Value = model.records;
			parameters[7].Value = model.bottomInfo;
			parameters[8].Value = model.vBottom;
			parameters[9].Value = model.seoKey;
			parameters[10].Value = model.seoDescribe;
			parameters[11].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
			strSql.Append("delete from WebInfo ");
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
		public GoosleB2C.Model.WebInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,webName,title,logo,vLogo,vName,vCode,records,bottomInfo,vBottom,seoKey,seoDescribe from WebInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.WebInfo model=new GoosleB2C.Model.WebInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["webName"]!=null && ds.Tables[0].Rows[0]["webName"].ToString()!="")
				{
					model.webName=ds.Tables[0].Rows[0]["webName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["logo"]!=null && ds.Tables[0].Rows[0]["logo"].ToString()!="")
				{
					model.logo=ds.Tables[0].Rows[0]["logo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vLogo"]!=null && ds.Tables[0].Rows[0]["vLogo"].ToString()!="")
				{
					model.vLogo=ds.Tables[0].Rows[0]["vLogo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vName"]!=null && ds.Tables[0].Rows[0]["vName"].ToString()!="")
				{
					model.vName=ds.Tables[0].Rows[0]["vName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vCode"]!=null && ds.Tables[0].Rows[0]["vCode"].ToString()!="")
				{
					model.vCode=ds.Tables[0].Rows[0]["vCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["records"]!=null && ds.Tables[0].Rows[0]["records"].ToString()!="")
				{
					model.records=ds.Tables[0].Rows[0]["records"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bottomInfo"]!=null && ds.Tables[0].Rows[0]["bottomInfo"].ToString()!="")
				{
					model.bottomInfo=ds.Tables[0].Rows[0]["bottomInfo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vBottom"]!=null && ds.Tables[0].Rows[0]["vBottom"].ToString()!="")
				{
					model.vBottom=ds.Tables[0].Rows[0]["vBottom"].ToString();
				}
				if(ds.Tables[0].Rows[0]["seoKey"]!=null && ds.Tables[0].Rows[0]["seoKey"].ToString()!="")
				{
					model.seoKey=ds.Tables[0].Rows[0]["seoKey"].ToString();
				}
				if(ds.Tables[0].Rows[0]["seoDescribe"]!=null && ds.Tables[0].Rows[0]["seoDescribe"].ToString()!="")
				{
					model.seoDescribe=ds.Tables[0].Rows[0]["seoDescribe"].ToString();
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
			strSql.Append("select id,webName,title,logo,vLogo,vName,vCode,records,bottomInfo,vBottom,seoKey,seoDescribe ");
			strSql.Append(" FROM WebInfo ");
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
			strSql.Append(" id,webName,title,logo,vLogo,vName,vCode,records,bottomInfo,vBottom,seoKey,seoDescribe ");
			strSql.Append(" FROM WebInfo ");
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
			strSql.Append("select count(1) FROM WebInfo ");
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
			strSql.Append(")AS Row, T.*  from WebInfo T ");
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
			parameters[0].Value = "WebInfo";
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

