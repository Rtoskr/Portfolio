using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;

namespace Web.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        // GET: Theme
        public ActionResult Theme()
        {
            return View();
        }

        // GET: Configuration
        public ActionResult Configuration()
        {
            return View();
        }

        // POST: SaveTheme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTheme(FormCollection formData)
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
            return RedirectToAction("Theme", "Settings");
        }

        // POST: Admin/SaveSettings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSettings(FormCollection formInfo)
        {
            // We're going to be making config changes here.  We have to create a new Configuration based on our
            // current App.config values.
            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            foreach (var settingItem in formInfo.AllKeys)
            {
                try
                {
                    if (config.AppSettings.Settings[settingItem].Value != formInfo[settingItem])
                    {
                        try
                        {
                            Trace.TraceInformation(string.Format("Updated {0}. Old Value: {1}, New Value: {2}.", settingItem, ConfigurationManager.AppSettings[settingItem], formInfo[settingItem]));
                            config.AppSettings.Settings[settingItem].Value = formInfo[settingItem];
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                }
            }
            // Save our config changes.
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the running config.
            ConfigurationManager.RefreshSection("appSettings");

            return Content("Settings saved at " + DateTime.Now.AddHours(-4).ToShortTimeString() + ".", "text/html");
        }
    }
}
