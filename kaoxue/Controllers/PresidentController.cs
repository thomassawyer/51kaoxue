using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class PresidentController : Controller
    {
        //
        // GET: /President/
        public ActionResult Index()
        {
            return View();
        }

        private string Level = string.Empty; //学段
        private string District = string.Empty; // 地区

        /// <summary>
        /// 名校推荐
        /// </summary>
        /// <returns></returns>
        public string EliteSchool_Recommend()
        {
            string sql = "select top 4 id,name,(select count(1) from tbltest where schoolid=s.id) as testnum,areaid from tblschool s order by testnum desc";
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
        /// 试题推荐
        /// </summary>
        /// <returns></returns>
        public string Test_Recommend()
        {
            string sql = "select top 9 testname,id,uploadtime from tbltest";
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
        /// 获取备考数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            int pageindex = Convert.ToInt32(Request["pageindex"]);
            //int startindex = (pageindex - 1) * 5;
            //if (pageindex != 1)
            //{
            //    startindex = (pageindex - 1) * 5 + 1;
            //}
            //int endindex = pageindex * 5;
            //构造数据起始坐标
            int startindex = 0;
            int endindex = 0;
            if (pageindex > 1)
            {
                startindex = (pageindex - 1) * 10 + 1;
                endindex = pageindex * 10;
            }
            else
            {
                startindex = (pageindex - 1) * 10;
                endindex = pageindex * 10;
            }
            //构造数据起始坐标结束
            ProduceParameters();
            string condition = ProduceCondition();

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.intime desc)AS Row, T.*  from vw_school T  
                                                WHERE  {0} 
                                                ) 
                                                TT WHERE TT.Row between {1} and {2}", condition, startindex, endindex);
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
        /// 获取某小节数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount()
        {
            ProduceParameters();
            string condition = ProduceCondition();
            string sql = string.Format("select count(1) from vw_school where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

        /// <summary>
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Level = Request["level"];
            this.District = Request["district"];
        }


        /// <summary>
        /// 创造条件句
        /// </summary>
        /// <returns></returns>
        private string ProduceCondition()
        {
            string condition = " id is not null";

            string level = this.Level;
            if (this.Level != "0" && !string.IsNullOrEmpty(this.Level))
            {
                condition += string.Format(" and level={0}", this.Level);
            }
            if (!string.IsNullOrEmpty(this.District) && this.District != "0")
                condition += string.Format(" and areaid={0}", this.District);
            return condition;
        }

    }
}
