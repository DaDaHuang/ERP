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
    public class SEOutStoresController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: SEOutStores
        public ActionResult Index()
        {
            return View(db.SEOutStore.ToList());
        }

        // GET: SEOutStores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOutStore sEOutStore = db.SEOutStore.Find(id);
            if (sEOutStore == null)
            {
                return HttpNotFound();
            }
            return View(sEOutStore);
        }

        // GET: SEOutStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEOutStores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEOutCode,SEOutDate,OperatorCode,SEOrderCode,CustomerCode,StoreCode,InvenCode,UnitPrice,SellPrice,Quantity,SEMoney,EmployeeCode,IsFlag")] SEOutStore sEOutStore)
        {
            if (ModelState.IsValid)
            {
                db.SEOutStore.Add(sEOutStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEOutStore);
        }

        // GET: SEOutStores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOutStore sEOutStore = db.SEOutStore.Find(id);
            if (sEOutStore == null)
            {
                return HttpNotFound();
            }
            return View(sEOutStore);
        }

        // POST: SEOutStores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEOutCode,SEOutDate,OperatorCode,SEOrderCode,CustomerCode,StoreCode,InvenCode,UnitPrice,SellPrice,Quantity,SEMoney,EmployeeCode,IsFlag")] SEOutStore sEOutStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEOutStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEOutStore);
        }

        // GET: SEOutStores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEOutStore sEOutStore = db.SEOutStore.Find(id);
            if (sEOutStore == null)
            {
                return HttpNotFound();
            }
            return View(sEOutStore);
        }

        // POST: SEOutStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SEOutStore sEOutStore = db.SEOutStore.Find(id);
            db.SEOutStore.Remove(sEOutStore);
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
