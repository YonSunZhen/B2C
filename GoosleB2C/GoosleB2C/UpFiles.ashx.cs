using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace GoosleB2C.Web
{
    /// <summary>
    /// UpFiles 的摘要说明
    /// </summary>
    public class UpFiles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;              // From中获取文件对象
            if (files.Count > 0)
            {
                string path = "";                                                            //路径字符串
                Random rnd = new Random();
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];                                        //得到文件对象
                    if (file.ContentLength > 0)
                    {
                        string fileName = file.FileName;
                        string extension = Path.GetExtension(fileName);
                        path = "UpLoadImg/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "/";
                        string serverPath= System.Web.HttpContext.Current.Server.MapPath(path);
                        if (!Directory.Exists(serverPath))
                        {
                            Directory.CreateDirectory(serverPath);
                        }
                        string newName = Guid.NewGuid().ToString();  
                                                  //文件名称
                        path = path +newName + extension;
                        file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));        //保存文件。
                    }
                }
                context.Response.Write(path);            //返回文件存储后的路径，用于回显。
            }
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
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