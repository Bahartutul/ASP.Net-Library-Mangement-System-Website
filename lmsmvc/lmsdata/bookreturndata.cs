using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
    class bookreturndata:Ibookreturndata
    {
        private bookdbcontext context;
        public bookreturndata(bookdbcontext context)
        {
            this.context = context;
        }
        public IEnumerable<bookreturn> GetAll()
        {
            return this.context.bookreturns.ToList();
        }

        public bookreturn Get(int id)
        {
            return this.context.bookreturns.SingleOrDefault(b => b.userid == id);
        }

        public int insert(bookreturn b)
        {
            this.context.bookreturns.Add(b);
            return this.context.SaveChanges();
        }

        public int delete(int id)
        {
            bookreturn a = this.context.bookreturns.SingleOrDefault(c => c.userid == id);
            context.bookreturns.Remove(a);
            return this.context.SaveChanges();
        }
    }
}
