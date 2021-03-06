﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarApp.Models;

namespace CarApp.Controllers
{
    public class CarController : Controller
    {
        private PostalKingEntities db = new PostalKingEntities();

        // GET: Car
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Make1).Include(c => c.Model1);
            return View(cars.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            ViewBag.make = new SelectList(db.Makes, "Id", "make1");
            ViewBag.model = new SelectList(db.Models, "Id", "model1");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,vinNumber,make,model,engineType,source,arrivalDate,colour,price,year")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.make = new SelectList(db.Makes, "Id", "make1", car.make);
            ViewBag.model = new SelectList(db.Models, "Id", "model1", car.model);
            return View(car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.make = new SelectList(db.Makes, "Id", "make1", car.make);
            ViewBag.model = new SelectList(db.Models, "Id", "model1", car.model);
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,vinNumber,make,model,engineType,source,arrivalDate,colour,price,year")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.make = new SelectList(db.Makes, "Id", "make1", car.make);
            ViewBag.model = new SelectList(db.Models, "Id", "model1", car.model);
            return View(car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
