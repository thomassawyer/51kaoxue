using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class AncientController : Controller
    {
        //
        // GET: /Ancient/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public string Get_First_Category()
        {
            string sql = @"SELECT [id]
                                  ,[title]
                              FROM [ancient_category_first]";
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
        /// 获取二级分类
        /// </summary>
        /// <param name="first_id">一级分类编号</param>
        /// <returns></returns>
        public string Get_Second_Category(string first_id)
        {
            string sql = string.Format(@"SELECT  [id]
                                                  ,[title]
                                                  ,[first_id]
                                              FROM [ancient_category_second]
                                              where first_id={0}",first_id);
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
        /// 获取三级分类
        /// </summary>
        /// <param name="second_id">二级分类编号</param>
        /// <returns></returns>
        public string Get_Third_Category(string second_id)
        {
            string sql = string.Format(@"SELECT  [id]
                                                      ,[title]
                                                      ,[second_id]
                                                  FROM [ancient_category_third]
                                                  where second_id={0}",second_id);
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
        /// 阅读排行榜
        /// </summary>
        /// <returns></returns>
        public string Reading_Lists()
        {
            string sql = string.Format(@"SELECT TOP 10 [id]
                                                      ,[title]
                                                  FROM [tblancient]
                                                  order by viewcounts desc");
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
        /// 相关推荐
        /// </summary>
        /// <param name="first_id">一级分类编号</param>
        /// <returns></returns>
        public string Relative_Recommend(string first_id)
        {
            string sql = string.Format(@"SELECT TOP 5 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                      ,[viewcounts]
                                                  FROM [tblancient]
                                                  where first_id={0}
                                                  order by pubdate desc", first_id);
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
        /// 相关推荐
        /// </summary>
        /// <param name="first_id">一级分类编号</param>
        /// <returns></returns>
        public string Relative_Recommend_By_Keywords(string keyword)
        {
            string sql = string.Format(@"SELECT TOP 5 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                      ,[viewcounts]
                                                  FROM [tblancient]
                                                  where keyword like '%{0}%'
                                                  order by pubdate desc", keyword);
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
