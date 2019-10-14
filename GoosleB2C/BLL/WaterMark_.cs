using System;
using System.Collections.Generic;
using System.Data;

namespace GoosleB2C.BLL
{
    public partial class WaterMark
    {
        public bool Update_State(GoosleB2C.Model.WaterMark model)
        {
            return dal.Update_State(model);
        }
    }
}
