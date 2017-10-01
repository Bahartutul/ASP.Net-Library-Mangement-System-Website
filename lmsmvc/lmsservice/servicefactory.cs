using lmsdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
   public abstract class servicefactory
    {
      public static Ibookservice getbookservice()
       {
           return new bookservice(datafactory.getdata());
       }
       public static Iuserservice getuserservice()
       {
           return new userservice(datafactory.getuserdata());
       }
       public static Iborrowservice getborrowservice()
       {
           return new borrowservice(datafactory.getborrowdata());
       }
       public static Ibookreturnservice getbookreturnservice()
       {
           return new bookreturnservice(datafactory.getbookreturndata());
       }
    }
}
