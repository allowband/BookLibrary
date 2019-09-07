using BookLibrary.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Artist { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Book()
        {

        }

        public Book(BookViewModel book)
        {
            this.Title = book.Title;
            this.ReleaseDate = book.ReleaseDate;
            this.Genre = book.Genre;
            this.Artist = book.Artist;
            this.UserId = book.UserId;
        }
    }
}