using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GoosleB2C.DBUtility;
using System.Data;
using System.Text;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    public partial class Introduce : System.Web.UI.Page
    {
        BLL.CompanyInfo companginfo_bll = new BLL.CompanyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) { } 
                                           
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
            string id = Request.Form["id"];
            string sql = "id = " + id;
            DataSet companyInfo = companginfo_bll.GetList(sql);
            string strJSON = JsonHelper.CreateJsonOne(companyInfo.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }        
        private void Edit()
        {       
                    
            string id = Request.Form["id"];
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
            Response.Write(writeMsg);
            Response.End();            
        } 
        private Model.CompanyInfo GetData(string id)
        {
            int int_id = int.Parse(id);
            Model.CompanyInfo model = new Model.CompanyInfo();           
            //model.webDetails = "[{'" + "ipt_introduce'" + ":'" + Request.Form["ipt_introduce"] + "'},{" + "'ipt_srcs'" + ":'" + Request.Form["img_Path"] + "'}]";
            //model.webDetails = "[{\"" + "ipt_introduce\"" + ":\"" + Request.Form["ipt_introduce"] + "\"},{" + "\"ipt_srcs\"" + ":\"" + Request.Form["img_Path"] + "\"}]";
            if (Request.Form["ipt_introduce"] != null)
            {
                if (Request.Form["img_Path"] != null)
                {
                    model.webDetails = Request.Form["ipt_introduce"] + "&&" + Request.Form["img_Path"];
                }
                else
                {
                    model.webDetails = Request.Form["ipt_introduce"];
                }
            }
            else
            {
                model.webDetails = Request.Form["img_Path"];
            }
            model.id = int_id;
            model.name = "公司简介";           
            model.name2 = Request.Form["ipt_name2"];
            model.mainImg =  Request.Form["mainImg"];            
            model.remarks = Request.Form["ipt_remarks"];
            return model;
        }                  
    }
}