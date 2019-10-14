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
    public partial class SuccessCase : System.Web.UI.Page
    {
        BLL.SuccessCase successcasebll_ = new BLL.SuccessCase();
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
            //分页获取数据列表
            //StringBuilder sb = new StringBuilder("1=1");
            //string strWhere = sb.ToString();
            //int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            //int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            //string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            //string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            //if (page < 1) return;
            //string orderField = sort.Replace("JSON_", "");
            //DataSet article_ = DataHandler.GetList("SuccessCase", "*", "Id", size, page, false, false,strWhere);

            DataSet successcase = successcasebll_.GetList_();
            int count = successcase.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(successcase.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string userId;
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                userId = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                userId = "";
            }
            DataSet ds = successcasebll_.GetOneList(1, "Id = " + "\'" + userId + "\'", "orders ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void UpdateData()
        {
            string id;
            if (Request.Form["id"] != "")
            {
                id = Request.Form["id"];
            }
            else
            {
                id = "";
            }
            Model.SuccessCase model = GetData(id);
            string writeMsg = "操作失败";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (successcasebll_.Add(model))
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
                    if (successcasebll_.Update(model))
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
        private Model.SuccessCase GetData(string id)
        {
            Model.SuccessCase model = new Model.SuccessCase();
            if(!(id.Equals("") || id.Equals("0")))
            {
                model = successcasebll_.GetModel(id);
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;
                if (Tools.CheckSQLStr(Request.Form["ipt_readcount"]) != "")
                {
                    model.readCount = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_readcount"]));
                }
                else
                {
                    model.readCount = 0;
                }
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.Id = newid;
                model.creator = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.createTime = DateTime.Now;
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;
                if(Tools.CheckSQLStr(Request.Form["ipt_readcount"]) != "")
                {
                    model.readCount = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_readcount"]));
                }
                else
                {
                    model.readCount = 0;
                }                
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
            {
                model.state = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_state"]));
            }
            else
            {
                model.state = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_orders"]) != "")
            {
                model.orders = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_orders"]));
            }
            else
            {
                model.orders = 1;
            }
            
            model.title = Tools.CheckSQLStr(Request.Form["ipt_title"]);
            model.webContent = Request.Form["ipt_webcontent"];
            model.content = Tools.CheckSQLStr(Request.Form["ipt_content"]);
            model.imgs = Tools.CheckSQLStr(Request.Form["ipt_imgs"]);
            model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);
            model.seoTitle = Tools.CheckSQLStr(Request.Form["ipt_seotitle"]);
            model.seoKey = Tools.CheckSQLStr(Request.Form["ipt_seokey"]);
            model.seoDescribe = Tools.CheckSQLStr(Request.Form["ipt_seodescribe"]);
            model.summay = Tools.CheckSQLStr(Request.Form["ipt_summay"]);
            model.mainImg = Tools.CheckSQLStr(Request.Form["ipt_mainImg"]);
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {               
                if (successcasebll_.DeleteList(selectID))
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