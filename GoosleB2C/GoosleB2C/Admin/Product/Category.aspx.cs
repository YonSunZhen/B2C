using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoosleB2C.BLL;
using GoosleB2C.MyTool;
using GoosleB2C.DBUtility;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace GoosleB2C.Web.Admin.Product
{
    public partial class Category : BasePage
    {
        BLL.Category bll = new BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            if (Request.Form["action"] != "")
                action = Request.Form["action"];


            switch (action)
            {
                case "query"://查询数据
                    QueryData();
                    break;
                case "submit"://更新结构
                    Update();
                    break;
                case "del"://删除
                    Del();
                    break;
                case "edit"://编辑
                    Edit();
                    break;
                case "add"://添加
                    Add();
                    break;
                default:
                    break;
            }
        }

        public class Child
        {
            public string id { get; set; }
            public string text { get; set; }
            public string father { get; set; }
            public string level { get; set; }
            public string path { get; set; }
            public string order { get; set; }
            public string seotitle { get; set; }
            public string seokey { get; set; }
            public string seoremark { get; set; }
        }

        public class Append
        {
            public string text { get; set; }
            public string father { get; set; }
            public string level { get; set; }
            public string path { get; set; }
            public string order { get; set; }
            public string seotitle { get; set; }
            public string seokey { get; set; }
            public string seoremark { get; set; }
        }

        public class Remove
        {
            public string id { get; set; }
        }

        public class RootObject
        {
            public string id { get; set; }
            public string level { get; set; }
            public string father { get; set; }
            public string path { get; set; }
            public string text { get; set; }
            public string order { get; set; }
            public string seotitle { get; set; }
            public string seokey { get; set; }
            public string seoremark { get; set; }
            public List<Child> child { get; set; }
            public List<Remove> remove { get; set; }
            public List<Append> append { get; set; }
        }


        #region 更新结构
        /// <summary>
        /// 更新结构
        /// </summary>
        private void Update()
        {
            string json = Request["json"];
            RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
            string writeMsg = "";          
            foreach (Child c in rb.child)
            {
                Model.Category model = new Model.Category();
                //
                model = bll.GetModels(Convert.ToInt32(Tools.CheckSQLStr(c.id)));
                //
                model.father = c.father != "" ? Convert.ToInt32(Tools.CheckSQLStr(c.father)) : 0;
                //
                model.level = c.level != "" ? Convert.ToInt32(Tools.CheckSQLStr(c.level)) : 0;
                //
                model.path = c.path != "" ? Tools.CheckSQLStr(c.path) : "0";
                //
                model.order = Convert.ToInt32(Tools.CheckSQLStr(c.order));
                //
                model.updateTime = DateTime.Now;
                if (model != null)
                {
                    if (bll.Updates(model))
                    {
                        writeMsg = "更新成功!";
                    }
                    else
                    {
                        writeMsg = "更新失败!";
                        break;
                    }

                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 编辑数据
        /// <summary>
        /// 编辑数据更新
        /// </summary>
        private void Edit()
        {
            string json = Request["json"];
            RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
            string writeMsg = "";
            foreach (Child c in rb.child)
            {
                Model.Category model = new Model.Category();
                //
                model = bll.GetModels(Convert.ToInt32(Tools.CheckSQLStr(c.id)));
                //
                model.categoryName = c.text != "" ? Tools.CheckSQLStr(c.text) : "";                
                //
                model.seoTitle = c.seotitle != "" ? Tools.CheckSQLStr(c.seotitle) : "0";
                //
                model.seoKey = c.seokey != "" ? Tools.CheckSQLStr(c.seokey) : "0";
                //
                model.seoRemark = c.seoremark != "" ? Tools.CheckSQLStr(c.seoremark) : "0";
                //
                model.updateTime = DateTime.Now;
                if (model != null)
                {
                    if (bll.Updates(model))
                    {
                        writeMsg = "更新成功!";
                    }
                    else
                    {
                        writeMsg = "更新失败!";
                        break;
                    }

                }
            }
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        private void Add()
        {
            string json = Request["json"];
            RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
            string writeMsg = "";
            //增加数据
            foreach (Append a in rb.append)
            {
                Model.Category model = new Model.Category();
                //
                model.categoryName = a.text != "" ? Tools.CheckSQLStr(a.text) : "";
                //
                model.father = a.father != "" ? Convert.ToInt32(Tools.CheckSQLStr(a.father)) : 0;
                //
                model.level = a.level != "" ? Convert.ToInt32(Tools.CheckSQLStr(a.level)) : 0;
                //
                model.path = a.path != "" ? Tools.CheckSQLStr(a.path) : "0";
                //
                model.order = Convert.ToInt32(a.order);
                //
                model.seoTitle = a.seotitle != "" ? Tools.CheckSQLStr(a.seotitle) : "0";
                //
                model.seoKey = a.seokey != "" ? Tools.CheckSQLStr(a.seokey) : "0";
                //
                model.seoRemark = a.seoremark != "" ? Tools.CheckSQLStr(a.seoremark) : "0";
                //
                model.updateTime = DateTime.Now;
                if (model != null)
                {
                    if (bll.Adds(model) > 0)
                    {
                        writeMsg = "增加成功!";
                    }
                    else
                    {
                        writeMsg = "增加失败!";
                        break;
                    }

                }
            }
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        private void Del()
        {
            string json = Request["json"];
            RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
            string writeMsg = "";
            //增加数据
            foreach (Remove r in rb.remove)
            {
                if (r.id != string.Empty && r.id != "0")
                {
                    int delNum = DataHandler.DelData("Category", r.id);
                    if (delNum > 0)
                    {
                        writeMsg = string.Format("删除成功", delNum.ToString());
                    }
                    else
                    {
                        writeMsg = "删除失败！";
                        break;
                    }

                }
            }

            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 查询数据
        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData()
        {
            DataSet str = bll.GetTree();
            DataSet str2 = bll.GetID();
            int count = bll.GetTree().Tables[0].Rows.Count;
            string strJSON = JsonHelper.CreateJsonParameters(str.Tables[0], true, count);
            string strJSON2 = JsonHelper.CreateJsonParameters(str2.Tables[0], true, count);
            string strID = strJSON2.Substring(29,2);
            string strInsert = ",\"MaxID\":" + strID;
            string finalJSON = strJSON.Insert(strJSON.LastIndexOf(","), strInsert);
            Response.Write(finalJSON);
            Response.End();

        }//_5_1_a_s_p_x
        #endregion
    }
}