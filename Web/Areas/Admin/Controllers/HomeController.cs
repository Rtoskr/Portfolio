using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: Admin/Home/DoAuth
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoAuth(FormCollection formData)
        {
            if(ConfigurationManager.AppSettings["+AdminPassword"] != formData["adminPassword"])
            {
                ViewBag.ErrorMessage = "Incorrect password specified.";
                return View("Login");
            }
            else
            {
                Session.Add("isAdmin", true);
                return Redirect(formData["redirectRoute"]);
            }
            
        }

        // GET: Admin/Home/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}