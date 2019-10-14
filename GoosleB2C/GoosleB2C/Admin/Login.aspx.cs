using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.MyTool;

namespace GoosleB2C.Web
{
     public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           // this.txtUser.Text = MyTool.MyDES.Encode("zhen987", 1);
          
        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (this.txtUser.Text.Trim() == "" || this.txtPwd.Text.Trim() == "")
            {
                Tools.jsAlert(this.Page, "用户名/密码不能为空！");
                
            }
            else if (this.txtChknumber.Text.Trim().ToLower() != MyCookie.getCookie("CheckCode"))
            {
                Tools.jsAlert(this.Page, "验证码出错！");
                
            }
            else
            {
                BLL.Managers managerBll = new BLL.Managers();
                Model.Managers managerModel = new Model.Managers();
                managerModel=managerBll.GetModelByName(Tools.CheckSQLStr(this.txtUser.Text.Trim()));
                if(managerModel==null)
                {
                    Tools.jsAlert(this.Page, "用户不存在或密码错误！");
                }
                else
                {
                    string psw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(MyDES.Decode(managerModel.passWord, 1), "MD5").ToLower();
                    if (psw != this.txtPwd.Text.Trim())
                    {
                        Tools.jsAlert(this.Page, "用户不存在或密码错误！");
                        return;

                    }
                    if (managerModel.state != 1)
                    {
                        Tools.jsAlert(this.Page, "用户已被删除或禁用！");


                    }
                    else
                    {
                        MyCookie.setCookie("uName", managerModel.userName, 0);
                        MyCookie.setCookie("uID", managerModel.id, 0);
                        MyCookie.setCookie("uType", managerModel.userType.ToString(), 0);
                        Session["adUser"] = managerModel.id;

                        //managerModel.loginDate = DateTime.Now;
                        //修改部分
                        managerModel.loginTimes = managerModel.loginTimes + 1;
                        managerModel.lastLoginDate = managerModel.loginDate;
                        managerModel.loginDate = DateTime.Now;
                        //修改结束
                        managerBll.Update(managerModel);
                        Response.Redirect("Default.aspx");
                    }
                }
               
                
            }
            
        }

        protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
