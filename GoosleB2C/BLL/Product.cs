using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// 又超级管理员管理
	/// </summary>
	public partial class Product
	{
		private readonly GoosleB2C.DAL.Product dal=new GoosleB2C.DAL.Product();
		public Product()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string pId)
        {
            return dal.Exists(pId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoosleB2C.Model.Product model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string pId)
        {

            return dal.Delete(pId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string pIdlist)
        {
            return dal.DeleteList(pIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.Product GetModel(string pId)
        {

            return dal.GetModel(pId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GoosleB2C.Model.Product GetModelByCache(string pId)
        {

            string CacheKey = "ProductModel-" + pId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(pId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (GoosleB2C.Model.Product)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoosleB2C.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoosleB2C.Model.Product> DataTableToList(DataTable dt)
        {
            List<GoosleB2C.Model.Product> modelList = new List<GoosleB2C.Model.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GoosleB2C.Model.Product model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoosleB2C.Model.Product();
                    if (dt.Rows[n]["pId"] != null && dt.Rows[n]["pId"].ToString() != "")
                    {
                        model.pId = dt.Rows[n]["pId"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["orders"] != null && dt.Rows[n]["orders"].ToString() != "")
                    {
                        model.orders = int.Parse(dt.Rows[n]["orders"].ToString());
                    }
                    if (dt.Rows[n]["proCategory"] != null && dt.Rows[n]["proCategory"].ToString() != "")
                    {
                        model.proCategory = int.Parse(dt.Rows[n]["proCategory"].ToString());
                    }
                    if (dt.Rows[n]["img1"] != null && dt.Rows[n]["img1"].ToString() != "")
                    {
                        model.img1 = dt.Rows[n]["img1"].ToString();
                    }
                    if (dt.Rows[n]["img2"] != null && dt.Rows[n]["img2"].ToString() != "")
                    {
                        model.img2 = dt.Rows[n]["img2"].ToString();
                    }
                    if (dt.Rows[n]["img3"] != null && dt.Rows[n]["img3"].ToString() != "")
                    {
                        model.img3 = dt.Rows[n]["img3"].ToString();
                    }
                    if (dt.Rows[n]["img4"] != null && dt.Rows[n]["img4"].ToString() != "")
                    {
                        model.img4 = dt.Rows[n]["img4"].ToString();
                    }
                    if (dt.Rows[n]["img5"] != null && dt.Rows[n]["img5"].ToString() != "")
                    {
                        model.img5 = dt.Rows[n]["img5"].ToString();
                    }
                    if (dt.Rows[n]["originalPrice"] != null && dt.Rows[n]["originalPrice"].ToString() != "")
                    {
                        model.originalPrice = decimal.Parse(dt.Rows[n]["originalPrice"].ToString());
                    }
                    if (dt.Rows[n]["price"] != null && dt.Rows[n]["price"].ToString() != "")
                    {
                        model.price = decimal.Parse(dt.Rows[n]["price"].ToString());
                    }
                    if (dt.Rows[n]["total"] != null && dt.Rows[n]["total"].ToString() != "")
                    {
                        model.total = int.Parse(dt.Rows[n]["total"].ToString());
                    }
                    if (dt.Rows[n]["sales"] != null && dt.Rows[n]["sales"].ToString() != "")
                    {
                        model.sales = int.Parse(dt.Rows[n]["sales"].ToString());
                    }
                    if (dt.Rows[n]["webDetails"] != null && dt.Rows[n]["webDetails"].ToString() != "")
                    {
                        model.webDetails = dt.Rows[n]["webDetails"].ToString();
                    }
                    if (dt.Rows[n]["details"] != null && dt.Rows[n]["details"].ToString() != "")
                    {
                        model.details = dt.Rows[n]["details"].ToString();
                    }
                    if (dt.Rows[n]["detailImgs"] != null && dt.Rows[n]["detailImgs"].ToString() != "")
                    {
                        model.detailImgs = dt.Rows[n]["detailImgs"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["deliveryTempId"] != null && dt.Rows[n]["deliveryTempId"].ToString() != "")
                    {
                        model.deliveryTempId = dt.Rows[n]["deliveryTempId"].ToString();
                    }
                    if (dt.Rows[n]["seoTitle"] != null && dt.Rows[n]["seoTitle"].ToString() != "")
                    {
                        model.seoTitle = dt.Rows[n]["seoTitle"].ToString();
                    }
                    if (dt.Rows[n]["seoKey"] != null && dt.Rows[n]["seoKey"].ToString() != "")
                    {
                        model.seoKey = dt.Rows[n]["seoKey"].ToString();
                    }
                    if (dt.Rows[n]["seoDescribe"] != null && dt.Rows[n]["seoDescribe"].ToString() != "")
                    {
                        model.seoDescribe = dt.Rows[n]["seoDescribe"].ToString();
                    }
                    if (dt.Rows[n]["creator"] != null && dt.Rows[n]["creator"].ToString() != "")
                    {
                        model.creator = dt.Rows[n]["creator"].ToString();
                    }
                    if (dt.Rows[n]["createTtime"] != null && dt.Rows[n]["createTtime"].ToString() != "")
                    {
                        model.createTtime = DateTime.Parse(dt.Rows[n]["createTtime"].ToString());
                    }
                    if (dt.Rows[n]["modifier"] != null && dt.Rows[n]["modifier"].ToString() != "")
                    {
                        model.modifier = dt.Rows[n]["modifier"].ToString();
                    }
                    if (dt.Rows[n]["modifyDate"] != null && dt.Rows[n]["modifyDate"].ToString() != "")
                    {
                        model.modifyDate = DateTime.Parse(dt.Rows[n]["modifyDate"].ToString());
                    }
                    if (dt.Rows[n]["remark"] != null && dt.Rows[n]["remark"].ToString() != "")
                    {
                        model.remark = dt.Rows[n]["remark"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

