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
    public partial class ArticleType : System.Web.UI.Page
    {
        BLL.ArticleType articletype_bll = new BLL.ArticleType();
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
            DataSet dsArticletype = articletype_bll.GetAllList();
            int count = articletype_bll.GetAllList().Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsArticletype.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string articleTypeid;           
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                articleTypeid = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                articleTypeid = "";
            }
            DataSet ds = articletype_bll.GetList(1, "id=" + articleTypeid, "id ASC");
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
            Model.ArticleType model = GetData(id);
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {

                    if (articletype_bll.Add(model))
                    {
                        writeMsg = "增加成功!";
                    }
                    else
                    {
                        writeMsg = "增加失败!";
                    }

                }
                else
                {

                    if (articletype_bll.Update(model))
                    {
                        writeMsg = "更新成功!";
                    }
                    else
                    {
                        writeMsg = "更新失败!";
                    }

                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private Model.ArticleType GetData(string id)
        {
            Model.ArticleType model = new Model.ArticleType();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = articletype_bll.GetModel(int.Parse(id));
            }
            else
            {                            
                model.id = articletype_bll.GetMaxId();
            }                      
            model.typeName = Tools.CheckSQLStr(Request.Form["ipt_typename"]);           
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            //string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            string selectID = "";
            if (Request.Form["cbx_select"] != "")
            {
                selectID = Request.Form["cbx_select"];
            }
            else
            {
                selectID = "";
            }
            if (Tools.CheckSQLStr(selectID) != string.Empty && Tools.CheckSQLStr(selectID) != "0")
            {
                if (articletype_bll.DeleteList(selectID))
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
    }
}