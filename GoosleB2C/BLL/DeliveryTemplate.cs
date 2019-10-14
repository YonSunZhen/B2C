using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// DeliveryTemplate
	/// </summary>
	public partial class DeliveryTemplate
	{
		private readonly GoosleB2C.DAL.DeliveryTemplate dal=new GoosleB2C.DAL.DeliveryTemplate();
		public DeliveryTemplate()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.DeliveryTemplate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.DeliveryTemplate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoosleB2C.Model.DeliveryTemplate GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.DeliveryTemplate GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "DeliveryTemplateModel-" ;
			object objModel = GoosleB2C.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = GoosleB2C.Common.ConfigHelper.GetConfigInt("ModelCache");
						GoosleB2C.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoosleB2C.Model.DeliveryTemplate)objModel;
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
		public List<GoosleB2C.Model.DeliveryTemplate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.DeliveryTemplate> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.DeliveryTemplate> modelList = new List<GoosleB2C.Model.DeliveryTemplate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.DeliveryTemplate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.DeliveryTemplate();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
					model.id=dt.Rows[n]["id"].ToString();
					}
					if(dt.Rows[n]["tempName"]!=null && dt.Rows[n]["tempName"].ToString()!="")
					{
					model.tempName=dt.Rows[n]["tempName"].ToString();
					}
					if(dt.Rows[n]["isChoose"]!=null && dt.Rows[n]["isChoose"].ToString()!="")
					{
						model.isChoose=int.Parse(dt.Rows[n]["isChoose"].ToString());
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

