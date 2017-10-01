using lmsentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsdata
{
    class userdata:Iuserdata
    {
        private bookdbcontext context;
        public userdata(bookdbcontext context)
        {
            this.context = context;
        }
        public IEnumerable<user> GetAll()
        {

            return this.context.users.ToList();
        }

        public user Get(int id)
        {
            return this.context.users.SingleOrDefault(a => a.userid == id);
        }

       

      


        int Iuserdata.insert(user u)
        {
            this.context.users.Add(u);
            return this.context.SaveChanges();

        }

        int Iuserdata.update(user u)
        {
            user usr = this.context.users.SingleOrDefault(a => a.userid == u.userid);
            usr.username = u.username;
            usr.password = u.password;
            usr.con_password = u.con_password;
            usr.gender = u.gender;
            usr.address = u.address;
            usr.account_type = u.account_type;

            return this.context.SaveChanges();
        }

        int Iuserdata.delete(int id)
        {
            user usr = this.context.users.SingleOrDefault(a => a.userid == id);
            this.context.users.Remove(usr);
            return this.context.SaveChanges();
        }
    }
}
