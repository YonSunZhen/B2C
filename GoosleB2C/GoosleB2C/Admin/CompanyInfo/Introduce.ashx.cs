using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    /// <summary>
    /// Introduce1 的摘要说明
    /// </summary>
    public class Introduce1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            var file = context.Request.Files;
            for(int i = 0; i < file.Count; i++)
            {
                var h = file[i];
                var ext = Path.GetExtension(h.FileName);
                if (!(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif"))
                {
                    context.Response.Write("shit,你传的不是图片");
                    context.Response.End();
                }
                else
                {
                    string path = "../../UpLoadImg/" + Guid.NewGuid().ToString() + "_" + h.FileName;
                    h.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
                    context.Response.Redirect("Introduce.aspx");
                }
            }
            

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}