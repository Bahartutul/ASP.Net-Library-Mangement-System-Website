using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
    class borrowdata:Iborrowdata
    {
        private bookdbcontext context;
        public borrowdata(bookdbcontext context)
        {
            this.context = context;
        }
        public IEnumerable<borrow> GetAll()
        {
           
                return this.context.borrows.ToList();
            
        }

        public lmsentity.borrow Get(int id)
         {
             
                 return this.context.borrows.SingleOrDefault(a => a.userid == id);
             
        }
        public lmsentity.borrow Getbysl(int id)
        {

            return this.context.borrows.SingleOrDefault(a => a.sl == id);

        }

        public int insert(borrow b)
        {
            this.context.borrows.Add(b);
            return this.context.SaveChanges();
        }

        

        public int delete(int id)
        {
            borrow borrow = this.context.borrows.SingleOrDefault(a => a.sl == id);
            this.context.borrows.Remove(borrow);
            return this.context.SaveChanges();
        }
    }
}
