using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:CompanyContact
	/// </summary>
	public partial class CompanyContact
	{
		public CompanyContact()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "CompanyContact"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CompanyContact");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.CompanyContact model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CompanyContact(");
			strSql.Append("id,name,address,telephone,phone,email,contacts,weixin)");
			strSql.Append(" values (");
			strSql.Append("@id,@name,@address,@telephone,@phone,@email,@contacts,@weixin)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,200),
					new SqlParameter("@address", SqlDbType.VarChar,300),
					new SqlParameter("@telephone", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@contacts", SqlDbType.VarChar,20),
					new SqlParameter("@weixin", SqlDbType.VarChar,80)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.address;
			parameters[3].Value = model.telephone;
			parameters[4].Value = model.phone;
			parameters[5].Value = model.email;
			parameters[6].Value = model.contacts;
			parameters[7].Value = model.weixin;

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
		public bool Update(GoosleB2C.Model.CompanyContact model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CompanyContact set ");
			strSql.Append("name=@name,");
			strSql.Append("address=@address,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("phone=@phone,");
			strSql.Append("email=@email,");
			strSql.Append("contacts=@contacts,");
			strSql.Append("weixin=@weixin");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,200),
					new SqlParameter("@address", SqlDbType.VarChar,300),
					new SqlParameter("@telephone", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@contacts", SqlDbType.VarChar,20),
					new SqlParameter("@weixin", SqlDbType.VarChar,80),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.address;
			parameters[2].Value = model.telephone;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.email;
			parameters[5].Value = model.contacts;
			parameters[6].Value = model.weixin;
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
			strSql.Append("delete from CompanyContact ");
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
			strSql.Append("delete from CompanyContact ");
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
		public GoosleB2C.Model.CompanyContact GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,address,telephone,phone,email,contacts,weixin from CompanyContact ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.CompanyContact model=new GoosleB2C.Model.CompanyContact();
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
				if(ds.Tables[0].Rows[0]["address"]!=null && ds.Tables[0].Rows[0]["address"].ToString()!="")
				{
					model.address=ds.Tables[0].Rows[0]["address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["telephone"]!=null && ds.Tables[0].Rows[0]["telephone"].ToString()!="")
				{
					model.telephone=ds.Tables[0].Rows[0]["telephone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["phone"]!=null && ds.Tables[0].Rows[0]["phone"].ToString()!="")
				{
					model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["contacts"]!=null && ds.Tables[0].Rows[0]["contacts"].ToString()!="")
				{
					model.contacts=ds.Tables[0].Rows[0]["contacts"].ToString();
				}
				if(ds.Tables[0].Rows[0]["weixin"]!=null && ds.Tables[0].Rows[0]["weixin"].ToString()!="")
				{
					model.weixin=ds.Tables[0].Rows[0]["weixin"].ToString();
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
			strSql.Append("select id,name,address,telephone,phone,email,contacts,weixin ");
			strSql.Append(" FROM CompanyContact ");
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
			strSql.Append(" id,name,address,telephone,phone,email,contacts,weixin ");
			strSql.Append(" FROM CompanyContact ");
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
			strSql.Append("select count(1) FROM CompanyContact ");
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
			strSql.Append(")AS Row, T.*  from CompanyContact T ");
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
			parameters[0].Value = "CompanyContact";
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

