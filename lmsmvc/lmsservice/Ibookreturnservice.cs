using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
   public interface Ibookreturnservice
    {
        IEnumerable<bookreturn> GetAll();
        bookreturn Get(int id);
        int insert(bookreturn b);
        int delete(int id);
    }
}
