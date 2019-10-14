using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    /// <summary>
    /// 数据访问类:Article
    /// </summary>
    public partial class Article
    {
        /// <summary>
		/// 获得文章title和创建时间
		/// </summary>
		public DataSet GetTitle()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select title, createTime");
            strSql.Append(" FROM Article ");
            //strSql.Append(" where id = 1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetArticleType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, typeName");
            strSql.Append(" FROM ArticleType ");           
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList_()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Article.Id,Article.type,Article.state,Article.title,Article.orders,Article.webContent,Article.content,Article.imgs,Article.readCount,Article.remark,Article.creator,Article.createTime,Article.modifier,Article.modifyDate,Article.seoTitle,Article.seoKey,Article.seoDescribe,ArticleType.typeName ");
            strSql.Append(" FROM Article LEFT JOIN ArticleType ON  Article.type = ArticleType.id order by Article.orders ASC");
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetOneList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("Article.Id,Article.type,Article.state,Article.title,Article.orders,Article.webContent,Article.content,Article.imgs,Article.readCount,Article.remark,Article.creator,Article.createTime,Article.modifier,Article.modifyDate,Article.seoTitle,Article.seoKey,Article.seoDescribe,ArticleType.typeName");
            strSql.Append(" FROM Article LEFT JOIN ArticleType");
            strSql.Append(" ON  Article.type = ArticleType.id");           
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetImgsSrc(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select imgs from Article ");
            strSql.Append(" where Id in (" + IDlist + ") ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetWxList_()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Article.Id,Article.type,Article.state,Article.title,Article.orders,Article.webContent,Article.content,Article.imgs,Article.readCount,Article.remark,Article.creator,Article.createTime,Article.modifier,Article.modifyDate,Article.seoTitle,Article.seoKey,Article.seoDescribe,ArticleType.typeName ");
            strSql.Append(" FROM Article LEFT JOIN ArticleType ON  Article.type = ArticleType.id Where Article.state=1 order by Article.orders ASC");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }

}


