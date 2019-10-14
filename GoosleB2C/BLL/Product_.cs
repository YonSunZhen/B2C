using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;

namespace GoosleB2C.BLL
{
    public partial class Product
    {
        public DataSet QueryDeliveryTemp()
        {
            return dal.QueryDeliveryTemp();
        }
    }
}
