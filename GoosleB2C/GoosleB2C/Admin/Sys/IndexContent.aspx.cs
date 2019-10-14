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
    public partial class IndexContent : System.Web.UI.Page
    {
        BLL.IndexContent indexContentBll = new BLL.IndexContent();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if(Request.Form["action"] != "")
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
            DataSet indexImg = DataHandler.GetList("IndexContent", "*", "id", size, page, false, false, strWhere);
            int count = indexContentBll.GetList(strWhere).Tables[0].Rows.Count;
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
            DataSet ds = indexContentBll.GetList("id=" + "\'" + Id + "\'");
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
            Model.IndexContent model = GetData(id);
            string writeMsg = "操作失败";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (indexContentBll.Add(model))
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
                    if (indexContentBll.Update(model))
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
        private Model.IndexContent GetData(string id)
        {
            Model.IndexContent model = new Model.IndexContent();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = indexContentBll.GetModel(id);               
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.id = newid;                
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_isshowsuccess"]) != "")
            {
                model.isShowSuccess = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_isshowsuccess"]));
            }
            else
            {
                model.isShowSuccess = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_isshowproduct"]) != "")
            {
                model.isShowProduct = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_isshowproduct"]));
            }
            else
            {
                model.isShowProduct = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_isshowarticle"]) != "")
            {
                model.isShowArticle = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_isshowarticle"]));
            }
            else
            {
                model.isShowArticle = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_isshowvideo"]) != "")
            {
                model.isShowVideo = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_isshowvideo"]));
            }
            else
            {
                model.isShowVideo = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_isrun"]) != "")
            {
                model.isRun = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_isrun"]));
            }
            else
            {
                model.isRun = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_videopath"]) != "")
            {
                model.videoPath = Tools.CheckSQLStr(Request.Form["ipt_videopath"]);
            }
            else
            {
                model.videoPath = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_videotitle"]) != "")
            {
                model.videoTitle = Tools.CheckSQLStr(Request.Form["ipt_videotitle"]);
            }
            else
            {
                model.videoTitle = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_successtotal"]) != "")
            {
                model.successTotal = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_successtotal"]));
            }
            else
            {
                model.successTotal = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_producttotal"]) != "")
            {
                model.productTotal = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_producttotal"]));
            }
            else
            {
                model.productTotal = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_articletotal"]) != "")
            {
                model.articleTotal = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_articletotal"]));
            }
            else
            {
                model.articleTotal = 0;
            }
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                if (indexContentBll.DeleteList(selectID))
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