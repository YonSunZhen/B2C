using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Brand
	/// </summary>
	public partial class Brand
	{
		private readonly GoosleB2C.DAL.Brand dal=new GoosleB2C.DAL.Brand();
		public Brand()
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
		public bool Add(GoosleB2C.Model.Brand model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Brand model)
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
		public GoosleB2C.Model.Brand GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Brand GetModelByCache(int id)
		{
			
			string CacheKey = "BrandModel-" + id;
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
			return (GoosleB2C.Model.Brand)objModel;
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
		public List<GoosleB2C.Model.Brand> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Brand> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Brand> modelList = new List<GoosleB2C.Model.Brand>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Brand model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Brand();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["img1"]!=null && dt.Rows[n]["img1"].ToString()!="")
					{
					model.img1=dt.Rows[n]["img1"].ToString();
					}
					if(dt.Rows[n]["img2"]!=null && dt.Rows[n]["img2"].ToString()!="")
					{
					model.img2=dt.Rows[n]["img2"].ToString();
					}
					if(dt.Rows[n]["img3"]!=null && dt.Rows[n]["img3"].ToString()!="")
					{
					model.img3=dt.Rows[n]["img3"].ToString();
					}
					if(dt.Rows[n]["url1"]!=null && dt.Rows[n]["url1"].ToString()!="")
					{
					model.url1=dt.Rows[n]["url1"].ToString();
					}
					if(dt.Rows[n]["url2"]!=null && dt.Rows[n]["url2"].ToString()!="")
					{
					model.url2=dt.Rows[n]["url2"].ToString();
					}
					if(dt.Rows[n]["url3"]!=null && dt.Rows[n]["url3"].ToString()!="")
					{
					model.url3=dt.Rows[n]["url3"].ToString();
					}
					if(dt.Rows[n]["pImg1"]!=null && dt.Rows[n]["pImg1"].ToString()!="")
					{
					model.pImg1=dt.Rows[n]["pImg1"].ToString();
					}
					if(dt.Rows[n]["pImg2"]!=null && dt.Rows[n]["pImg2"].ToString()!="")
					{
					model.pImg2=dt.Rows[n]["pImg2"].ToString();
					}
					if(dt.Rows[n]["pImg3"]!=null && dt.Rows[n]["pImg3"].ToString()!="")
					{
					model.pImg3=dt.Rows[n]["pImg3"].ToString();
					}
					if(dt.Rows[n]["pImg4"]!=null && dt.Rows[n]["pImg4"].ToString()!="")
					{
					model.pImg4=dt.Rows[n]["pImg4"].ToString();
					}
					if(dt.Rows[n]["pImg5"]!=null && dt.Rows[n]["pImg5"].ToString()!="")
					{
					model.pImg5=dt.Rows[n]["pImg5"].ToString();
					}
					if(dt.Rows[n]["purl1"]!=null && dt.Rows[n]["purl1"].ToString()!="")
					{
					model.purl1=dt.Rows[n]["purl1"].ToString();
					}
					if(dt.Rows[n]["purl2"]!=null && dt.Rows[n]["purl2"].ToString()!="")
					{
					model.purl2=dt.Rows[n]["purl2"].ToString();
					}
					if(dt.Rows[n]["purl3"]!=null && dt.Rows[n]["purl3"].ToString()!="")
					{
					model.purl3=dt.Rows[n]["purl3"].ToString();
					}
					if(dt.Rows[n]["purl4"]!=null && dt.Rows[n]["purl4"].ToString()!="")
					{
					model.purl4=dt.Rows[n]["purl4"].ToString();
					}
					if(dt.Rows[n]["purl5"]!=null && dt.Rows[n]["purl5"].ToString()!="")
					{
					model.purl5=dt.Rows[n]["purl5"].ToString();
					}
					if(dt.Rows[n]["vImg1"]!=null && dt.Rows[n]["vImg1"].ToString()!="")
					{
					model.vImg1=dt.Rows[n]["vImg1"].ToString();
					}
					if(dt.Rows[n]["vImg2"]!=null && dt.Rows[n]["vImg2"].ToString()!="")
					{
					model.vImg2=dt.Rows[n]["vImg2"].ToString();
					}
					if(dt.Rows[n]["vImg3"]!=null && dt.Rows[n]["vImg3"].ToString()!="")
					{
					model.vImg3=dt.Rows[n]["vImg3"].ToString();
					}
					if(dt.Rows[n]["vImg4"]!=null && dt.Rows[n]["vImg4"].ToString()!="")
					{
					model.vImg4=dt.Rows[n]["vImg4"].ToString();
					}
					if(dt.Rows[n]["vImg5"]!=null && dt.Rows[n]["vImg5"].ToString()!="")
					{
					model.vImg5=dt.Rows[n]["vImg5"].ToString();
					}
					if(dt.Rows[n]["vurl1"]!=null && dt.Rows[n]["vurl1"].ToString()!="")
					{
					model.vurl1=dt.Rows[n]["vurl1"].ToString();
					}
					if(dt.Rows[n]["vurl2"]!=null && dt.Rows[n]["vurl2"].ToString()!="")
					{
					model.vurl2=dt.Rows[n]["vurl2"].ToString();
					}
					if(dt.Rows[n]["vurl3"]!=null && dt.Rows[n]["vurl3"].ToString()!="")
					{
					model.vurl3=dt.Rows[n]["vurl3"].ToString();
					}
					if(dt.Rows[n]["vurl4"]!=null && dt.Rows[n]["vurl4"].ToString()!="")
					{
					model.vurl4=dt.Rows[n]["vurl4"].ToString();
					}
					if(dt.Rows[n]["vurl5"]!=null && dt.Rows[n]["vurl5"].ToString()!="")
					{
					model.vurl5=dt.Rows[n]["vurl5"].ToString();
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

