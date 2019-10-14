using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using GoosleB2C.DBUtility;
using System.IO;

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    public partial class hahaha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["picture"] != null)
            {
                Response.Clear();
                Response.ContentType = "application/json";
                String result = "success";
                try
                {
                    File.Delete(Server.MapPath(@"\Images\") + Request["picname"].ToString());
                }
                catch(Exception ee)
                {
                    result = ee.Message;
                }
                Response.Write("{\"result\":\"" + result + "\"}");
                Response.End();
            }
            //string action = string.Empty;
            //if (Request.Form["action"] !=null && Request.Form["src"] !=null)
            //{
            //    action = Request.Form["action"];
            //}
            //else
            //{
            //    action = string.Empty;
            //}
            //switch (action)
            //{
            //    case "delete":
            //        Del();
            //        break;
            //}
        }
        private void Del()
        {
            string guid = Request.Form["guid"];
            string imgName = Request.Form["imgName"];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string file = "../../UpLoadImg/" + year + "/" + month + "/" + "主图_" + guid + "_" + imgName;
            string thumb = "../../UpLoadImg/" + year + "/" + month + "/" + "thumb_" + guid + "_" + imgName;
            if (File.Exists(Server.MapPath(file)))
            {
                FileInfo f = new FileInfo(Server.MapPath(file));
                if(f.Attributes.ToString().IndexOf("ReadyOnly") >= 0)
                {
                    f.Attributes = FileAttributes.Normal;
                }
                File.Delete(Server.MapPath(file));
            }
            if (File.Exists(Server.MapPath(thumb)))
            {
                FileInfo fi = new FileInfo(Server.MapPath(file));
                if (fi.Attributes.ToString().IndexOf("ReadyOnly") >= 0)
                {
                    fi.Attributes = FileAttributes.Normal;
                }
                File.Delete(Server.MapPath(thumb));
            }
        }
    }
}