using lmsdata;
using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
    class borrowservice:Iborrowservice
    {
        private Iborrowdata data;
        public borrowservice(Iborrowdata data)
        {
            this.data = data;
        }
        public IEnumerable<borrow> GetAll()
        {
            return this.data.GetAll();
        }

        public borrow Get(int id)
        {
            return this.data.Get(id);
        }

        public borrow Getbysl(int id)
        {
            return this.data.Getbysl(id);
        }

        public int insert(borrow b)
        {
            return this.data.insert(b);
        }

        public int delete(int id)
        {
            return this.data.delete(id);
        }
    }
}
