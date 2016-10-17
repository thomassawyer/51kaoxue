using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class GradeController : Controller
    {
        //
        // GET: /Grade/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 专题推荐
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Zhunati_tuijian(string level)
        {
            string condition = string.Format(" level {0} and istop=1", level);
            string json = string.Empty;
            DataSet ds = zhuangti_bll.GetList(6, condition, " updatetime desc");
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
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Beike_jingpin(string level)
        {
            string condition = string.Format(" level {0} and isjing=1", level);
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
        /// 精品套题
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Taoti_jingpin(string level)
        {
            string condition = string.Format(" level {0} and istuijian=1", level);
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
        /// 名校套题
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Taoti_mingxiao(string level)
        {
            string condition = string.Format(" level {0} and ismingxiao=1", level);
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
        /// 高考备考
        /// </summary>
        /// <returns></returns>
        public string Gaokao_beizhan()
        {
            string sql = string.Format(@"SELECT TOP 6 
                                                        id,
                                                        category,
                                                      [name]
                                                      ,[uploadtime]
                                                  FROM [select_beikao_all]
                                                  where beikao>0
                                                  order by uploadtime desc");
            string json = string.Empty;
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
        /// 中考模拟
        /// </summary>
        /// <returns></returns>
        public string Moni_zhongkao() 
        {
            string sql = string.Format(@"select top 6 * from select_test_all where category=1 and testcategory=22 order by uploadtime desc");
            string json = string.Empty;
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
        /// 高考模拟
        /// </summary>
        /// <returns></returns>
        public string Moni_gaokao()
        {
            string sql = @"SELECT TOP 6 
                                        id,
                                      [testname]
                                      ,[uploadtime]
                                  FROM [tbltest]
                                  where testcategory=16
                                  and level=12
                                  order by uploadtime desc";
            string json = string.Empty;
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
        /// 精品课件
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Kejian_jingping(string level)
        {
            string condition = string.Format(" level {0} and isjing=1", level);
            string json = string.Empty;
            DataSet ds = kejian_bll.GetList(6, condition, " uploadtime desc");
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
        /// 精品教案
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Jiaoan_jingpin(string level)
        {
            string condition = string.Format(" level {0} and isjing=1", level);
            string json = string.Empty;
            DataSet ds = jiaoan_bll.GetList(6, condition, " uploadtime desc");
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
        /// 精品学案
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Xuean_jingpin(string level)
        {
            string condition = string.Format(" level {0} and isjing=1", level);
            string json = string.Empty;
            DataSet ds = xuean_bll.GetList(6, condition, " uploadtime desc");
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
        /// 精品练习
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Lianxi_jingpin(string level)
        {
            string sql = string.Format(@"SELECT TOP 6
                                                        id,
                                                      [name]
                                                      ,[uploadtime]
      
                                                  FROM [vw_tongbu]
                                                  where level {0} and isjing=1
                                                  order by uploadtime desc",level);
            string json = string.Empty;
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
        /// 精品素材
        /// </summary>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Sucai_jingpin(string level)
        {
            string condition = string.Format(" level {0} and isjing=1", level);
            string json = string.Empty;
            DataSet ds = sucai_bll.GetList(6, condition, " uploadtime desc");
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
        /// 通过试题类型获取试题（月考试题，阶段试题）
        /// </summary>
        /// <param name="level"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public string GetTestByCategory(string level,int category)
        {
            string condition = string.Format(" level {0} and testcategory={1}", level,category);
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

        //专题业务
        Maticsoft.BLL.tblzhuanti zhuangti_bll = new Maticsoft.BLL.tblzhuanti();
        //备课业务
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
        //套题业务
        Maticsoft.BLL.tblTaoti taoti_bll = new Maticsoft.BLL.tblTaoti();
        //课件业务
        Maticsoft.BLL.tblKejian kejian_bll = new Maticsoft.BLL.tblKejian();
        //教案业务
        Maticsoft.BLL.tblJiaoan jiaoan_bll = new Maticsoft.BLL.tblJiaoan();
        //学案业务
        Maticsoft.BLL.tblXuean xuean_bll = new Maticsoft.BLL.tblXuean();
        //素材业务
        Maticsoft.BLL.tblSucai sucai_bll = new Maticsoft.BLL.tblSucai();
        //试题业务
        Maticsoft.BLL.tbltest test_bll = new Maticsoft.BLL.tbltest();
    }
}
