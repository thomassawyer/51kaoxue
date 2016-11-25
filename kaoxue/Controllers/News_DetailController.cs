using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class News_DetailController : Controller
    {
        //
        // GET: /News_Detail/

        public ActionResult Index()
        {
            string param = Request["myTitle"];
            ViewBag.title = param;
            return View();
        }

        /// <summary>
        /// 获取新闻详细内容
        /// </summary>
        /// <param name="id">新闻编号</param>
        /// <returns></returns>
        public string GetNewsDetail(int id)
        {
            string sql = string.Format(" select * from tblnews where id={0}",id);
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



    }
}
