using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoosleB2C.Web
{
    public partial class UpTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            string FileName = "";
            if (Request.Form["action"] != "")
            {
                action = Request.Form["action"];
            }
            if(Request.Form["FileName"] != "")
            {
                FileName = Request.Form["FileName"];
            }
            else
            {
                return;
            }
                

            switch (action)
            {
                case "topimg"://查询数据
                    checkimg(FileName);
                    break;               
                default:
                    break;
            }

        }


        /// <summary>

        /// 修改照片

        /// </summary>

        /// <param name="FileName">上传控件名name</param>

        private void checkimg(string FileName)
        {
            if (Request.Files[FileName].ContentLength > 0)
            {
                HttpPostedFile f = Request.Files[FileName];//获取控件元素
                string filename = f.FileName;//获取文件名
                string path = "/UpLoadImg/" + Imgname(filename);//上传地址+文件名，imgname是我自己写的文件重新命名的方法
                 f.SaveAs(Server.MapPath(path));//上传文件到服务器
                try
                {
                    Response.Write(path);
                }
                catch (Exception ex)
                { Response.Write(ex); }
            }
            else
            {
                Response.Write("error");
            }

        }
        private string Imgname(string name)
        {
            return Guid.NewGuid().ToString()+"_" + name;
        }

    }
}