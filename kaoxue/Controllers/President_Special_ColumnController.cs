using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class President_Special_ColumnController : Controller
    {
        //
        // GET: /President_Special_Column/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取校长信息
        /// </summary>
        /// <returns></returns>
        public string GetPresidentInfo()
        {
            string sql = "select id,name,headname,schoolid,memo,headimgsrc from vw_school where headid=" + Request["id"];
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
        /// 校长专栏
        /// </summary>
        /// <returns></returns>
        public string President_Special_Columns()
        {
            string sql = "select top(14) id,title,pubdate from tblnews where type=5 order by pubdate desc";
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
        /// 获取新闻详细内容
        /// </summary>
        /// <param name="id">新闻编号</param>
        /// <returns></returns>
        public string GetNewsDetail(int id)
        {
            string sql = string.Format(" select * from tblnews where id={0}", id);
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
