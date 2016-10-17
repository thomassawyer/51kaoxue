using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class GuideController : Controller
    {
        //
        // GET: /Guide/

        public ActionResult Index()
        {
            return View();
        }

        private int Subject = 0;

        /// <summary>
        /// 获取备课数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            int pageindex = Convert.ToInt32(Request["pageindex"]);
            int startindex = 0;
            int endindex = 0;
            if (pageindex > 1)
            {
                startindex = (pageindex - 1) * 20 + 1;
                endindex = pageindex * 20;
            }
            else 
            {
                 startindex = (pageindex - 1) * 20;
                 endindex = pageindex * 20;
            }
            string condition = ProduceCondition();

            string sql = string.Format(@"SELECT id,name,updatetime FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.updatetime desc)AS Row, T.*  from tblzhuanti T  
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
        /// 创造条件句
        /// </summary>
        /// <returns></returns>
        private string ProduceCondition()
        {
            string condition = " id is not null";
            string temp = Make_Conditions(Request["subject"]);
            if (!string.IsNullOrEmpty(temp))
                condition += temp;
            return condition;
        }

        /// <summary>
        /// 获取某小节数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount()
        {
            string condition = ProduceCondition();
            string sql = string.Format("select count(1) from tblzhuanti where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
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
                conditions += " and subject in";
            }
            switch (subjectname)
            {
                case "语文":
                    conditions += " ('1','9','19')";
                    Subject = 22;
                    break;
                case "数学":
                    conditions += " ('2','10','20')";
                    Subject = 23;
                    break;
                case "英语":
                    conditions += " ('3','11','21')";
                    Subject = 24;
                    break;
                case "物理":
                    conditions += " ('12','22')";
                    Subject = 25;
                    break;
                case "化学":
                    conditions += " ('13','23')";
                    Subject = 26;
                    break;
                case "生物":
                    conditions += " ('14','24')";
                    Subject = 27;
                    break;
                case "历史":
                    conditions += " ('15','25')";
                    Subject = 28;
                    break;
                case "地理":
                    conditions += " ('16','26')";
                    Subject = 30;
                    break;
                case "政治":
                    conditions += " ('17','27')";
                    Subject = 29;
                    break;
                case "科学":
                    conditions += "(28)";
                    break;
                case "理综":
                    conditions += "(30)";
                    break;
                case "文综":
                    conditions += "(29)";
                    break;
                default:
                    break;
            }
            return conditions;
        }
    }
}
