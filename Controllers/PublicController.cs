using BookLibrary.DataAccessLayer;
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
            return View();
        }
    }
}