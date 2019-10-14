using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using GoosleB2C.DBUtility;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.Sys
{
    

    public partial class Roles : BasePage

    {
        private string uname = GoosleB2C.MyTool.MyCookie.getCookie("uName");
        BLL.Roles bll = new BLL.Roles();
        BLL.Powers pbll = new BLL.Powers();
        BLL.Functions fbll = new BLL.Functions();
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
                case "querypower"://查询角色权限
                    querypower();
                    break;
                case "queryManagers":
                    queryManagers();
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 查询role的manager
        /// </summary>
        private void queryManagers()
        {
            string roleid = Request.Form["id"];
            DataSet ds = bll.GetManagerListByRoleId(roleid);
            int count = bll.GetManagerListByRoleId(roleid).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        /// <summary>
        /// 更新角色权限
        /// </summary>
        private Boolean submitpower(string roleid,string funid)
        {
            int flag = 0;
            string[] temp = funid.Split(',');
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!(roleid == null))
            {
                //删除旧权限记录
                pbll.DeletePowerByRoleId(roleid);  
            }
            if (!(funid == null))
            {
                //新增新权限记录
                
                for (int i = 0; i < temp.Length; i++)
                {
                    string guid = Guid.NewGuid().ToString("");
                    Model.Powers newpower = new Model.Powers();
                    newpower.id = guid;
                    newpower.funId = temp[i];
                    newpower.roleId = roleid;
                    newpower.powerValue = 1;
                    newpower.createDate = Convert.ToDateTime(now);
                    if(pbll.Add(newpower))flag++;
                }
            }
            if (temp.Length == flag) return true;
            else return false;

        }

        /// <summary>
        /// 查询角色权限
        /// </summary>
        private void querypower()
        {
            string id = Request.Form["id"];
            if (!(id==null)) {
                DataSet str = pbll.GetPowerList(id);
                int count = pbll.GetPowerList(id).Tables[0].Rows.Count;
                string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
                Response.Write(strJSON);
            }
            else
            {
                DataSet str = fbll.GetAllList();
                int count = fbll.GetAllList().Tables[0].Rows.Count;
                string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
                Response.Write(strJSON);
            }
            Response.End();
        }
        #region 删除指定ID 的数据
        /// <summary>
        /// 删除数据
        /// </summary>
        private void DelData()
        {
            string writeMsg = "删除失败！";
            int flag = 0;
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            string temp = selectID.Replace("'", "");
            string[] roleid = temp.Split(',');
            //删除角色权限信息
            for(int i = 0; i < roleid.Length; i++)
            {
                if (pbll.DeletePowerByRoleId(roleid[i])) flag++;
            }
            if (selectID != string.Empty && selectID != "0")
            {
                int delNum = DataHandler.DelData("Roles", selectID);
                if (delNum > 0&&flag==roleid.Length)
                {
                    writeMsg = string.Format("删除成功，本次共删除{0}条", delNum.ToString());
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
        #endregion

        #region 添加或修改提交的数据
        /// <summary>
        /// 添加或修改数据
        /// </summary>
        private void UpdateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            string funid = Request.Form["funid"] != "" ? Request.Form["funid"] : "";
            Model.Roles model = GetData(id);
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("")||id.Equals("0"))
                {

                    if (bll.Add(model)&& submitpower(model.id, funid))
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

                    if (bll.Update(model)&&submitpower(id,funid))
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
        private Model.Roles GetData(String id)
        {
            Model.Roles model = new Model.Roles();
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = bll.GetModel(id);
                model.createUser = Request.Form["ipt_createuser"] != "" ? Request.Form["ipt_createuser"] : "";
                model.createDate = Request.Form["ipt_createdate"] != "" ? Convert.ToDateTime((Request.Form["ipt_createdate"])) : dt;

            }
            else
            {
                string guid = Guid.NewGuid().ToString("");
                model.id = guid;
                model.createUser = uname;
                model.createDate = Convert.ToDateTime(now);

            }
            string rolename = Tools.CheckSQLStr(Request.Form["ipt_rolename"]);

            //sql注入验证

            if (Tools.CheckSQLStr(Request.Form["ipt_rolename"]) != "")
            {
                model.roleName = Request.Form["ipt_rolename"];

            }
            else
            {
                model.roleName = "";
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_roleorder"]) != "")
            {
                model.roleOrder = Convert.ToInt32(Request.Form["ipt_roleorder"]);
            }
            else
            {
                model.roleOrder = 0;
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_intro"]) != "")
            {
                model.intro = Request.Form["ipt_intro"];
            }
            else
            {
                model.intro = "";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_remark"]) != "")
            {
                model.remark = Request.Form["ipt_remark"];
            }
            else
            {
                model.remark = "";
            }
            
            
 
            model.updateUser = uname;
            model.updateDate = Convert.ToDateTime(now);
            return model;
        }
        #endregion

        #region 查询指定ID 的数据
        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        private void QueryOneData()
        {

            string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
            DataSet ds = bll.GetList(1, "id=\'" + userid+"\'", "ID ASC");
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

            //int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            //int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            //string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            //string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            //if (page < 1) return;
            //string orderField = sort.Replace("JSON_", "");
            //string strWhere = GetWhere();

            //DataSet dsUser = DataHandler.GetList("Roles", "*", "id", size, page, false, false, strWhere);
            DataSet str = bll.GetAllList(); 
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            //int count = bll.GetList(strWhere).Tables[0].Rows.Count;//获取总数
            //string strJSON = JsonHelper.CreateJsonParameters(dsUser.Tables[0], true, count);

            Response.Write(strJSON);
            Response.End();

        }
        #endregion
    }
}

