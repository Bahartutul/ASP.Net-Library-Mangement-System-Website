using lmsentity;
using lmsmvc.Models;
using lmsservice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lmsmvc.Controllers
{
    public class bookController : Controller
    {
        Iuserservice uservice = servicefactory.getuserservice();

        // GET: book
        public ActionResult Index()
        {
            Ibookservice service = servicefactory.getbookservice();
            IEnumerable<book> booklist = service.GetAll();
            List<bookmodel> viewlist = new List<bookmodel>();
            foreach (book b in booklist)
            {
                bookmodel book = new bookmodel()
                {
                    id = b.id,
                    serialno = b.serialno,
                    book_name = b.book_name,
                    author = b.author,
                    edition = b.edition,
                    shelf = b.shelf,
                    amount = b.amount
                };
                viewlist.Add(book);
            }
            return View(viewlist);
        }


        [HttpPost]
        public ActionResult Index(string searchString)
        {
            IEnumerable<book> a = service.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                a = from c in a
                    where c.book_name.ToUpper().Contains(searchString.Trim().ToUpper()) || c.author.ToUpper().Contains(searchString.Trim().ToUpper())
                    select c;


                //var det = db.products.ToList();
                List<bookmodel> viewlist = new List<bookmodel>();
                foreach (book b in a)
                {
                    bookmodel book = new bookmodel()
                    {
                        id = b.id,
                        serialno = b.serialno,
                        book_name = b.book_name,
                        author = b.author,
                        edition = b.edition,
                        shelf = b.shelf,
                        amount = b.amount
                    };
                    viewlist.Add(book);
                }

                return View(viewlist);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }



        public ActionResult login()
        {
            ViewBag.message = "";
            return View();
        }
        [HttpPost]
        public ActionResult login(user u)
        {

            var a = uservice.GetAll().Where(b => b.username.Equals(u.username) && b.password.Equals(u.password)).FirstOrDefault();
            if (a != null && a.account_type == "admin")
            {
                return RedirectToAction("Index");
            }
            else if (a != null && a.account_type == "user")
            {
                Session["username"] = a.username;
                Session["userid"] = a.userid;
               
                return RedirectToAction("uPanel");
                
            }


            else
            {
                
                ViewBag.message = "Username and Password not match...";
                return View(u);
            }
        }

        // GET: book/Details/5
        public ActionResult Details(int id)
        {
            Ibookservice service = servicefactory.getbookservice();
            book book = service.Get(id);

            return View(book);
        }

        // GET: book/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: book/Create
        [HttpPost]
        public ActionResult Create(book b)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                Ibookservice service = servicefactory.getbookservice();

                service.insert(b);



                return RedirectToAction("Index");

            }
            else
            {
                return View(b);
            }

        }

        // GET: book/Edit/5
        public ActionResult Edit(int id)
        {
            book b = service.Get(id);
            return View(b);
        }

        // POST: book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, book b)
        {
            if (b.edition != null)
            {
                service.update(b);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }

        }

        // GET: book/Delete/5
        Ibookservice service = servicefactory.getbookservice();
        public ActionResult Delete(int id)
        {

            book b = service.Get(id);
            return View(b);
        }

        // POST: book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, book b)
        {
            service.delete(id);

            // TODO: Add delete logic here

            return RedirectToAction("Index");

        }

        //Get borrow all Details
        public ActionResult aborrowdetails()
        {

            IEnumerable<borrow> borrowlist = bservice.GetAll();
            List<borrowmodel> viewlist = new List<borrowmodel>();
            foreach (borrow b in borrowlist)
            {
                borrowmodel borrow = new borrowmodel()
                {
                    sl=b.sl,
                    userid = b.userid,
                    username = b.username,
                    serialno = b.serialno,
                    book_name = b.book_name,
                    borrow_date = b.borrow_date,
                    return_date = b.return_date



                };
                viewlist.Add(borrow);
            }

            return View(viewlist);
        }

        [HttpPost]
        public ActionResult aborrowdetails(string searchString)
        {
            IEnumerable<borrow> b = bservice.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                b = from c in b
                    where c.username.ToUpper().Contains(searchString.Trim().ToUpper())
                    select c;


                //var det = db.products.ToList();
                List<borrowmodel> viewlist = new List<borrowmodel>();
                foreach (borrow u in b)
                {
                    borrowmodel borrow = new borrowmodel()
                    {
                        sl=u.sl,
                        userid = u.userid,
                        username = u.username,
                        serialno=u.serialno,
                        book_name=u.book_name,
                        borrow_date=u.borrow_date,
                        return_date=u.return_date
                    };
                    viewlist.Add(borrow);
                }

                return View(viewlist);
            }
            else
            {
                return RedirectToAction("aborrowdetails");
            }

        }

        //Get book_return page
        public ActionResult book_return(int id)
        {
            borrow b = bservice.Getbysl(id);
            string a = Convert.ToDateTime(b.return_date).ToShortDateString();
            DateTime dt = Convert.ToDateTime(a).Date;
            DateTime dt1 = DateTime.Today.Date;
            if(dt>dt1)
            {
                ViewBag.date = DateTime.Today.ToShortDateString();
                ViewBag.fine = "0";
                return View(b);
            }
            else
            {
                ViewBag.date = DateTime.Today.ToShortDateString();
                double diff = dt1.Subtract(dt).TotalDays;
                ViewBag.fine = diff*5;
                return View(b);
            }
                              
        }

        [HttpPost]
        public ActionResult book_return(int id,string userid,string username,string sl,string bname,string bdate,string rdate,string ratdate,string fine)
        {
            if (!String.IsNullOrEmpty(userid) && !String.IsNullOrEmpty(username))
            {
                var b = service.GetAll().Where(d => d.serialno == sl && d.book_name == bname).FirstOrDefault();
                Ibookreturnservice brservice = servicefactory.getbookreturnservice();
                bookreturn br = new bookreturn();
                br.userid = Convert.ToInt32(userid);
                br.username = username;
                br.serialno = sl;
                br.book_name = bname;
                br.borrow_date = bdate;
                br.return_date = rdate;
                br.return_at = ratdate;
                br.fine = Convert.ToInt32(fine);
                brservice.insert(br);
                
                b.amount = b.amount + 1;
                service.update(b);

                bservice.delete(id);

                ViewBag.msg = "Return successfully done...!!!";
                return View(br);
            }
            else
            {
                bookreturn br = new bookreturn();
                ViewBag.msg = "Something wrong...!!!";
                return View(br);
            }
        }
     
        //************************************************user(admin panel)********************************************

        //get user_details
        public ActionResult ulist()
        {

            IEnumerable<user> userlist = uservice.GetAll().Where(a => a.account_type == "user");
            List<usermodel> viewlist = new List<usermodel>();
            foreach (user u in userlist)
            {
                usermodel user = new usermodel()
                {
                    userid = u.userid,
                    username = u.username,
                    password = u.password,
                    con_password = u.con_password,
                    gender = u.gender,
                    address = u.address,
                    account_type = u.account_type

                };
                viewlist.Add(user);
            }
            return View(viewlist);
        }

        [HttpPost]
        public ActionResult ulist(string usearchString)
        {
            IEnumerable<user> a = uservice.GetAll().Where(b => b.account_type == "user");

            if (!String.IsNullOrEmpty(usearchString))
            {
                a = from c in a
                    where c.username.ToUpper().Contains(usearchString.Trim().ToUpper()) || c.account_type.ToUpper().Contains(usearchString.Trim().ToUpper())
                    select c;


                //var det = db.products.ToList();
                List<usermodel> viewlist = new List<usermodel>();
                foreach (user u in a)
                {
                    usermodel usr = new usermodel()
                    {
                        userid = u.userid,
                        username = u.username,
                        password = u.password,
                        con_password = u.con_password,
                        gender = u.gender,
                        address = u.address,
                        account_type = u.account_type
                    };
                    viewlist.Add(usr);
                }

                return View(viewlist);
            }
            else
            {
                return RedirectToAction("ulist");
            }

        }
        //get userCreate
        public ActionResult uCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uCreate(user u)
        {
            if (ModelState.IsValid && u.username != null && u.password != null && u.gender != null && u.address != null)
            {
                uservice.insert(u);
                return RedirectToAction("ulist");
            }
            else
            {
                return View(u);
            }
        }
        //get userEdit
        public ActionResult uEdit(int id)
        {
            user u = uservice.Get(id);
            return View(u);

        }
        [HttpPost]
        public ActionResult uEdit(int id, user u)
        {
            
            uservice.update(u);
            return RedirectToAction("ulist");
        }
        //get userdetails
        public ActionResult uDetails(int id)
        {
            user u = uservice.Get(id);


            return View(u);
        }
        //Get delete user
        public ActionResult uDelete(int id)
        {
            user u = uservice.Get(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult uDelete(int id, user u)
        {
            uservice.delete(id);
            return RedirectToAction("ulist");
        }
        //get Singup
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(user u)
        {
            if (ModelState.IsValid && u.username != null && u.password != null && u.gender != null && u.address != null)
            {
                uservice.insert(u);
                ViewBag.message = "Succesfully registered....!!!";
                return View(u);
            }
            else
            {
                return View(u);
            }
        }


        //*******************************************************User Panel*******************************************************
        Iborrowservice bservice = servicefactory.getborrowservice();
        public ActionResult uPanel()
        {
           /* int uid = Convert.ToInt32(userid);
            user u = uservice.Get(uid);*/
           

                Ibookservice service = servicefactory.getbookservice();
                IEnumerable<book> booklist = service.GetAll();
                List<bookmodel> viewlist = new List<bookmodel>();
                foreach (book b in booklist)
                {
                    bookmodel book = new bookmodel()
                    {
                        id = b.id,
                        serialno = b.serialno,
                        book_name = b.book_name,
                        author = b.author,
                        edition = b.edition,
                        shelf = b.shelf,
                        amount = b.amount
                    };
                    viewlist.Add(book);
                }

                return View(viewlist);
      

        }
        [HttpPost]
        public ActionResult uPanel(string searchString)
        {
            IEnumerable<book> a = service.GetAll();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                a = from c in a
                    where c.book_name.ToUpper().Contains(searchString.Trim().ToUpper()) || c.author.ToUpper().Contains(searchString.Trim().ToUpper())
                    select c;


                //var det = db.products.ToList();
                List<bookmodel> viewlist = new List<bookmodel>();
                foreach (book b in a)
                {
                    bookmodel book = new bookmodel()
                    {
                        id = b.id,
                        serialno = b.serialno,
                        book_name = b.book_name,
                        author = b.author,
                        edition = b.edition,
                        shelf = b.shelf,
                        amount = b.amount
                    };
                    viewlist.Add(book);
                }

                return View(viewlist);
            }
            else
            {
                return RedirectToAction("uPanel");
            }

        }

        //borrow page Get
        public ActionResult Borrow(int id)
        {
            book b = service.Get(id);

            ViewBag.date = DateTime.Today.ToShortDateString();
            ViewBag.date7 = DateTime.Today.AddDays(7).ToShortDateString();
            return View(b);
        }

        [HttpPost]
        public ActionResult Borrow(int id,string userid, string username, string sl, string bname, string bdate, string rdate)
        {

            /*  if (!String.IsNullOrEmpty(userid) && !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(sl) && !String.IsNullOrEmpty(bname) &&!String.IsNullOrEmpty(bdate) && !String.IsNullOrEmpty(rdate))
              {*/
            if (!String.IsNullOrEmpty(userid) && !String.IsNullOrEmpty(username))
            {
                book book = service.Get(id);


                int uid = Convert.ToInt32(userid);
                if (bservice.GetAll().Where(c => c.userid == uid).Count() < 3)
                {
                    borrow b = new borrow();
                    b.userid = uid;
                    b.username = username;
                    b.serialno = sl;
                    b.book_name = bname;
                    b.borrow_date = bdate;
                    b.return_date = rdate;
                    book.amount = book.amount - 1;
                    service.update(book);
                    bservice.insert(b);
                    ViewBag.msg = "Borrow book succesfully done...!!!";
                    return View(b);
                }
                else
                {
                    borrow b = new borrow();
                    ViewBag.msg1 = "You can not borrow more then 3 book at a time...!!!";
                    return View(b);
                }
            }
            else
            {

                borrow b = new borrow();
                ViewBag.error = "You must login first to borrow...!!!";
                /*  ViewBag.date = DateTime.Today.ToShortDateString();
                  ViewBag.date7 = DateTime.Today.AddDays(7).ToShortDateString();*/


                return View(b);
            }


            // }
            /* else
        {
            ViewBag.msg = "Not inserted...";
            return View(b);
        }*/
        }

        //user panel to book_details show
        public ActionResult ubDetails(int id)
        {
            Ibookservice service = servicefactory.getbookservice();
            book book = service.Get(id);

            return View(book);
        }

        //Get login id borrow Details
        public ActionResult borrowdetails(int id)
        {

            // var a = uservice.GetAll().Where(b => b.username.Equals(u.username) && b.password.Equals(u.password)).FirstOrDefault();
        /*    if (id)
            {
                IEnumerable<borrow> borrowlist = bservice.GetAll();
                List<borrowmodel> viewlist = new List<borrowmodel>();
                foreach (borrow b in borrowlist)
                {
                    borrowmodel borrow = new borrowmodel()
                    {
                        userid = b.userid,
                        username = b.username,
                        serialno = b.serialno,
                        book_name = b.book_name,
                        borrow_date = b.borrow_date,
                        return_date = b.return_date



                    };
                    viewlist.Add(borrow);

                }
                return View(viewlist);
            }
            else
            {*/
                IEnumerable<borrow> borrowlist = bservice.GetAll().Where(c => c.userid == id);
                List<borrowmodel> viewlist = new List<borrowmodel>();
                foreach (borrow b in borrowlist)
                {
                    borrowmodel borrow = new borrowmodel()
                    {
                        userid = b.userid,
                        username = b.username,
                        serialno = b.serialno,
                        book_name = b.book_name,
                        borrow_date = b.borrow_date,
                        return_date = b.return_date



                    };
                    viewlist.Add(borrow);
                }

                return View(viewlist);
                
           // }
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }
    }
}
