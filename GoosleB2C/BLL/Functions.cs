using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Functions
	/// </summary>
	public partial class Functions
	{
		private readonly GoosleB2C.DAL.Functions dal=new GoosleB2C.DAL.Functions();
		public Functions()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.Functions model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoosleB2C.Model.Functions model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.Functions GetModel(string id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GoosleB2C.Model.Functions GetModelByCache(string id)
        {

            string CacheKey = "FunctionsModel-" + id;
            object objModel = GoosleB2C.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = GoosleB2C.Common.ConfigHelper.GetConfigInt("ModelCache");
                        GoosleB2C.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (GoosleB2C.Model.Functions)objModel;
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
        public List<GoosleB2C.Model.Functions> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoosleB2C.Model.Functions> DataTableToList(DataTable dt)
        {
            List<GoosleB2C.Model.Functions> modelList = new List<GoosleB2C.Model.Functions>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GoosleB2C.Model.Functions model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoosleB2C.Model.Functions();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = dt.Rows[n]["id"].ToString();
                    }
                    if (dt.Rows[n]["functionName"] != null && dt.Rows[n]["functionName"].ToString() != "")
                    {
                        model.functionName = dt.Rows[n]["functionName"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
                    }
                    if (dt.Rows[n]["father"] != null && dt.Rows[n]["father"].ToString() != "")
                    {
                        model.father = dt.Rows[n]["father"].ToString();
                    }
                    if (dt.Rows[n]["funLevel"] != null && dt.Rows[n]["funLevel"].ToString() != "")
                    {
                        model.funLevel = int.Parse(dt.Rows[n]["funLevel"].ToString());
                    }
                    if (dt.Rows[n]["funOrder"] != null && dt.Rows[n]["funOrder"].ToString() != "")
                    {
                        model.funOrder = int.Parse(dt.Rows[n]["funOrder"].ToString());
                    }
                    if (dt.Rows[n]["funType"] != null && dt.Rows[n]["funType"].ToString() != "")
                    {
                        model.funType = int.Parse(dt.Rows[n]["funType"].ToString());
                    }
                    if (dt.Rows[n]["img1"] != null && dt.Rows[n]["img1"].ToString() != "")
                    {
                        model.img1 = dt.Rows[n]["img1"].ToString();
                    }
                    if (dt.Rows[n]["img2"] != null && dt.Rows[n]["img2"].ToString() != "")
                    {
                        model.img2 = dt.Rows[n]["img2"].ToString();
                    }
                    if (dt.Rows[n]["intro"] != null && dt.Rows[n]["intro"].ToString() != "")
                    {
                        model.intro = dt.Rows[n]["intro"].ToString();
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

