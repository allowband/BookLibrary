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
    [Route("User")]
    public class UserController : Controller
    {
        BookLibraryDBContext _db = new BookLibraryDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakeAnOffer()
        {
            var bookToTake_id_temp = Session["book_id"];
            if(bookToTake_id_temp != null)
            {
                int bookToTake_id = (int)bookToTake_id_temp;
                var bookToTake = _db.Books.FirstOrDefault(bk => bk.Id == bookToTake_id);
                var vm = new OfferViewModel(bookToTake);
                var currentUser = Session["UserProfile"] as User;
                vm.MyBooks = _db.Books.Where(bk => bk.UserId == currentUser.Id).ToList();
                return View(vm);
            }

            return RedirectToAction("HomePage","LoginUser");
        }

        public ActionResult ReplaceBook(int bookiwant_id,int bookimgiving_id)
        {
            var bookIWant = _db.Books.FirstOrDefault(bk => bk.Id == bookiwant_id);
            var bookImGivnig = _db.Books.FirstOrDefault(bk => bk.Id == bookimgiving_id);
            if(bookIWant != null && bookImGivnig != null)
            {
                var my_id = bookImGivnig.UserId;
                var other_id = bookIWant.UserId;
                _db.Books.Find(bookIWant.Id).UserId = my_id;
                _db.Books.Find(bookImGivnig.Id).UserId = other_id;
                _db.SaveChanges();
                return RedirectToAction("HomePage", "Public");
            }
            return RedirectToAction("HomePage", "Public");
        }

        
        
    }
}