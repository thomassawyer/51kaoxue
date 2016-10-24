using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class SchoolDetailController : Controller
    {
        //
        // GET: /SchoolDetail/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <returns></returns>
        public string GetSchoolInfo(int id)
        {
            string sql = "select name,content,star,imgsrc,id,areaid from tblschool where id=" + id;
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
        /// 获取学校试题
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <returns></returns>
        public string GetSchoolTest(int id)
        {
            string sql = "select top 7 testname,id,uploadtime from tbltest where schoolid=" + id;
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
        public string President_Special_Column()
        {
            string sql = "select top(5) id,title,pubdate from tblnews where type=5 order by pubdate desc";
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
        /// 本省试题
        /// </summary>
        /// <param name="aredid">省份编号</param>
        /// <returns></returns>
        public string Province_Test(int areaid)
        {
            string sql = "select top 18 testname,id,uploadtime from tbltest where areaid=" + areaid + " order by uploadtime desc";
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
        /// 校长介绍
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <returns></returns>
        public string President_Introduce(int id)
        {
            string sql = "select id,name,memo,imgsrc from tblteacher where schoolid=" + id;
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
        /// 相关名校
        /// </summary>
        /// <param name="areaid">省份编号</param>
        /// <returns></returns>
        public string Correlation_Elite_School(int areaid)
        {
            string sql = string.Format(@"SELECT  top 8 [id]
                                                  ,[name]
                                                  ,[imgsrc]
                                                    ,areaid
                                              FROM [tblschool]
                                              where areaid = {0}
                                              order by SchoolPosition desc", areaid);
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
