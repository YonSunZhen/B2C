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
    public partial class Managers : BasePage
    {
        BLL.Managers managersbll = new BLL.Managers();
        BLL.Managers_ managersbll_ = new BLL.Managers_();
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
                case "QueryRoleName"://查询角色名称
                    QueryRoleName();
                    break;
                default:
                    break;
            }
        }
        #region 删除指定ID 的数据
        /// <summary>
        /// 删除数据
        /// </summary>
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                if (managersbll.DeleteList(selectID))
                {
                    writeMsg = "删除成功！";
                }
                else
                {
                    writeMsg = "删除失败！";
                }
                //int delNum = DataHandler.DelData("Managers", Tools.CheckSQLStr(selectID));
                //if (delNum > 0)
                //{
                //    writeMsg = string.Format("删除成功，本次共删除{0}条", delNum.ToString());
                //}
                //else
                //{
                //    writeMsg = "删除失败！";
                //}
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 添加或修改提交的数据
        /// <summary>
        /// 添加或修改数据
        /// </summary>
        private void UpdateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            Model.Managers model = GetData(Tools.CheckSQLStr(id));
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {

                    if (managersbll.Add(model))
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

                    if (managersbll.Update(model))
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
        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Model.Managers GetData(string id)
        {
            Model.Managers model = new Model.Managers();
            Model.Managers loginmodel = new Model.Managers();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = managersbll.GetModel(id);                
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.id = newid;
                model.creator = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.cteateDate = DateTime.Now;
                model.lastLoginDate = null;
                model.loginDate = null;
                model.loginTimes = 0;
            }
            
            model.userName = Tools.CheckSQLStr(Request.Form["ipt_username"]);
            model.passWord = Tools.CheckSQLStr(Request.Form["ipt_password"]);
            model.cnName = Tools.CheckSQLStr(Request.Form["ipt_cnname"]);
            model.mobile = Tools.CheckSQLStr(Request.Form["ipt_mobile"]);
            model.expand1 = Tools.CheckSQLStr(Request.Form["ipt_expand1"]);           
            model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);          
            if (Tools.CheckSQLStr(Request.Form["ipt_roleid"]) != "")
            {
                model.roleId = Tools.CheckSQLStr(Request.Form["ipt_roleid"]);
            }
            else
            {
                model.roleId = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
            {
                model.state = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_state"]));
            }
            else
            {
                model.state = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_usertype"]) != "")
            {
                model.userType = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_usertype"]));
            }
            else
            {
                model.userType = 1;
            }
            return model;
        }
        #endregion
       
        #region 查询指定ID 的数据
        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        private void QueryOneData()
        {
            string userid = Tools.CheckSQLStr(Request.Form["id"]) != "" ? Tools.CheckSQLStr(Request.Form["id"]) : "";
            DataSet ds = managersbll_.GetList(1, "\'" + userid + "\'", "Managers.id ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 查询数据
        /// <summary>
        /// 组合搜索条件
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData()
        {

            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            string orderField = sort.Replace("JSON_", "");
            string strWhere = GetWhere();
            
            DataSet dsManagers = managersbll_.GetList(strWhere);
            int count = dsManagers.Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsManagers.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();

        }//_5_1_a_s_p_x
        #endregion

        private void QueryRoleName()
        {
            DataSet RolesName = managersbll_.GetList_RolesName();
            string strJSON = CreateJsonTwo(RolesName.Tables[0], false);
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
                            JsonString.Append("role" + dt.Columns[j].ColumnName.ToString().ToLower() + ":" + "\"" + dt.Rows[i][j].ToString() + "\",");
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