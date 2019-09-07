using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLibrary.DataAccessLayer
{
    public class BookLibraryDBContext : DbContext
    {
        public BookLibraryDBContext() : base("BookLibraryDB")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}