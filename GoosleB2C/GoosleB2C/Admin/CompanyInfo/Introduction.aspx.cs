using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    public partial class Introduction : System.Web.UI.Page
    {
        BLL.CompanyInfo companginfo_bll = new BLL.CompanyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {           
            string a = Request.Form["action"];
            switch (a)
            {
                case "edit":
                    Edit();
                    break;
                case "query":
                    QueryData();
                    break;                   
            }
        }
        private void QueryData()
        {
            string id = Tools.CheckSQLStr(Request.Form["id"]);
            //string id = Request.QueryString["id"].ToString();
            string sql = "id = " + id;
            DataSet companyInfo = companginfo_bll.GetList(sql);
            string strJSON = JsonHelper.CreateJsonOne(companyInfo.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void Edit()
        {
            string id = Tools.CheckSQLStr(Request.Form["id"]);
            //string id = Request.QueryString["id"];
            Model.CompanyInfo model = GetData(id);
            string writeMsg = "提交失败";
            if (model != null)
            {
                if (companginfo_bll.Update(model))
                {
                    writeMsg = "提交成功";
                }
                else
                {
                    writeMsg = "提交失败";
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private Model.CompanyInfo GetData(string id)
        {
            int int_id = int.Parse(id);
            //string webDetails = Server.UrlEncode(Request.Form["ipt_webDetails"]);
            Model.CompanyInfo model = new Model.CompanyInfo();           
                     
            model.id = int_id;
            model.name = Tools.CheckSQLStr(Request.Form["ipt_name"]);
            model.name2 = Tools.CheckSQLStr(Request.Form["ipt_name2"]);
            model.mainImg = Tools.CheckSQLStr(Request.Form["ipt_mainImg"]);
            model.webDetails = Request.Form["ipt_webDetails"];
            //model.webDetails = webDetails;
            model.details = Tools.CheckSQLStr(Request.Form["ipt_introduce"]);
            model.imgs = Tools.CheckSQLStr(Request.Form["ipt_imgs"]);
            model.remarks = Tools.CheckSQLStr(Request.Form["ipt_remarks"]);
            return model;
        }
    }
}