using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public abstract class datafactory
    {
       public static Ibookdata getdata()
       {
           return new bookdata(new bookdbcontext());
       }
       public static Iuserdata getuserdata()
       {
           return new userdata(new bookdbcontext());

       }
       public static Iborrowdata getborrowdata()
       {
           return new borrowdata(new bookdbcontext());
       }
       public static Ibookreturndata getbookreturndata()
       {
           return new bookreturndata(new bookdbcontext());
       }
    }
}
