using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using GoosleB2C.MyTool;
using GoosleB2C.DBUtility;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoosleB2C.Web.back
{
    /// <summary> 
    /// BackSer 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class BackSer : System.Web.Services.WebService
    {
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

        public class Root_visit
        {
            public string id { get; set; }
            public string url { get; set; }
            public string ip { get; set; }
            public string vid { get; set; }
            public string visittime { get; set; }
        }

        [WebMethod]
        public void getBrand()
        {
            BLL.Brand bll = new BLL.Brand();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getIndexContent()
        {
            BLL.IndexContent bll = new BLL.IndexContent();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }
        [WebMethod]
        public void getIndexImg()
        {
            BLL.IndexImg bll = new BLL.IndexImg();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getProduction()
        {
            BLL.Product bll = new BLL.Product();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getCategory()
        {
            BLL.Category bll = new BLL.Category();
            DataSet str = bll.GetTree();
            int count = bll.GetTree().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getCompanyInfo()
        {
            BLL.CompanyInfo bll = new BLL.CompanyInfo();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getWebInfo()
        {
            BLL.WebInfo bll = new BLL.WebInfo();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getSuccessCase()
        {
            BLL.SuccessCase bll = new BLL.SuccessCase();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getArticleType()
        {
            BLL.ArticleType bll = new BLL.ArticleType();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getArticle()
        {
            BLL.Article bll = new BLL.Article();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void getMessage()
        {
            BLL.Message  bll = new BLL.Message ();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void addMessage(string obj)
        {
            Root rb = JsonConvert.DeserializeObject<Root>(obj);
            string writeMsg = "";
            string name = rb.name;
            string wx = rb.wx;
            string phone = rb.phone;
            string content = rb.msg;
            string ip = rb.ip;
            int sex = rb.sex;
            BLL.Message bll = new BLL.Message();
            Model.Message model = new Model.Message();
            model.id = System.Guid.NewGuid().ToString();
            //
            model.name = name;
            //
            model.sex = sex;
            //
            model.weixin = wx;
            //
            model.phone = phone;
            //
            model.content = content;
            //
            model.ip = ip;
            //
            model.isRead = 0;
            //
            model.isShow = 1;
            //
            model.isAnswer = 0;
            //     
            model.createTime = DateTime.Now;
            if (model != null)
            {
                if (bll.Add(model) == true)
                {
                    writeMsg = "增加成功!";
                }
                else
                {
                    writeMsg = "增加失败!";
                }
            }
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(\"" + writeMsg + "\")");
        }

        [WebMethod]
        public void getVisitRecord()
        {
            BLL.VisitRecord bll = new BLL.VisitRecord();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(" + strJSON + ")");
        }

        [WebMethod]
        public void updataVisitRecord(string obj)
        {   
            Root_visit rb = JsonConvert.DeserializeObject<Root_visit>(obj);
            string writeMsg = "";
            string id = rb.id;
            string url = rb.url;
            string visittime = rb.visittime;
            BLL.VisitRecord bll = new BLL.VisitRecord();
            Model.VisitRecord model = new Model.VisitRecord();
            model = bll.GetModel(id);
            model.url = url;
            model.visitTime = DateTime.Now;
            if (model != null)
            {
                if (bll.Update(model) == true)
                {
                    writeMsg = "更新成功!";
                }
                else
                {
                    writeMsg = "更新失败!";
                }
            }
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(\"" + writeMsg + "\")");
        }

        [WebMethod]
        public void addVisitRecord(string obj)
        {
            Root_visit rb = JsonConvert.DeserializeObject<Root_visit>(obj);
            string writeMsg = "";
            string ip = rb.ip;
            string url = rb.url;
            string visittime = rb.visittime;
            BLL.VisitRecord bll = new BLL.VisitRecord();
            Model.VisitRecord model = new Model.VisitRecord();
            model.id = System.Guid.NewGuid().ToString();
            //
            model.ip = ip;
            //
            model.url = url;
            //
            model.visitTime = DateTime.Now;
            if (model != null)
            {
                if (bll.Add(model) == true)
                {
                    writeMsg = "增加成功!";
                }
                else
                {
                    writeMsg = "增加失败!";
                }
            }
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "(\"" + writeMsg + "\")");
        }

        [WebMethod]
        public void getDBTableInfos(string EnterpriseCode)
        {
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "({ \"Result\": \"" + EnterpriseCode + "\" })");
        }
        //获取主页数据
        [WebMethod]
        public void getIndexData()
        {
            string jsonText = "{\"zone\":\"海淀\",\"zone_en\":\"haidian\"}";
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
            string zone = jo["zone"].ToString();
            string zone_en = jo["zone_en"].ToString();
        }
        //获取微信成功案例
        [WebMethod]
        public void getWxSucCase()
        {
            BLL.SuccessCase bll = new BLL.SuccessCase();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
            

        }

        [WebMethod]
        public void getWXCompanyInfo()
        {
            BLL.CompanyInfo bll = new BLL.CompanyInfo();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }

        [WebMethod]
        public void getWxIndexProduce(int num)
        {
            BLL.Product bll = new BLL.Product();
            DataSet str = bll.GetList(num, "", "orders");
            int count = bll.GetList(num, "", "orders").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }

        [WebMethod]
        public void WxMsgPost(string massage,string phone,string name,string sex, string openid,string userInfo)
        {
            Model.Users user = new Model.Users();
            Model.Message msg = new Model.Message();
            BLL.Users bll = new BLL.Users();
            BLL.Message mbll = new BLL.Message();
            DateTime now = DateTime.Now;
            JObject userinfo = (JObject)JsonConvert.DeserializeObject(userInfo);
            string nickname = userinfo["nickName"].ToString();
            string avatarUrl = userinfo["avatarUrl"].ToString();
            //判断是否为新用户
            if (!bll.WxExists(openid)){
                //是新用户，新建用户记录
               string id = getUniqueId();
                user.uId = id;
                user.wId = openid;
                user.phone = phone;
                user.wImg = avatarUrl;
                user.wName = nickname;
                user.loginTime = now;
                user.state = 1;
                user.realName = name;
                user.sex = sex.Equals("male")? 1:0;
                bll.Add(user);
            }
            //插入用户留言
            if (openid != null)
            {
                msg.content = massage;
                msg.id = getUniqueId();
                msg.isAnswer = 0;
                msg.isShow = 1;
                msg.phone = phone;
                msg.weixin = nickname;
                msg.vId = openid;
                msg.sex = sex.Equals("male")? 1:0;
                msg.name = name;
                msg.createTime = now;
                msg.isRead = 0;
                msg.to = "0";
                System.Console.WriteLine(mbll.Add(msg));

            }
            
            


            //System.Diagnostics.Debug.WriteLine(massage+phone+name+sex+ openid+ userInfo);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write("success");
        }

        [WebMethod]
        public void getUserStatus(string code)
        {

            try
            {
                string Wxsecret = "3190bc3b89144d8d66ff8463d07866d9";
                string url = "https://api.weixin.qq.com/sns/jscode2session?appid=wx464e8044db2dba36&secret="+Wxsecret+"&js_code=" + code+"&grant_type = authorization_code";; 
                Encoding encoding = Encoding.UTF8;
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream ,encoding))
                {
                    //reader.ReadToEnd();
                    string res = reader.ReadToEnd();
                    System.Console.WriteLine(res);
                    HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
                    HttpContext.Current.Response.Write(res);

                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            //HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            //HttpContext.Current.Response.Write(reader.ReadToEnd());
        }
        //获取用户留言
        [WebMethod]
        public void getWxUserMsg(string openid)
        {
            BLL.Message  Mbll = new BLL.Message();
            string wherestr = "vId = '"+openid+"'"+ "or [to] = '" + openid+"' order by createTime";
            DataSet str = Mbll.GetList(wherestr);
            int count = Mbll.GetList(wherestr).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);

        }
        [WebMethod]
        public void getWxCategory()
        {
            BLL.Category bll = new BLL.Category();
            DataSet str = bll.GetTree();
            int count = bll.GetTree().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }

        [WebMethod]
        public void getWxProduction(string id)
        {
            BLL.Product bll = new BLL.Product();
            string sql = "proCategory = '"+id+"'";
            DataSet str = bll.GetList(sql);
            int count = bll.GetList(sql).Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);

            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void getWxCompanyContact()
        {
            BLL.CompanyContact bll = new BLL.CompanyContact();
            DataSet str = bll.GetList("1=1");
            int count = bll.GetList("1=1").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);

        }
        [WebMethod]
        public void getIndexCase(int num)
        {
                BLL.SuccessCase bll = new BLL.SuccessCase();
                DataSet str = bll.GetList(num, "", "orders");
                int count = bll.GetList(num, "", "orders").Tables[0].Rows.Count;
                string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
                HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
                HttpContext.Current.Response.Write(strJSON);
           

        }
        //微信获取公司资讯
        [WebMethod]
        public void getWxArticle()
        {
            BLL.Article bll = new BLL.Article();
            DataSet str = bll.GetList("");
            int count = bll.GetList("").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        //微信获取主页公司资讯
        //[WebMethod]
        //public void getWxIndexArticle()
        //{
        //    BLL.Article bll = new BLL.Article();
        //    DataSet str = bll.GetList(2, "", "orders");
        //    int count = bll.GetList(2, "", "orders").Tables[0].Rows.Count;
        //    string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
        //    HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
        //    HttpContext.Current.Response.Write(strJSON);
        //}
        //微信获取公司资讯类型
        [WebMethod]
        public void getWxArtcleType()
        {
            BLL.ArticleType bll = new BLL.ArticleType();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        //微信获取公司Brand
        [WebMethod]
        public void getWxIndexBrand()
        {
            BLL.Brand bll = new BLL.Brand();
            DataSet str = bll.GetAllList();
            int count = bll.GetAllList().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }

        [WebMethod]
        public void getWxIndexArticle(int num)
        {
            BLL.Article bll = new BLL.Article();
            DataSet str = bll.GetList(num, "", "orders");
            int count = bll.GetList(num, "", "orders").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void getWxProductByGuid(string guid)
        {
            BLL.Product bll = new BLL.Product();
            DataSet str = bll.GetList("pid='"+guid+"'");
            int count = bll.GetList("pid='" + guid + "'").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void getWxCaseByGuid(string guid)
        {
            BLL.SuccessCase bll = new BLL.SuccessCase();
            DataSet str = bll.GetList("id='" + guid + "'");
            int count = bll.GetList("id='" + guid + "'").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void getWxPassageByGuid(string guid)
        {
            BLL.Article bll = new BLL.Article();
            DataSet str = bll.GetList("id='" + guid + "'");
            int count = bll.GetList("id='" + guid + "'").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void WxSearchPro(string name)
        {
            BLL.Product bll = new BLL.Product();
            DataSet str = bll.GetList("title like '%" + name + "%'");
            int count = bll.GetList("title like '%" + name + "%'").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        [WebMethod]
        public void WxIndexContent()
        {
            BLL.IndexContent bll = new BLL.IndexContent();
            DataSet str = bll.GetList("");
            int count = bll.GetList("").Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.Write(strJSON);
        }
        //获取32位全球唯一标识
        public string getUniqueId()
        {
            return Guid.NewGuid().ToString();
        }


    }


}
