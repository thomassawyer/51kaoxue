using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class The_School_TestController : Controller
    {
        //
        // GET: /The_School_Test/

        public ActionResult Index()
        {
            return View();
        }

        private string Id; //学校编号

        /// <summary>
        /// 获取试题数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            int pageindex = Convert.ToInt32(Request["pageindex"]);
            //int startindex = (pageindex - 1) * 17;
            //if (pageindex > 1)
            //{
            //    startindex = (pageindex - 1) * 17 + 1;
            //}
            //int endindex = pageindex * 17;
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
                                                order by T.uploadtime desc)AS Row, T.*  from tbltest T  
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
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Id = Request["id"];
        }


        /// <summary>
        /// 创造条件句
        /// </summary>
        /// <returns></returns>
        private string ProduceCondition()
        {
            string condition = " id is not null";
            if (!string.IsNullOrEmpty(this.Id))
            {
                condition += " and schoolid=" + this.Id;
            }
            return condition;
        }

        /// <summary>
        /// 获取某小节数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount()
        {
            ProduceParameters();
            string condition = ProduceCondition();
            string sql = string.Format("select count(1) from tbltest where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

    }
}
