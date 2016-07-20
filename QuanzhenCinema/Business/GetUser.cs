using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace QuanzhenCinema.Business
{
    public class GetUser
    {
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public UserInfo getUser()
        {
            if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                UserInfo data = new JavaScriptSerializer().Deserialize<UserInfo>(Ticket.UserData);
                return data;
            }
            return null;
        }
    }
}