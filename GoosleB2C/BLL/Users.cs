using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Users
	/// </summary>
	public partial class Users
	{
		private readonly GoosleB2C.DAL.Users dal=new GoosleB2C.DAL.Users();
		public Users()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string uId)
		{
			return dal.Exists(uId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoosleB2C.Model.Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string uId)
		{
			
			return dal.Delete(uId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string uIdlist )
		{
			return dal.DeleteList(uIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoosleB2C.Model.Users GetModel(string uId)
		{
			
			return dal.GetModel(uId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Users GetModelByCache(string uId)
		{
			
			string CacheKey = "UsersModel-" + uId;
			object objModel = GoosleB2C.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(uId);
					if (objModel != null)
					{
						int ModelCache = GoosleB2C.Common.ConfigHelper.GetConfigInt("ModelCache");
						GoosleB2C.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoosleB2C.Model.Users)objModel;
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
		public List<GoosleB2C.Model.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Users> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Users> modelList = new List<GoosleB2C.Model.Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Users();
					if(dt.Rows[n]["uId"]!=null && dt.Rows[n]["uId"].ToString()!="")
					{
					model.uId=dt.Rows[n]["uId"].ToString();
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["PassWord"]!=null && dt.Rows[n]["PassWord"].ToString()!="")
					{
					model.PassWord=dt.Rows[n]["PassWord"].ToString();
					}
					if(dt.Rows[n]["wId"]!=null && dt.Rows[n]["wId"].ToString()!="")
					{
					model.wId=dt.Rows[n]["wId"].ToString();
					}
					if(dt.Rows[n]["wName"]!=null && dt.Rows[n]["wName"].ToString()!="")
					{
					model.wName=dt.Rows[n]["wName"].ToString();
					}
					if(dt.Rows[n]["wImg"]!=null && dt.Rows[n]["wImg"].ToString()!="")
					{
					model.wImg=dt.Rows[n]["wImg"].ToString();
					}
					if(dt.Rows[n]["wCode"]!=null && dt.Rows[n]["wCode"].ToString()!="")
					{
					model.wCode=dt.Rows[n]["wCode"].ToString();
					}
					if(dt.Rows[n]["realName"]!=null && dt.Rows[n]["realName"].ToString()!="")
					{
					model.realName=dt.Rows[n]["realName"].ToString();
					}
					if(dt.Rows[n]["sex"]!=null && dt.Rows[n]["sex"].ToString()!="")
					{
						model.sex=int.Parse(dt.Rows[n]["sex"].ToString());
					}
					if(dt.Rows[n]["phone"]!=null && dt.Rows[n]["phone"].ToString()!="")
					{
					model.phone=dt.Rows[n]["phone"].ToString();
					}
					if(dt.Rows[n]["state"]!=null && dt.Rows[n]["state"].ToString()!="")
					{
						model.state=int.Parse(dt.Rows[n]["state"].ToString());
					}
					if(dt.Rows[n]["levelId"]!=null && dt.Rows[n]["levelId"].ToString()!="")
					{
					model.levelId=dt.Rows[n]["levelId"].ToString();
					}
					if(dt.Rows[n]["points"]!=null && dt.Rows[n]["points"].ToString()!="")
					{
						model.points=int.Parse(dt.Rows[n]["points"].ToString());
					}
					if(dt.Rows[n]["remak"]!=null && dt.Rows[n]["remak"].ToString()!="")
					{
					model.remak=dt.Rows[n]["remak"].ToString();
					}
					if(dt.Rows[n]["fund"]!=null && dt.Rows[n]["fund"].ToString()!="")
					{
						model.fund=decimal.Parse(dt.Rows[n]["fund"].ToString());
					}
					if(dt.Rows[n]["loginTime"]!=null && dt.Rows[n]["loginTime"].ToString()!="")
					{
						model.loginTime=DateTime.Parse(dt.Rows[n]["loginTime"].ToString());
					}
					if(dt.Rows[n]["loginIp"]!=null && dt.Rows[n]["loginIp"].ToString()!="")
					{
					model.loginIp=dt.Rows[n]["loginIp"].ToString();
					}
					if(dt.Rows[n]["lastTime"]!=null && dt.Rows[n]["lastTime"].ToString()!="")
					{
						model.lastTime=DateTime.Parse(dt.Rows[n]["lastTime"].ToString());
					}
					if(dt.Rows[n]["lastIp"]!=null && dt.Rows[n]["lastIp"].ToString()!="")
					{
					model.lastIp=dt.Rows[n]["lastIp"].ToString();
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

