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
    public partial class WebInfo : System.Web.UI.Page
    {
        BLL.WebInfo webinfobll = new BLL.WebInfo();
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
            string strSql = "id = 1";
            DataSet ds = webinfobll.GetList(strSql);
            int count = ds.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void Edit()
        {
            Model.WebInfo model = GetData();
            string writeMsg = "操作失败";
            if(model != null)
            {
                if (webinfobll.Update(model))
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
        private Model.WebInfo GetData()
        {
            Model.WebInfo model = new Model.WebInfo();          
            model.id = 1;
            model.webName = Tools.CheckSQLStr(Request.Form["ipt_webname"]);
            model.title = Tools.CheckSQLStr(Request.Form["ipt_title"]);
            model.records = Tools.CheckSQLStr(Request.Form["ipt_records"]);
            model.seoDescribe = Tools.CheckSQLStr(Request.Form["ipt_seodescribe"]);
            model.seoKey = Tools.CheckSQLStr(Request.Form["ipt_seokey"]);
            model.vName = Tools.CheckSQLStr(Request.Form["ipt_vname"]);
            model.logo = Tools.CheckSQLStr(Request.Form["ipt_logo"]);
            model.vLogo = Tools.CheckSQLStr(Request.Form["ipt_vlogo"]);
            model.vCode = Tools.CheckSQLStr(Request.Form["ipt_vcode"]);
            //ckeditor如果sql检查的话为空值
            model.bottomInfo = Request.Form["ipt_bottominfo"];            
            model.vBottom = Tools.CheckSQLStr(Request.Form["ipt_vbottom"]);
            return model;
        }
    }
}