using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Powers
	/// </summary>
	public partial class Powers
	{
		public Powers()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Powers");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Powers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Powers(");
			strSql.Append("id,roleId,funId,powerValue,createDate)");
			strSql.Append(" values (");
			strSql.Append("@id,@roleId,@funId,@powerValue,@createDate)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@roleId", SqlDbType.VarChar,36),
					new SqlParameter("@funId", SqlDbType.VarChar,36),
					new SqlParameter("@powerValue", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.roleId;
			parameters[2].Value = model.funId;
			parameters[3].Value = model.powerValue;
			parameters[4].Value = model.createDate;

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
		public bool Update(GoosleB2C.Model.Powers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Powers set ");
			strSql.Append("roleId=@roleId,");
			strSql.Append("funId=@funId,");
			strSql.Append("powerValue=@powerValue,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@roleId", SqlDbType.VarChar,36),
					new SqlParameter("@funId", SqlDbType.VarChar,36),
					new SqlParameter("@powerValue", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.roleId;
			parameters[1].Value = model.funId;
			parameters[2].Value = model.powerValue;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.id;

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
			strSql.Append("delete from Powers ");
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
			strSql.Append("delete from Powers ");
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
		public GoosleB2C.Model.Powers GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,roleId,funId,powerValue,createDate from Powers ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.Powers model=new GoosleB2C.Model.Powers();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["roleId"]!=null && ds.Tables[0].Rows[0]["roleId"].ToString()!="")
				{
					model.roleId=ds.Tables[0].Rows[0]["roleId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["funId"]!=null && ds.Tables[0].Rows[0]["funId"].ToString()!="")
				{
					model.funId=ds.Tables[0].Rows[0]["funId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["powerValue"]!=null && ds.Tables[0].Rows[0]["powerValue"].ToString()!="")
				{
					model.powerValue=int.Parse(ds.Tables[0].Rows[0]["powerValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["createDate"]!=null && ds.Tables[0].Rows[0]["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(ds.Tables[0].Rows[0]["createDate"].ToString());
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
			strSql.Append("select id,roleId,funId,powerValue,createDate ");
			strSql.Append(" FROM Powers ");
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
			strSql.Append(" id,roleId,funId,powerValue,createDate ");
			strSql.Append(" FROM Powers ");
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
			strSql.Append("select count(1) FROM Powers ");
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
			strSql.Append(")AS Row, T.*  from Powers T ");
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
			parameters[0].Value = "Powers";
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

