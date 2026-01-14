 
using System;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Cylsys.Common;
using Cash_Future_MappingSystem.BAL;



namespace CRMITStaffing.CustomHelper
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string returnURL = filterContext.HttpContext.Request.RawUrl;
            var user = UserManager.User;
   
            if(user==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Index" },
                    { "controller", "Login" },
                    { "returnUrl", returnURL}       
                });
            }
            else
            {
                //Helper.WriteLog("Request for insert PageAcesslog !");

                var page_url = returnURL;
                var SessionId = filterContext.HttpContext.Session.SessionID;

                String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                //Helper.WriteLog("PageAcesslog Req IP : " + ip);

                PageAccessLog pageAccessLog = new PageAccessLog();
                pageAccessLog.InsertPageAccessLogsData(page_url, SessionId, ip);


            }
        }
    }

    
}