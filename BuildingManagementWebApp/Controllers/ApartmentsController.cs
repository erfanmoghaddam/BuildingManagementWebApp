using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuildingManagementWebApp.Models;

namespace BuildingManagementWebApp.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private BuildingManagementDBEntities db = new BuildingManagementDBEntities();

        // GET: Apartments
        public ActionResult Index()
        {
            var apartments = db.Apartments.Include(a => a.Building).Include(a => a.Tenant);
            return View(apartments.ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(db.Buildings, "BuildingId", "Address");
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "FirstName");
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApartmentId,BuildingId,ApartmentNumber,Rooms,Price,Status,Description,TenantId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingId = new SelectList(db.Buildings, "BuildingId", "Address", apartment.BuildingId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "FirstName", apartment.TenantId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "BuildingId", "Address", apartment.BuildingId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "FirstName", apartment.TenantId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApartmentId,BuildingId,ApartmentNumber,Rooms,Price,Status,Description,TenantId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "BuildingId", "Address", apartment.BuildingId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "FirstName", apartment.TenantId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Apartment apartment = db.Apartments.Find(id);
            db.Apartments.Remove(apartment);
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
