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

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    public partial class Product : System.Web.UI.Page
    {
        BLL.Product productBll = new BLL.Product();
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
                case "QueryDeliverytemp":
                    QueryDeliveryTemp();
                    break;
                default:
                    break;
            }
        }
        private void QueryData()
        {
            DataSet product = productBll.GetAllList();
            int count = product.Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(product.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        private void QueryOneData()
        {
            string pId;
            if (Tools.CheckSQLStr(Request.Form["id"]) != "")
            {
                pId = Tools.CheckSQLStr(Request.Form["id"]);
            }
            else
            {
                pId = "";
            }
            DataSet ds = productBll.GetList(" pId = " + "\'" + pId + "\'");
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

                if (productBll.DeleteList(selectID))
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
            Model.Product model = GetData(id);
            string writeMsg = "操作失败";
            if (model != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (productBll.Add(model))
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
                    if (productBll.Update(model))
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
        private Model.Product GetData(string id)
        {
            Model.Product model = new Model.Product();
            if (!(id.Equals("") || id.Equals("0")))
            {
                model = productBll.GetModel(id);
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;
            }
            else
            {
                string newid = Guid.NewGuid().ToString();
                model.pId = newid;
                model.creator = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.createTtime = DateTime.Now;
                model.modifier = GoosleB2C.MyTool.MyCookie.getCookie("uName");
                model.modifyDate = DateTime.Now;               
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_procategory"]) != "")
            {
                model.proCategory = Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_procategory"]));
            }
            else
            {
                model.proCategory = 1;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_state"]) != "")
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
            if(Tools.CheckSQLStr(Request.Form["ipt_deliverytempid"]) != "")
            {
                model.deliveryTempId = Tools.CheckSQLStr(Request.Form["ipt_deliverytempid"]);
            }
            else
            {
                model.deliveryTempId = "e24a287d-b37c-4b40-bec2-acf6118db42a";
            }
            if(Tools.CheckSQLStr(Request.Form["ipt_total"]) != "")
            {
                model.total = int.Parse(Tools.CheckSQLStr(Request.Form["ipt_total"]));
            }
            else
            {
                model.total = 0;
            }
            if (Tools.CheckSQLStr(Request.Form["ipt_sales"]) != "")
            {
                model.sales = int.Parse(Tools.CheckSQLStr(Request.Form["ipt_sales"]));
            }
            else
            {
                model.sales = 0;
            }
            model.title = Tools.CheckSQLStr(Request.Form["ipt_title"]);
            model.webDetails = Request.Form["ipt_webdetails"];
            model.details = Tools.CheckSQLStr(Request.Form["ipt_details"]);
            model.detailImgs = Request.Form["ipt_detailimgs"];
            model.remark = Tools.CheckSQLStr(Request.Form["ipt_remark"]);
            model.seoTitle = Tools.CheckSQLStr(Request.Form["ipt_seotitle"]);
            model.seoKey = Tools.CheckSQLStr(Request.Form["ipt_seokey"]);
            model.seoDescribe = Tools.CheckSQLStr(Request.Form["ipt_seodescribe"]);
            model.img1 = Request.Form["ipt_img1"];
            model.img2 = Request.Form["ipt_img2"];
            model.img3 = Request.Form["ipt_img3"];
            model.img4 = Request.Form["ipt_img4"];
            model.img5 = Request.Form["ipt_img5"];
            model.originalPrice = int.Parse(Tools.CheckSQLStr(Request.Form["ipt_originalprice"]));
            model.price = int.Parse(Tools.CheckSQLStr(Request.Form["ipt_price"]));                       
            return model;
        }
        private void QueryDeliveryTemp()
        {
            DataSet ds = productBll.QueryDeliveryTemp();
            string strJSON = CreateJsonTwo(ds.Tables[0], false);
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