using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Brand
	/// </summary>
	public partial class Brand
	{
		public Brand()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Brand"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Brand");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Brand(");
			strSql.Append("id,img1,img2,img3,url1,url2,url3,pImg1,pImg2,pImg3,pImg4,pImg5,purl1,purl2,purl3,purl4,purl5,vImg1,vImg2,vImg3,vImg4,vImg5,vurl1,vurl2,vurl3,vurl4,vurl5)");
			strSql.Append(" values (");
			strSql.Append("@id,@img1,@img2,@img3,@url1,@url2,@url3,@pImg1,@pImg2,@pImg3,@pImg4,@pImg5,@purl1,@purl2,@purl3,@purl4,@purl5,@vImg1,@vImg2,@vImg3,@vImg4,@vImg5,@vurl1,@vurl2,@vurl3,@vurl4,@vurl5)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@img1", SqlDbType.VarChar,300),
					new SqlParameter("@img2", SqlDbType.VarChar,300),
					new SqlParameter("@img3", SqlDbType.VarChar,300),
					new SqlParameter("@url1", SqlDbType.VarChar,300),
					new SqlParameter("@url2", SqlDbType.VarChar,300),
					new SqlParameter("@url3", SqlDbType.VarChar,300),
					new SqlParameter("@pImg1", SqlDbType.VarChar,300),
					new SqlParameter("@pImg2", SqlDbType.VarChar,300),
					new SqlParameter("@pImg3", SqlDbType.VarChar,300),
					new SqlParameter("@pImg4", SqlDbType.VarChar,300),
					new SqlParameter("@pImg5", SqlDbType.VarChar,300),
					new SqlParameter("@purl1", SqlDbType.VarChar,300),
					new SqlParameter("@purl2", SqlDbType.VarChar,300),
					new SqlParameter("@purl3", SqlDbType.VarChar,300),
					new SqlParameter("@purl4", SqlDbType.VarChar,300),
					new SqlParameter("@purl5", SqlDbType.VarChar,300),
					new SqlParameter("@vImg1", SqlDbType.VarChar,300),
					new SqlParameter("@vImg2", SqlDbType.VarChar,300),
					new SqlParameter("@vImg3", SqlDbType.VarChar,300),
					new SqlParameter("@vImg4", SqlDbType.VarChar,300),
					new SqlParameter("@vImg5", SqlDbType.VarChar,300),
					new SqlParameter("@vurl1", SqlDbType.VarChar,300),
					new SqlParameter("@vurl2", SqlDbType.VarChar,300),
					new SqlParameter("@vurl3", SqlDbType.VarChar,300),
					new SqlParameter("@vurl4", SqlDbType.VarChar,300),
					new SqlParameter("@vurl5", SqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.img1;
			parameters[2].Value = model.img2;
			parameters[3].Value = model.img3;
			parameters[4].Value = model.url1;
			parameters[5].Value = model.url2;
			parameters[6].Value = model.url3;
			parameters[7].Value = model.pImg1;
			parameters[8].Value = model.pImg2;
			parameters[9].Value = model.pImg3;
			parameters[10].Value = model.pImg4;
			parameters[11].Value = model.pImg5;
			parameters[12].Value = model.purl1;
			parameters[13].Value = model.purl2;
			parameters[14].Value = model.purl3;
			parameters[15].Value = model.purl4;
			parameters[16].Value = model.purl5;
			parameters[17].Value = model.vImg1;
			parameters[18].Value = model.vImg2;
			parameters[19].Value = model.vImg3;
			parameters[20].Value = model.vImg4;
			parameters[21].Value = model.vImg5;
			parameters[22].Value = model.vurl1;
			parameters[23].Value = model.vurl2;
			parameters[24].Value = model.vurl3;
			parameters[25].Value = model.vurl4;
			parameters[26].Value = model.vurl5;

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
		public bool Update(GoosleB2C.Model.Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Brand set ");
			strSql.Append("img1=@img1,");
			strSql.Append("img2=@img2,");
			strSql.Append("img3=@img3,");
			strSql.Append("url1=@url1,");
			strSql.Append("url2=@url2,");
			strSql.Append("url3=@url3,");
			strSql.Append("pImg1=@pImg1,");
			strSql.Append("pImg2=@pImg2,");
			strSql.Append("pImg3=@pImg3,");
			strSql.Append("pImg4=@pImg4,");
			strSql.Append("pImg5=@pImg5,");
			strSql.Append("purl1=@purl1,");
			strSql.Append("purl2=@purl2,");
			strSql.Append("purl3=@purl3,");
			strSql.Append("purl4=@purl4,");
			strSql.Append("purl5=@purl5,");
			strSql.Append("vImg1=@vImg1,");
			strSql.Append("vImg2=@vImg2,");
			strSql.Append("vImg3=@vImg3,");
			strSql.Append("vImg4=@vImg4,");
			strSql.Append("vImg5=@vImg5,");
			strSql.Append("vurl1=@vurl1,");
			strSql.Append("vurl2=@vurl2,");
			strSql.Append("vurl3=@vurl3,");
			strSql.Append("vurl4=@vurl4,");
			strSql.Append("vurl5=@vurl5");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@img1", SqlDbType.VarChar,300),
					new SqlParameter("@img2", SqlDbType.VarChar,300),
					new SqlParameter("@img3", SqlDbType.VarChar,300),
					new SqlParameter("@url1", SqlDbType.VarChar,300),
					new SqlParameter("@url2", SqlDbType.VarChar,300),
					new SqlParameter("@url3", SqlDbType.VarChar,300),
					new SqlParameter("@pImg1", SqlDbType.VarChar,300),
					new SqlParameter("@pImg2", SqlDbType.VarChar,300),
					new SqlParameter("@pImg3", SqlDbType.VarChar,300),
					new SqlParameter("@pImg4", SqlDbType.VarChar,300),
					new SqlParameter("@pImg5", SqlDbType.VarChar,300),
					new SqlParameter("@purl1", SqlDbType.VarChar,300),
					new SqlParameter("@purl2", SqlDbType.VarChar,300),
					new SqlParameter("@purl3", SqlDbType.VarChar,300),
					new SqlParameter("@purl4", SqlDbType.VarChar,300),
					new SqlParameter("@purl5", SqlDbType.VarChar,300),
					new SqlParameter("@vImg1", SqlDbType.VarChar,300),
					new SqlParameter("@vImg2", SqlDbType.VarChar,300),
					new SqlParameter("@vImg3", SqlDbType.VarChar,300),
					new SqlParameter("@vImg4", SqlDbType.VarChar,300),
					new SqlParameter("@vImg5", SqlDbType.VarChar,300),
					new SqlParameter("@vurl1", SqlDbType.VarChar,300),
					new SqlParameter("@vurl2", SqlDbType.VarChar,300),
					new SqlParameter("@vurl3", SqlDbType.VarChar,300),
					new SqlParameter("@vurl4", SqlDbType.VarChar,300),
					new SqlParameter("@vurl5", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.img1;
			parameters[1].Value = model.img2;
			parameters[2].Value = model.img3;
			parameters[3].Value = model.url1;
			parameters[4].Value = model.url2;
			parameters[5].Value = model.url3;
			parameters[6].Value = model.pImg1;
			parameters[7].Value = model.pImg2;
			parameters[8].Value = model.pImg3;
			parameters[9].Value = model.pImg4;
			parameters[10].Value = model.pImg5;
			parameters[11].Value = model.purl1;
			parameters[12].Value = model.purl2;
			parameters[13].Value = model.purl3;
			parameters[14].Value = model.purl4;
			parameters[15].Value = model.purl5;
			parameters[16].Value = model.vImg1;
			parameters[17].Value = model.vImg2;
			parameters[18].Value = model.vImg3;
			parameters[19].Value = model.vImg4;
			parameters[20].Value = model.vImg5;
			parameters[21].Value = model.vurl1;
			parameters[22].Value = model.vurl2;
			parameters[23].Value = model.vurl3;
			parameters[24].Value = model.vurl4;
			parameters[25].Value = model.vurl5;
			parameters[26].Value = model.id;

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
			strSql.Append("delete from Brand ");
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
			strSql.Append("delete from Brand ");
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
		public GoosleB2C.Model.Brand GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,img1,img2,img3,url1,url2,url3,pImg1,pImg2,pImg3,pImg4,pImg5,purl1,purl2,purl3,purl4,purl5,vImg1,vImg2,vImg3,vImg4,vImg5,vurl1,vurl2,vurl3,vurl4,vurl5 from Brand ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoosleB2C.Model.Brand model=new GoosleB2C.Model.Brand();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["img1"]!=null && ds.Tables[0].Rows[0]["img1"].ToString()!="")
				{
					model.img1=ds.Tables[0].Rows[0]["img1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img2"]!=null && ds.Tables[0].Rows[0]["img2"].ToString()!="")
				{
					model.img2=ds.Tables[0].Rows[0]["img2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img3"]!=null && ds.Tables[0].Rows[0]["img3"].ToString()!="")
				{
					model.img3=ds.Tables[0].Rows[0]["img3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url1"]!=null && ds.Tables[0].Rows[0]["url1"].ToString()!="")
				{
					model.url1=ds.Tables[0].Rows[0]["url1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url2"]!=null && ds.Tables[0].Rows[0]["url2"].ToString()!="")
				{
					model.url2=ds.Tables[0].Rows[0]["url2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url3"]!=null && ds.Tables[0].Rows[0]["url3"].ToString()!="")
				{
					model.url3=ds.Tables[0].Rows[0]["url3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pImg1"]!=null && ds.Tables[0].Rows[0]["pImg1"].ToString()!="")
				{
					model.pImg1=ds.Tables[0].Rows[0]["pImg1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pImg2"]!=null && ds.Tables[0].Rows[0]["pImg2"].ToString()!="")
				{
					model.pImg2=ds.Tables[0].Rows[0]["pImg2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pImg3"]!=null && ds.Tables[0].Rows[0]["pImg3"].ToString()!="")
				{
					model.pImg3=ds.Tables[0].Rows[0]["pImg3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pImg4"]!=null && ds.Tables[0].Rows[0]["pImg4"].ToString()!="")
				{
					model.pImg4=ds.Tables[0].Rows[0]["pImg4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pImg5"]!=null && ds.Tables[0].Rows[0]["pImg5"].ToString()!="")
				{
					model.pImg5=ds.Tables[0].Rows[0]["pImg5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["purl1"]!=null && ds.Tables[0].Rows[0]["purl1"].ToString()!="")
				{
					model.purl1=ds.Tables[0].Rows[0]["purl1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["purl2"]!=null && ds.Tables[0].Rows[0]["purl2"].ToString()!="")
				{
					model.purl2=ds.Tables[0].Rows[0]["purl2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["purl3"]!=null && ds.Tables[0].Rows[0]["purl3"].ToString()!="")
				{
					model.purl3=ds.Tables[0].Rows[0]["purl3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["purl4"]!=null && ds.Tables[0].Rows[0]["purl4"].ToString()!="")
				{
					model.purl4=ds.Tables[0].Rows[0]["purl4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["purl5"]!=null && ds.Tables[0].Rows[0]["purl5"].ToString()!="")
				{
					model.purl5=ds.Tables[0].Rows[0]["purl5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vImg1"]!=null && ds.Tables[0].Rows[0]["vImg1"].ToString()!="")
				{
					model.vImg1=ds.Tables[0].Rows[0]["vImg1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vImg2"]!=null && ds.Tables[0].Rows[0]["vImg2"].ToString()!="")
				{
					model.vImg2=ds.Tables[0].Rows[0]["vImg2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vImg3"]!=null && ds.Tables[0].Rows[0]["vImg3"].ToString()!="")
				{
					model.vImg3=ds.Tables[0].Rows[0]["vImg3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vImg4"]!=null && ds.Tables[0].Rows[0]["vImg4"].ToString()!="")
				{
					model.vImg4=ds.Tables[0].Rows[0]["vImg4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vImg5"]!=null && ds.Tables[0].Rows[0]["vImg5"].ToString()!="")
				{
					model.vImg5=ds.Tables[0].Rows[0]["vImg5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vurl1"]!=null && ds.Tables[0].Rows[0]["vurl1"].ToString()!="")
				{
					model.vurl1=ds.Tables[0].Rows[0]["vurl1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vurl2"]!=null && ds.Tables[0].Rows[0]["vurl2"].ToString()!="")
				{
					model.vurl2=ds.Tables[0].Rows[0]["vurl2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vurl3"]!=null && ds.Tables[0].Rows[0]["vurl3"].ToString()!="")
				{
					model.vurl3=ds.Tables[0].Rows[0]["vurl3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vurl4"]!=null && ds.Tables[0].Rows[0]["vurl4"].ToString()!="")
				{
					model.vurl4=ds.Tables[0].Rows[0]["vurl4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vurl5"]!=null && ds.Tables[0].Rows[0]["vurl5"].ToString()!="")
				{
					model.vurl5=ds.Tables[0].Rows[0]["vurl5"].ToString();
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
			strSql.Append("select id,img1,img2,img3,url1,url2,url3,pImg1,pImg2,pImg3,pImg4,pImg5,purl1,purl2,purl3,purl4,purl5,vImg1,vImg2,vImg3,vImg4,vImg5,vurl1,vurl2,vurl3,vurl4,vurl5 ");
			strSql.Append(" FROM Brand ");
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
			strSql.Append(" id,img1,img2,img3,url1,url2,url3,pImg1,pImg2,pImg3,pImg4,pImg5,purl1,purl2,purl3,purl4,purl5,vImg1,vImg2,vImg3,vImg4,vImg5,vurl1,vurl2,vurl3,vurl4,vurl5 ");
			strSql.Append(" FROM Brand ");
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
			strSql.Append("select count(1) FROM Brand ");
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
			strSql.Append(")AS Row, T.*  from Brand T ");
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
			parameters[0].Value = "Brand";
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

