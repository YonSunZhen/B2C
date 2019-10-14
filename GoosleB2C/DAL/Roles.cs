using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Roles
	/// </summary>
	public partial class Roles
	{
		public Roles()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Roles");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Roles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Roles(");
			strSql.Append("id,roleName,roleOrder,intro,createUser,createDate,updateUser,updateDate,remark)");
			strSql.Append(" values (");
			strSql.Append("@id,@roleName,@roleOrder,@intro,@createUser,@createDate,@updateUser,@updateDate,@remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@roleName", SqlDbType.VarChar,30),
					new SqlParameter("@roleOrder", SqlDbType.SmallInt,2),
					new SqlParameter("@intro", SqlDbType.VarChar,300),
					new SqlParameter("@createUser", SqlDbType.VarChar,14),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.VarChar,14),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.roleName;
			parameters[2].Value = model.roleOrder;
			parameters[3].Value = model.intro;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.updateUser;
			parameters[7].Value = model.updateDate;
			parameters[8].Value = model.remark;

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
		public bool Update(GoosleB2C.Model.Roles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Roles set ");
			strSql.Append("roleName=@roleName,");
			strSql.Append("roleOrder=@roleOrder,");
			strSql.Append("intro=@intro,");
			strSql.Append("createUser=@createUser,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("updateUser=@updateUser,");
			strSql.Append("updateDate=@updateDate,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@roleName", SqlDbType.VarChar,30),
					new SqlParameter("@roleOrder", SqlDbType.SmallInt,2),
					new SqlParameter("@intro", SqlDbType.VarChar,300),
					new SqlParameter("@createUser", SqlDbType.VarChar,14),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.VarChar,14),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.roleName;
			parameters[1].Value = model.roleOrder;
			parameters[2].Value = model.intro;
			parameters[3].Value = model.createUser;
			parameters[4].Value = model.createDate;
			parameters[5].Value = model.updateUser;
			parameters[6].Value = model.updateDate;
			parameters[7].Value = model.remark;
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
			strSql.Append("delete from Roles ");
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
			strSql.Append("delete from Roles ");
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
		public GoosleB2C.Model.Roles GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,roleName,roleOrder,intro,createUser,createDate,updateUser,updateDate,remark from Roles ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.Roles model=new GoosleB2C.Model.Roles();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["roleName"]!=null && ds.Tables[0].Rows[0]["roleName"].ToString()!="")
				{
					model.roleName=ds.Tables[0].Rows[0]["roleName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["roleOrder"]!=null && ds.Tables[0].Rows[0]["roleOrder"].ToString()!="")
				{
					model.roleOrder=int.Parse(ds.Tables[0].Rows[0]["roleOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["intro"]!=null && ds.Tables[0].Rows[0]["intro"].ToString()!="")
				{
					model.intro=ds.Tables[0].Rows[0]["intro"].ToString();
				}
				if(ds.Tables[0].Rows[0]["createUser"]!=null && ds.Tables[0].Rows[0]["createUser"].ToString()!="")
				{
					model.createUser=ds.Tables[0].Rows[0]["createUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["createDate"]!=null && ds.Tables[0].Rows[0]["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(ds.Tables[0].Rows[0]["createDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["updateUser"]!=null && ds.Tables[0].Rows[0]["updateUser"].ToString()!="")
				{
					model.updateUser=ds.Tables[0].Rows[0]["updateUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["updateDate"]!=null && ds.Tables[0].Rows[0]["updateDate"].ToString()!="")
				{
					model.updateDate=DateTime.Parse(ds.Tables[0].Rows[0]["updateDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null && ds.Tables[0].Rows[0]["remark"].ToString()!="")
				{
					model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
			strSql.Append("select id,roleName,roleOrder,intro,createUser,createDate,updateUser,updateDate,remark ");
			strSql.Append(" FROM Roles ");
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
			strSql.Append(" id,roleName,roleOrder,intro,createUser,createDate,updateUser,updateDate,remark ");
			strSql.Append(" FROM Roles ");
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
			strSql.Append("select count(1) FROM Roles ");
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
			strSql.Append(")AS Row, T.*  from Roles T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
        }

        
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize, int PageIndex, string strWhere)
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
            parameters[0].Value = "Roles";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        #endregion  Method
    }
}

