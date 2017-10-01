using lmsdata;
using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsservice
{
    class userservice:Iuserservice
    {
        private Iuserdata data;

        public userservice(Iuserdata data)
        {
            this.data = data;
        }
        public IEnumerable<user> GetAll()
        {
            return this.data.GetAll();
        }

        public user Get(int id)
        {
            return this.data.Get(id);
        }

        public int insert(user u)
        {
            return this.data.insert(u);
        }

        public int update(user u)
        {
            return this.data.update(u);
        }

        public int delete(int id)
        {
            return this.data.delete(id);
        }
    }
}
