using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SettingsService.Context;
using SettingsService.Models;

namespace SettingsService.Controllers
{
    public class SettingForOneQueuesController : Controller
    {
        private SettingContext db = new SettingContext();

        // GET: SettingForOneQueues
        public ActionResult Index()
        {
            return View(db.SettingForOneQueues.ToList());
        }

        // GET: SettingForOneQueues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingForOneQueue settingForOneQueue = db.SettingForOneQueues.Find(id);
            if (settingForOneQueue == null)
            {
                return HttpNotFound();
            }
            return View(settingForOneQueue);
        }

        // GET: SettingForOneQueues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingForOneQueues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Queue")] SettingForOneQueue settingForOneQueue)
        {
            if (ModelState.IsValid)
            {
                db.SettingForOneQueues.Add(settingForOneQueue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(settingForOneQueue);
        }

        // GET: SettingForOneQueues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingForOneQueue settingForOneQueue = db.SettingForOneQueues.Find(id);
            if (settingForOneQueue == null)
            {
                return HttpNotFound();
            }
            return View(settingForOneQueue);
        }

        // POST: SettingForOneQueues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Queue")] SettingForOneQueue settingForOneQueue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settingForOneQueue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(settingForOneQueue);
        }

        // GET: SettingForOneQueues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingForOneQueue settingForOneQueue = db.SettingForOneQueues.Find(id);
            if (settingForOneQueue == null)
            {
                return HttpNotFound();
            }
            return View(settingForOneQueue);
        }

        // POST: SettingForOneQueues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SettingForOneQueue settingForOneQueue = db.SettingForOneQueues.Find(id);
            db.SettingForOneQueues.Remove(settingForOneQueue);
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
