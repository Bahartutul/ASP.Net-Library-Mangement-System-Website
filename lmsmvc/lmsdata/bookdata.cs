
using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
    class bookdata:Ibookdata
    {
        private  bookdbcontext context;

        public bookdata(bookdbcontext context)
        {
            this.context = context;
        }
        //bookdbcontext context = new bookdbcontext();
        public IEnumerable<book> GetAll()
        {
            return this.context.books.ToList();
        }

        public book Get(int id)
        {
            return this.context.books.SingleOrDefault(b => b.id == id);
            
        }

        public int insert(book b)
        {
            this.context.books.Add(b);
            return this.context.SaveChanges();
        }

        public int update(book b)
        {
            book a = this.context.books.SingleOrDefault(c => c.id == b.id);
            a.serialno = b.serialno;
            a.book_name = b.book_name;
            a.author = b.author;
            a.edition = b.edition;
            a.shelf = b.shelf;
            a.amount = b.amount;
            return this.context.SaveChanges();
        }

        public int delete(int id)
        {
            book a = this.context.books.SingleOrDefault(c => c.id == id);
            context.books.Remove(a);
            return this.context.SaveChanges();
        }
    }
}
