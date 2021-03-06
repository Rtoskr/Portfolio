﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Migrations;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class HistoryController : Controller
    {
        private SiteDBContext db = new SiteDBContext();

        // GET: Admin/History
        public ActionResult Index()
        {
            return View(db.WorkHistoryList.ToList());
        }

        // GET: Admin/History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistoryList.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // GET: Admin/History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employer,Title,StartDate,EndDate,Description")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.Resumes.FirstOrDefault().WorkHistoryList.Add(workHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workHistory);
        }

        // GET: Admin/History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistoryList.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: Admin/History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employer,Title,StartDate,EndDate,Description")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workHistory);
        }

        // GET: Admin/History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistoryList.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: Admin/History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkHistory workHistory = db.WorkHistoryList.Find(id);
            db.WorkHistoryList.Remove(workHistory);
            db.SaveChanges();
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
