using IMACH_MK_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IMACH_MK_I.Controllers
{
    public class HomeController : Controller
    {
        IMACH_MK_I_DBEntities db = new IMACH_MK_I_DBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //User is the model. and value for returnUrl will be automatically received by this action.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User_LoginModel u)
        {
            if (ModelState.IsValid)
            {
                string strEmail = u.Email;
                string strPassword = u.Pass;

                var User = db.Users.Where(x => x.Email == strEmail.ToUpper() && x.Pass == strPassword).FirstOrDefault();

                //Verify credentials against database in real project
                if (User != null)
                {
                    FormsAuthentication.SetAuthCookie(User.ID.ToString(), true);

                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    ModelState.AddModelError("authenticationError", "User name or Password is wrong. Try it again");
                }
            }
            else
            {
                ModelState.AddModelError("modelStateValidEror", "An Error Occured Please Contact With System Admin !");
            }
            return View(u);
        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}