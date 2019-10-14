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
    public partial class DeliveryTemplate_
    {
        private readonly GoosleB2C.DAL.DeliveryTemplate_ dal = new GoosleB2C.DAL.DeliveryTemplate_();
        public DeliveryTemplate_()
        {

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.DeliveryTemplate GetModel(string id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoosleB2C.Model.DeliveryTemplate model)
        {
            return dal.Update(model);
        }

        /// <summary>
		/// 根据是否选中来查找是否存在该记录
		/// </summary>
		public bool Exists(int id)
        {
            return dal.Exists(id);
        }
    }
}
