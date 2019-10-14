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
    public partial class VisitRecord : System.Web.UI.Page
    {
        BLL.VisitRecord visitRecordBll = new BLL.VisitRecord();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
            {
                action = Request.Form["action"];
            }
            switch (action)
            {
                case "query":
                    QueryData();
                    break;
                case "del":
                    DelData();
                    break;
                case "queryBydate":
                    QueryByDate();
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

            DataSet ds = DataHandler.GetList("VisitRecord", "*", "id", size, page, false, false, strWhere);
            int count = visitRecordBll.GetList(strWhere).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        //组合搜索条件
        private string GetWhere()
        {
            StringBuilder sb = new StringBuilder("1=1");
            string searchType;
            string searchValue;
            if (Request.Form["search_type"] != "")
            {
                searchType = Request.Form["search_type"];
            }
            else
            {
                searchType = "";
            }
            if (Request.Form["search_value"] != "")
            {
                searchValue = Request.Form["search_value"];
            }
            else
            {
                searchValue = "";
            }           
            //string searchType = "";
            //string searchValue = "";
            if (searchType != null && searchValue != null)
            {
                sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue, searchType);
            }
            return sb.ToString();
        }
        private void DelData()
        {
            string writeMsg = "删除失败！";
            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {                
                if (visitRecordBll.DeleteList(selectID))
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
        private void QueryByDate()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            string orderField = sort.Replace("JSON_", "");
            string strWhere = GetWhereByDate();

            //string startDate = Request.Form["startDate"];
            //string endDate = Request.Form["endDate"];
            //string strWhere = "visitTime between " + "\'" + startDate + " 0:0:0" + "\'" + " AND " + "\'" + endDate + " 23:59:59" + "\'";

            //DataSet ds = visitRecordBll.GetList(strWhere);
            //int count = ds.Tables[0].Rows.Count;
            //string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);
            DataSet ds = DataHandler.GetList("VisitRecord", "*", "id", size, page, false, false, strWhere);
            int count = visitRecordBll.GetList(strWhere).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);

            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private string GetWhereByDate()
        {
            StringBuilder sb = new StringBuilder();
            string startDate;
            string endDate;
            if (Request.Form["startDate"] != "")
            {
                startDate = Request.Form["startDate"];
            }
            else
            {
                startDate  = "";
            }
            if (Request.Form["endDate"] != "")
            {
                endDate  = Request.Form["endDate"];
            }
            else
            {
                endDate  = "";
            }
            if (startDate  != null && endDate  != null)
            {
                sb.AppendFormat("visitTime between " + "\'" + startDate + " 0:0:0" + "\'" + " AND " + "\'" + endDate + " 23:59:59" + "\'");
            }
            return sb.ToString();
        }
    }
}