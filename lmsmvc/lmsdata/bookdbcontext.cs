using lmsentity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public class bookdbcontext:DbContext
    {
       public DbSet<book> books { get; set; }
       public DbSet<user> users { get; set; }
      public DbSet<borrow> borrows { get; set; }
      public DbSet<bookreturn> bookreturns { get; set; }

     // public System.Data.Entity.DbSet<lmsmvc.Models.bookreturnmodel> bookreturnmodels { get; set; }

    //  public System.Data.Entity.DbSet<lmsmvc.Models.bookreturnmodel> bookreturnmodels { get; set; }

      //public System.Data.Entity.DbSet<lmsmvc.Models.borrowmodel> borrowmodels { get; set; }

    //  public System.Data.Entity.DbSet<lmsmvc.Models.borrowmodel> borrowmodels { get; set; }
      // public System.Data.Entity.DbSet<lmsmvc.Models.usermodel> usermodels { get; set; }

      // public System.Data.Entity.DbSet<lmsmvc.Models.usermodel> usermodels { get; set; }

       //public System.Data.Entity.DbSet<lmsmvc.Models.bookmodel> bookmodels { get; set; }

      // public System.Data.Entity.DbSet<lmsmvc.Models.bookmodel> bookmodels { get; set; }

      // public System.Data.Entity.DbSet<lmsmvc.Models.usermodel> usermodels { get; set; }
      // public System.Data.Entity.DbSet<lmsmvc.Models.bookmodel> bookmodels { get; set; }
    }
}
