using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanzhenCinema.Models;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Security.Principal;

namespace QuanzhenCinema.Business
{
    public class MyFormsPrincipal<TUserData> : IPrincipal
    where TUserData : class, new()
    {
        private IIdentity _identity;
        private TUserData _userData;

        public static void SignIn(int loginName, UserInfo userData, int expiration)
        {
            if (loginName == 0)
                throw new ArgumentNullException("loginName");
            if (userData == null)
                throw new ArgumentNullException("userData");

            // 1. 把需要保存的用户数据转成一个字符串。
            string data = null;
            if (userData != null)
                data = (new JavaScriptSerializer()).Serialize(userData);

            // 2. 创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, loginName.ToString(), DateTime.Now, DateTime.Now.AddDays(1), true, data);

            // 3. 加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);

            // 4. 根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (expiration > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expiration);

            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            // 5. 写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }

        public static void TrySetUserInfo(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            // 1. 读登录Cookie
            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;

            try
            {
                TUserData userData = null;
                // 2. 解密Cookie值，获取FormsAuthenticationTicket对象
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket != null && string.IsNullOrEmpty(ticket.UserData) == false)
                    // 3. 还原用户数据
                    userData = (new JavaScriptSerializer()).Deserialize<TUserData>(ticket.UserData);

                if (ticket != null && userData != null)
                    // 4. 构造我们的MyFormsPrincipal实例，重新给context.User赋值。
                    context.User = new MyFormsPrincipal<TUserData>(ticket, userData);
            }
            catch { /* 有异常也不要抛出，防止攻击者试探。 */ }
        }

        public MyFormsPrincipal(FormsAuthenticationTicket ticket, TUserData userData)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (userData == null)
                throw new ArgumentNullException("userData");

            _identity = new FormsIdentity(ticket);
            _userData = userData;
        }

        public TUserData UserData
        {
            get { return _userData; }
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public bool IsInRole(string role)
        {
            // 把判断用户组的操作留给UserData去实现。

            IPrincipal principal = _userData as IPrincipal;
            if (principal == null)
                throw new NotImplementedException();
            else
                return principal.IsInRole(role);
        }
    }

    public class UserInfo : IPrincipal
    {
        public int ID;
        public string PASSWORD;
//        public int authority;
        public string POSITION;
        public string ROLE;
        public string NAME;

        // 如果还有其它的用户信息，可以继续添加。

        public override string ToString()
        {
            return string.Format("ID: {0}, PASSWORD: {1}, POSITION: {2}, ROLE: {3}, NAME: {4}",
                ID, PASSWORD, POSITION, ROLE, NAME);
        }

        #region IPrincipal Members
        [ScriptIgnore]
        public IIdentity Identity
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string role)
        {
            if (string.Compare(role, "admin", true) == 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}