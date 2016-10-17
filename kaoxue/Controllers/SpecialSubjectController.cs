using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class SpecialSubjectController : Controller
    {
        //
        // GET: /SpecialSubject/
        private string Level = string.Empty; //学段
        private string Grade = string.Empty;//年级
        private string District = string.Empty; // 地区

        public ActionResult Index()
        {
            ViewBag.title = "专题";
            return View();
        }


        /// <summary>
        /// 热门下载
        /// </summary>
        /// <returns></returns>
        public string GetTest_Hot_Download()
        {
            DataSet ds = test_bll.GetList(10, string.Empty, " neednum desc");
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
        /// <returns></returns>
        public string GetTest_Recommend()
        {
            string condition = " istuijian=1";
            DataSet ds = test_bll.GetList(10, condition, " uploadtime desc");
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
        /// 获取专题数据
        /// </summary>
        /// <returns></returns>
        public string GetList(int id)
        {
            string sql = string.Format(@"SELECT [category]
                                                  ,[id]
                                                  ,[name]
                                                  ,[uploadtime]
                                                  ,[extension]
                                                  ,[prepareid]
                                                  ,[neednum]
                                              FROM [select_beike_all] t
                                              where id in(
                                              select testid from tblassign a where zttypeid in 
	                                            (select id from tblzttype where ztid={0})
	                                            and a.category = t.category
	                                            )
                                              order by uploadtime desc", id);
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

        //学科业务
        Maticsoft.BLL.tblsubject subject_bll = new Maticsoft.BLL.tblsubject();
        //版本业务
        Maticsoft.BLL.tblbookversion bookversion_bll = new Maticsoft.BLL.tblbookversion();
        //备课业务
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
        //试题业务
        Maticsoft.BLL.tbltest test_bll = new Maticsoft.BLL.tbltest();
        //试题类型业务
        Maticsoft.BLL.tblTestCategory testcategory_bll = new Maticsoft.BLL.tblTestCategory();
        //年级业务
        Maticsoft.BLL.tblgrade grade_bll = new Maticsoft.BLL.tblgrade();
        //地区业务
        Maticsoft.BLL.tblarea area_bll = new Maticsoft.BLL.tblarea();

    }
}
