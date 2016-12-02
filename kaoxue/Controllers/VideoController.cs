using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 课堂讲学
        /// </summary>
        /// <returns></returns>
        public string Classroom_Teaching(int subjectId)
        {
            string sql = string.Format(@"SELECT TOP 6 [id]
                                              ,[subjectId]
                                              ,[gradeId]
                                              ,[videoTypeId]
                                              ,[title]
                                              ,[videocontent]
                                              ,[videoImageUrl]
                                              ,[videoUrl]
                                              ,[videobackImage]
                                              ,[teacherName]
                                              ,[curriculumTime]
                                              ,[classCount]
                                              ,[chapterId]
                                              ,[updateTime]
                                              ,[viewingTimes]
                                              ,[videoForUser]
                                              ,[videoTime]
                                              ,[Name]
                                              ,[GradeName]
                                              ,[VideoTypeName]
                                              ,[ChapterName]
                                          FROM [vw_videoInfo]
                                          where videoTypeId=1
                                          and subjectId={0}
                                          order by updateTime desc",subjectId);
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
        /// 心理解压
        /// </summary>
        /// <returns></returns>
        public string Psychological_decompression()
        {
            string sql = string.Format(@"SELECT TOP 3 [id]
                                              ,[subjectId]
                                              ,[gradeId]
                                              ,[videoTypeId]
                                              ,[title]
                                              ,[videocontent]
                                              ,[videoImageUrl]
                                              ,[videoUrl]
                                              ,[videobackImage]
                                              ,[teacherName]
                                              ,[curriculumTime]
                                              ,[classCount]
                                              ,[chapterId]
                                              ,[updateTime]
                                              ,[viewingTimes]
                                              ,[videoForUser]
                                              ,[videoTime]
                                              ,[Name]
                                              ,[GradeName]
                                              ,[VideoTypeName]
                                              ,[ChapterName]
                                          FROM [vw_videoInfo]
                                          where videoTypeId=4
                                          order by updateTime desc");
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
        /// 试题解析
        /// </summary>
        /// <returns></returns>
        public string Test_Questions_Analysis(int subjectId)
        {
            string sql = string.Format(@"SELECT TOP 6 [id]
                                              ,[subjectId]
                                              ,[gradeId]
                                              ,[videoTypeId]
                                              ,[title]
                                              ,[videocontent]
                                              ,[videoImageUrl]
                                              ,[videoUrl]
                                              ,[videobackImage]
                                              ,[teacherName]
                                              ,[curriculumTime]
                                              ,[classCount]
                                              ,[chapterId]
                                              ,[updateTime]
                                              ,[viewingTimes]
                                              ,[videoForUser]
                                              ,[videoTime]
                                              ,[Name]
                                              ,[GradeName]
                                              ,[VideoTypeName]
                                              ,[ChapterName]
                                          FROM [vw_videoInfo]
                                          where videoTypeId=2
                                          and subjectId={0}
                                          order by updateTime desc",subjectId);
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
        /// 高考研讨会
        /// </summary>
        /// <returns></returns>
        public string Seminar(int subjectId)
        {
            string sql = string.Format(@"SELECT TOP 6 [id]
                                              ,[subjectId]
                                              ,[gradeId]
                                              ,[videoTypeId]
                                              ,[title]
                                              ,[videocontent]
                                              ,[videoImageUrl]
                                              ,[videoUrl]
                                              ,[videobackImage]
                                              ,[teacherName]
                                              ,[curriculumTime]
                                              ,[classCount]
                                              ,[chapterId]
                                              ,[updateTime]
                                              ,[viewingTimes]
                                              ,[videoForUser]
                                              ,[videoTime]
                                              ,[Name]
                                              ,[GradeName]
                                              ,[VideoTypeName]
                                              ,[ChapterName]
                                          FROM [vw_videoInfo]
                                          where videoTypeId=5
                                          and subjectId={0}
                                          order by updateTime desc", subjectId);
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
        /// 高考备战
        /// </summary>
        /// <returns></returns>
        public string Exam_Prepare()
        {
            string sql = string.Format(@"SELECT TOP 6 [id]
                                              ,[subjectId]
                                              ,[gradeId]
                                              ,[videoTypeId]
                                              ,[title]
                                              ,[videocontent]
                                              ,[videoImageUrl]
                                              ,[videoUrl]
                                              ,[videobackImage]
                                              ,[teacherName]
                                              ,[curriculumTime]
                                              ,[classCount]
                                              ,[chapterId]
                                              ,[updateTime]
                                              ,[viewingTimes]
                                              ,[videoForUser]
                                              ,[videoTime]
                                              ,[Name]
                                              ,[GradeName]
                                              ,[VideoTypeName]
                                              ,[ChapterName]
                                          FROM [vw_videoInfo]
                                          where videoTypeId=3
                                          order by updateTime desc");
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

        //视频信息业务
        Maticsoft.BLL.tblvideoInfo videoinfo_bll = new Maticsoft.BLL.tblvideoInfo();

    }
}
