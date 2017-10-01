using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
   public interface Iborrowservice
    {
        IEnumerable<borrow> GetAll();
        borrow Get(int id);
        borrow Getbysl(int id);
        int insert(borrow b);

        int delete(int id);
    }
}
