using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:WaterMark
	/// </summary>
	public partial class WaterMark
	{
		public WaterMark()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WaterMark"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WaterMark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.WaterMark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WaterMark(");
			strSql.Append("id,state,waterType,position,words,img,transparent)");
			strSql.Append(" values (");
			strSql.Append("@id,@state,@waterType,@position,@words,@img,@transparent)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@waterType", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@words", SqlDbType.VarChar,100),
					new SqlParameter("@img", SqlDbType.VarChar,300),
					new SqlParameter("@transparent", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.state;
			parameters[2].Value = model.waterType;
			parameters[3].Value = model.position;
			parameters[4].Value = model.words;
			parameters[5].Value = model.img;
			parameters[6].Value = model.transparent;

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
		public bool Update(GoosleB2C.Model.WaterMark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WaterMark set ");
			strSql.Append("state=@state,");
			strSql.Append("waterType=@waterType,");
			strSql.Append("position=@position,");
			strSql.Append("words=@words,");
			strSql.Append("img=@img,");
			strSql.Append("transparent=@transparent");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@waterType", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@words", SqlDbType.VarChar,100),
					new SqlParameter("@img", SqlDbType.VarChar,300),
					new SqlParameter("@transparent", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.state;
			parameters[1].Value = model.waterType;
			parameters[2].Value = model.position;
			parameters[3].Value = model.words;
			parameters[4].Value = model.img;
			parameters[5].Value = model.transparent;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from WaterMark ");
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
			strSql.Append("delete from WaterMark ");
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
		public GoosleB2C.Model.WaterMark GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,state,waterType,position,words,img,transparent from WaterMark ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.WaterMark model=new GoosleB2C.Model.WaterMark();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["state"]!=null && ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["waterType"]!=null && ds.Tables[0].Rows[0]["waterType"].ToString()!="")
				{
					model.waterType=int.Parse(ds.Tables[0].Rows[0]["waterType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["position"]!=null && ds.Tables[0].Rows[0]["position"].ToString()!="")
				{
					model.position=int.Parse(ds.Tables[0].Rows[0]["position"].ToString());
				}
				if(ds.Tables[0].Rows[0]["words"]!=null && ds.Tables[0].Rows[0]["words"].ToString()!="")
				{
					model.words=ds.Tables[0].Rows[0]["words"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img"]!=null && ds.Tables[0].Rows[0]["img"].ToString()!="")
				{
					model.img=ds.Tables[0].Rows[0]["img"].ToString();
				}
				if(ds.Tables[0].Rows[0]["transparent"]!=null && ds.Tables[0].Rows[0]["transparent"].ToString()!="")
				{
					model.transparent=int.Parse(ds.Tables[0].Rows[0]["transparent"].ToString());
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
			strSql.Append("select id,state,waterType,position,words,img,transparent ");
			strSql.Append(" FROM WaterMark ");
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
			strSql.Append(" id,state,waterType,position,words,img,transparent ");
			strSql.Append(" FROM WaterMark ");
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
			strSql.Append("select count(1) FROM WaterMark ");
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
			strSql.Append(")AS Row, T.*  from WaterMark T ");
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
			parameters[0].Value = "WaterMark";
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

