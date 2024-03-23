using Rentit.BL.Dtos;
using Rentit.DAL;
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
      

        bool AddRequest (RequestRentAddDto item , int propertyid); 
        bool AcceptByHost (int propertyid);
        bool CancelByHost(int propertyid);
        bool AcceptByAdmin(int propertyid);
        bool CancelByAdmin(int propertyid);
    }
}
