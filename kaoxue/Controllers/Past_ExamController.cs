using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class Past_ExamController : Controller
    {
        private string Level = string.Empty; //学段
        private string Year = string.Empty;//年份
        private string Daohangid = string.Empty; //导航编号
        private string SubjectId = string.Empty; // 学科编号

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取年份名称
        /// </summary>
        /// <returns></returns>
        public string GetYears()
        {
            string sql = "select id,name from tblyear order by name desc";
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
        /// 通过年份获取省份(导航)名称
        /// </summary>
        /// <returns></returns>
        public string GetProvince()
        {
            ProduceParameters();
            string sql = string.Format("select id,name,year from tbldaohang where year={0}",this.Year);
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
        /// 通过导航编号获取数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            ProduceParameters();
            string sql = string.Format("select distinct daohangid,subject,subjectid from vw_zhenti where daohangid={0}", this.Daohangid);
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
        /// 通过导航编号获取数据
        /// </summary>
        /// <returns></returns>
        public string GetList1()
        {
            ProduceParameters();
            string sql = string.Format("select id,daohangid,subjectid,type,testid from vw_zhenti where daohangid={0}  and subjectid={1}", this.Daohangid, this.SubjectId);
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
            if (!string.IsNullOrEmpty(this.Year) && this.Year != "0")
                condition += string.Format(" and gradeid={0}", this.Year);
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
            this.Year = Request["year"];
            this.Daohangid = Request["daohangid"];
            this.SubjectId = Request["subjectid"];
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
