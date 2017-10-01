using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
   public interface Iuserdata
    {
       IEnumerable<user> GetAll();
       user Get(int id);
       int insert(user u);
       int update(user u);
       int delete(int id);
    }
}
