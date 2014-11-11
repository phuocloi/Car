using CarRentalWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalWebService.Controllers
{
    public class DashBoardController : Controller
    {
        private DbContextModel db = new DbContextModel();
        // GET: DashBoard
        public ActionResult Index()
        {
            ////var gettop = (from p in db.Reviews
            ////              orderby p.Id descending
            ////              select p).Skip(0).Take(10).ToList();
            ////return View(gettop);
            ////return View();
            ////var orders = from od in db.Requests
            ////             group od by od.Model_Id into OD
            ////             orderby OD.Key
            ////             select new
            ////             {
            ////                 Product = OD.Count()
            ////             };
            //int dem = 0;
            
            //List<String> ten = new List<String>();
            //var a = (from r in db.Requests orderby r.Id descending select r).ToList();

            //foreach (Request b in a)
            //{
            //    CarModel c = (from md in db.CarModels where md.Id == b.Model_Id select md).FirstOrDefault();
            //    dem++;
            //    ten.Add(c.Name);
            //    //bool ok = db.CarModels.Any(m=>m.Id==b.Model_Id);
            //    //if (ok)
            //    //{
            //    //    dem++;
            //    //    ten.Add(b.Model.Name);
            //    //}
           
            return View();
        }
        public ActionResult Test()
        {
            var a = from m in db.CarModels
                    select new
                    {
                        ma = from r in db.Requests group r by r.Model_Id into gr where m.Id == gr.Key select gr.Key,
                        ten = m.Name,
                        solanthue = (from r in db.Requests group r by r.Model_Id into gr where m.Id == gr.Key select gr.Key).Count()
                    };

            //}
            //ViewBag.Dem = dem.ToString();
            //ViewBag.Brand = ten;
            ViewBag.a = a;
            return View(a);
        }

        // GET: DashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
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

        // GET: DashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Edit/5
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

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
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

        //Top 10 Comment

        public ActionResult _GetTop()
        {
            //var gettop = db.Reviews.LastOrDefault();
            var gettop = (from p in db.Reviews
                          orderby p.Id descending
                          select p).Skip(0).Take(10).ToList();
            return View(gettop);
        }

        public ActionResult GetTopCar()
        {
            //var gettop = db.Reviews.LastOrDefault();
            var gettop = (from p in db.Requests
                          orderby p.Id descending
                          select p).Skip(0).Take(10).ToList();
            return View(gettop);

            
        }

    }
}
