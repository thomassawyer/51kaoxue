using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.DBUtility;
using System.Data;

namespace kaoxue.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string UserNameIsExists(string username)
        {
            string sql = string.Format("select count(1) from webusers where username='{0}'", username);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            if (temp > 0)
                return "1";
            else
                return "0";
        }


        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string ValidateUsernameAndPassword(string username,string password)
        {
            password = CommonLib.Comlib.HashCode(password); 
            string sql = string.Format("select count(1) from webusers where username='{0}' and password='{1}'", username,password);
            int temp = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            if (temp > 0)
            {
                sql = string.Format("select * from webusers where username='{0}' and password='{1}'", username, password);
                DataSet ds = DbHelperSQL.Query(sql);
                Session["UserName"] = username;
                Session["UserId"] = ds.Tables[0].Rows[0]["id"];
                return "1";
            }
            else
            {
                return "0";
            }
                
        }
    }
}
