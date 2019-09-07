using BookLibrary.DataAccessLayer;
using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    //[Route("/")]
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
                        return RedirectToAction("ProfilePage", "User");
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
                    var real_user = _db.Users.FirstOrDefault(usr => usr.Email == user.Email && usr.Password == user.Password);
                    if (real_user != null)
                    {
                        return RedirectToAction("ProfilePage", "User");
                    }
                    else
                    {
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
    }
}
