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
    public partial class CompanyContact : System.Web.UI.Page
    {
        BLL.CompanyContact companyContactBll = new BLL.CompanyContact();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Form["action"];
            switch (action)
            {
                case "edit":
                    Editdata();
                    break;
                case "query":
                    Querydata();
                    break;
            }
        }
        private void Editdata()
        {
            string writeMsg = "操作失败";
            Model.CompanyContact model = new Model.CompanyContact();
            model = GetData();
            if(model != null)
            {
                if (companyContactBll.Update(model))
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
        Model.CompanyContact GetData()
        {
            Model.CompanyContact model = new Model.CompanyContact();
            model.id = 1;
            model.name = Tools.CheckSQLStr(Request.Form["ipt_name"]);
            if (Tools.CheckSQLStr(Request.Form["ipt_phone"]) != "")
            {
                model.phone = Tools.CheckSQLStr(Request.Form["ipt_phone"]);
            }
            else
            {
                model.phone = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_telephone"]) != "")
            {
                model.telephone = Tools.CheckSQLStr(Request.Form["ipt_telephone"]);
            }
            else
            {
                model.telephone = "";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_weixin"]) != "")
            {
                model.weixin = Tools.CheckSQLStr(Request.Form["ipt_weixin"]);
            }
            else
            {
                model.weixin = "";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_email"]) != "")
            {
                model.email = Tools.CheckSQLStr(Request.Form["ipt_email"]);
            }
            else
            {
                model.email = "";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_address"]) != "")
            {
                model.address = Tools.CheckSQLStr(Request.Form["ipt_address"]);
            }
            else
            {
                model.address = "";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_contacts"]) != "")
            {
                model.contacts = Tools.CheckSQLStr(Request.Form["ipt_contacts"]);
            }
            else
            {
                model.contacts = "";
            }                                               
            return model;
        }
        private void Querydata()
        {
            string strWhere = "id = 1";
            DataSet companycontact = companyContactBll.GetList(strWhere);
            int count = companycontact.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonOne(companycontact.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
    }
}