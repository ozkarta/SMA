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
<<<<<<< HEAD
<<<<<<< HEAD
       
        public RedirectToRouteResult translate(string currentView, string Language,string controller)
=======
      
        public RedirectToRouteResult translate(string currentView, string currentController, string Language)
>>>>>>> origin/master
=======
=======
>>>>>>> parent of 15be318... 9:38_5.6.2015
        public ActionResult Register()
        {
            ViewBag.ErrorMessage = "";
            return View("Register");
        }
        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        public RedirectToRouteResult translate(string currentView, string Language)
<<<<<<< HEAD
>>>>>>> origin/master
=======
>>>>>>> parent of 15be318... 9:38_5.6.2015
        {
            GlobalVariables.currentLanguageTrial = Language;
            //Debug.WriteLine("11231231231   --" + Language.ToString());

            GlobalVariables.initVariables();
            //return View(currentView);
<<<<<<< HEAD
            return RedirectToAction(currentView);
        }
<<<<<<< HEAD
<<<<<<< HEAD
      
=======
            return RedirectToAction(currentView, currentController);
        }
       
>>>>>>> origin/master
=======
=======
>>>>>>> parent of 15be318... 9:38_5.6.2015
        [HttpPost]
        public ActionResult RegisterValidation()
        {
            
            string defaultLanguage = Request["defaultLanguage"].ToString();
            string userName = Request["user_name"].ToString();
            string firstName = Request["first_name"].ToString();
            string lastName = Request["last_name"].ToString();
            string phone = Request["phone"].ToString();
            string email = Request["email"].ToString();
            string password = Request["password"].ToString();
            string passwordConfirmation = Request["password_confirmation"].ToString();
            
            if(GlobalMethods.isValidMail(email))
            {
                if (GlobalMethods.isValidPassword(password, passwordConfirmation))
                {
                   if(!GlobalMethods.userNameValidation(userName))
                   {
                      
                       if (GlobalMethods.registerUser(defaultLanguage, userName, firstName, lastName, phone, email, password))
                       {
                           ViewBag.ErrorMessage = "";
                           return View("RegisterValidation");
                       }
                       else
                       {
                           ViewBag.ErrorMessage = "There was error registerring the user, Please try later.";
                           return View("Register");   
                       }
                       
                   }
                   else
                   {
                        ViewBag.ErrorMessage = "User name you entered already exists";
                        return View("Register");
                   }
                }
                else
                {
                    ViewBag.ErrorMessage = "The Password is incorrect";
                    return View("Register");
                }
                
            }
            else
            {
                ViewBag.ErrorMessage = "The Mail Is Incorrect";
                return View("Register");
            }
        }


        public ActionResult LogInValidation()
        {
            return View("LogInValidation");
        }
<<<<<<< HEAD
>>>>>>> origin/master
=======
>>>>>>> parent of 15be318... 9:38_5.6.2015
    }
}