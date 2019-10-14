using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;

namespace GoosleB2C.Web.Admin
{
    public partial class ck_test : System.Web.UI.Page
    {
        BLL.CompanyInfo companginfo_bll = new BLL.CompanyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Request.Form["action"];
            switch (a)
            {                
                case "query":
                    QueryData();
                    break;
            }
        }
        private void QueryData()
        {
            string id = Request.Form["id"];
            //string id = Request.QueryString["id"].ToString();
            string sql = "id = " + id;
            DataSet companyInfo = companginfo_bll.GetList(sql);
            string strJSON = JsonHelper.CreateJsonOne(companyInfo.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
    }
}