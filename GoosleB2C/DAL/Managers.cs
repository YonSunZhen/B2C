using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Managers
	/// </summary>
	public partial class Managers
	{
		public Managers()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Managers");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Managers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Managers(");
			strSql.Append("id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark)");
			strSql.Append(" values (");
			strSql.Append("@id,@userName,@passWord,@cnName,@state,@userType,@roleId,@mobile,@creator,@cteateDate,@lastLoginDate,@loginDate,@loginTimes,@expand1,@remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@userName", SqlDbType.VarChar,30),
					new SqlParameter("@passWord", SqlDbType.VarChar,64),
					new SqlParameter("@cnName", SqlDbType.VarChar,14),
					new SqlParameter("@state", SqlDbType.SmallInt,2),
					new SqlParameter("@userType", SqlDbType.SmallInt,2),
					new SqlParameter("@roleId", SqlDbType.VarChar,36),
					new SqlParameter("@mobile", SqlDbType.VarChar,12),
					new SqlParameter("@creator", SqlDbType.VarChar,14),
					new SqlParameter("@cteateDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@loginDate", SqlDbType.DateTime),
					new SqlParameter("@loginTimes", SqlDbType.Int,4),
					new SqlParameter("@expand1", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.userName;
			parameters[2].Value = model.passWord;
			parameters[3].Value = model.cnName;
			parameters[4].Value = model.state;
			parameters[5].Value = model.userType;
			parameters[6].Value = model.roleId;
			parameters[7].Value = model.mobile;
			parameters[8].Value = model.creator;
			parameters[9].Value = model.cteateDate;
			parameters[10].Value = model.lastLoginDate;
			parameters[11].Value = model.loginDate;
			parameters[12].Value = model.loginTimes;
			parameters[13].Value = model.expand1;
			parameters[14].Value = model.remark;

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
		public bool Update(GoosleB2C.Model.Managers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Managers set ");
			strSql.Append("userName=@userName,");
			strSql.Append("passWord=@passWord,");
			strSql.Append("cnName=@cnName,");
			strSql.Append("state=@state,");
			strSql.Append("userType=@userType,");
			strSql.Append("roleId=@roleId,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("creator=@creator,");
			strSql.Append("cteateDate=@cteateDate,");
			strSql.Append("lastLoginDate=@lastLoginDate,");
			strSql.Append("loginDate=@loginDate,");
			strSql.Append("loginTimes=@loginTimes,");
			strSql.Append("expand1=@expand1,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,30),
					new SqlParameter("@passWord", SqlDbType.VarChar,64),
					new SqlParameter("@cnName", SqlDbType.VarChar,14),
					new SqlParameter("@state", SqlDbType.SmallInt,2),
					new SqlParameter("@userType", SqlDbType.SmallInt,2),
					new SqlParameter("@roleId", SqlDbType.VarChar,36),
					new SqlParameter("@mobile", SqlDbType.VarChar,12),
					new SqlParameter("@creator", SqlDbType.VarChar,14),
					new SqlParameter("@cteateDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@loginDate", SqlDbType.DateTime),
					new SqlParameter("@loginTimes", SqlDbType.Int,4),
					new SqlParameter("@expand1", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.passWord;
			parameters[2].Value = model.cnName;
			parameters[3].Value = model.state;
			parameters[4].Value = model.userType;
			parameters[5].Value = model.roleId;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.creator;
			parameters[8].Value = model.cteateDate;
			parameters[9].Value = model.lastLoginDate;
			parameters[10].Value = model.loginDate;
			parameters[11].Value = model.loginTimes;
			parameters[12].Value = model.expand1;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from Managers ");
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
			strSql.Append("delete from Managers ");
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
		public GoosleB2C.Model.Managers GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark from Managers ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = id;

			GoosleB2C.Model.Managers model=new GoosleB2C.Model.Managers();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=ds.Tables[0].Rows[0]["id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["userName"]!=null && ds.Tables[0].Rows[0]["userName"].ToString()!="")
				{
					model.userName=ds.Tables[0].Rows[0]["userName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["passWord"]!=null && ds.Tables[0].Rows[0]["passWord"].ToString()!="")
				{
					model.passWord=ds.Tables[0].Rows[0]["passWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cnName"]!=null && ds.Tables[0].Rows[0]["cnName"].ToString()!="")
				{
					model.cnName=ds.Tables[0].Rows[0]["cnName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["state"]!=null && ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["userType"]!=null && ds.Tables[0].Rows[0]["userType"].ToString()!="")
				{
					model.userType=int.Parse(ds.Tables[0].Rows[0]["userType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["roleId"]!=null && ds.Tables[0].Rows[0]["roleId"].ToString()!="")
				{
					model.roleId=ds.Tables[0].Rows[0]["roleId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null && ds.Tables[0].Rows[0]["mobile"].ToString()!="")
				{
					model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["creator"]!=null && ds.Tables[0].Rows[0]["creator"].ToString()!="")
				{
					model.creator=ds.Tables[0].Rows[0]["creator"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cteateDate"]!=null && ds.Tables[0].Rows[0]["cteateDate"].ToString()!="")
				{
					model.cteateDate=DateTime.Parse(ds.Tables[0].Rows[0]["cteateDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lastLoginDate"]!=null && ds.Tables[0].Rows[0]["lastLoginDate"].ToString()!="")
				{
					model.lastLoginDate=DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["loginDate"]!=null && ds.Tables[0].Rows[0]["loginDate"].ToString()!="")
				{
					model.loginDate=DateTime.Parse(ds.Tables[0].Rows[0]["loginDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["loginTimes"]!=null && ds.Tables[0].Rows[0]["loginTimes"].ToString()!="")
				{
					model.loginTimes=int.Parse(ds.Tables[0].Rows[0]["loginTimes"].ToString());
				}
				if(ds.Tables[0].Rows[0]["expand1"]!=null && ds.Tables[0].Rows[0]["expand1"].ToString()!="")
				{
					model.expand1=ds.Tables[0].Rows[0]["expand1"].ToString();
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
			strSql.Append("select id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark ");
			strSql.Append(" FROM Managers ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+ strWhere);
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
			strSql.Append(" id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark ");
			strSql.Append(" FROM Managers ");
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
			strSql.Append("select count(1) FROM Managers ");
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
			strSql.Append(")AS Row, T.*  from Managers T ");
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
        //public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        //      {
        //          SqlParameter[] parameters = {
        //                  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //                  new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //                  new SqlParameter("@PageSize", SqlDbType.Int),
        //                  new SqlParameter("@PageIndex", SqlDbType.Int),
        //                  new SqlParameter("@IsReCount", SqlDbType.Bit),
        //                  new SqlParameter("@OrderType", SqlDbType.Bit),
        //                  new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //                  };
        //          parameters[0].Value = "Managers";
        //          parameters[1].Value = "id";
        //          parameters[2].Value = PageSize;
        //          parameters[3].Value = PageIndex;
        //          parameters[4].Value = 0;
        //          parameters[5].Value = 0;
        //          parameters[6].Value = strWhere;
        //          return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        //      }        
        #endregion  Method
        public GoosleB2C.Model.Managers GetModelByName(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark from Managers ");
            strSql.Append(" where userName=@userName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,30)};
            parameters[0].Value = userName;

            GoosleB2C.Model.Managers model = new GoosleB2C.Model.Managers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userName"] != null && ds.Tables[0].Rows[0]["userName"].ToString() != "")
                {
                    model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passWord"] != null && ds.Tables[0].Rows[0]["passWord"].ToString() != "")
                {
                    model.passWord = ds.Tables[0].Rows[0]["passWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cnName"] != null && ds.Tables[0].Rows[0]["cnName"].ToString() != "")
                {
                    model.cnName = ds.Tables[0].Rows[0]["cnName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userType"] != null && ds.Tables[0].Rows[0]["userType"].ToString() != "")
                {
                    model.userType = int.Parse(ds.Tables[0].Rows[0]["userType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["roleId"] != null && ds.Tables[0].Rows[0]["roleId"].ToString() != "")
                {
                    model.roleId = ds.Tables[0].Rows[0]["roleId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mobile"] != null && ds.Tables[0].Rows[0]["mobile"].ToString() != "")
                {
                    model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["creator"] != null && ds.Tables[0].Rows[0]["creator"].ToString() != "")
                {
                    model.creator = ds.Tables[0].Rows[0]["creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cteateDate"] != null && ds.Tables[0].Rows[0]["cteateDate"].ToString() != "")
                {
                    model.cteateDate = DateTime.Parse(ds.Tables[0].Rows[0]["cteateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastLoginDate"] != null && ds.Tables[0].Rows[0]["lastLoginDate"].ToString() != "")
                {
                    model.lastLoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginDate"] != null && ds.Tables[0].Rows[0]["loginDate"].ToString() != "")
                {
                    model.loginDate = DateTime.Parse(ds.Tables[0].Rows[0]["loginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginTimes"] != null && ds.Tables[0].Rows[0]["loginTimes"].ToString() != "")
                {
                    model.loginTimes = int.Parse(ds.Tables[0].Rows[0]["loginTimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["expand1"] != null && ds.Tables[0].Rows[0]["expand1"].ToString() != "")
                {
                    model.expand1 = ds.Tables[0].Rows[0]["expand1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

