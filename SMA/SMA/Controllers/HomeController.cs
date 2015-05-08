using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMA.CS;
using System.Diagnostics;
namespace SMA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Ozzle Application";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

<<<<<<< HEAD
       
        public RedirectToRouteResult translate(string currentView, string Language,string controller)
=======
      
        public RedirectToRouteResult translate(string currentView, string currentController, string Language)
>>>>>>> origin/master
        {
            GlobalVariables.currentLanguageTrial = Language;
            //Debug.WriteLine("11231231231   --" + Language.ToString());

            GlobalVariables.initVariables();
            //return View(currentView);
<<<<<<< HEAD
            return RedirectToAction(currentView);
        }
      
=======
            return RedirectToAction(currentView, currentController);
        }
       
>>>>>>> origin/master
    }
}