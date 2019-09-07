using BookLibrary.DataAccessLayer;
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
                        Session["UserProfile"] = real_user;
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
                        //var newUser = new Models.User(user);
                        var newUser = _db.Users.Add(new Models.User(user));
                        _db.SaveChanges();
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        //TempData["CurrentUser"] = real_user;
                        Session["UserProfile"] = newUser;
                        return View("ProfilePage", newUser);
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

        public ActionResult LogOut()
        {
            try
            {
                Session.Clear();
                return View("Login");

            }catch(Exception e)
            {
                throw e;
            }
        }

        public ActionResult ProfilePage(User user)
        {
            if (user.Email != null)
            {
                var books = _db.Books.Where(bk => bk.UserId == user.Id).ToList();
                if (books != null)
                {
                    ViewData["Books"] = books;
                }
                return View(user);


            }
            else
            {
                var currentUser = Session["UserProfile"] as User;
                var books = _db.Books.Where(bk => bk.UserId == currentUser.Id).ToList();
                if (books != null)
                {
                    ViewData["Books"] = books;
                }
                
                return View(currentUser);
            }
            
        }
    }
}
