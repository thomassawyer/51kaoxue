using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class DownloadController : Controller
    {
        //
        // GET: /Download/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns>0 代表用户未登录 1 准许下载 2 与绑定IP不符 3 精品资源,该会员级别不够 4 账户余额不足 5 会员余额过期且账户余额不足</returns>
        public string DownLoad(int id,int category)
        {
            #region 验证用户是否登录
            if (Session["UserId"] == null)
                return "0";
            
            #endregion

            string sql = ProductSql(id,category);
            DataSet ds = DbHelperSQL.Query(sql);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            if (dt != null)
            {

                string usql = "select username,id,level,daoqidate,ip from webusers where id='" + Session["UserId"] + "'";
                var uds = DbHelperSQL.Query(usql);
                var udt = uds.Tables[0];
                string userlevel = "", userdaoqi = "", userip = "";
                if (udt != null && udt.Rows.Count > 0)
                {
                    userdaoqi = udt.Rows[0]["daoqidate"].ToString();
                    userlevel = udt.Rows[0]["level"].ToString();
                    userip = udt.Rows[0]["ip"].ToString();
                }


                #region 下载
                var userid = Session["UserId"];
                var neednum = dt.Rows[0]["neednum"].ToString();
                var level = dt.Rows[0]["level"].ToString();
                var name = dt.Rows[0]["name"].ToString();
                var subjectid = dt.Rows[0]["subjectid"].ToString();
                if (userdaoqi != "" && DateTime.Parse(userdaoqi) >= DateTime.Now)
                {
                    if (userlevel == "2" || userlevel == "3")
                    {
                        if (userip.Length == 0)
                        {
                            sql = string.Format("insert into tbldlrecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                            DbHelperSQL.ExecuteSql(sql);
                            return "1";
                        }
                        else
                        {
                            
                            if (this.GetIP() == userip)
                            {
                                sql = string.Format("insert into tbldlrecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                                DbHelperSQL.ExecuteSql(sql);
                                return "1";
                            }
                            else
                            {
                                return "2";;
                            }
                        }
                    }
                    else if (userlevel == "1")
                    {
                        if (dt.Rows[0]["isjing"].ToString() == "1")
                        {
                            return "3";
                        }
                        else
                        {
                            sql = string.Format("insert into tbldlrecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                            DbHelperSQL.ExecuteSql(sql);
                            return "1";
                        }
                    }
                    else
                    {
                        sql = "select accountbalance from tblfinance where userid='" + userid + "'";
                        var fdt = DbHelperSQL.Query(sql).Tables[0];
                        if (fdt != null && fdt.Rows.Count > 0)
                        {
                            try
                            {
                                sql = "select count(id) from tbldlrecord where userid=" + userid + " and fileid=" + id;
                                if (DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString() == "0")
                                {
                                    if (int.Parse(dt.Rows[0]["neednum"].ToString()) <= int.Parse(fdt.Rows[0]["accountbalance"].ToString()))
                                    {
                                        sql = "update tblfinance set accountbalance=accountbalance-" + dt.Rows[0]["neednum"].ToString() + " where userid='" + Session["UserId"] + "'";
                                        DbHelperSQL.ExecuteSql(sql);
                                        sql = "update tblkejian set downloadnum=downloadnum+1 where id=" + id;
                                        DbHelperSQL.ExecuteSql(sql);
                                        sql = string.Format("insert into tbldlrecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                                        DbHelperSQL.ExecuteSql(sql);
                                        sql = string.Format("insert into tblfinancerecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                                        DbHelperSQL.ExecuteSql(sql);
                                        return "1";
                                    }
                                    else
                                    {
                                        return "4";
                                        
                                    }
                                }
                                else
                                    return "1";
                            }
                            catch (Exception ex)
                            { }
                        }
                        else
                        {
                            return "4";
                            
                        }
                    }
                }
                else
                {
                    sql = "select accountbalance from tblfinance where userid='" + userid + "'";
                    var fdt = DbHelperSQL.Query(sql).Tables[0];
                    if (fdt != null && fdt.Rows.Count > 0)
                    {
                        try
                        {
                            sql = "select count(id) from tbldlrecord where userid=" + userid + " and fileid=" + id;
                            if (DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString() == "0")
                            {
                                if (int.Parse(dt.Rows[0]["neednum"].ToString()) <= int.Parse(fdt.Rows[0]["accountbalance"].ToString()))
                                {
                                    sql = "update tblfinance set accountbalance=accountbalance-" + dt.Rows[0]["neednum"].ToString() + " where userid='" + Session["UserId"] + "'";
                                    DbHelperSQL.ExecuteSql(sql);
                                    sql = "update tblkejian set downloadnum=downloadnum+1 where id=" + id;
                                    DbHelperSQL.ExecuteSql(sql);
                                    sql = string.Format("insert into tbldlrecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                                    DbHelperSQL.ExecuteSql(sql);
                                    sql = string.Format("insert into tblfinancerecord(userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userid, category, id, DateTime.Now.ToString(), neednum, level, name, subjectid);
                                    DbHelperSQL.ExecuteSql(sql);
                                    return "1";
                                }
                                else
                                {
                                    return "5";
                                    
                                }
                            }
                            else
                                return "1";
                        }
                        catch (Exception ex)
                        { }
                    }
                    else
                    {
                        return "5";
                        
                    }
                }

                #endregion
            }
            return "";
        }


        /// <summary>
        /// 获取文件详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetInformation(int id,int category)
        {
            string sql = ProductSql(id,category);
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
       /// 获取IP
       /// </summary>
       /// <returns></returns>
        private string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }
        /// <summary>
        /// 构造sql语句
        /// </summary>
        /// <param name="category">类型编号</param>
        /// <returns></returns>
        public string ProductSql(int id,int category)
        {
            string sql = string.Empty;
            switch (category) 
            { 
                case 1:
                    sql = "select level,testname as name,subjectname as subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,schoolid,isjingpin as isjing,subjectid from vw_test where id=" + id;
                    break;
                case 2:
                    sql = "select level,name,subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,isjing,subjectid from vw_kejian where id=" + id;
                    break;
                case 3:
                    sql = "select level,name,subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,isjing,subjectid from vw_jiaoan where id=" + id;
                    break;
                case 4:
                    sql = "select level,name,subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,isjing,subjectid from vw_xuean where id=" + id;
                    break;
                case 5:
                    sql = "select level,name,subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,isjing,subjectid from vw_sucai where id=" + id;
                    break;
                case 6:
                    sql = "select level,name,subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,areaid,isjing,subjectid from vw_tongbu where id=" + id;
                    break;
                case 7:
                    sql = "select level,name,subjectname as subname,areaname,extension,downloadnum,neednum,uploadtime,filesrc,content,subjectid from vw_lunwen where id=" + id;
                    break;
                default:
                    break;
            }
            return sql;
        }

    }
}
