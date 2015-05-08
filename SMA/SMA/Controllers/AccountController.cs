using SMA.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

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

            if (GlobalMethods.isValidMail(email))
            {
                if (GlobalMethods.isValidPassword(password, passwordConfirmation))
                {
                    if (!GlobalMethods.userNameValidation(userName))
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

        public ActionResult Register()
        {
            ViewBag.ErrorMessage = "";
            return View("Register");
        }
        public ActionResult LogIn()
        {
            return View("LogIn");
        }

    }
}