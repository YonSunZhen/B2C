using System;
using System.Data;
using System.Collections.Generic;

namespace GoosleB2C.BLL
{
    public partial class Message
    {
        public bool Update_readTime_isRead(GoosleB2C.Model.Message model)
        {
            return dal.Update_readTime_isRead(model);
        }
        public bool isAnswer(GoosleB2C.Model.Message model)
        {
            return dal.isAnswer(model);
        }
    }
}
