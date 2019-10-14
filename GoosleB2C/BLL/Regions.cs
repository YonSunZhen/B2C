using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Regions
	/// </summary>
	public partial class Regions
	{
		private readonly GoosleB2C.DAL.Regions dal=new GoosleB2C.DAL.Regions();
		public Regions()
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
		public bool Add(GoosleB2C.Model.Regions model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Regions model)
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
		public GoosleB2C.Model.Regions GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Regions GetModelByCache(int id)
		{
			
			string CacheKey = "RegionsModel-" + id;
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
			return (GoosleB2C.Model.Regions)objModel;
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
		public List<GoosleB2C.Model.Regions> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Regions> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Regions> modelList = new List<GoosleB2C.Model.Regions>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Regions model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Regions();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["regionName"]!=null && dt.Rows[n]["regionName"].ToString()!="")
					{
					model.regionName=dt.Rows[n]["regionName"].ToString();
					}
					if(dt.Rows[n]["regionCode"]!=null && dt.Rows[n]["regionCode"].ToString()!="")
					{
					model.regionCode=dt.Rows[n]["regionCode"].ToString();
					}
					if(dt.Rows[n]["fatherId"]!=null && dt.Rows[n]["fatherId"].ToString()!="")
					{
						model.fatherId=int.Parse(dt.Rows[n]["fatherId"].ToString());
					}
					if(dt.Rows[n]["level"]!=null && dt.Rows[n]["level"].ToString()!="")
					{
						model.level=int.Parse(dt.Rows[n]["level"].ToString());
					}
					if(dt.Rows[n]["regionOrder"]!=null && dt.Rows[n]["regionOrder"].ToString()!="")
					{
						model.regionOrder=int.Parse(dt.Rows[n]["regionOrder"].ToString());
					}
					if(dt.Rows[n]["enName"]!=null && dt.Rows[n]["enName"].ToString()!="")
					{
					model.enName=dt.Rows[n]["enName"].ToString();
					}
					if(dt.Rows[n]["shortEnName"]!=null && dt.Rows[n]["shortEnName"].ToString()!="")
					{
					model.shortEnName=dt.Rows[n]["shortEnName"].ToString();
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

