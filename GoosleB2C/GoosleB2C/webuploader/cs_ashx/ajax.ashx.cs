using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace GoosleB2C.Web.webuploader.cs_ashx
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {
        string result = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["action"];
            switch (type)
            {
                case "helloworld":
                    HelloWord();
                    break;
                case "UpLoadFile":
                    UploadImage(context);
                    break;
                case "delImg":
                    DelImage(context);
                    break;                
                default:
                    //Uploader(context);
                    break;
            }
            context.Response.Write(result);
            context.Response.End();
            //context.Response.Write("Hello World");
        }
        private void UploadImage(HttpContext context)
        {
            string isthumb = context.Request.Form["thumbnail"];
            string width = context.Request.Form["width"];
            string height = context.Request.Form["height"];
            string waterMarkType = context.Request.Form["waterMarkType"];
            string waterMarkPosition = context.Request.Form["waterMarkPosition"];
            string waterMarkContent = context.Request.Form["waterMarkContent"];
            string waterMarkPicture = context.Request.Form["waterMarkPicture"];
            string waterMarkTransparency = context.Request.Form["waterMarkTransparency"];
            //创建缩略图的方式
            string Logo_brand = context.Request.Form["Logo_brand"];
            bool thumb = isthumb == "true" ? true : false;
            //上传图片           
            HttpPostedFile postedFile = context.Request.Files[0];
            var path = "/UpLoadImg/";  //上传保存的路径
            int size = 5;   //文件大小限制,单位mb 

            ImageHelper up = new ImageHelper();

            //var upImage = up.UploadImage(postedFile, path, size, false);			
            //生成缩略图
            
            var upImage = up.UploadImage(postedFile, path, size, thumb, Logo_brand, int.Parse(waterMarkType), int.Parse(waterMarkPosition), waterMarkContent, waterMarkPicture, int.Parse(waterMarkTransparency), int.Parse(width), int.Parse(height));            
            //生成水印
            //var upImage = up.UploadImage(postedFile, path, size, WatermarkType.Text, "水印文字", WatermarkPosition.Center, false);
            //生成水印+缩略图
            //var upImage = up.UploadImage(postedFile, path, size, WatermarkType.Text, "水印文字", WatermarkPosition.Center, true, 200);

            result = JsonConvert.SerializeObject(upImage);

        }
        private void HelloWord()
        {
            result = "hello world";
        }
        private void DelImage(HttpContext context)
        {
            string oriSrc = context.Request.QueryString["oriSrc"];
            string thumbSrc = context.Request.QueryString["thumbSrc"];
            try
            {
                string ori = context.Server.MapPath(oriSrc);
                string thumb = context.Server.MapPath(thumbSrc);
                File.Delete(ori);
                File.Delete(thumb);
                result = "{rl" + ":\"" + "删除成功" + "\"}";
            }
            catch (Exception ex)
            {
                throw ex;
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