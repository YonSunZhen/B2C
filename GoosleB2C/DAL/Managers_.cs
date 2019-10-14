using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GoosleB2C.DBUtility;//Please add references
namespace GoosleB2C.DAL
{
    public partial class Managers_
    {
        public Managers_() {}

        public bool Exists(string id,int i)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Managers");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 通过用户名得到一个对象实体
        /// </summary>
        public GoosleB2C.Model.Managers GetModelByName(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userName,passWord,cnName,state,userType,roleId,mobile,creator,cteateDate,lastLoginDate,loginDate,loginTimes,expand1,remark from Managers ");
            strSql.Append(" where userName=@userName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,30)};
            parameters[0].Value = userName;

            GoosleB2C.Model.Managers model = new GoosleB2C.Model.Managers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userName"] != null && ds.Tables[0].Rows[0]["userName"].ToString() != "")
                {
                    model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passWord"] != null && ds.Tables[0].Rows[0]["passWord"].ToString() != "")
                {
                    model.passWord = ds.Tables[0].Rows[0]["passWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cnName"] != null && ds.Tables[0].Rows[0]["cnName"].ToString() != "")
                {
                    model.cnName = ds.Tables[0].Rows[0]["cnName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userType"] != null && ds.Tables[0].Rows[0]["userType"].ToString() != "")
                {
                    model.userType = int.Parse(ds.Tables[0].Rows[0]["userType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["roleId"] != null && ds.Tables[0].Rows[0]["roleId"].ToString() != "")
                {
                    model.roleId = ds.Tables[0].Rows[0]["roleId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mobile"] != null && ds.Tables[0].Rows[0]["mobile"].ToString() != "")
                {
                    model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["creator"] != null && ds.Tables[0].Rows[0]["creator"].ToString() != "")
                {
                    model.creator = ds.Tables[0].Rows[0]["creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cteateDate"] != null && ds.Tables[0].Rows[0]["cteateDate"].ToString() != "")
                {
                    model.cteateDate = DateTime.Parse(ds.Tables[0].Rows[0]["cteateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastLoginDate"] != null && ds.Tables[0].Rows[0]["lastLoginDate"].ToString() != "")
                {
                    model.lastLoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginDate"] != null && ds.Tables[0].Rows[0]["loginDate"].ToString() != "")
                {
                    model.loginDate = DateTime.Parse(ds.Tables[0].Rows[0]["loginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginTimes"] != null && ds.Tables[0].Rows[0]["loginTimes"].ToString() != "")
                {
                    model.loginTimes = int.Parse(ds.Tables[0].Rows[0]["loginTimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["expand1"] != null && ds.Tables[0].Rows[0]["expand1"].ToString() != "")
                {
                    model.expand1 = ds.Tables[0].Rows[0]["expand1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        //查询全部或特定查询
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Managers.id,Managers.userName,Managers.passWord,Managers.cnName,Managers.state,Managers.userType,Managers.roleId,Managers.mobile,Managers.creator,Managers.cteateDate,Managers.lastLoginDate,Managers.loginDate,Managers.loginTimes,Managers.expand1,Managers.remark,Roles.roleName ");
            strSql.Append(" FROM Managers LEFT JOIN Roles");
            strSql.Append(" ON  Managers.roleId = Roles.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append( " where " + strWhere + " and Managers.userType != 99");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        //修改查询
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("Managers.id, Managers.userName,Managers.passWord,Managers.cnName,Managers.state,Managers.userType,Managers.roleId,Managers.mobile,Managers.creator,Managers.cteateDate,Managers.lastLoginDate,Managers.loginDate,Managers.loginTimes,Managers.expand1,Managers.remark, Roles.roleName");
            strSql.Append(" FROM Managers LEFT JOIN Roles");
            strSql.Append(" ON  Managers.roleId = Roles.id");
            //strSql.Append(" FROM Managers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  Managers.id = " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList_RolesName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,roleName ");
            strSql.Append(" FROM Roles ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
