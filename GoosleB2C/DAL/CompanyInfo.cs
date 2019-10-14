using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:CompanyInfo
	/// </summary>
	public partial class CompanyInfo
	{
		public CompanyInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "CompanyInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CompanyInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.CompanyInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CompanyInfo(");
			strSql.Append("id,name,name2,mainImg,webDetails,details,imgs,remarks)");
			strSql.Append(" values (");
			strSql.Append("@id,@name,@name2,@mainImg,@webDetails,@details,@imgs,@remarks)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@name2", SqlDbType.VarChar,200),
					new SqlParameter("@mainImg", SqlDbType.VarChar,200),
					new SqlParameter("@webDetails", SqlDbType.VarChar),
					new SqlParameter("@details", SqlDbType.VarChar),
					new SqlParameter("@imgs", SqlDbType.VarChar),
					new SqlParameter("@remarks", SqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.name2;
			parameters[3].Value = model.mainImg;
			parameters[4].Value = model.webDetails;
			parameters[5].Value = model.details;
			parameters[6].Value = model.imgs;
			parameters[7].Value = model.remarks;

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
		public bool Update(GoosleB2C.Model.CompanyInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CompanyInfo set ");
			strSql.Append("name=@name,");
			strSql.Append("name2=@name2,");
			strSql.Append("mainImg=@mainImg,");
			strSql.Append("webDetails=@webDetails,");
			strSql.Append("details=@details,");
			strSql.Append("imgs=@imgs,");
			strSql.Append("remarks=@remarks");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@name2", SqlDbType.VarChar,200),
					new SqlParameter("@mainImg", SqlDbType.VarChar,200),
					new SqlParameter("@webDetails", SqlDbType.VarChar),
					new SqlParameter("@details", SqlDbType.VarChar),
					new SqlParameter("@imgs", SqlDbType.VarChar),
					new SqlParameter("@remarks", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.name2;
			parameters[2].Value = model.mainImg;
			parameters[3].Value = model.webDetails;
			parameters[4].Value = model.details;
			parameters[5].Value = model.imgs;
			parameters[6].Value = model.remarks;
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
			strSql.Append("delete from CompanyInfo ");
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
			strSql.Append("delete from CompanyInfo ");
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
		public GoosleB2C.Model.CompanyInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,name2,mainImg,webDetails,details,imgs,remarks from CompanyInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.CompanyInfo model=new GoosleB2C.Model.CompanyInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["name2"]!=null && ds.Tables[0].Rows[0]["name2"].ToString()!="")
				{
					model.name2=ds.Tables[0].Rows[0]["name2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mainImg"]!=null && ds.Tables[0].Rows[0]["mainImg"].ToString()!="")
				{
					model.mainImg=ds.Tables[0].Rows[0]["mainImg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webDetails"]!=null && ds.Tables[0].Rows[0]["webDetails"].ToString()!="")
				{
					model.webDetails=ds.Tables[0].Rows[0]["webDetails"].ToString();
				}
				if(ds.Tables[0].Rows[0]["details"]!=null && ds.Tables[0].Rows[0]["details"].ToString()!="")
				{
					model.details=ds.Tables[0].Rows[0]["details"].ToString();
				}
				if(ds.Tables[0].Rows[0]["imgs"]!=null && ds.Tables[0].Rows[0]["imgs"].ToString()!="")
				{
					model.imgs=ds.Tables[0].Rows[0]["imgs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["remarks"]!=null && ds.Tables[0].Rows[0]["remarks"].ToString()!="")
				{
					model.remarks=ds.Tables[0].Rows[0]["remarks"].ToString();
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
			strSql.Append("select id,name,name2,mainImg,webDetails,details,imgs,remarks ");
			strSql.Append(" FROM CompanyInfo ");
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
			strSql.Append(" id,name,name2,mainImg,webDetails,details,imgs,remarks ");
			strSql.Append(" FROM CompanyInfo ");
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
			strSql.Append("select count(1) FROM CompanyInfo ");
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
			strSql.Append(")AS Row, T.*  from CompanyInfo T ");
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
			parameters[0].Value = "CompanyInfo";
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

