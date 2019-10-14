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


    public partial class Powers : BasePage

    {
        private string uname = GoosleB2C.MyTool.MyCookie.getCookie("uName");
        BLL.Powers bll = new BLL.Powers();

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
                int delNum = DataHandler.DelData("Roles", selectID);
                if (delNum > 0)
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
            Model.Powers model = GetData(id);
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {

                    if (bll.Add(model))
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

                    if (bll.Update(model))
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
        private Model.Powers GetData(String id)
        {
            Model.Powers model = new Model.Powers();
            //string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            //if (!(id.Equals("") || id.Equals("0")))
            //{
            //    model = bll.GetModel(id);
            //    model.createUser = Request.Form["ipt_createuser"] != "" ? Request.Form["ipt_createuser"] : "";
            //    model.createDate = Request.Form["ipt_createdate"] != "" ? Convert.ToDateTime((Request.Form["ipt_createdate"])) : dt;

            //}
            //else
            //{
            //    string guid = Guid.NewGuid().ToString("");
            //    model.id = guid;
            //    model.createUser = uname;
            //    model.createDate = Convert.ToDateTime(now);

            //}




            //model.roleName = Request.Form["ipt_rolename"] != "" ? Request.Form["ipt_rolename"] : "";

            //model.roleOrder = Request.Form["ipt_roleorder"] != "" ? Convert.ToInt32(Request.Form["ipt_roleorder"]) : 0;

            //model.intro = Request.Form["ipt_intro"] != "" ? Request.Form["ipt_intro"] : "";

            ////            model.createUser = Request.Form["ipt_createuser"] != "" ? Request.Form["ipt_createuser"] : "";

            ////            model.createDate = Request.Form["ipt_createdate"] != "" ? Convert.ToDateTime((Request.Form["ipt_createdate"])) : dt;

            //model.updateUser = uname;

            //model.updateDate = Convert.ToDateTime(now);

            //model.remark = Request.Form["ipt_remark"] != "" ? Request.Form["ipt_remark"] : "";
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
            DataSet ds = bll.GetList(1, "id=\'" + userid + "\'", "ID ASC");
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

