using lmsentity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public interface Ibookreturndata
    {
       IEnumerable<bookreturn> GetAll();
       bookreturn Get(int id);
       int insert(bookreturn b);
       int delete(int id);
    }
}
