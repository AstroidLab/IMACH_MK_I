using IMACH_MK_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IMACH_MK_I.CustomActionFilters
{
    public class AuthorizationChecker : ActionFilterAttribute
    {
        IMACH_MK_I_DBEntities db = new IMACH_MK_I_DBEntities();
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string UserID = HttpContext.Current.User.Identity.Name.ToString();
            var User = db.Users.Where(x => x.ID.ToString() == UserID).FirstOrDefault();
            string AdminAuthID = "298e3aee-ba95-4889-83a2-3d71ee80db46";
            if (User !=null)
            {
                if (User.Authorizations.Where(x=>x.ID.ToString() == AdminAuthID).FirstOrDefault() == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Home/Logout");
                }
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Home/Logout");
            }
        }
    }
}