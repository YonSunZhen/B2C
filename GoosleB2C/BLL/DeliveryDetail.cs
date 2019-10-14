using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// DeliveryDetail
	/// </summary>
	public partial class DeliveryDetail
	{
		private readonly GoosleB2C.DAL.DeliveryDetail dal=new GoosleB2C.DAL.DeliveryDetail();
		public DeliveryDetail()
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
		public bool Add(GoosleB2C.Model.DeliveryDetail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.DeliveryDetail model)
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
		public GoosleB2C.Model.DeliveryDetail GetModel(string id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.DeliveryDetail GetModelByCache(string id)
		{
			
			string CacheKey = "DeliveryDetailModel-" + id;
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
			return (GoosleB2C.Model.DeliveryDetail)objModel;
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
		public List<GoosleB2C.Model.DeliveryDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.DeliveryDetail> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.DeliveryDetail> modelList = new List<GoosleB2C.Model.DeliveryDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.DeliveryDetail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.DeliveryDetail();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
					model.id=dt.Rows[n]["id"].ToString();
					}
					if(dt.Rows[n]["tempId"]!=null && dt.Rows[n]["tempId"].ToString()!="")
					{
					model.tempId=dt.Rows[n]["tempId"].ToString();
					}
					if(dt.Rows[n]["provinceId"]!=null && dt.Rows[n]["provinceId"].ToString()!="")
					{
						model.provinceId=int.Parse(dt.Rows[n]["provinceId"].ToString());
					}
					if(dt.Rows[n]["firstWeight"]!=null && dt.Rows[n]["firstWeight"].ToString()!="")
					{
						model.firstWeight=decimal.Parse(dt.Rows[n]["firstWeight"].ToString());
					}
					if(dt.Rows[n]["addedWeight"]!=null && dt.Rows[n]["addedWeight"].ToString()!="")
					{
						model.addedWeight=decimal.Parse(dt.Rows[n]["addedWeight"].ToString());
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

