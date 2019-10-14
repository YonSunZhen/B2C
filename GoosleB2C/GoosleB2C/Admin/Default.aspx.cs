using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoosleB2C.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                if (string.IsNullOrEmpty(GoosleB2C.MyTool.MyCookie.getCookie("uName")))
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["adUser"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["adUser"].ToString() != GoosleB2C.MyTool.MyCookie.getCookie("uID"))
                {
                    Response.Redirect("Login.aspx");
                }
                
                
            }

        }
    }
}