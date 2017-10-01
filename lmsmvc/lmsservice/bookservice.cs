using lmsdata;
using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
    class bookservice:Ibookservice
    {
        private Ibookdata data;
        public bookservice(Ibookdata data)
        {
            this.data = data;
        }
        public IEnumerable<book> GetAll()
        {
            return this.data.GetAll();
        }

        public book Get(int id)
        {
            return this.data.Get(id);
        }

        public int insert(book b)
        {
            return this.data.insert(b);
        }

        public int update(book b)
        {
            return this.data.update(b);
        }

        public int delete(int id)
        {
            return this.data.delete(id);
        }
    }
}
