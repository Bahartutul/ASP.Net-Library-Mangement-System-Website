using lmsentity;
using lmsmvc.Models;
using lmsservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lmsmvc.Controllers
{
    public class reportController : Controller
    {
        // GET: report
        public ActionResult Index()
        {
            Ibookreturnservice service = servicefactory.getbookreturnservice();
            var users = service.GetAll().Where(d=>Convert.ToDateTime( d.return_at)>=Convert.ToDateTime(d.return_date)) .OrderBy(d=>d.return_at).Take(3);
            //GroupBy(d => d.userid).Max()
        //   IEnumerable< bookreturn> users = service.GetAll().Where(a => a.userid).Count;
            List<bookreturnmodel> viewlist = new List<bookreturnmodel>();
            foreach (bookreturn u in users)
            {
                bookreturnmodel user = new bookreturnmodel()
                {
                    userid = u.userid,
                    username = u.username,
                    serialno=u.serialno,
                    book_name=u.book_name,
                    borrow_date=u.borrow_date,
                    return_date=u.return_date,
                    return_at=u.return_at,
                    fine=u.fine

                };
                viewlist.Add(user);
            }
            return View(viewlist);
           
        }

      /*  public ActionResult report2()
        {
            Ibookreturnservice service = servicefactory.getbookreturnservice();
            var users = service. GetAll(). GroupBy(d => d.userid).Max();
            //GroupBy(d => d.userid).Max()
            //   IEnumerable< bookreturn> users = service.GetAll().Where(a => a.userid).Count;
            List<bookreturnmodel> viewlist = new List<bookreturnmodel>();
            foreach (bookreturn u in users)
            {
                bookreturnmodel user = new bookreturnmodel()
                {
                    userid = u.userid,
                    username = u.username,
                    serialno = u.serialno,
                    book_name = u.book_name,
                    borrow_date = u.borrow_date,
                    return_date = u.return_date,
                    return_at = u.return_at,
                    fine = u.fine

                };
                viewlist.Add(user);
            }
            return View(viewlist);

        }*/
        Iuserservice uservice = servicefactory.getuserservice();
        public ActionResult warnmsg(int id)
        {
            user u = uservice.Get(id);

            return View(u);
        }
        // GET: report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
