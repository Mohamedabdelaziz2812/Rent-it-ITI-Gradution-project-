using Rentit.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public interface IUserManager
    {
        UserDto GetUserDetails (int id);    
    }
}
