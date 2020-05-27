using IMACH_MK_I.CustomActionFilters;
using IMACH_MK_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IMACH_MK_I.Controllers
{
    [Authorize]
    [AuthorizationChecker]
    public class AdminController : Controller
    {
        IMACH_MK_I_DBEntities db = new IMACH_MK_I_DBEntities();

        public Users _CurrentUser()
        {
            string uid = User.Identity.Name.ToString();
            return db.Users.Where(x => x.ID.ToString() == uid).FirstOrDefault();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _UserPartial()
        {
            return View(_CurrentUser());
        }

    }
}