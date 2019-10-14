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
    public partial class Links : System.Web.UI.Page
    {
        BLL.Links linksbll = new BLL.Links();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
                action = Request.Form["action"];
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
            DataSet links = linksbll.GetListbyorders();
            int count = links.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(links.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void UpdateData()
        {
            string id;
            string writeMsg = "操作失败";
            Model.Links model = new Model.Links();
            if(Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                id = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                id = "";
            }
            model = GetData(id);
            if(model != null)
            {
                if(id.Equals("") || id.Equals("0"))
                {
                    if (linksbll.Add(model))
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
                    if (linksbll.Update(model))
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
        public Model.Links GetData(string id)
        {
            Model.Links model = new Model.Links();
            if(!(id.Equals("") || id.Equals("0")))
            {
                model = linksbll.GetModel(id);
            }
            else
            {
                string newId = Guid.NewGuid().ToString();
                model.id = newId;
                model.createDate = DateTime.Now;
            }
            model.linkName = Tools.CheckSQLStr(Request.Form["ipt_linkname"]);
            model.url = Tools.CheckSQLStr(Request.Form["ipt_url"]);
            model.orders = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_orders"]));
            if(Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
            {
                model.state = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_state"]));
            }
            else
            {
                model.state = 0;
            }
            model.tags = Tools.CheckSQLStr(Request.Form["ipt_tags"]);
            model.creator = Tools.CheckSQLStr(Request.Form["ipt_creator"]);
            model.remarks = Tools.CheckSQLStr(Request.Form["ipt_remarks"]);
            return model;
        }
        private void DelData()
        {
            string writeMsg = "操作失败";
            string selectID;
            if(Request.Form["cbx_select"] != "")
            {
                selectID = Request.Form["cbx_select"];
            }
            else
            {
                selectID = "";
            }
            if(selectID != string.Empty && selectID != "0")
            {
                if (linksbll.DeleteList(selectID))
                {
                    writeMsg = "删除成功";
                }
                else
                {
                    writeMsg = "删除失败";
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private void QueryOneData()
        {
            string linkId;
            if(Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                linkId = Request.Form["id"];
            }
            else
            {
                linkId = "";
            }
            DataSet ds = linksbll.GetList(1, "id = " + "\'" + linkId + "\'", "id ASC");
            int count = ds.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
    }
}