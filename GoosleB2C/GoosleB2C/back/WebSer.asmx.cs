using GoosleB2C.DBUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace GoosleB2C.Web.back
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
    public class WebSer : System.Web.Services.WebService
    {
        BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
        BLL.Article ArticleBll = new BLL.Article();
        BLL.Product ProductBll = new BLL.Product();
        BLL.Category CategoryBll = new BLL.Category();
        BLL.Links LinkBll = new BLL.Links();
        BLL.CompanyContact CompanyContactBll = new BLL.CompanyContact();
        BLL.SuccessCase SuccessCaseBll = new BLL.SuccessCase();
        BLL.Brand BrandBll = new BLL.Brand();
        BLL.WebInfo WebInfoBll = new BLL.WebInfo();
        BLL.ArticleType ArticleTypeBll = new BLL.ArticleType();
        BLL.VisitRecord VisitRecordBll = new BLL.VisitRecord();

        public class Root
        {
            public string id { get; set; }
            public string name { get; set; }
            public string wx { get; set; }
            public string phone { get; set; }
            public string ip { get; set; }
            public string msg { get; set; }
            public int sex { get; set; }
            public int isShow { get; set; }
            public int isRead { get; set; }
            public int isAnswer { get; set; }
            public string vid { get; set; }
        }

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

        /// <summary>
        /// 获得企业简介详情
        /// </summary>
        [WebMethod]
        public void GetDetails()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = CompanyInfoBll.GetDetails();
            int count = CompanyInfoBll.GetDetails().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 获得文章列表详情
        /// </summary>
        [WebMethod]
        public void GetTitle()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            //BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
            //DataSet str1 = ArticleBll.GetTitle();
            DataSet str1 = ArticleBll.GetList(0, " state=1", "createTime DESC");
            int count = ArticleBll.GetList(0, " state=1", "createTime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 获得产品展示详情
        /// </summary>
        [WebMethod]
        public void GetProducts()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
    
            DataSet str1 = ProductBll.GetList(0, " state=1", "createTtime DESC");
            int count = ProductBll.GetList(0, " state=1", "createTtime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 根据产品id获得某一个产品
        /// </summary>
        [WebMethod]
        public void GetOneProduct(string id)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = ProductBll.GetList("pId=\'" + id + "\'");
            int count = ProductBll.GetList("pId=\'" + id + "\'").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        //[WebMethod]
        //public void GetOneProduct(string id)
        //{
        //    string id1 =  id;
        //    DataSet str = ProductBll.GetList("pId=\'" + id + "\'");
        //    int count = ProductBll.GetList("pId=\'" + id + "\'").Tables[0].Rows.Count;//获取总数 
        //    string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

        //    HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
        //    string jsonCallBackFunName = string.Empty;
        //    jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
        //    HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        //}

        /// <summary>
        /// 获得产品分类树
        /// </summary>
        [WebMethod]
        public void GetCategory()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = CategoryBll.GetList_();
            int count = CategoryBll.GetList_().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据id获得公司信息
        /// </summary>
        [WebMethod]
        public void GetCompanyInfo(string id)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = CompanyInfoBll.GetList("id=\'" + id + "\'");
            int count = CompanyInfoBll.GetList("id=\'" + id + "\'").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得友情链接
        /// </summary>
        [WebMethod]
        public void GetLinks()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = LinkBll.GetList( 0 , " state=1", "createDate DESC");
            int count = LinkBll.GetList(0, " state=1", "createDate DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得公司详细联系方式和地址
        /// </summary>
        [WebMethod]
        public void GetCompanyContact()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = CompanyContactBll.GetAllList();
            int count = CompanyContactBll.GetAllList().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据文章id获得某一个产品
        /// </summary>
        [WebMethod]
        public void GetArticleDetail(string id)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = ArticleBll.GetList("Id=\'" + id + "\'");
            int count = ArticleBll.GetList("Id=\'" + id + "\'").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 根据分页获取文章列表
        /// </summary>
        [WebMethod]
        public void GetArticleByPage(int start, int end)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = ArticleBll.GetListByPage("", "createTime desc", start, end);
            int count = ArticleBll.GetListByPage("", "createTime desc", start, end).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得成功案例
        /// </summary>
        [WebMethod]
        public void GetSuccessCases()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = SuccessCaseBll.GetList(0, " state=1", "createTime DESC");
            int count = SuccessCaseBll.GetList(0, " state=1", "createTime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得成功案例通过id
        /// </summary>
        [WebMethod]
        public void GetSuccessCaseById(string id)
        {
            id = MyTool.Tools.CheckSQLStr(id);
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = SuccessCaseBll.GetList("Id=\'" + id + "\'");
            int count = SuccessCaseBll.GetList("Id=\'" + id + "\'").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据分页获取成功案例
        /// </summary>
        [WebMethod]
        public void GetSuccessByPage(int start, int end)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = SuccessCaseBll.GetListByPage("", "createTime desc", start, end);
            int count = SuccessCaseBll.GetListByPage("", "createTime desc", start, end).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据分页获得产品列表
        /// </summary>
        [WebMethod]
        public void GetProductsByPage(int start, int end)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            DataSet str1 = ProductBll.GetListByPage("", "createTtime DESC" ,start, end);
            int count = ProductBll.GetListByPage("", "createTtime DESC", start, end).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据产品类型获得产品列表
        /// </summary>
        [WebMethod]
        public void GetProductsByType(int id)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            DataSet str1 = ProductBll.GetList(0, " proCategory=  "+id , "createTtime DESC");
            int count = ProductBll.GetList(0, " proCategory=  " + id, "createTtime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据分页获得产品列表
        /// </summary>
        [WebMethod]
        public void GetProductsByPage1(int id,int start,int end)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            DataSet str1 = ProductBll.GetListByPage(" proCategory=  " + id, "createTtime DESC", start, end);
            int count = ProductBll.GetListByPage(" proCategory=  " + id, "createTtime DESC", start, end).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据文章类型获得文章列表详情
        /// </summary>
        [WebMethod]
        public void GetTitleByType(int id)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            //BLL.CompanyInfo CompanyInfoBll = new BLL.CompanyInfo();
            //DataSet str1 = ArticleBll.GetTitle();
            DataSet str1 = ArticleBll.GetList(0, " state=1 AND type="+id, "createTime DESC");
            int count = ArticleBll.GetList(0, " state=1 AND type=" + id, "createTime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据文章类型分页获取文章列表
        /// </summary>
        [WebMethod]
        public void GetArticleByPageAndType(int id, int start, int end)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = ArticleBll.GetListByPage("type="+id, "createTime desc", start, end);
            int count = ArticleBll.GetListByPage("type="+id, "createTime desc", start, end).Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得首页轮播图
        /// </summary>
        [WebMethod]
        public void GetBrand()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = BrandBll.GetAllList();
            int count = BrandBll.GetAllList().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得网站首页的头部和教部
        /// </summary>
        [WebMethod]
        public void GetHeaderFooter()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = WebInfoBll.GetAllList();
            int count = WebInfoBll.GetAllList().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得文章类型
        /// </summary>
        [WebMethod]
        public void GetArticleType()
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            DataSet str1 = ArticleTypeBll.GetAllList();
            int count = ArticleTypeBll.GetAllList().Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 更新文章阅读量
        /// </summary>
        [WebMethod]
        public void UpdateArticleReadCount(string id, int readCount)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            id = MyTool.Tools.CheckSQLStr(id);
            Model.Article model = new Model.Article();
            model = ArticleBll.GetModel(id);
            model.readCount = readCount;
            if (ArticleBll.Update(model))
            {
                HttpContext.Current.Response.Write("添加成功");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("添加失败");
                HttpContext.Current.Response.End();
            }
            
        }

        /// <summary>
        /// 更新成功案例阅读量
        /// </summary>
        [WebMethod]
        public void UpdateSuccessReadCount(string id, int readCount)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            id = MyTool.Tools.CheckSQLStr(id);
            Model.SuccessCase model = new Model.SuccessCase();
            model = SuccessCaseBll.GetModel(id);
            model.readCount = readCount;
            if (SuccessCaseBll.Update(model))
            {
                HttpContext.Current.Response.Write("添加成功");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("添加失败");
                HttpContext.Current.Response.End();
            }

        }

        /// <summary>
        /// 增加访问记录
        /// </summary>
        [WebMethod]
        public void AddVisitRecord(string url)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            //ip = MyTool.Tools.CheckSQLStr(ip);
            url = MyTool.Tools.CheckSQLStr(url);

            Model.VisitRecord model = new Model.VisitRecord();
            string newid = Guid.NewGuid().ToString();
            model.id = newid;
            model.ip = MyTool.Tools.GetIp();
            model.url = url;
            model.visitTime = DateTime.Now;
   
            if (VisitRecordBll.Add(model))
            {
                HttpContext.Current.Response.Write("添加成功");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("添加失败");
                HttpContext.Current.Response.End();
            }

        }

        /// <summary>
        /// 根据产品名搜索产品
        /// </summary>
        [WebMethod]
        public void SearchProduct(string name)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            name = MyTool.Tools.CheckSQLStr(name);
            DataSet str1 = ProductBll.GetList(0, " title LIKE  " + "\'" + "%" +name+"%" + "\'", "createTtime DESC");
            int count = ProductBll.GetList(0, " title LIKE   " + "\'" + "%" + name + "%" + "\'", "createTtime DESC").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str1.Tables[0], true, count);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(strJSON));
            HttpContext.Current.Response.End();

        }




    }
}
