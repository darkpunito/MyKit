using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRentKit.Controllers
{
    public class HelloWorldController : Controller
    {
        
        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}



        public ActionResult Index()
        {
            return View();
        }

    }
}
