using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Migrations;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private SiteDBContext SiteDB = new SiteDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();    
        }

        public ActionResult Resume()
        {
            return View(SiteDB.Resumes.FirstOrDefault());
        }
    }
}