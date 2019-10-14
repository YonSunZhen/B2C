using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Category
	/// </summary>
	public partial class Category
	{
		private readonly GoosleB2C.DAL.Category dal=new GoosleB2C.DAL.Category();
		public Category()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoosleB2C.Model.Category model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Category model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
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
		public GoosleB2C.Model.Category GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Category GetModelByCache(int id)
		{
			
			string CacheKey = "CategoryModel-" + id;
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
				catch{}
			}
			return (GoosleB2C.Model.Category)objModel;
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
		public List<GoosleB2C.Model.Category> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Category> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Category> modelList = new List<GoosleB2C.Model.Category>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Category model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Category();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["categoryName"]!=null && dt.Rows[n]["categoryName"].ToString()!="")
					{
					model.categoryName=dt.Rows[n]["categoryName"].ToString();
					}
					if(dt.Rows[n]["father"]!=null && dt.Rows[n]["father"].ToString()!="")
					{
						model.father=int.Parse(dt.Rows[n]["father"].ToString());
					}
					if(dt.Rows[n]["level"]!=null && dt.Rows[n]["level"].ToString()!="")
					{
						model.level=int.Parse(dt.Rows[n]["level"].ToString());
					}
					if(dt.Rows[n]["path"]!=null && dt.Rows[n]["path"].ToString()!="")
					{
					model.path=dt.Rows[n]["path"].ToString();
					}
					if(dt.Rows[n]["img"]!=null && dt.Rows[n]["img"].ToString()!="")
					{
					model.img=dt.Rows[n]["img"].ToString();
					}
					if(dt.Rows[n]["order"]!=null && dt.Rows[n]["order"].ToString()!="")
					{
						model.order=int.Parse(dt.Rows[n]["order"].ToString());
					}
					if(dt.Rows[n]["seoTitle"]!=null && dt.Rows[n]["seoTitle"].ToString()!="")
					{
					model.seoTitle=dt.Rows[n]["seoTitle"].ToString();
					}
					if(dt.Rows[n]["seoKey"]!=null && dt.Rows[n]["seoKey"].ToString()!="")
					{
					model.seoKey=dt.Rows[n]["seoKey"].ToString();
					}
					if(dt.Rows[n]["seoRemark"]!=null && dt.Rows[n]["seoRemark"].ToString()!="")
					{
					model.seoRemark=dt.Rows[n]["seoRemark"].ToString();
					}
					if(dt.Rows[n]["remark"]!=null && dt.Rows[n]["remark"].ToString()!="")
					{
					model.remark=dt.Rows[n]["remark"].ToString();
					}
					if(dt.Rows[n]["updater"]!=null && dt.Rows[n]["updater"].ToString()!="")
					{
					model.updater=dt.Rows[n]["updater"].ToString();
					}
					if(dt.Rows[n]["updateTime"]!=null && dt.Rows[n]["updateTime"].ToString()!="")
					{
						model.updateTime=DateTime.Parse(dt.Rows[n]["updateTime"].ToString());
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

