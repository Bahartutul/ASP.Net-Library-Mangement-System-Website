using lmsdata;
using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
    class bookreturnservice:Ibookreturnservice
    {
        private Ibookreturndata data;
        public bookreturnservice(Ibookreturndata data)
        {
            this.data = data;
        }
        public IEnumerable<bookreturn> GetAll()
        {
            return this.data.GetAll();
        }

        public bookreturn Get(int id)
        {
            return this.data.Get(id);
        }

        public int insert(bookreturn b)
        {
            return this.data.insert(b);
        }

        public int delete(int id)
        {
            return this.data.delete(id);
        }
    }
}
