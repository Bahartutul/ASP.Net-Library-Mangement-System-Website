using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsentity
{
  public  class bookreturn
    {
          [Key]

      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int sl { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string serialno { get; set; }
        public string book_name { get; set; }
      public string borrow_date { get; set; }
        public string return_date { get; set; }
        public string return_at { get; set; }
        public int fine { get; set; }
    }
}
