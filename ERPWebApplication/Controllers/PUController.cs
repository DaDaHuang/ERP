using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWebApplication.Dao;
using PagedList;

namespace ERPWebApplication.Controllers
{
    public class PUController : Controller
    {
        SmallERPEntities db = new SmallERPEntities();
        // GET: 采购模块
        #region 采购订单
        //采购订单
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            var pageNumber = page ?? 1;
            var totalCount = 0;
            var persons = GetPerson(pageNumber, pageSize, ref totalCount);
            return View(db.PUOrder.ToList().ToPagedList(pageNumber, pageSize));
        }
        //StaticPagedList需要将某一页的数据、页码、每页数据的容量、和数据总条目传入，
        //也就是说这时候StaticPagedList不再像PagedList一样承担数据的划分工作，
        //而仅仅承担数据的绑定操作，这样真正起到了分页查询显示的效果，可以提高效率。
        public List<PUOrder> GetPerson(int pageNumber, int pageSize, ref int totalCount)
        {
            var persons = (from p in db.PUOrder orderby p.PUOrderCode descending select p).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            totalCount = db.PUOrder.Count();
            return persons.ToList();
        }

        public ActionResult PUOrderAdd()
        {
            return View(db.BSSupplier.ToList());
        }

        //编辑
        public ActionResult PUOrderMod(string id)
        {
            ViewBag.BSSupplier = db.BSSupplier.ToList();
            return View(db.PUOrder.SingleOrDefault(a => a.PUOrderCode == id));
        }

        public ActionResult PUOrderDel(string id)
        {
            var model = new PUOrder() { PUOrderCode = id };
            db.PUOrder.Attach(model);
            db.PUOrder.Remove(model);
            db.SaveChanges();
            return Redirect("/PU/Index");
        }

        //进行更新或添加的方法。
        [HttpPost]
        public ActionResult PUOrderSave(PUOrder model)//, HttpPostedFileBase file)
        {
            if (model.PUOrderCode !=null)
            {
                db.Entry(model).State = EntityState.Modified;
            }
            else
            {
                db.PUOrder.Add(model);
            }
            db.SaveChanges();
            return Redirect("/PU/Index");
        } 
        #endregion


    }
}