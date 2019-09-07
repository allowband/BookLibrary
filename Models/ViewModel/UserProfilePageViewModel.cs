using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models.ViewModel
{
    public class UserProfilePageViewModel
    {
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string State { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<Book> Books { get; set; }

        public UserProfilePageViewModel()
        {

        }

        public UserProfilePageViewModel(User user)
        {
            this.Email = user.Email;
            this.Name = user.Name;
            this.State = user.State;
            this.Books = new List<Book>();
            this.Books = user.Books.ToList();
        }
    }
}