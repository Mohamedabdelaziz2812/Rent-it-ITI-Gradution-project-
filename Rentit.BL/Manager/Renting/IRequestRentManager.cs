using Rentit.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public interface IRequestRentManager
    {
        IEnumerable<RequestRentReadDto> GetAllForAdmin();
        IEnumerable<RequestRentReadDto> GetAllForUser(int id);
        IEnumerable<RequestRentReadDto> GetAllForHost(int id);
      

        int AddRequest (RequestRentAddDto item , int propertyid); 
        int AcceptByHost (int requestid);
        int AcceptByAdmin(int requestid);
    }
}
