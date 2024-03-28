using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IRequestHostRepo
    {
        IEnumerable<RequestHost> GetAll();
        RequestHost? GetByID(int id);
        IEnumerable<RequestHost> GetRequestsWithUserId(int id);
        void Add (RequestHost requestHost); 
        void Update (RequestHost requestHost);  
        void SaveChanges ();
        void AddImagesToRequest(ImgesForRequest imgesrequest);


    }
}
