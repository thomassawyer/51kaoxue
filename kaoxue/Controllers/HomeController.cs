using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 构造banner页面代码
        /// </summary>
        private void MakeBannerHtml()
        {
            //获取首页轮播图
            //DataSet ds = GetBanner(1);
            //string html = string.Empty;
            //if (ds != null)
            //{
            //    if (ds.Tables.Count > 0)
            //    {
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            DataRow row = ds.Tables[0].Rows[i];
            //            html += "<li><img src='" + "http://www.5ihzy.com:82/" + row["pic"].ToString() + "' alt='" + (i + 1) + "' title='" + (i + 1) + "' id='wows1_" + (i + 1) + "'></li>";
            //        }
            //    }
            //}
            //ViewBag.Banner = html;
        }

        /// <summary>
        /// 获取最新专题
        /// </summary>
        /// <returns></returns>
        public string GetNewZhunati()
        {
            DataSet ds = zhuanti_bll.GetList(12, string.Empty, "updatetime desc");
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
        /// 根据学段获取套题
        /// </summary>
        /// <returns></returns>
        public string GetTaoTiByLevel(string level)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" level {0}", level);
            string json = string.Empty;
            DataSet ds = taoti_bll.GetList(12, condition, " pubdate desc");
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
        /// 获取名校套题
        /// </summary>
        /// <returns></returns>
        public string GetTaoTi()
        {
            string condition = " ismingxiao=1";
            DataSet ds = taoti_bll.GetList(12, condition, "pubdate desc");
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


        public string GetTestByLevel(string level)
        {
            string condition = " istuijian=1";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
                condition += string.Format(" and level {0}", level);
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
        /// 获取推荐试题
        /// </summary>
        /// <returns></returns>
        public string GetTest()
        {
            string condition = " istuijian=1";
            DataSet ds = test_bll.GetList(6, condition, "uploadtime desc");
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

        public string GetSchoolTest_Bylevel(string level)
        {
            string condition = " ismingxiao=1 and istuijian=1 ";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
            {
                condition += "and level " + level;
            }
            DataSet ds = test_bll.GetList(12, condition, "uploadtime desc");
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
        /// 获取名校试题
        /// </summary>
        /// <returns></returns>
        public string GetSchool_Test()
        {
            string condition = " ismingxiao=1 and istuijian=1 ";
            DataSet ds = test_bll.GetList(12, condition, "uploadtime desc");
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

        public string GetBeikeBylevel(string level)
        {
            string condition = " isjing=1 ";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
                condition += string.Format(" and level {0}", level);
            DataSet ds = beike_bll.GetList(6, condition, "pubdate desc");
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
        /// 精品备课
        /// </summary>
        /// <returns></returns>
        public string GetBeiKe()
        {
            string condition = " isjing=1";
            DataSet ds = beike_bll.GetList(6, condition, "pubdate desc");
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

        public string Taoti_Bylevel(string level)
        {
            string condition = " ";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
            {
                condition = " level " + level;
            }
            DataSet ds = taoti_bll.GetList(6, condition, "pubdate desc");
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
        /// 最新套题-初中
        /// </summary>
        /// <returns></returns>
        public string GetTaoti_SeniorMiddleSchool()
        {
            string condition = " ";
            DataSet ds = taoti_bll.GetList(6, condition, "pubdate desc");
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

        public string GetTest_Bylevel(string level)
        {
            string condition = " ";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
            {
                condition = " level " + level;
            }
            DataSet ds = test_bll.GetList(6, condition, "uploadtime desc");
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
        /// 最新试题-初中
        /// </summary>
        /// <returns></returns>
        public string GetTest_SeniorMiddleSchool()
        {
            string condition = " ";
            DataSet ds = test_bll.GetList(6, condition, "uploadtime desc");
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


        public string GetMid_Bylevel(string level)
        {
            string condition = " testcategory=24 or testcategory = 18";
            if (!string.IsNullOrEmpty(level.Trim(' ')))
            {
                condition = "testcategory=" + level;
            }
            DataSet ds = test_bll.GetList(6, condition, "uploadtime desc");
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
        /// 最新历年中考试卷
        /// </summary>
        /// <returns></returns>
        public string GetMid_examination()
        {
            string condition = " testcategory=24 or testcategory = 18";
            DataSet ds = test_bll.GetList(6, condition, "uploadtime desc");
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
        /// 获取新闻
        /// </summary>
        /// <param name="type">新闻类型</param>
        /// <returns></returns>
        public string GetNews(int type)
        {
            string sql = string.Format(@"SELECT TOP 16 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                  FROM [tblNews]
                                                  where type = {0}
                                                  order by pubdate desc", type);
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
        /// 获取新闻
        /// </summary>
        /// <param name="type">新闻类型</param>
        /// <returns></returns>
        public string GetNews3(int type)
        {
            string sql = string.Format(@"SELECT TOP 24 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                  FROM [tblNews]
                                                  where type = {0}
                                                  order by pubdate desc", type);
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
        /// 获取新闻
        /// </summary>
        /// <param name="type">新闻类型</param>
        /// <returns></returns>
        public string GetNews1(int type)
        {
            string sql = string.Format(@"SELECT TOP 6 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                  FROM [tblNews]
                                                  where type = {0}
                                                  order by pubdate desc", type);
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
        /// 获取新闻
        /// </summary>
        /// <param name="type">新闻类型</param>
        /// <returns></returns>
        public string GetNews2(int type)
        {
            string sql = string.Format(@"SELECT TOP 14 [id]
                                                      ,[title]
                                                      ,[pubdate]
                                                  FROM [tblNews]
                                                  where type = {0}
                                                  order by pubdate desc", type);
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

        /// <summary>
        /// 名校合作
        /// </summary>
        /// <returns></returns>
        public string GetSchool()
        {
            DataSet ds = school_bll.GetList(18, string.Empty, "SchoolPosition desc");
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
        /// 名师推荐
        /// </summary>
        /// <returns></returns>
        public string GetTeachers()
        {
            string sql = @"SELECT TOP 4 [id]
                                      ,[name]
                                      ,[star]
                                      ,[content]
                                      ,[level]
                                      ,[areaid]
                                      ,[intime]
                                      ,[imgsrc]
                                      ,[headname]
                                      ,[schoolid]
                                      ,[position]
                                      ,[memo]
                                      ,[areaname]
                                      ,[headimgsrc]
                                      ,[headid]
                                  FROM [vw_school]
                                  order by position desc";
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
        /// 备课资源数量
        /// </summary>
        /// <returns></returns>
        public int GetBeikeCount()
        {
            string sql = "SELECT  COUNT(1) FROM [select_beike_all]";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 今日上新
        /// </summary>
        /// <returns></returns>
        public int GetBeikeCountByDay()
        {
            string sql = string.Format("select  COUNT(1) from [select_beike_all] where convert(varchar(10),[select_beike_all].uploadtime,120)=convert(varchar(10),getdate(),120)");
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// GetMemberCount   For  GetSchoolCount
        /// </summary>
        /// <returns>SchoolCount</returns>
        public int GetMemberCount()
        {
            string sql = string.Format("select COUNT(1) from tblschool");
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        /// <summary>
        /// 试题数量
        /// </summary>
        /// <returns></returns>
        public int GetShitiCount()
        {
            string sql = "select count(1) from tbltest";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        /// <summary>
        /// 教师数量
        /// </summary>
        /// <returns></returns>
        public int GetTearcherCount()
        {
            string sql = "select count(1) from tblteacher";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <returns></returns>
        public string GetUserInfo()
        {
            if (Session["UserId"] != null)
            {
                string sql = string.Format("select username,level,school from webusers where id={0}", Session["UserId"]);
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
            else
            {
                return "0";
            }
        }





        //专题业务
        Maticsoft.BLL.tblzhuanti zhuanti_bll = new Maticsoft.BLL.tblzhuanti();
        //套题业务
        Maticsoft.BLL.tblTaoti taoti_bll = new Maticsoft.BLL.tblTaoti();
        //试题业务
        Maticsoft.BLL.tbltest test_bll = new Maticsoft.BLL.tbltest();
        //精品备课
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
        //新闻业务
        Maticsoft.BLL.tblNews news_bll = new Maticsoft.BLL.tblNews();
        //轮播图业务
        Maticsoft.BLL.tblBanner banner_bll = new Maticsoft.BLL.tblBanner();
        //学校业务
        Maticsoft.BLL.tblschool school_bll = new Maticsoft.BLL.tblschool();

    }
}
