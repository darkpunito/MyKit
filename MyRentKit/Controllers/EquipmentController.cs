using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using MyRentKit.Models;

namespace MyRentKit.Controllers
{
    public class EquipmentController : Controller
    {
        private EquipmentDBContext db = new EquipmentDBContext();

        //
        // GET: /Equipment/

        public ActionResult Index(string equipmentCategory, string searchString)
        {
            var CategoryLst = new List<string>();

            var CategoryQry = from d in db.Equipments
                              orderby d.Category
                              select d.Category;
            CategoryLst.AddRange(CategoryQry.Distinct());
            ViewBag.equipmentCategory = new SelectList(CategoryLst);

            var equipments = from m in db.Equipments
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                equipments = equipments.Where(s => s.Title.Contains(searchString));
            }

            if (string.IsNullOrEmpty(equipmentCategory))
                return View(equipments);
            else
            {
                return View(equipments.Where(x => x.Category == equipmentCategory));
            }
            //return View(db.Equipments.ToList());
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Category,Price,State")]Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipment);
        }

        //
        // GET: /Equipment/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult SearchByIndex(string searchstring)
        //{
        //    var equipments = from m in db.Equipments
        //                     select m;
        //    if(!String.IsNullOrEmpty(searchstring))
        //    {
        //        equipments = equipments.Where(m => m.Title.Contains(searchstring));
        //        return View(equipments);
        //    }

        //    return RedirectToAction("Index");
        //}
        //public ActionResult SearchByIndex(string equipmentCategory, string searchString)
        //{
        //    var CategoryLst = new List<string>();

        //    var CategoryQry = from d in db.Equipments
        //                   orderby d.Category
        //                   select d.Category;
        //    CategoryLst.AddRange(CategoryQry.Distinct());
        //    ViewBag.equipmentCategory = new SelectList(CategoryLst);

        //    var equipments = from m in db.Equipments
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        equipments = equipments.Where(s => s.Title.Contains(searchString));
        //    }

        //    if (string.IsNullOrEmpty(equipmentCategory))
        //        return View(equipments);
        //    else
        //    {
        //        return View(equipments.Where(x => x.Category == equipmentCategory));
        //    }

        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}