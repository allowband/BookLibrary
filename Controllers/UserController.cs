using BookLibrary.DataAccessLayer;
using BookLibrary.Models;
using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    
    public class UserController : Controller
    {
        BookLibraryDBContext _db = new BookLibraryDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakeAnOffer(Book bookToTake)
        {
            if(bookToTake != null)
            {
                var vm = new OfferViewModel(bookToTake);
                var currentUser = Session["UserProfile"] as User;
                vm.MyBooks = _db.Books.Where(bk => bk.UserId == currentUser.Id).ToList();
                return View(vm);
            }

            return RedirectToAction("HomePage","LoginUser");
        }

        
        
    }
}