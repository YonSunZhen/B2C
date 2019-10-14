using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:DeliveryDetail
	/// </summary>
	public partial class DeliveryDetail
	{
		public DeliveryDetail()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DeliveryDetail");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.DeliveryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DeliveryDetail(");
			strSql.Append("id,tempId,provinceId,firstWeight,addedWeight)");
			strSql.Append(" values (");
			strSql.Append("@id,@tempId,@provinceId,@firstWeight,@addedWeight)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@tempId", SqlDbType.VarChar,36),
					new SqlParameter("@provinceId", SqlDbType.Int,4),
					new SqlParameter("@firstWeight", SqlDbType.Float,8),
					new SqlParameter("@addedWeight", SqlDbType.Float,8)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.tempId;
			parameters[2].Value = model.provinceId;
			parameters[3].Value = model.firstWeight;
			parameters[4].Value = model.addedWeight;

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
		public bool Update(GoosleB2C.Model.DeliveryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DeliveryDetail set ");
			strSql.Append("tempId=@tempId,");
			strSql.Append("provinceId=@provinceId,");
			strSql.Append("firstWeight=@firstWeight,");
			strSql.Append("addedWeight=@addedWeight");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempId", SqlDbType.VarChar,36),
					new SqlParameter("@provinceId", SqlDbType.Int,4),
					new SqlParameter("@firstWeight", SqlDbType.Float,8),
					new SqlParameter("@addedWeight", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.tempId;
			parameters[1].Value = model.provinceId;
			parameters[2].Value = model.firstWeight;
			parameters[3].Value = model.addedWeight;
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
			strSql.Append("delete from DeliveryDetail ");
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
			strSql.Append("delete from DeliveryDetail ");
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
		public GoosleB2C.Model.DeliveryDetail GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,tempId,provinceId,firstWeight,addedWeight from DeliveryDetail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.DeliveryDetail model=new GoosleB2C.Model.DeliveryDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tempId"]!=null && ds.Tables[0].Rows[0]["tempId"].ToString()!="")
				{
					model.tempId=ds.Tables[0].Rows[0]["tempId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["provinceId"]!=null && ds.Tables[0].Rows[0]["provinceId"].ToString()!="")
				{
					model.provinceId=int.Parse(ds.Tables[0].Rows[0]["provinceId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["firstWeight"]!=null && ds.Tables[0].Rows[0]["firstWeight"].ToString()!="")
				{
					model.firstWeight=decimal.Parse(ds.Tables[0].Rows[0]["firstWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["addedWeight"]!=null && ds.Tables[0].Rows[0]["addedWeight"].ToString()!="")
				{
					model.addedWeight=decimal.Parse(ds.Tables[0].Rows[0]["addedWeight"].ToString());
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
			strSql.Append("select id,tempId,provinceId,firstWeight,addedWeight ");
			strSql.Append(" FROM DeliveryDetail ");
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
			strSql.Append(" id,tempId,provinceId,firstWeight,addedWeight ");
			strSql.Append(" FROM DeliveryDetail ");
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
			strSql.Append("select count(1) FROM DeliveryDetail ");
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
			strSql.Append(")AS Row, T.*  from DeliveryDetail T ");
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
			parameters[0].Value = "DeliveryDetail";
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

