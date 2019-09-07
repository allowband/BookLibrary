using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models.ViewModel
{
    public class BookViewModel
    {
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
    }
}