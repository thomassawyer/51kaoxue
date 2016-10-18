using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.DBUtility;
using System.Data;
namespace kaoxue.Controllers
{
    public class SubjectController : Controller
    {
        //
        // GET: /Subject/
        private int type=0;
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 精品备课
        /// </summary>
        /// <returns></returns>
        public string Beike_jingpin()
        {
            string condition = Make_Conditions(Request["subjectname"]) + " and isjing=1";
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
        /// 精品试题
        /// </summary>
        /// <returns></returns>
        public string Test_jingpin()
        {
            string condition = Make_Conditions(Request["subjectname"]) + " and isjingpin=1";
            string json = string.Empty;
            string sql = string.Format(@"SELECT TOP 6 [id]
                                                      ,[testname]
                                                      ,[uploadtime]
                                                  FROM [tbltest]
                                                  where {0}
                                                    order by uploadtime desc", condition);
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
        /// 最新专题推荐
        /// </summary>
        /// <returns></returns>
        public string Zhuanti_New_Recommmend()
        {
            string condition = Make_Conditions(Request["subjectname"]) + string.Format( " and level={0}",Request["level"]);
            condition = condition.Replace("subjectid","subject");
            string json = string.Empty;
            string sql = string.Format(@"SELECT TOP 6 [id]
                                                      ,[name]
                                                      ,[updatetime]
                                                  FROM [tblzhuanti]
                                                  where {0}
                                                  order by updatetime desc",condition);
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
        /// 最新试题
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Test_new(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if(!string.IsNullOrEmpty(level))
                condition+=string.Format(" and level {0}", level);
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
        /// 最新备考
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="wheel">第几轮</param>
        /// <returns></returns>
        public string Beikao_new(string subjectname,string wheel)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(wheel))
                condition += string.Format(" and name like '%{0}%'",wheel);
            string sql = @"SELECT  top 6        [category]
                                          ,[id]
                                          ,[name]
                                          ,[uploadtime]
                                          ,[testcategory]
                                      FROM [select_beikao_all]";
            sql +=" where " +condition;
            sql += " order by uploadtime desc";
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
        /// <param name="subjectname">科目名称</param>
        /// <returns></returns>
        public string Moni_junior(string subjectname) 
        {
            string sql = "select top 6 * from select_test_all where";
            string condition = Make_Conditions(subjectname);
            sql += condition;
            sql += " and category=1 and testcategory=22 order by uploadtime desc";
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
        /// 名校试题
        /// </summary>
        /// <param name="subjectname">学科名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Test_mingxiao(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" and level {0}",level);
            condition += " and ismingxiao=1";
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
        /// 课件
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Kejian(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" and level {0}", level);
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
        /// 同步练习
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Study_skills(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" and level {0}", level);
            string json = string.Empty;
            DataSet ds = tongbu_bll.GetList(6, condition, " uploadtime desc");
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
        /// 教案
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Jiaoan(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" and level {0}", level);
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
        /// 学案
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <param name="level">年级</param>
        /// <returns></returns>
        public string Xuean(string subjectname,string level)
        {
            string condition = Make_Conditions(subjectname);
            if (!string.IsNullOrEmpty(level))
                condition += string.Format(" and level {0}", level);
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
        /// 获取轮播图
        /// </summary>
        /// <param name="subjectname"></param>
        /// <returns></returns>
        public string GetBanner(string subjectname)
        {
            Make_Type(subjectname);
            string json = string.Empty;
            string condition = string.Format(" type={0}",type);
            DataSet ds = banner_bll.GetList(condition);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    json = JsonHelper.ToJson(ds.Tables[0]);
                }
            }
            return json;
        }

        //备课业务
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
        //试题业务
        Maticsoft.BLL.tbltest test_bll = new Maticsoft.BLL.tbltest();
        //专题业务
        Maticsoft.BLL.tblzhuanti zhuanti_bll = new Maticsoft.BLL.tblzhuanti();
        //课件业务
        Maticsoft.BLL.tblKejian kejian_bll = new Maticsoft.BLL.tblKejian();
        //同步练习业务
        Maticsoft.BLL.tblTongbu tongbu_bll = new Maticsoft.BLL.tblTongbu();
        //教案业务
        Maticsoft.BLL.tblJiaoan jiaoan_bll = new Maticsoft.BLL.tblJiaoan();
        //学案业务
        Maticsoft.BLL.tblXuean xuean_bll = new Maticsoft.BLL.tblXuean();
        //轮播图业务
        Maticsoft.BLL.tblBanner banner_bll = new Maticsoft.BLL.tblBanner();



        public void Make_Type(string subjectname)
        {
            Make_Conditions(subjectname);
        }

        /// <summary>
        /// 构造科目条件句
        /// </summary>
        /// <param name="subjectname">科目名称</param>
        /// <returns></returns>
        private string Make_Conditions(string subjectname)
        {
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(subjectname))
            {
                conditions += " subjectid in";
            }            
            switch (subjectname)
            {
                case "语文":
                    conditions += " ('1','9','19')";
                    type = 22;
                    break;
                case "数学":
                    conditions += " ('2','10','20')";
                    type = 23;
                    break;
                case "英语":
                    conditions += " ('3','11','21')";
                    type = 24;
                    break;
                case "物理":
                    conditions += " ('12','22')";
                    type = 25;
                    break;
                case "化学":
                    conditions += " ('13','23')";
                    type = 26;
                    break;
                case "生物":
                    conditions += " ('14','24')";
                    type = 27;
                    break;
                case "历史":
                    conditions += " ('15','25')";
                    type = 28;
                    break;
                case "地理":
                    conditions += " ('16','26')";
                    type = 30;
                    break;
                case "政治":
                    conditions += " ('17','27')";
                    type = 29;
                    break;
                case "科学":
                    conditions += "(28)";
                    break;
                default:
                    break;
            }
            return conditions;
        }
    }
}
