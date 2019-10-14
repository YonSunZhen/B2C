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

namespace GoosleB2C.Web
{
    public partial class UserLevel : System.Web.UI.Page
    {
        BLL.UserLevel userlevelbll = new BLL.UserLevel();
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
            DataSet dsUserLevel = userlevelbll.GetAllList();
            int count = userlevelbll.GetAllList().Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsUserLevel.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string userLevelid;
            //string userLevelid = Tools.CheckSQLStr(Request.Form["id"]) != "" ? Tools.CheckSQLStr(Request.Form["id"]) : "";
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                userLevelid = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                userLevelid = "";
            }
            DataSet ds = userlevelbll.GetList(1, "id=\'" + userLevelid + "\'", "id ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void UpdateData()
        {
            string id;
            //string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            if (Request.Form["id"] != "")
            {
                id = Request.Form["id"];
            }
            else
            {
                id = "";
            }
            Model.UserLevel model = GetData(id);
            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {

                    if (userlevelbll.Add(model))
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

                    if (userlevelbll.Update(model))
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
        private Model.UserLevel GetData(string id)
        {
            Model.UserLevel model = new Model.UserLevel();         
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = userlevelbll.GetModel(id);
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.id = newid;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_levelPiont"]) != null)
            {
                string levelPiont = Tools.CheckSQLStr(Request.Form["ipt_levelPiont"]);
                model.levelPiont = int.Parse(levelPiont);
            }
            else
            {
                model.levelPiont = 0;
            }            
            string discount = Tools.CheckSQLStr(Request.Form["ipt_discount"]);
            float discount_1 = float.Parse(discount) / 100;           
            model.levelName = Tools.CheckSQLStr(Request.Form["ipt_levelName"]);
            model.discount = Convert.ToDecimal(discount_1);
            
            model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";      
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            //string selectID = "";
            //if (Request.Form["cbx_select"] != "")
            //{
            //    selectID = Request.Form["cbx_select"];
            //}
            //else
            //{
            //    selectID = "";
            //}
            if (Tools.CheckSQLStr(selectID) != string.Empty && Tools.CheckSQLStr(selectID) != "0")
            {
                if (userlevelbll.DeleteList(selectID)){
                    writeMsg = "删除成功";           
                }
                else
                {
                    writeMsg = "删除失败";
                }
                //int delNum = DataHandler.DelData("UserLevel", Tools.CheckSQLStr(selectID));
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
    }
}