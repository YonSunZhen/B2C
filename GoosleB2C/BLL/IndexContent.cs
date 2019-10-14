using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// IndexContent
	/// </summary>
	public partial class IndexContent
	{
		private readonly GoosleB2C.DAL.IndexContent dal=new GoosleB2C.DAL.IndexContent();
		public IndexContent()
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
		public bool Add(GoosleB2C.Model.IndexContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.IndexContent model)
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
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoosleB2C.Model.IndexContent GetModel(string id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.IndexContent GetModelByCache(string id)
		{
			
			string CacheKey = "IndexContentModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoosleB2C.Model.IndexContent)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.IndexContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.IndexContent> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.IndexContent> modelList = new List<GoosleB2C.Model.IndexContent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.IndexContent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.IndexContent();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
					model.id=dt.Rows[n]["id"].ToString();
					}
					if(dt.Rows[n]["isShowSuccess"]!=null && dt.Rows[n]["isShowSuccess"].ToString()!="")
					{
						model.isShowSuccess=int.Parse(dt.Rows[n]["isShowSuccess"].ToString());
					}
					if(dt.Rows[n]["successTotal"]!=null && dt.Rows[n]["successTotal"].ToString()!="")
					{
						model.successTotal=int.Parse(dt.Rows[n]["successTotal"].ToString());
					}
					if(dt.Rows[n]["isShowProduct"]!=null && dt.Rows[n]["isShowProduct"].ToString()!="")
					{
						model.isShowProduct=int.Parse(dt.Rows[n]["isShowProduct"].ToString());
					}
					if(dt.Rows[n]["productTotal"]!=null && dt.Rows[n]["productTotal"].ToString()!="")
					{
						model.productTotal=int.Parse(dt.Rows[n]["productTotal"].ToString());
					}
					if(dt.Rows[n]["isShowArticle"]!=null && dt.Rows[n]["isShowArticle"].ToString()!="")
					{
						model.isShowArticle=int.Parse(dt.Rows[n]["isShowArticle"].ToString());
					}
					if(dt.Rows[n]["articleTotal"]!=null && dt.Rows[n]["articleTotal"].ToString()!="")
					{
						model.articleTotal=int.Parse(dt.Rows[n]["articleTotal"].ToString());
					}
					if(dt.Rows[n]["isShowVideo"]!=null && dt.Rows[n]["isShowVideo"].ToString()!="")
					{
						model.isShowVideo=int.Parse(dt.Rows[n]["isShowVideo"].ToString());
					}
					if(dt.Rows[n]["isRun"]!=null && dt.Rows[n]["isRun"].ToString()!="")
					{
						model.isRun=int.Parse(dt.Rows[n]["isRun"].ToString());
					}
					if(dt.Rows[n]["videoPath"]!=null && dt.Rows[n]["videoPath"].ToString()!="")
					{
					model.videoPath=dt.Rows[n]["videoPath"].ToString();
					}
					if(dt.Rows[n]["videoTitle"]!=null && dt.Rows[n]["videoTitle"].ToString()!="")
					{
					model.videoTitle=dt.Rows[n]["videoTitle"].ToString();
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

