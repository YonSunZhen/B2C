using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using System.Data;
using System.Text;
using GoosleB2C.MyTool;
using System.IO;

namespace GoosleB2C.Web.Admin.CompanyInfo
{
    public partial class Introduces : System.Web.UI.Page
    {
        BLL.CompanyInfo companginfo_bll = new BLL.CompanyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Request.Form["action"];
            switch (a)
            {
                case "edit":
                    Edit();
                    break;
                case "query":
                    QueryData();
                    break;
                    //case "mainImg":
                    //    Add_MainImg();
                    //    break;
            }
        }
        private void QueryData()
        {
            string id = Request.Form["id"];
            string sql = "id = " + id;
            DataSet companyInfo = companginfo_bll.GetList(sql);
            string strJSON = JsonHelper.CreateJsonOne(companyInfo.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        private void Edit()
        {
            string id = Request.Form["id"];
            Model.CompanyInfo model = GetData(id);
            string writeMsg = "提交失败";
            if (model != null)
            {
                if (companginfo_bll.Update_Other(model))
                {
                    writeMsg = "提交成功";
                }
                else
                {
                    writeMsg = "提交失败";
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        private Model.CompanyInfo GetData(string id)
        {
            int int_id = int.Parse(id);
            Model.CompanyInfo model = new Model.CompanyInfo();
            model.details = Request.Form["ipt_introduce"];
            model.id = int_id;
            model.name = "公司简介";
            model.name2 = Request.Form["ipt_name2"];
            model.remarks = Request.Form["ipt_remarks"];
            return model;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string pd = Request.Form["pd"];
            switch (pd)
            {
                case "2":
                    up_Imgs();
                    break;
                case "1":
                    up_mainImg();
                    break;
            }
        }
        private void up_Imgs()
        {
            Model.CompanyInfo model = new Model.CompanyInfo();
            HttpFileCollection files = Request.Files;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            int a = files.Count;
            string imgs = "";
            string path = Server.MapPath("../../UpLoadImg/");
            if (imgFile2.HasFiles)
            {
                if (!Directory.Exists(Server.MapPath("../../UpLoadImg/" + year)))
                {
                    Directory.CreateDirectory(Server.MapPath("../../UpLoadImg/" + year));
                    if (!Directory.Exists(Server.MapPath("../../UpLoadImg/" + year + "/" + month)))
                    {
                        Directory.CreateDirectory(Server.MapPath("../../UpLoadImg/" + year + "/" + month));
                    }
                }
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string filename = Guid.NewGuid().ToString() + "_详图_" + file.FileName;
                    string savepath = path + year + "/" + month + "/" + filename;
                    file.SaveAs(savepath);
                    imgs += "/UpLoadImg/" + year + "/" + month + "/" + filename + ";";
                }
            }
            model.id = 1;
            model.imgs = imgs;
            companginfo_bll.Update_imgs(model);
        }
        private void up_mainImg()
        {
            Model.CompanyInfo model = new Model.CompanyInfo();
            HttpFileCollection files = Request.Files;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            int a = files.Count;
            string path = Server.MapPath("../../UpLoadImg/");
            if (imgFile2.HasFiles)
            {
                if (!Directory.Exists(Server.MapPath("../../UpLoadImg/" + year)))
                {
                    Directory.CreateDirectory(Server.MapPath("../../UpLoadImg/" + year));
                    if (!Directory.Exists(Server.MapPath("../../UpLoadImg/" + year + "/" + month)))
                    {
                        Directory.CreateDirectory(Server.MapPath("../../UpLoadImg/" + year + "/" + month));
                    }
                }
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string filename = Guid.NewGuid().ToString() + "_主图_" + file.FileName;
                    string savepath = path + year + "/" + month + "/" + filename;
                    file.SaveAs(savepath);
                    model.id = 1;
                    model.mainImg = "/UpLoadImg/" + year + "/" + month + "/" + filename;
                    companginfo_bll.Update_one(model);
                }
            }
        }
    }
}