using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IUserRepo
    {
        User GetUserDetails (int id);  
        

    }
}
