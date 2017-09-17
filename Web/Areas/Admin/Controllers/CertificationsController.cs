using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Migrations;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class CertificationsController : Controller
    {
        private SiteDBContext db = new SiteDBContext();

        // GET: Admin/Certifications
        public async Task<ActionResult> Index()
        {
            return View(await db.Certifications.ToListAsync());
        }

        // GET: Admin/Certifications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = await db.Certifications.FindAsync(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // GET: Admin/Certifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Certifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Issuer,LinkUrl")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Resumes.FirstOrDefault().Certifications.Add(certification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(certification);
        }

        // GET: Admin/Certifications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = await db.Certifications.FindAsync(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: Admin/Certifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Issuer,LinkUrl")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(certification);
        }

        // GET: Admin/Certifications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = await db.Certifications.FindAsync(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: Admin/Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Certification certification = await db.Certifications.FindAsync(id);
            db.Certifications.Remove(certification);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
