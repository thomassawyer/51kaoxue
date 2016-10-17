using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class Beike_CenterController : Controller
    {
        //
        // GET: /Beike_Center/
        private string Level = string.Empty; //学段
        private string Subject = string.Empty;  //学科
        private string Version_First = string.Empty; //一级版本
        private string Version_Second = string.Empty; // 二级版本
        private string Version_Third = string.Empty; // 三级版本
        private string Version_Fourth = string.Empty; //四级版本
        private string Versionid = string.Empty; //版本编号
        private string Category = string.Empty;
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取学科
        /// </summary>
        /// <returns></returns>
        public string GetSubject()
        {
            ProduceParameters();
            string condition = " id<=27 and level=" + this.Level;
            DataSet ds = subject_bll.GetList(condition);
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
        /// 获取一级版本
        /// </summary>
        /// <returns></returns>
        public string GetVersion_First()
        {
            ProduceParameters();
            string condition = " pid=0 and subjectid=" + this.Subject + " order by orderid asc";
            DataSet ds = bookversion_bll.GetList(condition);
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
        /// 获取二级版本
        /// </summary>
        /// <returns></returns>
        public string GetVersion_Second()
        {
            ProduceParameters();
            string condition = " pid=" + this.Version_First + " and subjectid=" + this.Subject + " order by orderid asc";
            DataSet ds = bookversion_bll.GetList(condition);
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
        /// 获取三四级版本
        /// </summary>
        /// <returns></returns>
        public string GetVersion_ThirdAndFourth()
        {
            ProduceParameters();
            string condition = " pid=" + this.Version_Second + " and subjectid=" + this.Subject + " order by orderid asc";
            DataSet ds = bookversion_bll.GetList(condition);
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
        /// 获取备课数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            int pageindex = Convert.ToInt32(Request["pageindex"]);
            int startindex = (pageindex - 1) * 10;
            int endindex = pageindex * 10;
            ProduceParameters();
            string condition = ProduceCondition();

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.uploadtime desc)AS Row, T.*  from select_beikes_all T  
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
            string sql = string.Format("select count(1) from select_beikes_all where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

        /// <summary>
        /// 获取某版本数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount_Direction()
        {
            ProduceParameters();
            string condition = Produce_DirectoryCondition();
            string sql = string.Format("select count(1) from select_beikes_all where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

        /// <summary>
        /// 创造条件句
        /// </summary>
        /// <returns></returns>
        private string ProduceCondition()
        {
            string condition = " id is not null";
            if (!string.IsNullOrEmpty(this.Subject))
                condition += string.Format(" and subjectid={0}", this.Subject);

            string level = this.Level;
            if (level == "3") condition += " and subjectid in (select id from tblsubject where level=3)";
            else if (level == "2") condition += " and subjectid in (select id from tblsubject where level=2)";
            else if (level == "1") condition += " and subjectid in (select id from tblsubject where level=1)";


            if (!string.IsNullOrEmpty(this.Version_Fourth))
                this.Versionid = this.Version_Fourth;
            else if (!string.IsNullOrEmpty(this.Version_Third))
                this.Versionid = this.Version_Third;
            else if (!string.IsNullOrEmpty(this.Version_Second))
                this.Versionid = this.Version_Second;
            else if (!string.IsNullOrEmpty(this.Version_First))
                this.Versionid = this.Version_First;

            if (!string.IsNullOrEmpty(this.Versionid))
                condition += " and versionid in ("+digui(Convert.ToInt32(this.Versionid))+this.Versionid+")" ;
            if (!string.IsNullOrEmpty(this.Category))
                condition += string.Format(" and category={0}", this.Category);
            return condition;
        }

        private string Produce_DirectoryCondition()
        {
            string condition = " id is not null";
            if (!string.IsNullOrEmpty(this.Subject))
                condition += string.Format(" and subjectid={0}", this.Subject);

            string level = this.Level;
            if (level == "3") condition += " and subjectid in (select id from tblsubject where level=3)";
            else if (level == "2") condition += " and subjectid in (select id from tblsubject where level=2)";
            else if (level == "1") condition += " and subjectid in (select id from tblsubject where level=1)";
            if (!string.IsNullOrEmpty(this.Category))
                condition += string.Format(" and category={0}", this.Category);
            return condition;
        }

        /// <summary>
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Level = Request["level"];
            this.Subject = Request["subject"];
            this.Version_First = Request["version_first"];
            this.Version_Second = Request["version_second"];
            this.Version_Third = Request["version_third"];
            this.Version_Fourth = Request["version_fourth"];
            this.Category = Request["category"];
        }

        string str = string.Empty;
        private string digui(int pid)
        {
            string sql = "select id,pid from tblbookversion where pid=" + pid;
            DataSet ds = DbHelperSQL.Query(sql);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
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

        //学科业务
        Maticsoft.BLL.tblsubject subject_bll = new Maticsoft.BLL.tblsubject();
        //版本业务
        Maticsoft.BLL.tblbookversion bookversion_bll = new Maticsoft.BLL.tblbookversion();
        //备课业务
        Maticsoft.BLL.tblBeike beike_bll = new Maticsoft.BLL.tblBeike();
    }
}
