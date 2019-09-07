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
    public class BookController : Controller
    {
        BookLibraryDBContext _db = new BookLibraryDBContext();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(BookViewModel book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = Session["UserProfile"] as User;
                    book.User = new User(currentUser);
                    book.UserId = book.User.Id;
                    _db.Books.Add(new Models.Book(book));
                    _db.SaveChanges();
                    return RedirectToAction("HomePage", "Public");
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