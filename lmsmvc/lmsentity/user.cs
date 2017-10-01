
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsentity
{
   public class user
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }
       [Required]
        public string username { get; set; }
       [Required]
       [StringLength(11, ErrorMessage = "Must be between 3 and 11 characters", MinimumLength = 3)]
        public string password { get; set; }
       [Compare("password")]
       
        public string con_password { get; set; }
       [Required]
        public string gender { get; set; }
       [Required]
        public string address { get; set; }
        public string account_type { get; set; }
       
    }
}
