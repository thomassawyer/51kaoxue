using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kaoxue.Controllers
{
    public class Ancient_ArticleController : Controller
    {
        //
        // GET: /Ancient_Article/

        public ActionResult Index()
        {
            string param = Request["myTitle"];
            ViewBag.title = param; 

            return View();
        }

        /// <summary>
        /// 获取详细古文信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetInformation(int id)
        {
            string sql = string.Format(@"SELECT TOP 1000 [id]
                                                          ,[title]
                                                          ,[content]
                                                          ,[pubdate]
                                                          ,[keyword]
                                                          ,[viewcounts]
                                                      FROM [tblancient]
                                                    where id={0}",id);
            DataSet ds = DbHelperSQL.Query(sql);
            string json = string.Empty;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    json = JsonHelper.ToJson(ds.Tables[0]);
                }
            }
            return json;
        }

        /// <summary>
        /// 更新浏览次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_Viewcount(int id)
        {
            string sql = string.Format(@"UPDATE [tblancient]
                                                                       SET 
                                                                          viewcounts = viewcounts+1
                                                                     WHERE id={0}",id);
            int result = DbHelperSQL.ExecuteSql(sql);
            if (result > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

    }
}
