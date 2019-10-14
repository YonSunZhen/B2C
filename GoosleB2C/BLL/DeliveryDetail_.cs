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
    public partial class DeliveryDetail_
    {
        private readonly GoosleB2C.DAL.DeliveryDetail_ dal = new GoosleB2C.DAL.DeliveryDetail_();
        public DeliveryDetail_()
        {

        }

        /// <summary>
        /// 根据模板id删除数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }

        /// <summary>
		/// 通过tempId获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
		///  通过tempId获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
    }
}
