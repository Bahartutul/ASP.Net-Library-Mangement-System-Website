using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public interface Ibookdata
    {
       IEnumerable<book> GetAll();
       book Get(int id);
       
       int insert(book b);
       int update(book b);
       int delete(int id);
    }
}
