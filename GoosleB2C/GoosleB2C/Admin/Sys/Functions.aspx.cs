using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Reflection;
using System.Globalization;
using GoosleB2C.DBUtility;
using GoosleB2C.MyTool;


namespace GoosleB2C.Web.Admin.Sys
{
    public partial class Functions : BasePage
    {
        BLL.Functions functionsBll = new BLL.Functions();
        //BLL.Functions functionsBll_ = new BLL.Functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
                action = Request.Form["action"];
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
                case "ADD":
                    QueryFunctionName();
                    break;
                case "querypower":
                    querypower();
                    break;
                default:
                    break;
            }

        }

        #region 组合搜索条件
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
        #endregion

        #region 取得数据
        private Model.Functions GetData(string id)
        {
            //string model = "";
            Model.Functions Model = new Model.Functions();
            Model.Functions model1 = new Model.Functions();
            Model.Functions model2 = new Model.Functions();
            Model.Functions model3 = new Model.Functions();
            Model.Functions model4 = new Model.Functions();
            if (!(id.Equals("") || id.Equals("0")))
            {
                Model = functionsBll.GetModel(id);
                //修改时执行这里面的值
                       
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                Model.id = newid;

                //添加时执行这里面的东西，修改时根据id来的，所以创建id只能是添加时才有
            }

            Model.functionName = Tools.CheckSQLStr(Request.Form["ipt_functionname"]);
            Model.url = Tools.CheckSQLStr(Request.Form["ipt_url"]);
            //model.funLevel = Request.Form["ipt_funlevel"] != "" ? Convert.ToInt32(Request.Form["ipt_funlevel"]) : 0;
            Model.funOrder = Tools.CheckSQLStr(Request.Form["ipt_funorder"]) != "" ? Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_funorder"])) : 0;
            Model.funType = Tools.CheckSQLStr(Request.Form["ipt_funtype"]) != "" ? Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_funtype"])) : 0;
            Model.img1 = Tools.CheckSQLStr(Request.Form["ipt_img1"]);
            Model.img2 = Tools.CheckSQLStr(Request.Form["ipt_img2"]);
            Model.intro = Tools.CheckSQLStr(Request.Form["ipt_intro"]);
            Model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);
            string father = Convert.ToString(Tools.CheckSQLStr(Request.Form["ipt_father"]));
            if (father == "")
            {
                Model.father = "0";
                Model.funLevel = 1;
            }
            else
            {
                //Model.funLevel = 2;
                Model.father = father;
                model1 = functionsBll.GetModel(father);
                if (model1.father == "0")
                {
                    Model.funLevel = 2;
                    return Model;
                }
                if (model1.father != "0")
                {
                    Model.funLevel = 3;
                    model2 = functionsBll.GetModel(model1.father);
                    if (model2.father != "0")
                    {
                        Model.funLevel = 4;
                        model3 = functionsBll.GetModel(model2.father);
                        if (model3.father != "0")
                        {
                            Model.funLevel = 5;
                        }
                        else
                        {
                            return Model;
                        }
                    }
                    else
                    {
                        return Model;
                    }
                }               
                //if (functionsBll.GetModel(model1.father).father != "0")
                //{
                //    Model.funLevel = 4;
                //    return Model;
                //}

                //if (functionsBll.GetModel(model2.father).father != "0")
                //{
                //    Model.funLevel = 5;
                //    return Model;
                //}

            }
                
            return Model;
        }

        #endregion

        #region 取得某一条数据
        private void QueryOneData()
        {
            string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
            DataSet ds = functionsBll.GetList(1, "id=\'" + userid + "\'", "ID ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);     
            Response.Clear();
            Response.Write(strJSON);          
            Response.End();
        }

        #endregion

        #region 初始化页面数据
        private void QueryData()
        {
            //int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            //int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            //string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            //string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            //if (page < 1) return;
            //string orderField = sort.Replace("JSON_", "");
            //string strWhere = GetWhere();
            //string id = Request.Form["id"] != "" ? Request.Form["id"] : "0";
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            //string orderField = sort.Replace("JSON_", "");
            string strWhere = GetWhere();

            DataSet str = functionsBll.GetList(strWhere);
            int count = functionsBll.GetList(strWhere).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 添加或修改数据
        private void UpdateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            Model.Functions Model = GetData(id);
            string writeMsg = "操作失败";
            if(Model != null)
            {
                if(id.Equals("") || id.Equals("0"))
                {
                    if (functionsBll.Add(Model))
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
                    if (functionsBll.Update(Model))
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
        #endregion

        #region 删除数据
        private void DelData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                if (functionsBll.Delete(selectID))
                {
                    writeMsg = "删除成功！";
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }
            //if (selectID != string.Empty && selectID != "0")
            //{
            //    int delNum = DataHandler.DelData("Functions", selectID);
            //    if (delNum > 0)
            //    {
            //        writeMsg = string.Format("删除成功，本次共删除{0}条", delNum.ToString());
            //    }
            //    else
            //    {
            //        writeMsg = "删除失败！";
            //    }

            //}

            Response.Clear();
            Response.Write(writeMsg);
            Response.End();

        }

        #endregion

        #region 取得1级页面名
        private void QueryFunctionName()
        {
            //string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
            //string str = "funLevel=0";
            //string str1 = str.Replace("\"", "").Replace("\"", "");
            DataSet FunctionName = functionsBll.GetList_FunctionName("funLevel=1");
            string strJSON = JsonHelper.CreateJsonTwo(FunctionName.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 获得父级菜单(取得所有数据)
        private void querypower()
        {
            string id = Request.Form["id"];
            if (!(id == null))
            {
                DataSet str = functionsBll.GetList(id);
                int count = functionsBll.GetList(id).Tables[0].Rows.Count;
                string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
                Response.Write(strJSON);
            }
            else
            {
                DataSet str = functionsBll.GetAllList();
                int count = functionsBll.GetAllList().Tables[0].Rows.Count;
                string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
                Response.Write(strJSON);
            }
            Response.End();
        }
        #endregion

    }
}