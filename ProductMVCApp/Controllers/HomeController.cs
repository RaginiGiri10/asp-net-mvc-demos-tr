using ProductMVCApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCApp.Controllers
{
    public class HomeController : Controller
    {
      
      //  [LogFilter]
        public ActionResult Index()
        {
           
            int x = 5;
            int y = 0;
            int z = x / y;
            return View();
        }

        [HandleError(ExceptionType = typeof(DivideByZeroException), View = "DivideByZero")]
        
        public ActionResult About()
        {
            int x = 5;
            int y = 0;
            int z = x / y;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}