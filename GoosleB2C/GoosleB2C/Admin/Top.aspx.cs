using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoosleB2C.Web
{
    public partial class Top : System.Web.UI.Page
    {
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
                return GetType(GoosleB2C.MyTool.MyCookie.getCookie("uType"));
            }
        }

        public string UserId
        {
            get
            {

                return GoosleB2C.MyTool.MyCookie.getCookie("uId");
            }
        }

        private string GetType(string uType)
        {
            if (string.IsNullOrEmpty(uType))
            {
                return "";
            }
            int iType = Int32.Parse(uType);
            string strType = "";
            switch (iType)
            {
                case 88:
                    strType = "超级管理员";
                    break;
                case 1:
                    strType = "高级管理员";
                    break;
                default:
                    strType = "普通管理员";
                    break;

            }
            return strType;
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                this.lbUserId.Text = UserName;
                this.lbUserType.Text = UserType;
                this.lbServerTime.Text = DateTime.Now.ToShortDateString() + "    " + DateTime.Now.ToShortTimeString();
            }
        }
    }
}