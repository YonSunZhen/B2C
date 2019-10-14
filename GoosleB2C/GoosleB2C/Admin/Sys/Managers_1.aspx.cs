using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using GoosleB2C.DBUtility;

namespace GoosleB2C.Web.Admin.Sys
{
    public partial class Managers_1 : BasePage
    {
        BLL.Managers bll = new BLL.Managers();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action  = "";
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
                    UpdateData();
                    break;
                case "del":
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
            DataSet dsUser = DataHandler.GetList("Managers", "*", "id", size, page, false, false, strWhere);
            int count = bll.GetList(strWhere).Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsUser.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            int userid = Request.Form["id"] != "" ? Convert.ToInt32(Request.Form["id"]) : 0;
            DataSet ds = bll.GetList(1, "id=" + userid, "id ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void UpdateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "0";
            Model.Managers model = GetData(id);
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id == "0")
                {
                    if (bll.Add(model))
                    {
                        writeMsg = "增加成功！";
                    }
                    else
                    {
                        writeMsg = "增加失败！";
                    }
                }
                else
                {
                    if (bll.Update(model))
                    {
                        writeMsg = "更新成功！";
                    }
                    else
                    {
                        writeMsg = "更新失败！";
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
            if (selectID != string.Empty && selectID != "0")
            {
                //int delNum = DataHandler.DelData("Managers", selectID);
                bool delNum = bll.Delete(selectID);
                if (delNum)
                {
                    writeMsg = string.Format("删除成功!");
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
        private Model.Managers GetData(string id)
        {
            string newid = Guid.NewGuid().ToString();
            Model.Managers model = new Model.Managers();
            if (id == "0")
            {
                model.id = newid;
                model.userName = Request.Form["ipt_username"];
                model.passWord = Request.Form["ipt_userpwd"];
                model.cnName = Request.Form["ipt_cnname"];
                model.mobile = Request.Form["ipt_mobile"];
                model.creator = Request.Form["ipt_creator"];
                model.cteateDate = DateTime.Now;
                model.lastLoginDate = DateTime.Now;
                model.loginDate = DateTime.Now;
                model.loginTimes = 2;
                model.expand1 = Request.Form["ipt_expand1"];
                model.remark = Request.Form["ipt_remark"];
                if (Request.Form["ipt_roleid"] != "")
                {
                    model.roleId = Convert.ToString(Request.Form["ipt_roleid"]);
                }
                else
                {
                    model.roleId = "1";
                }
                if (Request.Form["ipt_state"] != "")
                {
                    model.state = Convert.ToInt32(Request.Form["ipt_state"]);
                }
                else
                {
                    model.state = 0;
                }
                if (Request.Form["ipt_usertype"] != "")
                {
                    model.userType = Convert.ToInt32(Request.Form["ipt_usertype"]);
                }
                else
                {
                    model.userType = 1;
                }
            }
            else
            {
                model = bll.GetModel(id);
            }
            return model;
        }
    }
}