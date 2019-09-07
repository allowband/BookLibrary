﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models.ViewModel
{
    public class RegisterViewModel
    {
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string State { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}