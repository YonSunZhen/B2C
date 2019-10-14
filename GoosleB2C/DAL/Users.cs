using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class Users
	{
		public Users()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string uId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where uId=@uId ");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.VarChar,36)};
			parameters[0].Value = uId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("uId,UserName,PassWord,wId,wName,wImg,wCode,realName,sex,phone,state,levelId,points,remak,fund,loginTime,loginIp,lastTime,lastIp)");
			strSql.Append(" values (");
			strSql.Append("@uId,@UserName,@PassWord,@wId,@wName,@wImg,@wCode,@realName,@sex,@phone,@state,@levelId,@points,@remak,@fund,@loginTime,@loginIp,@lastTime,@lastIp)");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.VarChar,36),
					new SqlParameter("@UserName", SqlDbType.VarChar,32),
					new SqlParameter("@PassWord", SqlDbType.VarChar,64),
					new SqlParameter("@wId", SqlDbType.VarChar,100),
					new SqlParameter("@wName", SqlDbType.VarChar,100),
					new SqlParameter("@wImg", SqlDbType.VarChar,200),
					new SqlParameter("@wCode", SqlDbType.VarChar,100),
					new SqlParameter("@realName", SqlDbType.VarChar,20),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.VarChar,11),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@levelId", SqlDbType.VarChar,36),
					new SqlParameter("@points", SqlDbType.Int,4),
					new SqlParameter("@remak", SqlDbType.VarChar,200),
					new SqlParameter("@fund", SqlDbType.Float,8),
					new SqlParameter("@loginTime", SqlDbType.DateTime),
					new SqlParameter("@loginIp", SqlDbType.VarChar,64),
					new SqlParameter("@lastTime", SqlDbType.DateTime),
					new SqlParameter("@lastIp", SqlDbType.VarChar,64)};
			parameters[0].Value = model.uId;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.PassWord;
			parameters[3].Value = model.wId;
			parameters[4].Value = model.wName;
			parameters[5].Value = model.wImg;
			parameters[6].Value = model.wCode;
			parameters[7].Value = model.realName;
			parameters[8].Value = model.sex;
			parameters[9].Value = model.phone;
			parameters[10].Value = model.state;
			parameters[11].Value = model.levelId;
			parameters[12].Value = model.points;
			parameters[13].Value = model.remak;
			parameters[14].Value = model.fund;
			parameters[15].Value = model.loginTime;
			parameters[16].Value = model.loginIp;
			parameters[17].Value = model.lastTime;
			parameters[18].Value = model.lastIp;

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
		public bool Update(GoosleB2C.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("wId=@wId,");
			strSql.Append("wName=@wName,");
			strSql.Append("wImg=@wImg,");
			strSql.Append("wCode=@wCode,");
			strSql.Append("realName=@realName,");
			strSql.Append("sex=@sex,");
			strSql.Append("phone=@phone,");
			strSql.Append("state=@state,");
			strSql.Append("levelId=@levelId,");
			strSql.Append("points=@points,");
			strSql.Append("remak=@remak,");
			strSql.Append("fund=@fund,");
			strSql.Append("loginTime=@loginTime,");
			strSql.Append("loginIp=@loginIp,");
			strSql.Append("lastTime=@lastTime,");
			strSql.Append("lastIp=@lastIp");
			strSql.Append(" where uId=@uId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,32),
					new SqlParameter("@PassWord", SqlDbType.VarChar,64),
					new SqlParameter("@wId", SqlDbType.VarChar,100),
					new SqlParameter("@wName", SqlDbType.VarChar,100),
					new SqlParameter("@wImg", SqlDbType.VarChar,200),
					new SqlParameter("@wCode", SqlDbType.VarChar,100),
					new SqlParameter("@realName", SqlDbType.VarChar,20),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.VarChar,11),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@levelId", SqlDbType.VarChar,36),
					new SqlParameter("@points", SqlDbType.Int,4),
					new SqlParameter("@remak", SqlDbType.VarChar,200),
					new SqlParameter("@fund", SqlDbType.Float,8),
					new SqlParameter("@loginTime", SqlDbType.DateTime),
					new SqlParameter("@loginIp", SqlDbType.VarChar,64),
					new SqlParameter("@lastTime", SqlDbType.DateTime),
					new SqlParameter("@lastIp", SqlDbType.VarChar,64),
					new SqlParameter("@uId", SqlDbType.VarChar,36)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.wId;
			parameters[3].Value = model.wName;
			parameters[4].Value = model.wImg;
			parameters[5].Value = model.wCode;
			parameters[6].Value = model.realName;
			parameters[7].Value = model.sex;
			parameters[8].Value = model.phone;
			parameters[9].Value = model.state;
			parameters[10].Value = model.levelId;
			parameters[11].Value = model.points;
			parameters[12].Value = model.remak;
			parameters[13].Value = model.fund;
			parameters[14].Value = model.loginTime;
			parameters[15].Value = model.loginIp;
			parameters[16].Value = model.lastTime;
			parameters[17].Value = model.lastIp;
			parameters[18].Value = model.uId;

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
		public bool Delete(string uId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where uId=@uId ");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.VarChar,36)};
			parameters[0].Value = uId;

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
		public bool DeleteList(string uIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where uId in ("+uIdlist + ")  ");
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
		public GoosleB2C.Model.Users GetModel(string uId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 uId,UserName,PassWord,wId,wName,wImg,wCode,realName,sex,phone,state,levelId,points,remak,fund,loginTime,loginIp,lastTime,lastIp from Users ");
			strSql.Append(" where uId=@uId ");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.VarChar,36)};
			parameters[0].Value = uId;

			GoosleB2C.Model.Users model=new GoosleB2C.Model.Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["uId"]!=null && ds.Tables[0].Rows[0]["uId"].ToString()!="")
				{
					model.uId=ds.Tables[0].Rows[0]["uId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PassWord"]!=null && ds.Tables[0].Rows[0]["PassWord"].ToString()!="")
				{
					model.PassWord=ds.Tables[0].Rows[0]["PassWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["wId"]!=null && ds.Tables[0].Rows[0]["wId"].ToString()!="")
				{
					model.wId=ds.Tables[0].Rows[0]["wId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["wName"]!=null && ds.Tables[0].Rows[0]["wName"].ToString()!="")
				{
					model.wName=ds.Tables[0].Rows[0]["wName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["wImg"]!=null && ds.Tables[0].Rows[0]["wImg"].ToString()!="")
				{
					model.wImg=ds.Tables[0].Rows[0]["wImg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["wCode"]!=null && ds.Tables[0].Rows[0]["wCode"].ToString()!="")
				{
					model.wCode=ds.Tables[0].Rows[0]["wCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["realName"]!=null && ds.Tables[0].Rows[0]["realName"].ToString()!="")
				{
					model.realName=ds.Tables[0].Rows[0]["realName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sex"]!=null && ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					model.sex=int.Parse(ds.Tables[0].Rows[0]["sex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["phone"]!=null && ds.Tables[0].Rows[0]["phone"].ToString()!="")
				{
					model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["state"]!=null && ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["levelId"]!=null && ds.Tables[0].Rows[0]["levelId"].ToString()!="")
				{
					model.levelId=ds.Tables[0].Rows[0]["levelId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["points"]!=null && ds.Tables[0].Rows[0]["points"].ToString()!="")
				{
					model.points=int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
				}
				if(ds.Tables[0].Rows[0]["remak"]!=null && ds.Tables[0].Rows[0]["remak"].ToString()!="")
				{
					model.remak=ds.Tables[0].Rows[0]["remak"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fund"]!=null && ds.Tables[0].Rows[0]["fund"].ToString()!="")
				{
					model.fund=decimal.Parse(ds.Tables[0].Rows[0]["fund"].ToString());
				}
				if(ds.Tables[0].Rows[0]["loginTime"]!=null && ds.Tables[0].Rows[0]["loginTime"].ToString()!="")
				{
					model.loginTime=DateTime.Parse(ds.Tables[0].Rows[0]["loginTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["loginIp"]!=null && ds.Tables[0].Rows[0]["loginIp"].ToString()!="")
				{
					model.loginIp=ds.Tables[0].Rows[0]["loginIp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lastTime"]!=null && ds.Tables[0].Rows[0]["lastTime"].ToString()!="")
				{
					model.lastTime=DateTime.Parse(ds.Tables[0].Rows[0]["lastTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lastIp"]!=null && ds.Tables[0].Rows[0]["lastIp"].ToString()!="")
				{
					model.lastIp=ds.Tables[0].Rows[0]["lastIp"].ToString();
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
			strSql.Append("select uId,UserName,PassWord,wId,wName,wImg,wCode,realName,sex,phone,state,levelId,points,remak,fund,loginTime,loginIp,lastTime,lastIp ");
			strSql.Append(" FROM Users ");
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
			strSql.Append(" uId,UserName,PassWord,wId,wName,wImg,wCode,realName,sex,phone,state,levelId,points,remak,fund,loginTime,loginIp,lastTime,lastIp ");
			strSql.Append(" FROM Users ");
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
			strSql.Append("select count(1) FROM Users ");
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
				strSql.Append("order by T.uId desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
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
			parameters[0].Value = "Users";
			parameters[1].Value = "uId";
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

