using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoosleB2C.Web
{
    public partial class Exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoosleB2C.MyTool.MyCookie.delCookie("uName");
            Response.Redirect("Login.aspx");
        }
    }
}