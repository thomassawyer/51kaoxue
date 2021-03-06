﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.DBUtility;
using System.Data;

namespace Good_Resource.Controllers
{
    public class Elite_SchoolController : Controller
    {
        private string Level = string.Empty; //学段
        private string Grade = string.Empty;//年级
        private string District = string.Empty; // 地区

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取年级名称
        /// </summary>
        /// <returns></returns>
        public string GetGrade()
        {
            ProduceParameters();
            string condition = " level=" + this.Level;
            DataSet ds = grade_bll.GetList(condition);
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
        /// 获取地区名称
        /// </summary>
        /// <returns></returns>
        public string GetArea()
        {
            DataSet ds = area_bll.GetAllList();
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
        /// 热门下载
        /// </summary>
        /// <returns></returns>
        public string GetTest_Hot_Download()
        {
            ProduceParameters();
            DataSet ds = test_bll.GetList(12, string.Empty, " uploadtime desc");
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
            DataSet ds = test_bll.GetList(11, condition, " uploadtime desc");
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
            string condition = ProduceCondition();

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.pubdate desc)AS Row, T.*  from vw_taoti T  
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

            string level = this.Level;
            if (this.Level != "0")
            {
                if (level == "3") condition += " and [level]=3";
                else if (level == "2") condition += " and [level]=2";
                else if (level == "1") condition += " and [level]=1";
            }
            if (!string.IsNullOrEmpty(this.Grade) && this.Grade != "0")
                condition += string.Format(" and gradeid={0}", this.Grade);
            if (!string.IsNullOrEmpty(this.District) && this.District != "0")
                condition += string.Format(" and areaid={0}", this.District);
            return condition;
        }

        private string Produce_DirectoryCondition()
        {
            string condition = " id in ( select id from tblTaoti where ismingxiao=1)";

            string level = this.Level;
            if (level == "3") condition += " and subjectid in (select id from tblsubject where level=3)";
            else if (level == "2") condition += " and subjectid in (select id from tblsubject where level=2)";
            else if (level == "1") condition += " and subjectid in (select id from tblsubject where level=1)";
            return condition;
        }

        /// <summary>
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Level = Request["level"];
            this.Grade = Request["grade"];
            this.District = Request["district"];
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
            string condition = ProduceCondition();
            string sql = string.Format("select count(1) from vw_taoti where {0}", condition);
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
