using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lmsmvc.Models
{
    public class borrowmodel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sl { get; set; }
        [Required]
        public int userid { get; set; }
        [Required]
        public string username { get; set; }
        public string serialno { get; set; }
        public string book_name { get; set; }
        public string borrow_date { get; set; }
        public string return_date { get; set; }
     
    }
}