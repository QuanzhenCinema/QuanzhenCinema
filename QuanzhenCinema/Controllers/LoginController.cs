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
                Response.Redirect("~/Login/Login");
            }
        }

        [BasicAuth]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Logon)
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

        public ActionResult Login()
        {
            if (Request.IsAuthenticated) { Response.Redirect("~/Login/Index"); }
            else
            ViewBag.LoginState = "未登录";
            return View();
        }

        [HttpPost]
     //[ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection fc)
        {
            string id = fc["ID"];
            string pwd = fc["PWD"];
            string sql = "select * from STAFF where ID=" + id;
            List<StaffManage.Schedule_STAFF> staff = db.Database.SqlQuery<StaffManage.Schedule_STAFF>(sql).ToList();
            if (staff.Count == 0)
                ViewBag.LoginState = "不存在该用户。";
            else if (staff.ElementAt(0).PASSWORD != pwd)
                ViewBag.LoginState = "密码输入错误。";
            else
            {
                UserInfo userinfo = new UserInfo();
                userinfo.ID = int.Parse(id);
                userinfo.PASSWORD = pwd;
                userinfo.POSITION = staff.ElementAt(0).POSITION;
                userinfo.ROLE = staff.ElementAt(0).ROLE;
                string UserData = new JavaScriptSerializer().Serialize(userinfo);
                MyFormsPrincipal<UserInfo>.SignIn(userinfo.ID, userinfo, 100);                
                ViewBag.LoginState = HttpContext.User.Identity.Name+ "已登录。";               
                Response.Redirect(userinfo.ROLE == "admin" ? "~/Login/IndexAdmin" : "~/Login/Index");
            }
            return View();
        }
    }
}