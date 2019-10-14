using GoosleB2C.DBUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace GoosleB2C.Web.Admin.Product
{
    /// <summary>
    /// Category1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://localhost:12238/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    //[SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class Category1 : System.Web.Services.WebService
    {
        BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
        BLL.Article ArticleBll = new BLL.Article();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HelloWorld()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            BLL.DeliveryTemplate DeliveryTemplateBll = new BLL.DeliveryTemplate();
            DataSet str1 = DeliveryTemplateBll.GetList("");
            int count = DeliveryTemplateBll.GetList("").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();

            //this.Context.Response.Write(data);
            //return "Hello World";
        }
        //public string method1()
        //{
        //    string str = "{\"msg\":\"这里是主要内容\"}";
        //    if (HttpContext.Current.Request["jsonp"] != null)//这里是执行是否需要返回JSONP字符串的唯一标识
        //    {
        //        HttpRequest Request = HttpContext.Current.Request;
        //        HttpResponse Response = HttpContext.Current.Response;
        //        string callback = Request["jsonp"];

        //        Response.Write(callback + "(" + str + ")");
        //        Response.End();//结束后续的操作，直接返回所需要的字符串
        //    }
        //    return str;

        //[WebMethod]
        //public void GetRemarks()
        //{
        //    HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        //    HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
        //    HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
        //    BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
        //    DataSet str1 = CompanyInfoBll.GetRemarks();
        //    int count = CompanyInfoBll.GetRemarks().Tables[0].Rows.Count;//获取总数                
        //    string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
        //    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
        //    HttpContext.Current.Response.End();
        //}
        [WebMethod]
        public void GetTitle()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            //BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
            //DataSet str1 = ArticleBll.GetTitle();
            DataSet str1 = ArticleBll.GetList(8,"", "createTime DESC");
            int count = ArticleBll.GetList(8, "", "createTime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

    }
}
