﻿using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kaoxue.Controllers
{
    public class VideoPlayController : Controller
    {
        //
        // GET: /VideoPlay/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取视频信息
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public string GetInformation(int id)
        {
            string sql = string.Format(@"SELECT [id]
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
                                          ,[introduce]
                                          ,[ChapterName]
                                      FROM [vw_videoInfo]
                                      where id={0}",id);
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
        /// 视频观看记录
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string Watching_Record()
        {

            if (Session["UserId"] == null)
                return "0";
            string sql = string.Format(@"SELECT TOP 1000 [id]
                                                  ,[videoId]
                                                  ,[videoName]
                                                  ,[lookUserId]
                                              FROM [tblvideoWatchRecord]
                                              where lookUserId={0}", Session["UserId"].ToString());
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
        /// 视频排行榜
        /// </summary>
        /// <returns></returns>
        public string Video_List()
        {
            string sql = @"SELECT TOP 12 [id]
                                          ,[title]
                                      FROM [vw_videoInfo]
                                      order by viewingTimes desc";
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
        /// 相关推荐
        /// </summary>
        /// <param name="chapterid">章节编号</param>
        /// <returns></returns>
        public string Related_Videos(int chapterid)
        {
            string sql = string.Format(@"SELECT TOP 8 [id]
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
                                                  ,[introduce]
                                                  ,[updateTime]
                                                  ,[viewingTimes]
                                                  ,[videoForUser]
                                                  ,[videoTime]
                                                  ,[name]
                                                  ,[GradeName]
                                                  ,[VideoTypeName]
                                                  ,[chapterName]
                                              FROM [vw_videoInfo]
                                              where chapterId={0}", chapterid);
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
        /// 增加观看次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Add_ViewCounts(int id) 
        {
            if (Session["UserId"] == null)
            {
                return 0;
            }
            string sql = string.Format(@"UPDATE [tblvideoInfo]
                                                       SET 
                                                          [viewingTimes] = [viewingTimes]+1
                                                     WHERE id={0}",id);
            int temp = DbHelperSQL.ExecuteSql(sql);
            return temp;
        }

        /// <summary>
        /// 新增观看记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videoname"></param>
        /// <returns></returns>
        public int Add_Record(int id,string videoname)
        {
            if (Session["UserId"] == null)
            {
                return 0;
            }

            string sql = string.Format(@"INSERT INTO [tblvideoWatchRecord]
                                                               ([videoId]
                                                               ,[videoName]
                                                               ,[lookUserId])
                                                         VALUES(
                                                               {0},
                                                               '{1}',
                                                               {2})",id,videoname,Session["UserId"].ToString());
            int temp = DbHelperSQL.ExecuteSql(sql);
            return temp;
        }
    }
}
