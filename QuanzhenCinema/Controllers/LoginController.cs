using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QuanzhenCinema.Business;
using QuanzhenCinema.Models;
using System.Web.Script.Serialization;

namespace QuanzhenCinema.Controllers
{
    public class LoginController : Controller
    {
        private Quanzhen db = new Quanzhen();

        public void logOutJudge(string Logon)
        {
            if (Logon == "退出")
            {
                GetUser gu = new GetUser();
                gu.Logout();
                Response.Redirect("~/Login/Index");
            }
        }

        [BasicAuth]
        public ActionResult LogOut()
        {
            logOutJudge("退出");
            return View();
        }

        [BasicAuth]
        public ActionResult IndexUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexUser(string Logon)
        {
            logOutJudge(Logon);
            return View();
        }

        [BasicAuth]
        public ActionResult IndexAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexAdmin(string Logon)
        {
            logOutJudge(Logon);
            return View();
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated) { Response.Redirect("~/Manager"); }
            else
                ViewBag.LoginState = "未登录";
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Manager");
            }
            string id = fc["ID"];
            string pwd = fc["PWD"];
            string sql = "select * from STAFF where ID=" + id;
            List<StaffManage.Schedule_STAFF> staff = db.Database.SqlQuery<StaffManage.Schedule_STAFF>(sql).ToList();

            if (staff.Count == 0 || staff.ElementAt(0).PASSWORD != pwd)
                ViewBag.LoginState = "工号或密码输入错误，请仔细核对后重新输入。";
            else
            {
                UserInfo userinfo = new UserInfo();
                userinfo.ID = int.Parse(id);
                userinfo.PASSWORD = pwd;
                userinfo.POSITION = staff.ElementAt(0).POSITION;
                userinfo.ROLE = staff.ElementAt(0).ROLE;
                string UserData = new JavaScriptSerializer().Serialize(userinfo);
                MyFormsPrincipal<UserInfo>.SignIn(userinfo.ID, userinfo, 100);
                ViewBag.LoginState = HttpContext.User.Identity.Name + "已登录。";
                Response.Redirect(userinfo.ROLE == "admin" ? "~/Manager" : "~/Home");
            }
            return View();
        }
    }
}