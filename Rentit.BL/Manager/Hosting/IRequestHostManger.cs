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
        int AddRequestHost(PropertyAddDto propertyAdd);
        int AcceptRequestByAdmin(int requestID);
    }
}
