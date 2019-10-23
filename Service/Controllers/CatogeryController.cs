using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Service.Models;

namespace Service.Controllers
{
    public class CatogeryController : Controller
    {
        private Entities db = new Entities();

        // GET: /Catogery/
        public ActionResult Index()
        {
            return View(db.Categeries.ToList());
        }

        public ActionResult GetproviderLIst()
        {
            var providerlist = db.AspNetUsers.Where(p => p.IsProvider == true).ToList();
            if (providerlist != null)
            {
                return View(providerlist);
            }else
            return ViewBag.ProviderMessage("No Provider Yet Registered");
        }
        public ActionResult GetUserList()
        {
            var UserLIst = db.AspNetUsers.Where(p => p.IsProvider == false).ToList();
            if (UserLIst != null)
            {
                return View(UserLIst);
            }
            else
            return ViewBag.Userlist("No User Yet Registered");
        }






        // GET: /Catogery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categery categery = db.Categeries.Find(id);
            if (categery == null)
            {
                return HttpNotFound();
            }
            return View(categery);
        }

        // GET: /Catogery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Catogery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Category,Description")] Categery categery)
        {
            if (ModelState.IsValid)
            {
                db.Categeries.Add(categery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categery);
        }

        // GET: /Catogery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categery categery = db.Categeries.Find(id);
            if (categery == null)
            {
                return HttpNotFound();
            }
            return View(categery);
        }

        // POST: /Catogery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Category,Description")] Categery categery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categery);
        }

        // GET: /Catogery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categery categery = db.Categeries.Find(id);
            if (categery == null)
            {
                return HttpNotFound();
            }
            return View(categery);
        }

        // POST: /Catogery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categery categery = db.Categeries.Find(id);
            db.Categeries.Remove(categery);
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
