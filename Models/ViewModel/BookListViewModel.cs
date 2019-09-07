using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models.ViewModel
{
    public class BookListViewModel
    {
        public List<Book> Books { get; set; }

        public BookListViewModel()
        {

        }

        public BookListViewModel(List<Book> books)
        {
            this.Books = new List<Book>();
            this.Books = books;
        }
    }
}