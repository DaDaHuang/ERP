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
    public class SEGathersController : Controller
    {
        private SmallERPEntities db = new SmallERPEntities();

        // GET: SEGathers
        public ActionResult Index()
        {
            return View(db.SEGather.ToList());
        }

        // GET: SEGathers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEGather sEGather = db.SEGather.Find(id);
            if (sEGather == null)
            {
                return HttpNotFound();
            }
            return View(sEGather);
        }

        // GET: SEGathers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEGathers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEGatherCode,SEGatherDate,OperatorCode,SEOutCode,SEOutDate,CustomerCode,SEMoney,AccountCode,EmployeeCode,Remark,IsFlag")] SEGather sEGather)
        {
            if (ModelState.IsValid)
            {
                db.SEGather.Add(sEGather);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEGather);
        }

        // GET: SEGathers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEGather sEGather = db.SEGather.Find(id);
            if (sEGather == null)
            {
                return HttpNotFound();
            }
            return View(sEGather);
        }

        // POST: SEGathers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEGatherCode,SEGatherDate,OperatorCode,SEOutCode,SEOutDate,CustomerCode,SEMoney,AccountCode,EmployeeCode,Remark,IsFlag")] SEGather sEGather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEGather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEGather);
        }

        // GET: SEGathers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEGather sEGather = db.SEGather.Find(id);
            if (sEGather == null)
            {
                return HttpNotFound();
            }
            return View(sEGather);
        }

        // POST: SEGathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SEGather sEGather = db.SEGather.Find(id);
            db.SEGather.Remove(sEGather);
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
