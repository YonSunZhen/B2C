using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// CompanyContact
	/// </summary>
	public partial class CompanyContact
	{
		private readonly GoosleB2C.DAL.CompanyContact dal=new GoosleB2C.DAL.CompanyContact();
		public CompanyContact()
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
		public bool Add(GoosleB2C.Model.CompanyContact model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.CompanyContact model)
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
		public GoosleB2C.Model.CompanyContact GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.CompanyContact GetModelByCache(int id)
		{
			
			string CacheKey = "CompanyContactModel-" + id;
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
			return (GoosleB2C.Model.CompanyContact)objModel;
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
		public List<GoosleB2C.Model.CompanyContact> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.CompanyContact> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.CompanyContact> modelList = new List<GoosleB2C.Model.CompanyContact>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.CompanyContact model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.CompanyContact();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["address"]!=null && dt.Rows[n]["address"].ToString()!="")
					{
					model.address=dt.Rows[n]["address"].ToString();
					}
					if(dt.Rows[n]["telephone"]!=null && dt.Rows[n]["telephone"].ToString()!="")
					{
					model.telephone=dt.Rows[n]["telephone"].ToString();
					}
					if(dt.Rows[n]["phone"]!=null && dt.Rows[n]["phone"].ToString()!="")
					{
					model.phone=dt.Rows[n]["phone"].ToString();
					}
					if(dt.Rows[n]["email"]!=null && dt.Rows[n]["email"].ToString()!="")
					{
					model.email=dt.Rows[n]["email"].ToString();
					}
					if(dt.Rows[n]["contacts"]!=null && dt.Rows[n]["contacts"].ToString()!="")
					{
					model.contacts=dt.Rows[n]["contacts"].ToString();
					}
					if(dt.Rows[n]["weixin"]!=null && dt.Rows[n]["weixin"].ToString()!="")
					{
					model.weixin=dt.Rows[n]["weixin"].ToString();
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

