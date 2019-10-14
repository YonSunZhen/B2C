using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoosleB2C.BLL
{
    public partial class Links
    {
        public DataSet GetListbyorders()
        {
            return dal.GetListByorders();
        }
    }
}
