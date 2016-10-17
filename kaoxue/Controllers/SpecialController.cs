using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class SpecialController : Controller
    {
        //
        // GET: /Special/
        private string Level = string.Empty; //学段
        private string Grade = string.Empty;//年级
        private string District = string.Empty; // 地区

        public ActionResult Index()
        {
            ViewBag.title = "套题";
            return View();
        }

        public ActionResult Beike()
        {
            ViewBag.title = "备课";
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
        /// 获取套题数据
        /// </summary>
        /// <returns></returns>
        public string GetList(int id, int way, int pageindex)
        {
            int startindex = (pageindex - 1) * 10;
            int endindex = pageindex * 10;

            string sql = ProductSql(id,way,startindex,endindex);
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
        /// 构造sql语句
        /// </summary>
        /// <param name="id">套题编号</param>
        /// <param name="way">获取数据的方式 1 套题  2 备课</param>
        /// <param name="startindex">起始条数</param>
        /// <param name="endindex">结束条数</param>
        /// <returns></returns>
        public string ProductSql(int id,int way,int startindex,int endindex)
        {
            string sql = string.Empty;
            switch (way)
            {
                case 1: //套题
                    sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.uploadtime desc)AS Row, T.*  from select_beike_all T  
                                                WHERE  category=1 and prepareid={0} 
                                                ) 
                                                TT WHERE TT.Row between {1} and {2}", id, startindex, endindex);
                    break;
                case 2: //备课
                    sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.uploadtime desc)AS Row, T.*  from select_beike_all T  
                                                WHERE  category!=1 and prepareid={0}
                                                ) 
                                                TT WHERE TT.Row between {1} and {2}", id, startindex, endindex);
                    break;
                default:
                    break;
            }
            return sql;
        }

        public string ProductDataCountSql(int id, int way)
        {
            string sql = string.Empty;
            switch (way)
            {
                case 1: //套题
                    sql = string.Format("select count(1) from select_beike_all where category=1 and prepareid={0}", id);
                    break;
                case 2: //备课
                    sql = string.Format("select count(1) from select_beike_all where category!=1 and prepareid={0}", id);
                    break;
                default:
                    break;
            }
            return sql;
        }

        /// <summary>
        /// 获取某小节数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount(int id,int way)
        {
            string sql = ProductDataCountSql(id,way);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
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
