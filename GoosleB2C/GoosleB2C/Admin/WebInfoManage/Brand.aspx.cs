using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.WebInfoManage
{
    public partial class Brand : System.Web.UI.Page
    {
        BLL.Brand brandBll = new BLL.Brand();
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
            string strWhere = "id = 1";
            DataSet ds = brandBll.GetList(strWhere);
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void Edit()
        {
            Model.Brand model = GetData();
            string writeMsg = "提交失败";
            if (model != null)
            {
                if (brandBll.Update(model))
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
        private Model.Brand GetData()
        {            
            Model.Brand model = new Model.Brand();
            model.id = 1;
            model.img1 = Tools.CheckSQLStr(Request.Form["ipt_img1"]);
            model.img2 = Tools.CheckSQLStr(Request.Form["ipt_img2"]);
            model.img3 = Tools.CheckSQLStr(Request.Form["ipt_img3"]);
            model.url1 = Tools.CheckSQLStr(Request.Form["ipt_url1"]);
            model.url2 = Tools.CheckSQLStr(Request.Form["ipt_url2"]);
            model.url3 = Tools.CheckSQLStr(Request.Form["ipt_url3"]);

            model.pImg1 = Tools.CheckSQLStr(Request.Form["ipt_pimg1"]);
            model.pImg2 = Tools.CheckSQLStr(Request.Form["ipt_pimg2"]);
            model.pImg3 = Tools.CheckSQLStr(Request.Form["ipt_pimg3"]);
            model.pImg4 = Tools.CheckSQLStr(Request.Form["ipt_pimg4"]);
            model.pImg5 = Tools.CheckSQLStr(Request.Form["ipt_pimg5"]);
            model.purl1 = Tools.CheckSQLStr(Request.Form["ipt_purl1"]);
            model.purl2 = Tools.CheckSQLStr(Request.Form["ipt_purl2"]);
            model.purl3 = Tools.CheckSQLStr(Request.Form["ipt_purl3"]);
            model.purl4 = Tools.CheckSQLStr(Request.Form["ipt_purl4"]);
            model.purl5 = Tools.CheckSQLStr(Request.Form["ipt_purl5"]);

            model.vImg1 = Tools.CheckSQLStr(Request.Form["ipt_vimg1"]);
            model.vImg2 = Tools.CheckSQLStr(Request.Form["ipt_vimg2"]);
            model.vImg3 = Tools.CheckSQLStr(Request.Form["ipt_vimg3"]);
            model.vImg4 = Tools.CheckSQLStr(Request.Form["ipt_vimg4"]);
            model.vImg5 = Tools.CheckSQLStr(Request.Form["ipt_vimg5"]);
            model.vurl1 = Tools.CheckSQLStr(Request.Form["ipt_vurl1"]);
            model.vurl2 = Tools.CheckSQLStr(Request.Form["ipt_vurl2"]);
            model.vurl3 = Tools.CheckSQLStr(Request.Form["ipt_vurl3"]);
            model.vurl4 = Tools.CheckSQLStr(Request.Form["ipt_vurl4"]);
            model.vurl5 = Tools.CheckSQLStr(Request.Form["ipt_vurl5"]);
            return model;
        }
    }
}