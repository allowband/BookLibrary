using BookLibrary.DataAccessLayer;
using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class PublicController : Controller
    {
        BookLibraryDBContext _db = new BookLibraryDBContext();
        // GET: Public
        public ActionResult HomePage()
        {
            //BookListViewModel vm = new BookListViewModel(_db.Books.ToList());
            return View(_db.Books.ToList());
        }
    }
}