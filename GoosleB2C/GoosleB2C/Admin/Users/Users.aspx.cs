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

namespace GoosleB2C.Web.Admin.Users
{
    public partial class Users : System.Web.UI.Page
    {
        BLL.Users userbll = new BLL.Users();
        //BLL.Users_ userbll_ = new BLL.Users_();
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
                case "submit"://提交数据，添加或修改
                    UpdateData();
                    break;                
                case "QueryLevelName"://查询角色名称
                    QueryLevelName();
                    break;
                case "del":
                    DelData();
                    break;
                case "GetlevelPoint":
                    GetlevelPoint();
                    break;
                default:
                    break;
            }
        }

        private void GetlevelPoint()
        {
            DataSet levlePoint = userbll.GetlevelPoint();
        }
        private string GetWhere()
        {
            StringBuilder sb = new StringBuilder("1=1");
            string searchType = Request.Form["search_type"] != "" ? Request.Form["search_type"] : string.Empty;
            string searchValue = Request.Form["search_value"] != "" ? Request.Form["search_value"] : string.Empty;
            //string searchType = "";
            //string searchValue = "";
            if (searchType != null && searchValue != null)
            {
                sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue, searchType);
            }
            return sb.ToString();
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

            

            DataSet dsManagers = userbll.GetList_(strWhere);
            int count = dsManagers.Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsManagers.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }      

        private void GetPoints()
        {
            DataSet points = userbll.GetPoints();
        }
        private Model.Users GetData(string id)
        {
            Model.Users model = new Model.Users();
            DataSet levlePoint = userbll.GetlevelPoint();
            string b = levlePoint.Tables[0].Rows[0]["id"].ToString();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = userbll.GetModel(id);
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.uId = newid;
                model.wId = null;
                model.wName = null;
                model.wImg = null;
                model.wCode = null;               
                model.loginTime = DateTime.Now;
                model.loginIp = null;
                model.lastTime = null;
                model.lastIp = null;              
            }

            model.UserName = Tools.CheckSQLStr(Request.Form["ipt_username"]);
            model.PassWord = Tools.CheckSQLStr(Request.Form["ipt_password"]);
            model.realName = Tools.CheckSQLStr(Request.Form["ipt_realname"]);
            model.phone = Tools.CheckSQLStr(Request.Form["ipt_phone"]);            
            model.fund = 0;
            model.remak = Tools.CheckSQLStr(Request.Form["ipt_remak"]);

            string a = Tools.CheckSQLStr(Request.Form["ipt_sex"]);
            model.sex = Convert.ToInt32(a);

            if (Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
            {
                model.state = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_state"]));
            }
            else
            {
                model.state = 1;
            }            
            model.points = 0;                      
            model.levelId = b;
            return model;
        }
        private void UpdateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            Model.Users model = GetData(Tools.CheckSQLStr(id));
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {

                    if (userbll.Add(model))
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

                    if (userbll.Update(model))
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
      
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (Tools.CheckSQLStr(selectID) != string.Empty && Tools.CheckSQLStr(selectID) != "0")
            {
                if (userbll.DeleteList(selectID))
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

        private void QueryLevelName()
        {
            DataSet LevelName = userbll.GetList_LevelName();
            string strJSON = CreateJson_UserLevel(LevelName.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        public static string CreateJson_UserLevel(DataTable dt, bool displayCount)
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
                            JsonString.Append(dt.Columns[j].ColumnName.ToString().ToLower() + ":" + "\"" + dt.Rows[i][j].ToString() + "\",");
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