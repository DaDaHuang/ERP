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
    public class SEOrdersController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: SEOrders
        public ActionResult Index()
        {
            return View(db.SEOrder.ToList());
        }

        //GET: SEOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOrder sEOrder = db.SEOrder.Find(id);
            if (sEOrder == null)
            {
                return HttpNotFound();
            }
            return View(sEOrder);
        }

        // GET: SEOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEOrders/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEOrderCode,SEOrderDate,OperatorCode,CustomerCode,StoreCode,InvenCode,SellPrice,Quantity,SEMoney,SenInvenDate,EmployeeCode,IsFlag")] SEOrder sEOrder)
        {
            if (ModelState.IsValid)
            {
                db.SEOrder.Add(sEOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEOrder);
        }

        // GET: SEOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOrder sEOrder = db.SEOrder.Find(id);
            if (sEOrder == null)
            {
                return HttpNotFound();
            }
            return View(sEOrder);
        }

        // POST: SEOrders/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEOrderCode,SEOrderDate,OperatorCode,CustomerCode,StoreCode,InvenCode,SellPrice,Quantity,SEMoney,SenInvenDate,EmployeeCode,IsFlag")] SEOrder sEOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEOrder);
        }

        // GET: SEOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOrder sEOrder = db.SEOrder.Find(id);
            if (sEOrder == null)
            {
                return HttpNotFound();
            }
            return View(sEOrder);
        }

        // POST: SEOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SEOrder sEOrder = db.SEOrder.Find(id);
            db.SEOrder.Remove(sEOrder);
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
