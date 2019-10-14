using System;
using System.Data;
using System.Collections.Generic;
using GoosleB2C.Common;
using GoosleB2C.Model;
namespace GoosleB2C.BLL
{
    /// <summary>
    /// CompanyInfo
    /// </summary>
    public partial class CompanyInfo
    {

        public DataSet GetDetails()
        {
            return dal.GetDetails();
        }
        public bool Update_one(GoosleB2C.Model.CompanyInfo model)
        {
            return dal.Update_one(model);
        }
        public bool Update_imgs(GoosleB2C.Model.CompanyInfo model)
        {
            return dal.Update_imgs(model);
        }
        public bool Update_Other(GoosleB2C.Model.CompanyInfo model)
        {
            return dal.Update_Other(model);
        }
    }
}

