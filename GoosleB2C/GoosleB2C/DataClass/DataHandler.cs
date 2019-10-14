using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace WikEasyUIDemo
{
    public class DataHandler
    {
        /// <summary>
        /// 此分页存储过程直接用皱建的，没修改 大家可以用自己的
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="getFields">需要返回的列</param>
        /// <param name="orderName">排序的字段名</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isGetCount">返回记录总数,非 0 值则返回</param>
        /// <param name="orderType">设置排序类型,0表示升序非0降序</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static  DataSet GetList(string tableName, string getFields,string orderName, int pageSize,int  pageIndex,bool isGetCount,bool orderType,string strWhere)
        {
         SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                  new SqlParameter("@PageSize", SqlDbType.Int),
               new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar, 1500)            
                                     };
            parameters[0].Value = tableName;
            parameters[1].Value = getFields;
            parameters[2].Value = orderName;
            parameters[3].Value = pageSize;
            parameters[4].Value = pageIndex;
            parameters[5].Value = isGetCount?1:0;
            parameters[6].Value = orderType ? 1 : 0;
            parameters[7].Value = strWhere;
            return DbHelperSQL.RunProcedure("pro_pageList", parameters, "ds");
        }
        public static int DelData(string tabName, string ID)
        {
            if (ID != string.Empty && ID != "0")
            {                
                string sql = string.Format("delete from {0}  WHERE (ID IN ({1}))", tabName, ID);
                int delNum = DbHelperSQL.ExecuteSql(sql);
                return delNum;
            }
            return 0;
        }
    }
}