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

namespace GoosleB2C.Web.Article
{
    public partial class Article : System.Web.UI.Page
    {
        BLL.Article articlebll_ = new BLL.Article();
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
                case "QueryArticleType"://查询文章类型
                    QueryArticleType();
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
            //DataSet article_ = DataHandler.GetList("Article", "*", "Id", size, page, false, false,strWhere);

            DataSet article = articlebll_.GetList_();
            int count = article.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(article.Tables[0], true, count);
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
            Model.Article model = GetData(id);
            string writeMsg = "操作失败";
            if(model != null)
            {
                if(id.Equals("") || id.Equals("0"))
                {
                    if (articlebll_.Add(model))
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
                    if (articlebll_.Update(model))
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
        private Model.Article GetData(string id)
        {
            Model.Article model = new Model.Article();
            if(!(id.Equals("") || id.Equals("0")))
            {
                model = articlebll_.GetModel(id);
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.Id = newid;
                model.creator = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.createTime = DateTime.Now;
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;
                model.readCount = 0;
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_type"]) != "")
            {
                model.type = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_type"]));
            }
            else
            {
                model.type = 1;
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
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
            if(Tools.CheckSQLStr(Request.Form["ipt_readcount"]) != "")
            {
                model.readCount = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_readcount"]));
            }
            else
            {
                model.readCount = 0;
            }
            model.title = Tools.CheckSQLStr(Request.Form["ipt_title"]);
            model.webContent = Request.Form["ipt_webcontent"];
            model.content = Tools.CheckSQLStr(Request.Form["ipt_content"]);
            model.imgs = Tools.CheckSQLStr(Request.Form["ipt_imgs"]);
            model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);
            model.seoTitle = Tools.CheckSQLStr(Request.Form["ipt_seotitle"]);
            model.seoKey = Tools.CheckSQLStr(Request.Form["ipt_seokey"]);
            model.seoDescribe = Tools.CheckSQLStr(Request.Form["ipt_seodescribe"]);
            return model;
        }
        private void QueryOneData()
        {
            string userId;
            if(Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                userId = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                userId = "";
            }
            //DataSet ds = articlebll_.GetOneList(1, "Article.Id = " + "\'" + userId + "\'", "Article.orders ASC");
            DataSet ds = articlebll_.GetList("Id=" + "\'" + userId + "\'");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";        
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                //DataSet ds = articlebll_.GetImgsSrc(selectID);
                //int count = ds.Tables[0].Rows.Count;
                //string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
                
                if (articlebll_.DeleteList(selectID))
                {
                    writeMsg = "删除成功！";
                }
                else
                {
                    writeMsg = "删除失败！";
                }
                //writeMsg = writeMsg + ";" + strJSON;               
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }



        private void QueryArticleType()
        {
            DataSet ArticleType = articlebll_.GetArticlType();
            string strJSON = CreateJsonTwo(ArticleType.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        public static string CreateJsonTwo(DataTable dt, bool displayCount)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("type" + dt.Columns[j].ColumnName.ToString().ToLower() + ":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append(dt.Columns[j].ColumnName.ToString().ToLower() + ":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }

                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }

                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}