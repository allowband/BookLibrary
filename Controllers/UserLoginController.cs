﻿using BookLibrary.DataAccessLayer;
using BookLibrary.Models;
using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookLibrary.Controllers
{
    //[Route("/")]
    [AllowAnonymous]
    public class UserLoginController : Controller
    {
        private BookLibraryDBContext _db = new BookLibraryDBContext();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var real_user = _db.Users.FirstOrDefault(usr => usr.Email == user.Email && usr.Password == user.Password);
                    if(real_user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        //TempData["CurrentUser"] = real_user;
                        //return RedirectToAction("ProfilePage", "User");
                        return View("ProfilePage", real_user);
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();

            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var real_user = _db.Users.FirstOrDefault(usr => usr.Email == user.Email);
                    if (real_user == null)
                    {
                        //user does not excists
                        //you can regirster
                        _db.Users.Add(new Models.User(user));
                        _db.SaveChanges();
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        //TempData["CurrentUser"] = real_user;
                        return View("ProfilePage", real_user);
                    }
                    else
                    {
                        //user with email excists
                        return View();
                    }
                }
                return View();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ActionResult ProfilePage(User user)
        {
            return View(user);
        }
    }
}
