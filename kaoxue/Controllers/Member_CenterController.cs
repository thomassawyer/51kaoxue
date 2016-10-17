using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Maticsoft.DBUtility;

namespace kaoxue.Controllers
{
    public class Member_CenterController : Controller
    {
        //
        // GET: /Member_Center/

        /// <summary>
        /// 用户资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 历史下载记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Download_Record()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Modify_Password()
        {
            return View();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public string GetUserInfo()
        {
            #region 验证用户是否登录
            if (Session["UserId"] == null)
                return "0";

            #endregion

            string sql = "select name,school,mobile,tel,address from webusers where id='" + Session["UserId"] + "'";
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
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public string ClearSession()
        {
            Session["UserId"] = null;
            return "1";
        }

        /// <summary>
        /// 保存用户资料
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var name = Request["name"];
            var school = Request["school"];
            var mobile = Request["mobile"];
            var tel = Request["tel"];
            var address = Request["address"];
            string sql = string.Format("update webusers set name='{0}',school='{1}',mobile='{2}',tel='{3}',address='{4}' where id='{5}'", name, school, mobile, tel, address, Session["UserId"]);
            if (DbHelperSQL.ExecuteSql(sql) > 0)
                return "1";
            else
                return "0";
        }

        /// <summary>
        /// 获取下载记录数据条数
        /// </summary>
        /// <returns></returns>
        public string GetDataCount()
        {
            #region 验证用户是否登录
            if (Session["UserId"] == null)
                return "0";

            #endregion
            string condition = string.Format(" userid={0}",Session["UserId"]);
            string sql = string.Format("select count(1) from tbldlrecord where {0}", condition);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return temp.ToString();
        }

        /// <summary>
        /// 获取下载记录数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            #region 验证用户是否登录
            if (Session["UserId"] == null)
                return "0";

            #endregion
            int pageindex = Convert.ToInt32(Request["pageindex"]);
            int startindex = (pageindex - 1) * 7;
            if (pageindex > 1) 
            {
                startindex = (pageindex - 1) * 7 + 1;
            }
            int endindex = pageindex * 7;
            string condition = string.Format(" userid={0}", Session["UserId"]);

            string sql = string.Format(@"SELECT * FROM 
                                                (  
                                                SELECT ROW_NUMBER() 
                                                OVER (
                                                order by T.dltime desc)AS Row, T.*  from tbldlrecord T  
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
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public string Update_Password()
        {
            #region 验证用户是否登录
            if (Session["UserId"] == null)
                return "3";

            #endregion
            var opwd = Request["oldpass"];
            var npwd = Request["newpass"];
            string sql = "select password from webusers where id='" + Session["UserId"] + "'";
            var ds = DbHelperSQL.Query(sql);
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                if (CommonLib.Comlib.HashCode(opwd) == dt.Rows[0]["password"].ToString())
                {
                    sql = "update webusers set password='" + CommonLib.Comlib.HashCode(npwd) + "' where id='" + Session["UserId"] + "'";
                    int temp = DbHelperSQL.ExecuteSql(sql);
                    if (temp > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }

                }
                else
                    return "2"; //原密码错误
            }
            else
                return "2";//原密码错误
        }
    }
}
