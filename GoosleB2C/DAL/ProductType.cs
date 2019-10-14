using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:ProductType
	/// </summary>
	public partial class ProductType
	{
		public ProductType()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductType");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductType(");
			strSql.Append("id,productId,typeName,originalPrice,Price,stock,img)");
			strSql.Append(" values (");
			strSql.Append("@id,@productId,@typeName,@originalPrice,@Price,@stock,@img)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@productId", SqlDbType.VarChar,36),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@originalPrice", SqlDbType.Float,8),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@img", SqlDbType.VarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.productId;
			parameters[2].Value = model.typeName;
			parameters[3].Value = model.originalPrice;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.stock;
			parameters[6].Value = model.img;

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
		public bool Update(GoosleB2C.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductType set ");
			strSql.Append("productId=@productId,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("originalPrice=@originalPrice,");
			strSql.Append("Price=@Price,");
			strSql.Append("stock=@stock,");
			strSql.Append("img=@img");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.VarChar,36),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@originalPrice", SqlDbType.Float,8),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@img", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.originalPrice;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.stock;
			parameters[5].Value = model.img;
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
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
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
			strSql.Append("delete from ProductType ");
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
		public GoosleB2C.Model.ProductType GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,typeName,originalPrice,Price,stock,img from ProductType ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.ProductType model=new GoosleB2C.Model.ProductType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["productId"]!=null && ds.Tables[0].Rows[0]["productId"].ToString()!="")
				{
					model.productId=ds.Tables[0].Rows[0]["productId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["typeName"]!=null && ds.Tables[0].Rows[0]["typeName"].ToString()!="")
				{
					model.typeName=ds.Tables[0].Rows[0]["typeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["originalPrice"]!=null && ds.Tables[0].Rows[0]["originalPrice"].ToString()!="")
				{
					model.originalPrice=decimal.Parse(ds.Tables[0].Rows[0]["originalPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["stock"]!=null && ds.Tables[0].Rows[0]["stock"].ToString()!="")
				{
					model.stock=int.Parse(ds.Tables[0].Rows[0]["stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["img"]!=null && ds.Tables[0].Rows[0]["img"].ToString()!="")
				{
					model.img=ds.Tables[0].Rows[0]["img"].ToString();
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
			strSql.Append("select id,productId,typeName,originalPrice,Price,stock,img ");
			strSql.Append(" FROM ProductType ");
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
			strSql.Append(" id,productId,typeName,originalPrice,Price,stock,img ");
			strSql.Append(" FROM ProductType ");
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
			strSql.Append("select count(1) FROM ProductType ");
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
			strSql.Append(")AS Row, T.*  from ProductType T ");
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
			parameters[0].Value = "ProductType";
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

