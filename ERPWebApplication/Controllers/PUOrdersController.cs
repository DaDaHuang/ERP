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
    public class PUOrdersController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: PUOrders
        public ActionResult Index()
        {
            var pUOrder = db.PUOrder.Include(p => p.BSSupplier);
            return View(pUOrder.ToList());
        }

        // GET: PUOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUOrder pUOrder = db.PUOrder.Find(id);
            if (pUOrder == null)
            {
                return HttpNotFound();
            }
            return View(pUOrder);
        }

        // GET: PUOrders/Create
        public ActionResult Create()
        {
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName");
            return View();
        }

        // POST: PUOrders/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PUOrderCode,PUOrderDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,RecInvenDate,EmployeeCode,IsFlag")] PUOrder pUOrder)
        {
            if (ModelState.IsValid)
            {
                db.PUOrder.Add(pUOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUOrder.SupplierCode);
            return View(pUOrder);
        }

        // GET: PUOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUOrder pUOrder = db.PUOrder.Find(id);
            if (pUOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUOrder.SupplierCode);
            return View(pUOrder);
        }

        // POST: PUOrders/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PUOrderCode,PUOrderDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,RecInvenDate,EmployeeCode,IsFlag")] PUOrder pUOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUOrder.SupplierCode);
            return View(pUOrder);
        }

        // GET: PUOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUOrder pUOrder = db.PUOrder.Find(id);
            if (pUOrder == null)
            {
                return HttpNotFound();
            }
            return View(pUOrder);
        }

        // POST: PUOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PUOrder pUOrder = db.PUOrder.Find(id);
            db.PUOrder.Remove(pUOrder);
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
