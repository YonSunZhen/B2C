using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Links
	/// </summary>
	public partial class Links
	{
		private readonly GoosleB2C.DAL.Links dal=new GoosleB2C.DAL.Links();
		public Links()
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
		public bool Add(GoosleB2C.Model.Links model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Links model)
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
		public GoosleB2C.Model.Links GetModel(string id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Links GetModelByCache(string id)
		{
			
			string CacheKey = "LinksModel-" + id;
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
			return (GoosleB2C.Model.Links)objModel;
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
		public List<GoosleB2C.Model.Links> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Links> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Links> modelList = new List<GoosleB2C.Model.Links>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Links model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Links();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
					model.id=dt.Rows[n]["id"].ToString();
					}
					if(dt.Rows[n]["linkName"]!=null && dt.Rows[n]["linkName"].ToString()!="")
					{
					model.linkName=dt.Rows[n]["linkName"].ToString();
					}
					if(dt.Rows[n]["url"]!=null && dt.Rows[n]["url"].ToString()!="")
					{
					model.url=dt.Rows[n]["url"].ToString();
					}
					if(dt.Rows[n]["orders"]!=null && dt.Rows[n]["orders"].ToString()!="")
					{
						model.orders=int.Parse(dt.Rows[n]["orders"].ToString());
					}
					if(dt.Rows[n]["tags"]!=null && dt.Rows[n]["tags"].ToString()!="")
					{
					model.tags=dt.Rows[n]["tags"].ToString();
					}
					if(dt.Rows[n]["state"]!=null && dt.Rows[n]["state"].ToString()!="")
					{
						model.state=int.Parse(dt.Rows[n]["state"].ToString());
					}
					if(dt.Rows[n]["createDate"]!=null && dt.Rows[n]["createDate"].ToString()!="")
					{
						model.createDate=DateTime.Parse(dt.Rows[n]["createDate"].ToString());
					}
					if(dt.Rows[n]["creator"]!=null && dt.Rows[n]["creator"].ToString()!="")
					{
					model.creator=dt.Rows[n]["creator"].ToString();
					}
					if(dt.Rows[n]["remarks"]!=null && dt.Rows[n]["remarks"].ToString()!="")
					{
					model.remarks=dt.Rows[n]["remarks"].ToString();
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

