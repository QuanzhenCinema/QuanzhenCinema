using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using QuanzhenCinema.Business;

namespace QuanzhenCinema
{
    public class BasicAuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public string[] Roles { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Login");     //访问特定页面时，未登录用户强制定位的地址
                return;
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string roles = GetRoles.GetActionRoles(actionName, controllerName);
            if (!string.IsNullOrWhiteSpace(roles))
            {
                this.Roles = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            if (Roles == null || Roles.Length == 0)
            {
                return;
            }
            string str = filterContext.HttpContext.User.Identity.Name;
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated) { }
            else
            {
                StaffManage sm = new StaffManage();
                string realRole = sm.searchRole(str);
                foreach (string role in Roles)
                {
                    if (role == realRole)
                    {
                        return;
                    }
                }
            }
            filterContext.Result = new RedirectResult("/Home");  //访问特定页面时，已登录但无权限用户强制定位的地址
        }
    }
}