using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IRequestRentRepo
    {
        IEnumerable<RequestRent> GetAllForAdmin();
        RequestRent? GetByID(int id);
        IEnumerable<RequestRent> GetRequestsRentWithUserId(int id);
        IEnumerable<RequestRent> GetRequestsRentWithHostId(int id);
        void Add(RequestRent requestRent);
        void Update(RequestRent requestRent);
        void SaveChanges();
    }
}
