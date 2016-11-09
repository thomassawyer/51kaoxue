using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }


        private string Keywords = string.Empty;


        /// <summary>
        /// 热门下载
        /// </summary>
        /// <returns></returns>
        public string GetTest_Hot_Download()
        {
            ProduceParameters();
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
        /// 获取备考数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            int pageindex = Convert.ToInt32(Request["pageindex"]);
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
            string condition = ProduceCondition2();

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.uploadtime desc)AS Row, T.*  from select_beike_all T  
                                                WHERE  {0} 
                                                ) 
                                                TT WHERE TT.Row between {1} and {2}", condition, startindex, endindex);
            DataSet ds = DbHelperSQL.Query(sql);
            string json = string.Empty;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        condition = ProduceCondition();
                        sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.uploadtime desc)AS Row, T.*  from select_beike_all T  
                                                WHERE  {0} 
                                                ) 
                                                TT WHERE TT.Row between {1} and {2}", condition, startindex, endindex);
                        ds = DbHelperSQL.Query(sql);
                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                            {
                                json = JsonHelper.ToJson(ds.Tables[0]);
                            }
                        }
                    }
                    else
                    {
                        json = JsonHelper.ToJson(ds.Tables[0]);
                    }
                    
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
            if (!string.IsNullOrEmpty(this.Keywords))
            {
                for (int i = 0; i < this.Keywords.Length; i++)
                {
                    condition += string.Format( " and name like '%{0}%'",this.Keywords[i]);
                }
            }
            return condition;
        }

        private string ProduceCondition2() 
        {
            string condition = " id is not null";
            if (!string.IsNullOrEmpty(this.Keywords))
            {
                condition += string.Format(" and name like '%{0}%'", this.Keywords);
            }
            return condition;
        }


        /// <summary>
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Keywords = Request["keywords"];
        }

        private string digui(int pid)
        {
            string str = string.Empty;
            string sql = "select id,pid from tblbookversion where pid=" + pid;
            DataSet ds = DbHelperSQL.Query(sql);
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    str += dt.Rows[i]["id"].ToString() + ",";
                    digui(int.Parse(dt.Rows[i]["id"].ToString()));
                }
            }
            return str;
        }

        /// <summary>
        /// 获取某小节数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount()
        {
            ProduceParameters();
            string condition = ProduceCondition2();
            string sql = string.Format("select count(1) from select_beike_all where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            if (temp == 0)
            {
                condition = ProduceCondition();
                sql = string.Format("select count(1) from select_beike_all where {0}", condition);
                temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
                return temp.ToString();
            }else
            {
                return temp.ToString();
            }
            
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
