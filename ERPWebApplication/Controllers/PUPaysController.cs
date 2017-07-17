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
    public class PUPaysController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: PUPays
        public ActionResult Index()
        {
            var pUPay = db.PUPay.Include(p => p.BSSupplier);
            return View(pUPay.ToList());
        }

        // GET: PUPays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUPay pUPay = db.PUPay.Find(id);
            if (pUPay == null)
            {
                return HttpNotFound();
            }
            return View(pUPay);
        }

        // GET: PUPays/Create
        public ActionResult Create()
        {
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName");
            return View();
        }

        // POST: PUPays/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PUPayCode,PUPayDate,OperatorCode,PUInCode,PUInDate,SupplierCode,PUMoney,AccountCode,EmployeeCode,Remark,IsFlag")] PUPay pUPay)
        {
            if (ModelState.IsValid)
            {
                db.PUPay.Add(pUPay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUPay.SupplierCode);
            return View(pUPay);
        }

        // GET: PUPays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUPay pUPay = db.PUPay.Find(id);
            if (pUPay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUPay.SupplierCode);
            return View(pUPay);
        }

        // POST: PUPays/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PUPayCode,PUPayDate,OperatorCode,PUInCode,PUInDate,SupplierCode,PUMoney,AccountCode,EmployeeCode,Remark,IsFlag")] PUPay pUPay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUPay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierCode = new SelectList(db.BSSupplier, "SupplierCode", "SupplierName", pUPay.SupplierCode);
            return View(pUPay);
        }

        // GET: PUPays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUPay pUPay = db.PUPay.Find(id);
            if (pUPay == null)
            {
                return HttpNotFound();
            }
            return View(pUPay);
        }

        // POST: PUPays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PUPay pUPay = db.PUPay.Find(id);
            db.PUPay.Remove(pUPay);
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
