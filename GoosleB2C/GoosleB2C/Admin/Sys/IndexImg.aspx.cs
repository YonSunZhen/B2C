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
    public partial class IndexImg : System.Web.UI.Page
    {
        BLL.IndexImg indexImgBll = new BLL.IndexImg();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
            {
                action = Request.Form["action"];
            }
            switch (action)
            {
                case "query"://查询数据
                    QueryData();
                    break;
                case "queryone"://查询指定ID 的数据，修改时用
                    QueryOneData();
                    break;
                case "submit"://提交数据，添加或修改
                    UpdateData();
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
            StringBuilder sb = new StringBuilder("1=1");
            string strWhere = sb.ToString();
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            string orderField = sort.Replace("JSON_", "");
            DataSet indexImg = DataHandler.GetList("IndexImg", "*", "id", size, page, false, false, strWhere);
            int count = indexImgBll.GetList(strWhere).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(indexImg.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string Id;
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                Id = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                Id = "";
            }           
            DataSet ds = indexImgBll.GetList("id=" + "\'" + Id + "\'");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void UpdateData()
        {
            string id;
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                id = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                id = "";
            }
            Model.IndexImg model = GetData(id);
            string writeMsg = "操作失败";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (indexImgBll.Add(model))
                    {
                        writeMsg = "增加成功";
                    }
                    else
                    {
                        writeMsg = "增加失败";
                    }
                }
                else
                {
                    if (indexImgBll.Update(model))
                    {
                        writeMsg = "更新成功";
                    }
                    else
                    {
                        writeMsg = "更新失败";
                    }
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private Model.IndexImg GetData(string id)
        {
            Model.IndexImg model = new Model.IndexImg();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = indexImgBll.GetModel(id);
                model.updatePeople = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.updateTime = DateTime.Now;
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.id = newid;                
                model.updatePeople = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.updateTime = DateTime.Now;                
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_urltype"]) != "")
            {
                model.urlType = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_urltype"]));
            }
            else
            {
                model.urlType = 1;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_position"]) != "")
            {
                model.position = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_position"]));
            }
            else
            {
                model.position = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_orders"]) != "")
            {
                model.orders = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_orders"]));
            }
            else
            {
                model.orders = 1;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_url"]) != "")
            {
                model.url = Tools.CheckSQLStr(Request.Form["ipt_url"]);
            }
            else
            {
                model.url = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_img"]) != "")
            {
                model.img = Tools.CheckSQLStr(Request.Form["ipt_img"]);
            }
            else
            {
                model.img = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_toid"]) != "")
            {
                model.toId = Tools.CheckSQLStr(Request.Form["ipt_toid"]);
            }
            else
            {
                model.toId = "";
            }
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {                
                if (indexImgBll.DeleteList(selectID))
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