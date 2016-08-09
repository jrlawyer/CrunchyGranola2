using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrunchyGranola2.DAL;
using CrunchyGranola2.ViewModels;

namespace CrunchyGranola2.Controllers
{
    public class HomeController : Controller
    {
        private CrunchyGranola2Context db = new CrunchyGranola2Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<DateOfLastPurchaseGroup> data = from customer in db.Customers
                    group customer by customer.DateOfLastPurchase into dateGroup
                    select new DateOfLastPurchaseGroup()
                    {
                        DateOfLastPurchase = dateGroup.Key,
                        CustomerCount = dateGroup.Count()
                    };
            
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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