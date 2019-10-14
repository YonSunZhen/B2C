using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.DBUtility;
using GoosleB2C.MyTool;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace GoosleB2C.Web.Admin.Sys
{
    public partial class DeliveryTemplate : System.Web.UI.Page
    {
        BLL.DeliveryTemplate DeliveryTemplateBll = new BLL.DeliveryTemplate();
        BLL.DeliveryTemplate_ DeliveryTemplateBll_ = new BLL.DeliveryTemplate_();
        BLL.DeliveryDetail DeliveryDetailBll = new BLL.DeliveryDetail();
        BLL.DeliveryDetail_ DeliveryDetailBll_ = new BLL.DeliveryDetail_();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
                action = Request.Form["action"];
            switch (action)
            {
                case "QueryDeliveryTemplateData":
                    QueryDeliveryTemplateData();
                    break;
                case "QueryOneTemplateData":
                    QueryOneTemplateData();
                    break;
                case "UpdateDeliveryTemplateData":
                    UpdateDeliveryTemplateData();
                    break;
                case "DelDeliveryTemplateData":
                    DelDeliveryTemplateData();
                    break;
                //case "ADD":
                    //QueryFunctionName();
                    //break;
                case "QueryDeliveryDetailData":
                    QueryDeliveryDetailData();
                    break;
                case "UpdateDeliveryDetailData":
                    UpdateDeliveryDetailData();
                    break;
                //case "QueryOneDetailData":
                //    QueryOneDetailData();
                //    break;
                default:
                    break;
            }
        }

        #region 初始化运费模板表
        private void QueryDeliveryTemplateData()
        {
            DataSet str = DeliveryTemplateBll.GetList("");
            int count = DeliveryTemplateBll.GetList("").Tables[0].Rows.Count;//获取总数                
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 取得输入框(模板表)的数据
        private Model.DeliveryTemplate GetDeliveryTemplateData(string id)
        {
            Model.DeliveryTemplate DeliveryTemplateModel = new Model.DeliveryTemplate();
            if (!(id.Equals("") || id.Equals("0")))
            {
                DeliveryTemplateModel = DeliveryTemplateBll_.GetModel(id);
                //修改时执行这里面的值

            }
            else
            {
                string DeliveryTemplateID = Guid.NewGuid().ToString();
                DeliveryTemplateModel.id = DeliveryTemplateID;

                //添加时执行这里面的东西，修改时根据id来的，所以创建id只能是添加时才有
            }

            DeliveryTemplateModel.tempName = Tools.CheckSQLStr(Request.Form["ipt_tempname"]);
            if (DeliveryTemplateBll_.Exists(1))
            {
                DeliveryTemplateModel.isChoose = 0;
            }
            else
            {
                DeliveryTemplateModel.isChoose = Tools.CheckSQLStr(Request.Form["ipt_ischoose"]) != "" ? Convert.ToInt32(Tools.CheckSQLStr(Request.Form["ipt_ischoose"])) : 0;
            }
            return DeliveryTemplateModel;
        }

        #endregion

        #region 添加或修改模板表数据
        private void UpdateDeliveryTemplateData()
        {
            string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            Model.DeliveryTemplate DeliveryTemplateModel = GetDeliveryTemplateData(id);
            Model.DeliveryDetail DeliveryDetailModel = new Model.DeliveryDetail();
            string writeMsg = "操作失败";
            if (DeliveryTemplateModel != null)
            {
                if (id.Equals("") || id.Equals("0"))
                {
                    if (DeliveryTemplateBll.Add(DeliveryTemplateModel))
                    {
                        //批量增加运费明细表的数据，一次增加31条
                        for (int i = 2; i < 33; i++)
                        {
                            string DeliveryDetailID = Guid.NewGuid().ToString();
                            DeliveryDetailModel.id = DeliveryDetailID;
                            DeliveryDetailModel.tempId = DeliveryTemplateModel.id;
                            DeliveryDetailModel.provinceId = i;
                            DeliveryDetailBll.Add(DeliveryDetailModel);
                        }
                        writeMsg = "增加成功!";
                    }
                    else
                    {
                        writeMsg = "增加失败!";
                    }
                }
                else
                {
                    if (DeliveryTemplateBll_.Update(DeliveryTemplateModel))
                    {
                        writeMsg = "更新成功!";
                    }
                    else
                    {
                        writeMsg = "更新失败!";
                    }
                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 删除运费模板数据
        private void DelDeliveryTemplateData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                if (DeliveryDetailBll_.Delete(selectID) && DeliveryTemplateBll_.Delete(selectID))
                {
                    writeMsg = "删除成功！";
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }

            Response.Clear();
            Response.Write(writeMsg);
            Response.End();

        }

        #endregion

        #region 取得一条运费模板数据
        private void QueryOneTemplateData()
        {
            string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
            DataSet ds = DeliveryTemplateBll.GetList(1, "id=\'" + userid + "\'", "ID ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }

        #endregion

        #region 初始化运费明细表
        private void QueryDeliveryDetailData()
        {
            string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
            int count = DeliveryDetailBll_.GetList("tempId=\'" + userid + "\'").Tables[0].Rows.Count;//获取总数
            //DataSet str = DeliveryDetailBll.GetList("tempId='61da4701-6b49-49d7-83ea-c3c7e1b5811d'");
            //int count = DeliveryDetailBll.GetList("tempId='61da4701-6b49-49d7-83ea-c3c7e1b5811d'").Tables[0].Rows.Count;//获取总数
            DataSet str = DeliveryDetailBll_.GetList(31, "tempId=\'" + userid + "\'", "provinceId ASC");
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 取得输入框(明细表)的数据
        private Model.DeliveryDetail GetDeliveryDetailData(string id)
        {
            Model.DeliveryDetail DeliveryDetailModel = new Model.DeliveryDetail();
            if (!(id.Equals("") || id.Equals("0")))
            {
                DeliveryDetailModel = DeliveryDetailBll.GetModel(id);
                //修改时执行这里面的值

            }
            else
            {
                //string DeliveryTemplateID = Guid.NewGuid().ToString();
                //DeliveryDetailModel.id = DeliveryTemplateID;

                //添加时执行这里面的东西，修改时根据id来的，所以创建id只能是添加时才有
            }
            DeliveryDetailModel.firstWeight = Tools.CheckSQLStr(Request.Form["ipt_firstweight"]) != "" ? Convert.ToDecimal(Tools.CheckSQLStr(Request.Form["ipt_firstweight"])) : 0;
            DeliveryDetailModel.addedWeight = Tools.CheckSQLStr(Request.Form["ipt_addedweight"]) != "" ? Convert.ToDecimal(Tools.CheckSQLStr(Request.Form["ipt_addedweight"])) : 0;
            return DeliveryDetailModel;
        }

        #endregion

        #region 修改明细表数据
        public class update

        {

            public string JSON_id { get; set; }
            public string JSON_tempid { get; set; }
            public int JSON_provinceid { get; set; }
            public string JSON_addedweight { get; set; }
            public string JSON_regionname { get; set; }
            public string JSON_firstweight { get; set; }

        }

        public class Update
        {
            public List<update> Detail { get; set; }
        }

        private void UpdateDeliveryDetailData()
        {
            string str = Request["update1"];
            string writeMsg = "";
            Update d = JsonConvert.DeserializeObject<Update>(str);
            //从json反序列化出一个User对象 
            foreach(update u in d.Detail)
            {
                Model.DeliveryDetail DeliveryDetailModel = new Model.DeliveryDetail();
                string id = u.JSON_id;
                DeliveryDetailModel = DeliveryDetailBll.GetModel(id);
                DeliveryDetailModel.firstWeight = Tools.CheckSQLStr(u.JSON_firstweight) != "" ? Convert.ToDecimal(Tools.CheckSQLStr(u.JSON_firstweight)) :0;
                DeliveryDetailModel.addedWeight = Tools.CheckSQLStr(u.JSON_addedweight) != "" ? Convert.ToDecimal(Tools.CheckSQLStr(u.JSON_addedweight)) :0;
                //return DeliveryDetailModel;
                if (DeliveryDetailBll.Update(DeliveryDetailModel))
                {
                    writeMsg = "修改成功!";
                }
                else
                {
                    writeMsg = "修改失败!";
                }

            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();

            //Update u = (Update)js.Deserialize(str, typeof(Update));
            //string id = Request.Form["id"] != "" ? Request.Form["id"] : "";
            //Model.DeliveryDetail DeliveryDetailModel = GetDeliveryDetailData(id);
            //string writeMsg = "操作失败";
            //if (DeliveryDetailModel != null)
            //{

            //    if (DeliveryDetailBll.Update(DeliveryDetailModel))
            //    {
            //        writeMsg = "修改成功!";
            //    }
            //    else
            //    {
            //        writeMsg = "修改失败!";
            //    }


            //}
            //Response.Clear();
            //Response.Write(writeMsg);
            //Response.End();
        }
        #endregion

        //#region 取得一条运费明细表数据
        //private void QueryOneDetailData()
        //{
        //    string userid = Request.Form["id"] != "" ? Request.Form["id"] : "";
        //    DataSet ds = DeliveryDetailBll.GetList(1, "id=\'" + userid + "\'", "ID ASC");
        //    string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
        //    Response.Clear();
        //    Response.Write(strJSON);
        //    Response.End();
        //}

        //#endregion
    }
}