using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Regions
	/// </summary>
	public partial class Regions
	{
		public Regions()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Regions"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Regions");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Regions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Regions(");
			strSql.Append("id,regionName,regionCode,fatherId,level,regionOrder,enName,shortEnName)");
			strSql.Append(" values (");
			strSql.Append("@id,@regionName,@regionCode,@fatherId,@level,@regionOrder,@enName,@shortEnName)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@regionName", SqlDbType.VarChar,80),
					new SqlParameter("@regionCode", SqlDbType.VarChar,36),
					new SqlParameter("@fatherId", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@regionOrder", SqlDbType.Int,4),
					new SqlParameter("@enName", SqlDbType.VarChar,120),
					new SqlParameter("@shortEnName", SqlDbType.VarChar,12)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.regionName;
			parameters[2].Value = model.regionCode;
			parameters[3].Value = model.fatherId;
			parameters[4].Value = model.level;
			parameters[5].Value = model.regionOrder;
			parameters[6].Value = model.enName;
			parameters[7].Value = model.shortEnName;

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
		public bool Update(GoosleB2C.Model.Regions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Regions set ");
			strSql.Append("regionName=@regionName,");
			strSql.Append("regionCode=@regionCode,");
			strSql.Append("fatherId=@fatherId,");
			strSql.Append("level=@level,");
			strSql.Append("regionOrder=@regionOrder,");
			strSql.Append("enName=@enName,");
			strSql.Append("shortEnName=@shortEnName");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@regionName", SqlDbType.VarChar,80),
					new SqlParameter("@regionCode", SqlDbType.VarChar,36),
					new SqlParameter("@fatherId", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@regionOrder", SqlDbType.Int,4),
					new SqlParameter("@enName", SqlDbType.VarChar,120),
					new SqlParameter("@shortEnName", SqlDbType.VarChar,12),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.regionName;
			parameters[1].Value = model.regionCode;
			parameters[2].Value = model.fatherId;
			parameters[3].Value = model.level;
			parameters[4].Value = model.regionOrder;
			parameters[5].Value = model.enName;
			parameters[6].Value = model.shortEnName;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from Regions ");
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
			strSql.Append("delete from Regions ");
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
		public GoosleB2C.Model.Regions GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,regionName,regionCode,fatherId,level,regionOrder,enName,shortEnName from Regions ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.Regions model=new GoosleB2C.Model.Regions();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["regionName"]!=null && ds.Tables[0].Rows[0]["regionName"].ToString()!="")
				{
					model.regionName=ds.Tables[0].Rows[0]["regionName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["regionCode"]!=null && ds.Tables[0].Rows[0]["regionCode"].ToString()!="")
				{
					model.regionCode=ds.Tables[0].Rows[0]["regionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fatherId"]!=null && ds.Tables[0].Rows[0]["fatherId"].ToString()!="")
				{
					model.fatherId=int.Parse(ds.Tables[0].Rows[0]["fatherId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level"]!=null && ds.Tables[0].Rows[0]["level"].ToString()!="")
				{
					model.level=int.Parse(ds.Tables[0].Rows[0]["level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["regionOrder"]!=null && ds.Tables[0].Rows[0]["regionOrder"].ToString()!="")
				{
					model.regionOrder=int.Parse(ds.Tables[0].Rows[0]["regionOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["enName"]!=null && ds.Tables[0].Rows[0]["enName"].ToString()!="")
				{
					model.enName=ds.Tables[0].Rows[0]["enName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shortEnName"]!=null && ds.Tables[0].Rows[0]["shortEnName"].ToString()!="")
				{
					model.shortEnName=ds.Tables[0].Rows[0]["shortEnName"].ToString();
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
			strSql.Append("select id,regionName,regionCode,fatherId,level,regionOrder,enName,shortEnName ");
			strSql.Append(" FROM Regions ");
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
			strSql.Append(" id,regionName,regionCode,fatherId,level,regionOrder,enName,shortEnName ");
			strSql.Append(" FROM Regions ");
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
			strSql.Append("select count(1) FROM Regions ");
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
			strSql.Append(")AS Row, T.*  from Regions T ");
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
			parameters[0].Value = "Regions";
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

