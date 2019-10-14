using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// WebInfo
	/// </summary>
	public partial class WebInfo
	{
		private readonly GoosleB2C.DAL.WebInfo dal=new GoosleB2C.DAL.WebInfo();
		public WebInfo()
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
		public bool Add(GoosleB2C.Model.WebInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.WebInfo model)
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
		public GoosleB2C.Model.WebInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.WebInfo GetModelByCache(int id)
		{
			
			string CacheKey = "WebInfoModel-" + id;
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
			return (GoosleB2C.Model.WebInfo)objModel;
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
		public List<GoosleB2C.Model.WebInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.WebInfo> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.WebInfo> modelList = new List<GoosleB2C.Model.WebInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.WebInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.WebInfo();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["webName"]!=null && dt.Rows[n]["webName"].ToString()!="")
					{
					model.webName=dt.Rows[n]["webName"].ToString();
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
					}
					if(dt.Rows[n]["logo"]!=null && dt.Rows[n]["logo"].ToString()!="")
					{
					model.logo=dt.Rows[n]["logo"].ToString();
					}
					if(dt.Rows[n]["vLogo"]!=null && dt.Rows[n]["vLogo"].ToString()!="")
					{
					model.vLogo=dt.Rows[n]["vLogo"].ToString();
					}
					if(dt.Rows[n]["vName"]!=null && dt.Rows[n]["vName"].ToString()!="")
					{
					model.vName=dt.Rows[n]["vName"].ToString();
					}
					if(dt.Rows[n]["vCode"]!=null && dt.Rows[n]["vCode"].ToString()!="")
					{
					model.vCode=dt.Rows[n]["vCode"].ToString();
					}
					if(dt.Rows[n]["records"]!=null && dt.Rows[n]["records"].ToString()!="")
					{
					model.records=dt.Rows[n]["records"].ToString();
					}
					if(dt.Rows[n]["bottomInfo"]!=null && dt.Rows[n]["bottomInfo"].ToString()!="")
					{
					model.bottomInfo=dt.Rows[n]["bottomInfo"].ToString();
					}
					if(dt.Rows[n]["vBottom"]!=null && dt.Rows[n]["vBottom"].ToString()!="")
					{
					model.vBottom=dt.Rows[n]["vBottom"].ToString();
					}
					if(dt.Rows[n]["seoKey"]!=null && dt.Rows[n]["seoKey"].ToString()!="")
					{
					model.seoKey=dt.Rows[n]["seoKey"].ToString();
					}
					if(dt.Rows[n]["seoDescribe"]!=null && dt.Rows[n]["seoDescribe"].ToString()!="")
					{
					model.seoDescribe=dt.Rows[n]["seoDescribe"].ToString();
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

