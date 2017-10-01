using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public interface Iborrowdata
    {
        IEnumerable<borrow> GetAll();
        borrow Get(int id);
        borrow Getbysl(int id);
        int insert(borrow b);
        
        int delete(int id);
    }
}
