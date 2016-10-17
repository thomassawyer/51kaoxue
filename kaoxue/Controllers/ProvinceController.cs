using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class ProvinceController : Controller
    {
        //
        // GET: /Province/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 本省名校试题
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <returns></returns>
        public string Test_Mingxiao(int area,string level)
        {
            string condition = string.Format(" areaid={0} and ismingxiao=1 and level {1}",area,level);
            string json = string.Empty;
            DataSet ds = test_bll.GetList(18,condition," uploadtime desc");
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
        /// 精品试题
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <returns></returns>
        public string Test_Jingpin(int area)
        {
            string condition = string.Format(" areaid={0} and isjingpin='1'", area);
            string json = string.Empty;
            string sql = string.Format(@"SELECT TOP 6 [id]
                                                      ,[testname]
                                                      ,[uploadtime]
                                                  FROM [tbltest]
                                                  where {0}
                                                  order by uploadtime desc",condition);
            DataSet ds = DbHelperSQL.Query(sql);
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
        /// 精品备课
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <returns></returns>
        public string Beike_jingpin(int area)
        {
            string condition = string.Format(" areaid={0} and isjing='1' and level between 10 and 12", area);
            string json = string.Empty;
            DataSet ds = beike_bll.GetList(6, condition, " pubdate desc");
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
        /// 推荐套题
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <returns></returns>
        public string Taoti_tuijian(int area)
        {
            string condition = string.Format(" areaid={0} and istuijian='1'", area);
            string json = string.Empty;
            DataSet ds = taoti_bll.GetList(6, condition, " pubdate desc");
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
        /// 月考阶段试题
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <returns></returns>
        public string Test_Month_Exam(int area)
        {
            string condition = string.Format(" areaid={0} and istuijian='1'", area);
            string json = string.Empty;
            DataSet ds = test_bll.GetList(5, condition, " uploadtime desc");
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
        /// 通过试题类型获取试题
        /// </summary>
        /// <param name="area">城市ID</param>
        /// <param name="category">试题类型</param>
        /// <returns></returns>
        public string GetTest_ByCategory(int area, int category)
        {
            string condition = string.Format(" areaid={0} and testcategory={1}", area,category);
            string json = string.Empty;
            DataSet ds = test_bll.GetList(6, condition, " uploadtime desc");
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
        /// 获取轮播图
        /// </summary>
        /// <param name="type">轮播图类型</param>
        /// <returns></returns>
        public string GetBanner(int type)
        {
            string condition = string.Format(" type={0}", type);
            DataSet ds = banner_bll.GetList(16, condition, "sort desc");
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


        //试题业务
        Maticsoft.BLL.tbltest test_bll = new Maticsoft.BLL.tbltest();
        //备课业务
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
        //套题业务
        Maticsoft.BLL.tblTaoti taoti_bll = new Maticsoft.BLL.tblTaoti();
        //轮播图业务
        Maticsoft.BLL.tblBanner banner_bll = new Maticsoft.BLL.tblBanner();
        
    }
}
