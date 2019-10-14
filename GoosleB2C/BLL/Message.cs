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
	public partial class Message
	{
		private readonly GoosleB2C.DAL.Message dal=new GoosleB2C.DAL.Message();
		public Message()
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
        public bool Add(GoosleB2C.Model.Message model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoosleB2C.Model.Message model)
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
        public GoosleB2C.Model.Message GetModel(string id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GoosleB2C.Model.Message GetModelByCache(string id)
        {

            string CacheKey = "MessageModel-" + id;
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
            return (GoosleB2C.Model.Message)objModel;
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
        public List<GoosleB2C.Model.Message> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoosleB2C.Model.Message> DataTableToList(DataTable dt)
        {
            List<GoosleB2C.Model.Message> modelList = new List<GoosleB2C.Model.Message>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GoosleB2C.Model.Message model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoosleB2C.Model.Message();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = dt.Rows[n]["id"].ToString();
                    }
                    if (dt.Rows[n]["vId"] != null && dt.Rows[n]["vId"].ToString() != "")
                    {
                        model.vId = dt.Rows[n]["vId"].ToString();
                    }
                    if (dt.Rows[n]["to"] != null && dt.Rows[n]["to"].ToString() != "")
                    {
                        model.to = dt.Rows[n]["to"].ToString();
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.sex = int.Parse(dt.Rows[n]["sex"].ToString());
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["weixin"] != null && dt.Rows[n]["weixin"].ToString() != "")
                    {
                        model.weixin = dt.Rows[n]["weixin"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["createTime"] != null && dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
                    if (dt.Rows[n]["ip"] != null && dt.Rows[n]["ip"].ToString() != "")
                    {
                        model.ip = dt.Rows[n]["ip"].ToString();
                    }
                    if (dt.Rows[n]["isShow"] != null && dt.Rows[n]["isShow"].ToString() != "")
                    {
                        model.isShow = int.Parse(dt.Rows[n]["isShow"].ToString());
                    }
                    if (dt.Rows[n]["isRead"] != null && dt.Rows[n]["isRead"].ToString() != "")
                    {
                        model.isRead = int.Parse(dt.Rows[n]["isRead"].ToString());
                    }
                    if (dt.Rows[n]["readTime"] != null && dt.Rows[n]["readTime"].ToString() != "")
                    {
                        model.readTime = DateTime.Parse(dt.Rows[n]["readTime"].ToString());
                    }
                    if (dt.Rows[n]["isAnswer"] != null && dt.Rows[n]["isAnswer"].ToString() != "")
                    {
                        model.isAnswer = int.Parse(dt.Rows[n]["isAnswer"].ToString());
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

