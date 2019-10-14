using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// Article
    /// </summary>
    public partial class Article
    {

        public DataSet GetTitle()
        {
            return dal.GetTitle();
        }
        public DataSet GetArticlType()
        {
            return dal.GetArticleType();
        }
        public DataSet GetList_()
        {
            return dal.GetList_();
        }
        public DataSet GetOneList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetOneList(Top, strWhere, filedOrder);
        }
        public DataSet GetImgsSrc(string IDlist)
        {
            return dal.GetImgsSrc(IDlist);
        }
        public DataSet GetWxList_()
        {
            return dal.GetWxList_();
        }
    }
}
