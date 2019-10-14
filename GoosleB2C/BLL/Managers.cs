using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
	/// <summary>
	/// Managers
	/// </summary>
	public partial class Managers
	{
		private readonly GoosleB2C.DAL.Managers dal=new GoosleB2C.DAL.Managers();
		public Managers()
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
		public bool Add(GoosleB2C.Model.Managers model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.Managers model)
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
		public GoosleB2C.Model.Managers GetModel(string id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoosleB2C.Model.Managers GetModelByCache(string id)
		{
			
			string CacheKey = "ManagersModel-" + id;
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
			return (GoosleB2C.Model.Managers)objModel;
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
		public List<GoosleB2C.Model.Managers> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoosleB2C.Model.Managers> DataTableToList(DataTable dt)
		{
			List<GoosleB2C.Model.Managers> modelList = new List<GoosleB2C.Model.Managers>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoosleB2C.Model.Managers model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoosleB2C.Model.Managers();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
					model.id=dt.Rows[n]["id"].ToString();
					}
					if(dt.Rows[n]["userName"]!=null && dt.Rows[n]["userName"].ToString()!="")
					{
					model.userName=dt.Rows[n]["userName"].ToString();
					}
					if(dt.Rows[n]["passWord"]!=null && dt.Rows[n]["passWord"].ToString()!="")
					{
					model.passWord=dt.Rows[n]["passWord"].ToString();
					}
					if(dt.Rows[n]["cnName"]!=null && dt.Rows[n]["cnName"].ToString()!="")
					{
					model.cnName=dt.Rows[n]["cnName"].ToString();
					}
					if(dt.Rows[n]["state"]!=null && dt.Rows[n]["state"].ToString()!="")
					{
						model.state=int.Parse(dt.Rows[n]["state"].ToString());
					}
					if(dt.Rows[n]["userType"]!=null && dt.Rows[n]["userType"].ToString()!="")
					{
						model.userType=int.Parse(dt.Rows[n]["userType"].ToString());
					}
					if(dt.Rows[n]["roleId"]!=null && dt.Rows[n]["roleId"].ToString()!="")
					{
					model.roleId=dt.Rows[n]["roleId"].ToString();
					}
					if(dt.Rows[n]["mobile"]!=null && dt.Rows[n]["mobile"].ToString()!="")
					{
					model.mobile=dt.Rows[n]["mobile"].ToString();
					}
					if(dt.Rows[n]["creator"]!=null && dt.Rows[n]["creator"].ToString()!="")
					{
					model.creator=dt.Rows[n]["creator"].ToString();
					}
					if(dt.Rows[n]["cteateDate"]!=null && dt.Rows[n]["cteateDate"].ToString()!="")
					{
						model.cteateDate=DateTime.Parse(dt.Rows[n]["cteateDate"].ToString());
					}
					if(dt.Rows[n]["lastLoginDate"]!=null && dt.Rows[n]["lastLoginDate"].ToString()!="")
					{
						model.lastLoginDate=DateTime.Parse(dt.Rows[n]["lastLoginDate"].ToString());
					}
					if(dt.Rows[n]["loginDate"]!=null && dt.Rows[n]["loginDate"].ToString()!="")
					{
						model.loginDate=DateTime.Parse(dt.Rows[n]["loginDate"].ToString());
					}
					if(dt.Rows[n]["loginTimes"]!=null && dt.Rows[n]["loginTimes"].ToString()!="")
					{
						model.loginTimes=int.Parse(dt.Rows[n]["loginTimes"].ToString());
					}
					if(dt.Rows[n]["expand1"]!=null && dt.Rows[n]["expand1"].ToString()!="")
					{
					model.expand1=dt.Rows[n]["expand1"].ToString();
					}
					if(dt.Rows[n]["remark"]!=null && dt.Rows[n]["remark"].ToString()!="")
					{
					model.remark=dt.Rows[n]["remark"].ToString();
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
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        //{
        //    return dal.GetList(PageSize, PageIndex, strWhere);
        //}              
        #endregion  Method
        public GoosleB2C.Model.Managers GetModelByName(string userName)
        {
            return dal.GetModelByName(userName);
        }
    }
}

