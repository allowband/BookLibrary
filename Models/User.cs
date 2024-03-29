﻿using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string State { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public User()
        {
            //Books = new HashSet<Book>();
            Books = new List<Book>();
        }

        public User(RegisterViewModel newUser)
        {
            this.Email = newUser.Email;
            this.Name = newUser.Name;
            this.Password = newUser.Password;
            this.State = newUser.State;
            Books = new List<Book>();
        }

        public User(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Password = user.Password;
            this.State = user.State;
            this.Email = user.Email;
            this.Books = new List<Book>();
            this.Books = user.Books;
        }

    }
}