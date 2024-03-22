using Rentit.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public interface IRequestHostManger
    {
        bool AddRequestHost(PropertyAddDto propertyAdd);
        bool AcceptHostRequestByAdmin(int requestID);
        bool CancelHostRequestByAdmin(int requestID);
        IEnumerable<RequestHostReadDto> GetAll();

    }
}
