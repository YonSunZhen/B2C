using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
	/// <summary>
	/// 数据访问类:Product
	/// </summary>
	public partial class Product
	{
		public Product()
		{}
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string pId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Product");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@pId", SqlDbType.VarChar,36)};
            parameters[0].Value = pId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Product(");
            strSql.Append("pId,title,orders,proCategory,img1,img2,img3,img4,img5,originalPrice,price,total,sales,webDetails,details,detailImgs,state,deliveryTempId,seoTitle,seoKey,seoDescribe,creator,createTtime,modifier,modifyDate,remark)");
            strSql.Append(" values (");
            strSql.Append("@pId,@title,@orders,@proCategory,@img1,@img2,@img3,@img4,@img5,@originalPrice,@price,@total,@sales,@webDetails,@details,@detailImgs,@state,@deliveryTempId,@seoTitle,@seoKey,@seoDescribe,@creator,@createTtime,@modifier,@modifyDate,@remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@pId", SqlDbType.VarChar,36),
                    new SqlParameter("@title", SqlDbType.VarChar,120),
                    new SqlParameter("@orders", SqlDbType.Int,4),
                    new SqlParameter("@proCategory", SqlDbType.Int,4),
                    new SqlParameter("@img1", SqlDbType.VarChar,200),
                    new SqlParameter("@img2", SqlDbType.VarChar,200),
                    new SqlParameter("@img3", SqlDbType.VarChar,200),
                    new SqlParameter("@img4", SqlDbType.VarChar,200),
                    new SqlParameter("@img5", SqlDbType.VarChar,200),
                    new SqlParameter("@originalPrice", SqlDbType.Float,8),
                    new SqlParameter("@price", SqlDbType.Float,8),
                    new SqlParameter("@total", SqlDbType.Int,4),
                    new SqlParameter("@sales", SqlDbType.Int,4),
                    new SqlParameter("@webDetails", SqlDbType.VarChar),
                    new SqlParameter("@details", SqlDbType.VarChar),
                    new SqlParameter("@detailImgs", SqlDbType.VarChar),
                    new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@deliveryTempId", SqlDbType.VarChar,36),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoDescribe", SqlDbType.VarChar,500),
                    new SqlParameter("@creator", SqlDbType.VarChar,20),
                    new SqlParameter("@createTtime", SqlDbType.DateTime),
                    new SqlParameter("@modifier", SqlDbType.VarChar,20),
                    new SqlParameter("@modifyDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.VarChar,300)};
            parameters[0].Value = model.pId;
            parameters[1].Value = model.title;
            parameters[2].Value = model.orders;
            parameters[3].Value = model.proCategory;
            parameters[4].Value = model.img1;
            parameters[5].Value = model.img2;
            parameters[6].Value = model.img3;
            parameters[7].Value = model.img4;
            parameters[8].Value = model.img5;
            parameters[9].Value = model.originalPrice;
            parameters[10].Value = model.price;
            parameters[11].Value = model.total;
            parameters[12].Value = model.sales;
            parameters[13].Value = model.webDetails;
            parameters[14].Value = model.details;
            parameters[15].Value = model.detailImgs;
            parameters[16].Value = model.state;
            parameters[17].Value = model.deliveryTempId;
            parameters[18].Value = model.seoTitle;
            parameters[19].Value = model.seoKey;
            parameters[20].Value = model.seoDescribe;
            parameters[21].Value = model.creator;
            parameters[22].Value = model.createTtime;
            parameters[23].Value = model.modifier;
            parameters[24].Value = model.modifyDate;
            parameters[25].Value = model.remark;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(GoosleB2C.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("title=@title,");
            strSql.Append("orders=@orders,");
            strSql.Append("proCategory=@proCategory,");
            strSql.Append("img1=@img1,");
            strSql.Append("img2=@img2,");
            strSql.Append("img3=@img3,");
            strSql.Append("img4=@img4,");
            strSql.Append("img5=@img5,");
            strSql.Append("originalPrice=@originalPrice,");
            strSql.Append("price=@price,");
            strSql.Append("total=@total,");
            strSql.Append("sales=@sales,");
            strSql.Append("webDetails=@webDetails,");
            strSql.Append("details=@details,");
            strSql.Append("detailImgs=@detailImgs,");
            strSql.Append("state=@state,");
            strSql.Append("deliveryTempId=@deliveryTempId,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("seoKey=@seoKey,");
            strSql.Append("seoDescribe=@seoDescribe,");
            strSql.Append("creator=@creator,");
            strSql.Append("createTtime=@createTtime,");
            strSql.Append("modifier=@modifier,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("remark=@remark");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@title", SqlDbType.VarChar,120),
                    new SqlParameter("@orders", SqlDbType.Int,4),
                    new SqlParameter("@proCategory", SqlDbType.Int,4),
                    new SqlParameter("@img1", SqlDbType.VarChar,200),
                    new SqlParameter("@img2", SqlDbType.VarChar,200),
                    new SqlParameter("@img3", SqlDbType.VarChar,200),
                    new SqlParameter("@img4", SqlDbType.VarChar,200),
                    new SqlParameter("@img5", SqlDbType.VarChar,200),
                    new SqlParameter("@originalPrice", SqlDbType.Float,8),
                    new SqlParameter("@price", SqlDbType.Float,8),
                    new SqlParameter("@total", SqlDbType.Int,4),
                    new SqlParameter("@sales", SqlDbType.Int,4),
                    new SqlParameter("@webDetails", SqlDbType.VarChar),
                    new SqlParameter("@details", SqlDbType.VarChar),
                    new SqlParameter("@detailImgs", SqlDbType.VarChar),
                    new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@deliveryTempId", SqlDbType.VarChar,36),
                    new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@seoKey", SqlDbType.VarChar,100),
                    new SqlParameter("@seoDescribe", SqlDbType.VarChar,500),
                    new SqlParameter("@creator", SqlDbType.VarChar,20),
                    new SqlParameter("@createTtime", SqlDbType.DateTime),
                    new SqlParameter("@modifier", SqlDbType.VarChar,20),
                    new SqlParameter("@modifyDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.VarChar,300),
                    new SqlParameter("@pId", SqlDbType.VarChar,36)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.orders;
            parameters[2].Value = model.proCategory;
            parameters[3].Value = model.img1;
            parameters[4].Value = model.img2;
            parameters[5].Value = model.img3;
            parameters[6].Value = model.img4;
            parameters[7].Value = model.img5;
            parameters[8].Value = model.originalPrice;
            parameters[9].Value = model.price;
            parameters[10].Value = model.total;
            parameters[11].Value = model.sales;
            parameters[12].Value = model.webDetails;
            parameters[13].Value = model.details;
            parameters[14].Value = model.detailImgs;
            parameters[15].Value = model.state;
            parameters[16].Value = model.deliveryTempId;
            parameters[17].Value = model.seoTitle;
            parameters[18].Value = model.seoKey;
            parameters[19].Value = model.seoDescribe;
            parameters[20].Value = model.creator;
            parameters[21].Value = model.createTtime;
            parameters[22].Value = model.modifier;
            parameters[23].Value = model.modifyDate;
            parameters[24].Value = model.remark;
            parameters[25].Value = model.pId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string pId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@pId", SqlDbType.VarChar,36)};
            parameters[0].Value = pId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string pIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where pId in (" + pIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public GoosleB2C.Model.Product GetModel(string pId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pId,title,orders,proCategory,img1,img2,img3,img4,img5,originalPrice,price,total,sales,webDetails,details,detailImgs,state,deliveryTempId,seoTitle,seoKey,seoDescribe,creator,createTtime,modifier,modifyDate,remark from Product ");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@pId", SqlDbType.VarChar,36)};
            parameters[0].Value = pId;

            GoosleB2C.Model.Product model = new GoosleB2C.Model.Product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["pId"] != null && ds.Tables[0].Rows[0]["pId"].ToString() != "")
                {
                    model.pId = ds.Tables[0].Rows[0]["pId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["orders"] != null && ds.Tables[0].Rows[0]["orders"].ToString() != "")
                {
                    model.orders = int.Parse(ds.Tables[0].Rows[0]["orders"].ToString());
                }
                if (ds.Tables[0].Rows[0]["proCategory"] != null && ds.Tables[0].Rows[0]["proCategory"].ToString() != "")
                {
                    model.proCategory = int.Parse(ds.Tables[0].Rows[0]["proCategory"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img1"] != null && ds.Tables[0].Rows[0]["img1"].ToString() != "")
                {
                    model.img1 = ds.Tables[0].Rows[0]["img1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img2"] != null && ds.Tables[0].Rows[0]["img2"].ToString() != "")
                {
                    model.img2 = ds.Tables[0].Rows[0]["img2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img3"] != null && ds.Tables[0].Rows[0]["img3"].ToString() != "")
                {
                    model.img3 = ds.Tables[0].Rows[0]["img3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img4"] != null && ds.Tables[0].Rows[0]["img4"].ToString() != "")
                {
                    model.img4 = ds.Tables[0].Rows[0]["img4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img5"] != null && ds.Tables[0].Rows[0]["img5"].ToString() != "")
                {
                    model.img5 = ds.Tables[0].Rows[0]["img5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["originalPrice"] != null && ds.Tables[0].Rows[0]["originalPrice"].ToString() != "")
                {
                    model.originalPrice = decimal.Parse(ds.Tables[0].Rows[0]["originalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"] != null && ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total"] != null && ds.Tables[0].Rows[0]["total"].ToString() != "")
                {
                    model.total = int.Parse(ds.Tables[0].Rows[0]["total"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sales"] != null && ds.Tables[0].Rows[0]["sales"].ToString() != "")
                {
                    model.sales = int.Parse(ds.Tables[0].Rows[0]["sales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["webDetails"] != null && ds.Tables[0].Rows[0]["webDetails"].ToString() != "")
                {
                    model.webDetails = ds.Tables[0].Rows[0]["webDetails"].ToString();
                }
                if (ds.Tables[0].Rows[0]["details"] != null && ds.Tables[0].Rows[0]["details"].ToString() != "")
                {
                    model.details = ds.Tables[0].Rows[0]["details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detailImgs"] != null && ds.Tables[0].Rows[0]["detailImgs"].ToString() != "")
                {
                    model.detailImgs = ds.Tables[0].Rows[0]["detailImgs"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deliveryTempId"] != null && ds.Tables[0].Rows[0]["deliveryTempId"].ToString() != "")
                {
                    model.deliveryTempId = ds.Tables[0].Rows[0]["deliveryTempId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoTitle"] != null && ds.Tables[0].Rows[0]["seoTitle"].ToString() != "")
                {
                    model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoKey"] != null && ds.Tables[0].Rows[0]["seoKey"].ToString() != "")
                {
                    model.seoKey = ds.Tables[0].Rows[0]["seoKey"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seoDescribe"] != null && ds.Tables[0].Rows[0]["seoDescribe"].ToString() != "")
                {
                    model.seoDescribe = ds.Tables[0].Rows[0]["seoDescribe"].ToString();
                }
                if (ds.Tables[0].Rows[0]["creator"] != null && ds.Tables[0].Rows[0]["creator"].ToString() != "")
                {
                    model.creator = ds.Tables[0].Rows[0]["creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["createTtime"] != null && ds.Tables[0].Rows[0]["createTtime"].ToString() != "")
                {
                    model.createTtime = DateTime.Parse(ds.Tables[0].Rows[0]["createTtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["modifier"] != null && ds.Tables[0].Rows[0]["modifier"].ToString() != "")
                {
                    model.modifier = ds.Tables[0].Rows[0]["modifier"].ToString();
                }
                if (ds.Tables[0].Rows[0]["modifyDate"] != null && ds.Tables[0].Rows[0]["modifyDate"].ToString() != "")
                {
                    model.modifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["modifyDate"].ToString());
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pId,title,orders,proCategory,img1,img2,img3,img4,img5,originalPrice,price,total,sales,webDetails,details,detailImgs,state,deliveryTempId,seoTitle,seoKey,seoDescribe,creator,createTtime,modifier,modifyDate,remark ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" pId,title,orders,proCategory,img1,img2,img3,img4,img5,originalPrice,price,total,sales,webDetails,details,detailImgs,state,deliveryTempId,seoTitle,seoKey,seoDescribe,creator,createTtime,modifier,modifyDate,remark ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.pId desc");
            }
            strSql.Append(")AS Row, T.*  from Product T ");
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
			parameters[0].Value = "Product";
			parameters[1].Value = "pId";
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

