using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GoosleB2C.BLL
{
    public partial class SuccessCase
    {
        public DataSet GetList_()
        {
            return dal.GetList_();
        }
        public DataSet GetOneList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetOneList(Top, strWhere, filedOrder);
        }
    }
}
