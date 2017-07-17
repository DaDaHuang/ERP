using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERPWebApplication.Dao;

namespace ERPWebApplication.Controllers
{
    public class PUInStoresController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: PUInStores
        public ActionResult Index()
        {
            var pUInStore = db.PUInStore.Include(p => p.BSSupplier);
            return View(pUInStore.ToList());
        }

        // GET: PUInStores/详情/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUInStore pUInStore = db.PUInStore.Find(id);
            if (pUInStore == null)
            {
                return HttpNotFound();
            }
            return View(pUInStore);
        }

        // GET: PUInStores/Create
        public ActionResult Create()
        {
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName");
            return View();
        }

        // POST: PUInStores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PUInCode,PUInDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,PUOrderCode,EmployeeCode,IsFlag")] PUInStore pUInStore)
        {
            if (ModelState.IsValid)
            {
                db.PUInStore.Add(pUInStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUInStore.SupplierCode);
            return View(pUInStore);
        }

        // GET: PUInStores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUInStore pUInStore = db.PUInStore.Find(id);
            if (pUInStore == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUInStore.SupplierCode);
            return View(pUInStore);
        }

        // POST: PUInStores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PUInCode,PUInDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,PUOrderCode,EmployeeCode,IsFlag")] PUInStore pUInStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUInStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUInStore.SupplierCode);
            return View(pUInStore);
        }

        // GET: PUInStores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUInStore pUInStore = db.PUInStore.Find(id);
            if (pUInStore == null)
            {
                return HttpNotFound();
            }
            return View(pUInStore);
        }

        // POST: PUInStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PUInStore pUInStore = db.PUInStore.Find(id);
            db.PUInStore.Remove(pUInStore);
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
