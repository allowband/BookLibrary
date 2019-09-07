using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models.ViewModel
{
    public class OfferViewModel
    {
        public Book BookIWant { get; set; }
        public List<Book> MyBooks { get; set; }

        public OfferViewModel()
        {


        }

        public OfferViewModel(Book bookToTake)
        {
            this.BookIWant = bookToTake;
            MyBooks = new List<Book>();
        }

    }
}