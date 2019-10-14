using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoosleB2C.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public string UserId
        {
            get
            {
                return GoosleB2C.MyTool.MyCookie.getCookie("uID");
               

            }
        }

        public string RealName
        {
            get
            {
                return GoosleB2C.MyTool.MyCookie.getCookie("realName");
            }
        }

        public string UserName
        {
            get
            {
                return GoosleB2C.MyTool.MyCookie.getCookie("uName");
            }
        }

        public string UserType
        {
            get
            {
                return GoosleB2C.MyTool.MyCookie.getCookie("uType");
            }
        }
        protected void CheckUer()
        {
            if (string.IsNullOrEmpty(GoosleB2C.MyTool.MyCookie.getCookie("uName")))
            {
                Response.Redirect("~/NotAllow.aspx");
            }
            else if (Session["adUser"] == null)
            {
                Response.Redirect("~/NotAllow.aspx");
            }
            else if(Session["adUser"].ToString()!=GoosleB2C.MyTool.MyCookie.getCookie("uID"))
            {
                Response.Redirect("~/NotAllow.aspx");
            }
        }
   
    }
}