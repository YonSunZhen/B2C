using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web
{
    public partial class Left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!string.IsNullOrEmpty(GoosleB2C.MyTool.MyCookie.getCookie("uID")))
                //{
                    getFuntion();
                //}

            }
        }



        private void getFuntion()
        {
            /*判断非法登录
            if (string.IsNullOrEmpty(GoosleB2C.MyTool.MyCookie.getCookie("uID")))
            {
                return;
            }
            */

            StringBuilder strb = new StringBuilder();
            strb.Append("<ul id=\"navigation\">");
            GoosleB2C.BLL.Functions funBll = new BLL.Functions();
            DataTable dt = funBll.GetList(" funType=1 ").Tables[0];
            DataRow[] drs = dt.Select("funLevel=1", "funOrder asc");
            foreach (DataRow dr in drs)
            {
                if (MyCookie.getCookie("uType") == "99" || getAllow(dr["id"].ToString(), MyCookie.getCookie("uID")) == true)
                {
                    strb.Append(" <li> <a class=\"head\">");
                    strb.Append(dr["functionName"].ToString());
                    strb.Append(@" </a>
                  <ul>");

                    DataRow[] drs2 = dt.Select("father='" + dr["id"].ToString() + "'", "funOrder asc");
                    foreach (DataRow dr2 in drs2)
                    {
                        if (MyCookie.getCookie("uType") == "99" || getAllow(dr2["id"].ToString(), MyCookie.getCookie("uID")) == true)
                        {
                            strb.Append("<li><a href=\"");
                            strb.Append(dr2["url"].ToString());
                            strb.Append("\" target=\"rightFrame\">");
                            strb.Append(dr2["functionName"].ToString());
                            strb.Append("</a></li>");
                        }
                    }

                    strb.Append(@" </ul>
                </li>");
                }

            }


            //            SysFunction_BLL funBll = new SysFunction_BLL();
            //            DataTable dt = funBll.GetList(" state=1 ").Tables[0];
            //            DataRow[] drs = dt.Select("levelNo=1", "orderNo asc");
            //            foreach (DataRow dr in drs)
            //            {
            //                if (MyCookie.getCookie("uType") == "99" || getAllow(dr["fId"].ToString(), MyCookie.getCookie("uID")) == true)
            //                {
            //                    strb.Append(" <li> <a class=\"head\">");
            //                    strb.Append(dr["cnName"].ToString());
            //                    strb.Append(@" </a>
            //      <ul>");

            //                    DataRow[] drs2 = dt.Select("parents='" + dr["fId"].ToString() + "'", "orderNo asc");
            //                    foreach (DataRow dr2 in drs2)
            //                    {
            //                        if (MyCookie.getCookie("uType") == "88" || getAllow(dr2["fId"].ToString(), MyCookie.getCookie("uID")) == true)
            //                        {
            //                            strb.Append("<li><a href=\"");
            //                            strb.Append(dr2["path"].ToString());
            //                            strb.Append("\" target=\"rightFrame\">");
            //                            strb.Append(dr2["cnName"].ToString());
            //                            strb.Append("</a></li>");
            //                        }
            //                    }

            //                    strb.Append(@" </ul>
            //    </li>");
            //                }

            //            }


            //从菜单表把数据读出来，这里生成菜单

            strb.Append(" <li> <a class=\"head\">一级菜单</a>");
            strb.Append("<ul> <li><a  href=\"users/ChangeUserType.aspx\"  target=\"rightFrame\" >二级菜单1</a></li>");
            strb.Append("<li><a  href=\"users/AddTimesByWeixin.aspx?id=3\"  target=\"rightFrame\" >二级菜单2</a></li>");
            strb.Append("<li><a  href=\"users/AddTimesByWeixin.aspx?id=2\"  target=\"rightFrame\" >二级菜单3</a></li>");
            strb.Append("<li><a  href=\"users/AddTimesByWeixin.aspx?id=1\"  target=\"rightFrame\">二级菜单4</a></li> ");         
            strb.Append("<li><a  href=\"users/DeleteTimes.aspx\"  target=\"rightFrame\">二级菜单5</a></li> ");

            strb.Append("<li><a  href=\"users/AddTimesByWeixin.aspx?id=1\"  target=\"rightFrame\">二级菜单6</a></li> </ul></li>");

            strb.Append("<li> <a class=\"head\">一级菜单2</a>");
            strb.Append("<ul> <li><a>版本所有：谷嫂网络信息技术有限公司</a></li>");
            strb.Append(" <li><a>技术支持：谷嫂信息技术有限公司</a></li> </ul></li>");




            strb.Append("</ul>");
            this.lt.Text = strb.ToString();
        }


        private bool getAllow(string fid, string uid)
        {
            return true;
            //UserRole_BLL roleBll = new UserRole_BLL();
            //return roleBll.CheckPower(uid, fid, "2");
        }
    }
}