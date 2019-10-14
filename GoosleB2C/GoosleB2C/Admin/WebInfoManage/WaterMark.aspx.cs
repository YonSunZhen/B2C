using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web.Admin.WebInfoManage
{
    public partial class WaterMark : System.Web.UI.Page
    {
        BLL.WaterMark watermarkBll = new BLL.WaterMark();
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
                case "queryWaterMark_state":
                    QuerybyState();
                    break;
                default:
                    break;
            }
        }
        private void QueryData()
        {
            DataSet ds = watermarkBll.GetAllList();
            int count = ds.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string userId;
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                userId = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                userId = "";
            }
            DataSet ds = watermarkBll.GetList("id=" + userId);
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
            Model.WaterMark model = GetData(id);
            string writeMsg = "操作失败";

            DataSet ds = watermarkBll.GetList("id != " + id + " and state = " + 1);
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                Model.WaterMark model_State = new Model.WaterMark();
                model_State.state = 0;
                model_State.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                bool success = watermarkBll.Update_State(model_State);
            }

            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (watermarkBll.Add(model))
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
                    if (watermarkBll.Update(model))
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
        private Model.WaterMark GetData(string id)
        {
            Model.WaterMark model = new Model.WaterMark();            
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = watermarkBll.GetModel(int.Parse(id));                               
            }
            else
            {
                model.id = watermarkBll.GetMaxId();                
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
            {
                model.state = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_state"]));
            }
            else
            {
                model.state = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_watertype"]) != "")
            {
                model.waterType = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_watertype"]));
            }
            else
            {
                model.waterType = 1;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_position"]) != "")
            {
                model.position = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_position"]));
            }
            else
            {
                model.position = 1;
            }
            model.words = Tools.CheckSQLStr(Request.Form["ipt_words"]);
            model.img = Tools.CheckSQLStr(Request.Form["ipt_img"]);
            model.transparent = int.Parse(Tools.CheckSQLStr(Request.Form["ipt_transparent"]));
            return model;
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                if (watermarkBll.DeleteList(selectID))
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
        private void QuerybyState()
        {
            DataSet ds = watermarkBll.GetList("state = " + 1);
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            if(strJSON == null)
            {
                strJSON = "{ ipt_state:\"0\" }";
            }
            Response.Write(strJSON);
            Response.End();
        }
    }
}