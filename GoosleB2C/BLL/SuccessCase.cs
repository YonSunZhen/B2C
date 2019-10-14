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
	public partial class SuccessCase
	{
		private readonly GoosleB2C.DAL.SuccessCase dal=new GoosleB2C.DAL.SuccessCase();
		public SuccessCase()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoosleB2C.Model.SuccessCase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoosleB2C.Model.SuccessCase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.SuccessCase GetModel(string Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GoosleB2C.Model.SuccessCase GetModelByCache(string Id)
        {

            string CacheKey = "SuccessCaseModel-" + Id;
            object objModel = GoosleB2C.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = GoosleB2C.Common.ConfigHelper.GetConfigInt("ModelCache");
                        GoosleB2C.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (GoosleB2C.Model.SuccessCase)objModel;
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
        public List<GoosleB2C.Model.SuccessCase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoosleB2C.Model.SuccessCase> DataTableToList(DataTable dt)
        {
            List<GoosleB2C.Model.SuccessCase> modelList = new List<GoosleB2C.Model.SuccessCase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GoosleB2C.Model.SuccessCase model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoosleB2C.Model.SuccessCase();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = dt.Rows[n]["Id"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["orders"] != null && dt.Rows[n]["orders"].ToString() != "")
                    {
                        model.orders = int.Parse(dt.Rows[n]["orders"].ToString());
                    }
                    if (dt.Rows[n]["mainImg"] != null && dt.Rows[n]["mainImg"].ToString() != "")
                    {
                        model.mainImg = dt.Rows[n]["mainImg"].ToString();
                    }
                    if (dt.Rows[n]["summay"] != null && dt.Rows[n]["summay"].ToString() != "")
                    {
                        model.summay = dt.Rows[n]["summay"].ToString();
                    }
                    if (dt.Rows[n]["webContent"] != null && dt.Rows[n]["webContent"].ToString() != "")
                    {
                        model.webContent = dt.Rows[n]["webContent"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["imgs"] != null && dt.Rows[n]["imgs"].ToString() != "")
                    {
                        model.imgs = dt.Rows[n]["imgs"].ToString();
                    }
                    if (dt.Rows[n]["readCount"] != null && dt.Rows[n]["readCount"].ToString() != "")
                    {
                        model.readCount = int.Parse(dt.Rows[n]["readCount"].ToString());
                    }
                    if (dt.Rows[n]["remark"] != null && dt.Rows[n]["remark"].ToString() != "")
                    {
                        model.remark = dt.Rows[n]["remark"].ToString();
                    }
                    if (dt.Rows[n]["creator"] != null && dt.Rows[n]["creator"].ToString() != "")
                    {
                        model.creator = dt.Rows[n]["creator"].ToString();
                    }
                    if (dt.Rows[n]["createTime"] != null && dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
                    if (dt.Rows[n]["modifier"] != null && dt.Rows[n]["modifier"].ToString() != "")
                    {
                        model.modifier = dt.Rows[n]["modifier"].ToString();
                    }
                    if (dt.Rows[n]["modifyDate"] != null && dt.Rows[n]["modifyDate"].ToString() != "")
                    {
                        model.modifyDate = DateTime.Parse(dt.Rows[n]["modifyDate"].ToString());
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
        /// 分页&自定义字段获取数据列表
        /// </summary>
        public DataSet GetListByPageColumn(string strWhere, string orderby, int startIndex, int endIndex, string column)
        {
            return dal.GetListByPageColumn(strWhere, orderby, startIndex, endIndex,column);
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

