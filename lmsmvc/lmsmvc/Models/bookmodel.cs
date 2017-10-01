﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lmsmvc.Models
{
    public class bookmodel
    {
        public int id { get; set; }
        public string serialno { get; set; }
        public string book_name { get; set; }
        public string author { get; set; }
        [Required(ErrorMessage = "Edition field is required")]
        public string edition { get; set; }
        public int shelf { get; set; }
        public int amount { get; set; }
    }
}