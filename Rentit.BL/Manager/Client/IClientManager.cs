using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public interface IClientManager
    {
        UserDto GetUserDetails (int id);  
        bool AddUser (Client user);
        int SaveChanges();
    }
}
