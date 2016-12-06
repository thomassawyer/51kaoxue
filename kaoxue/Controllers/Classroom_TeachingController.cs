using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kaoxue.Controllers
{
    public class Classroom_TeachingController : Controller
    {
        //
        // GET: /Classroom_Teaching/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有视频分类
        /// </summary>
        /// <returns></returns>
        public string GetVideoType()
        {
            DataSet ds = video_bll.GetAllList();
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
        /// 获取所有年级
        /// </summary>
        /// <returns></returns>
        public string GetGrade()
        {
            string sql = @"SELECT [id]
                                  ,[name]
                                  ,[level]
                              FROM [tblgrade]
                              order by id desc";
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
        /// 获取科目
        /// </summary>
        /// <param name="level">学段</param>
        /// <returns></returns>
        public string GetSubject(int level) 
        {
            string sql = string.Format(@"SELECT  [id]
                                                  ,[name]
                                                  ,[level]
                                              FROM [tblsubject]
                                              where level = {0}",level);
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
        /// 获取父级章节ID
        /// </summary>
        /// <param name="subjectid">科目编号</param>
        /// <param name="gradeid">年级编号</param>
        /// <param name="videoid">视频类型编号</param>
        /// <returns></returns>
        public string GetParentChaper(int subjectid,int gradeid,int videoid)
        {
            string sql = string.Format(@"SELECT [id]
                                                  ,[chapterName]
                                                  ,[subjectId]
                                                  ,[gradeId]
                                                  ,[videoId]
                                                  ,[FId]
                                                  ,[sortId]
                                              FROM [videoChaper]
                                              where subjectId={0}
                                              and gradeId={1}
                                              and videoId={2}
                                              and fid=0",subjectid,gradeid,videoid);
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

        public string GetChildChaper(int fid)
        {
            string sql = string.Format(@"SELECT [id]
                                                  ,[chapterName]
                                                  ,[subjectId]
                                                  ,[gradeId]
                                                  ,[videoId]
                                                  ,[FId]
                                                  ,[sortId]
                                              FROM [videoChaper]
                                              where fid={0}", fid);
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
        /// 获取视频数据
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
                startindex = (pageindex - 1) * 6 + 1;
                endindex = pageindex * 6;
            }
            else
            {
                startindex = (pageindex - 1) * 6;
                endindex = pageindex * 6;
            }
            //构造数据起始坐标结束
            ProduceParameters();
            string condition = ProduceCondition();

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.updateTime desc)AS Row, T.*  from vw_videoInfo T  
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
            string sql = string.Format("select count(1) from vw_videoInfo where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

        //科目
        public string Subject { get; set; }
        //年级
        public string Grade { get; set; }
        //视频分类
        public string Category { get; set; }
        //章节
        public string Chaper { get; set; }

        /// <summary>
        /// 参数工厂
        /// </summary>
        public void ProduceParameters()
        {
            this.Subject = Request["subjectid"];
            this.Grade = Request["gradeid"];
            this.Category = Request["category"];
            this.Chaper = Request["chaper"];
        }

        /// <summary>
        /// 创造条件句
        /// </summary>
        /// <returns></returns>
        private string ProduceCondition()
        {
            string condition = " id is not null";
            if (!string.IsNullOrEmpty(this.Subject) && this.Subject != "0")
                condition += string.Format(" and subjectId={0}", this.Subject);
            if (!string.IsNullOrEmpty(this.Category) && this.Category != "0")
                condition += string.Format(" and videoTypeId={0}", this.Category);
            if (!string.IsNullOrEmpty(this.Chaper) && this.Chaper != "0")
                condition += string.Format(" and chapterId={0}", this.Chaper);
            if (!string.IsNullOrEmpty(this.Grade) && this.Grade != "0")
                condition += string.Format(" and gradeId={0}", this.Grade);
            return condition;
        }

        //视频分类业务
        Maticsoft.BLL.tblvideo video_bll = new Maticsoft.BLL.tblvideo();
        //年级业务
        Maticsoft.BLL.tblgrade grade_bll = new Maticsoft.BLL.tblgrade();
        //科目业务
        Maticsoft.BLL.tblsubject subject_bll = new Maticsoft.BLL.tblsubject();
        //章节业务
        Maticsoft.BLL.videoChaper chaper_bll = new Maticsoft.BLL.videoChaper();
    }
}
