using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;
using System.Text;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.Sys
{
    public partial class Message : System.Web.UI.Page
    {
        BLL.Message messageBll = new BLL.Message();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
            {
                action = Request.Form["action"];
            }
            switch (action)
            {
                case "query":
                    QueryData();
                    break;
                case "queryone":
                    QueryOneData();
                    break;
                case "submit":
                    AddData();
                    break;
                case "del"://删除数据
                    DelData();
                    break;
                default:
                    break;                
            }
        }
        private void QueryData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            string orderField = sort.Replace("JSON_", "");
            string strWhere = GetWhere();

            DataSet ds = DataHandler.GetList("Message", "*", "createTime", size, page, false, true, strWhere);
            int count = messageBll.GetList(strWhere).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private string GetWhere()
        {
            StringBuilder sb = new StringBuilder("1=1");
            string searchType;
            string searchValue;
            if (Request.Form["search_type"] != "")
            {
                searchType = Request.Form["search_type"];
            }
            else
            {
                searchType = "";
            }
            if (Request.Form["search_value"] != "")
            {
                searchValue = Request.Form["search_value"];
            }
            else
            {
                searchValue = "";
            }
            //string searchType = "";
            //string searchValue = "";
            if (searchType != null && searchValue != null)
            {
                sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue, searchType);
            }
            return sb.ToString();
        }
        private void QueryOneData()
        {

            string vId;
            string id;                   
            if (Tools.CheckSQLStr(Request.Form["vid"]) != "")
            {
                vId = Tools.CheckSQLStr(Request.Form["vid"]);
            }
            else
            {
                vId = "";
            }
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                id = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                id = "";
            }
            if(!(Tools.CheckSQLStr(Request.Form["isread"]) != "0"))
            {
                Model.Message model = new Model.Message();
                model.id = id;
                model.isRead = 1;
                model.readTime = DateTime.Now;
                bool t = messageBll.Update_readTime_isRead(model);
            }
            

            DataSet ds = messageBll.GetList("vId = " + "\'" + vId + "\'" + " order by createTime DESC");
            int count = ds.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void AddData()
        {
            string vid;
            string id;
            string userIP;
            string writeMsg = "操作失败";
            //HttpRequest Request = HttpContext.Current.Request;
            if(Request.Form["vid"] != "")
            {
                vid = Request.Form["vid"];
            }
            else
            {
                vid = "";
            }
            if (Request.Form["id"] != "")
            {
                id = Request.Form["id"];
            }
            else
            {
                id = "";
            }
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                userIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            // 如果使用代理，获取真实IP 
            //if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            //{
            //    userIP = Request.ServerVariables["REMOTE_ADDR"];
            //}
            //else
            //{
            //    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //}                
            //if (userIP == null || userIP == "")
            //{
            //    userIP = Request.UserHostAddress;
            //}
            if (!(Tools.CheckSQLStr(Request.Form["isanswer"]) != "0"))
            {
                Model.Message model_ = new Model.Message();
                model_.id = id;
                model_.isAnswer = 1;             
                bool t = messageBll.isAnswer(model_);
            }

            Model.Message model = GetData(vid, userIP);
            if(model != null)
            {
                if (messageBll.Add(model))
                {
                    writeMsg = "回复成功";
                }
                else
                {
                    writeMsg = "回复失败";
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private Model.Message GetData(string vid, string userIP)
        {
            Model.Message model = new Model.Message();
            string content = Server.UrlDecode(Request.Form["ipt_content"]);
            model.id = Guid.NewGuid().ToString();
            model.createTime = DateTime.Now;
            model.vId = "0";
            model.to = vid;
            model.name = GoosleB2C.MyTool.MyCookie.getCookie("uName");
            model.sex = 1;
            model.phone = "12345678901";
            model.weixin = "GoosleB2C";
            model.ip = userIP;
            if(Tools.CheckSQLStr(Request.Form["isshow"]) != "")
            {
                model.isShow = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["isshow"]));
            }
            else
            {
                model.isShow = 1;
            }
            model.isRead = 1;
            model.isAnswer = 0;
            model.readTime = null;
            model.content = Tools.CheckSQLStr(content);
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                

                if (messageBll.DeleteList(selectID))
                {
                    writeMsg = "删除成功！";
                }
                else
                {
                    writeMsg = "删除失败！";
                }                           
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
    }
}