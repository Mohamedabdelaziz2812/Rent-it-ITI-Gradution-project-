using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IClientRepo
    {
        Client GetUserDetails (int id);  

        void AddUser (Client user);
        int SaveChanges();



    }
}
