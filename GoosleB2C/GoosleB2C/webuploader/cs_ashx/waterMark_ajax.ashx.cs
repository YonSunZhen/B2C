using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace GoosleB2C.Web.webuploader.cs_ashx
{
    /// <summary>
    /// waterMark_ajax 的摘要说明
    /// </summary>
    public class waterMark_ajax : IHttpHandler
    {
        string result = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string type = context.Request.QueryString["action"];
            switch (type)
            {
                case "UpLoadFile":
                    UpLoadImg(context);
                    break;
                case "UpLoadFile_ck":
                    UpLoadFile_ck(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(result);
            context.Response.End();
        }

        private void UpLoadImg(HttpContext context)
        {
            string isthumb = context.Request.Form["thumbnail"];
            bool thumb = isthumb == "true" ? true : false;
            HttpPostedFile postedFile = context.Request.Files[0];
            var path = "/UploadImg/";  //上传保存的路径
            int size = 5;   //文件大小限制,单位mb 
            ImageHelper up = new ImageHelper();
            var upImage = up.UploadImage(postedFile, path, size, thumb);
            result = JsonConvert.SerializeObject(upImage);
        }
        private void UpLoadFile_ck(HttpContext context)
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            var path = "/UploadImg/";  //上传保存的路径
            int size = 5;   //文件大小限制,单位mb 
            ImageHelper up = new ImageHelper();
            var upImage = up.UploadImage(postedFile, path, size);
            result = JsonConvert.SerializeObject(upImage);
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