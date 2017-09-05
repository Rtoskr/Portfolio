using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ExamplesController : Controller
    {
        // GET: Examples
        public ActionResult Index()
        {
            return View();
        }

        // GET: ThemeChanger
        public ActionResult ThemeChanger()
        {
            return View();
        }

        // POST: SaveBootstrapTheme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBootstrapTheme(FormCollection formData)
        {
            // We're going to be making config changes here.  We have to create a new Configuration based on our
            // current App.config values.
            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            // Set the appSettings key 'bootstrapTheme' to the selected value from the form.
            config.AppSettings.Settings["bootstrapTheme"].Value = formData["bootstrapTheme"];

            // Save the configuration change.
            config.Save(ConfigurationSaveMode.Modified);
            
            // Refresh the current App.Config with the new values.
            ConfigurationManager.RefreshSection("appSettings");

            // Return to the selector page.  I had this setup as AJAX before, but was having issues performing AJAX refresh
            // of an entire view (including layout.cshtml).
            return RedirectToAction("ThemeChanger", "Examples");
        }

    }
}