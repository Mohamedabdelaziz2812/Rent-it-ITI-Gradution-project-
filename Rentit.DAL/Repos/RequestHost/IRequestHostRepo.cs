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
        //IEnumerable<RequestHost> GetRequestHostPending ();  
        //IEnumerable<RequestHost> GetRequestHostAccecpted ();
        //IEnumerable<RequestHost> GetRequestHostRefused();
        IEnumerable<RequestHost> GetRequestsWithUserId(int id);
        //IEnumerable<RequestHost> GetPendingRequestsWithUserId(int id);
        //IEnumerable<RequestHost> GetAcceptedRequestsWithUserId(int id);
        //IEnumerable<RequestHost> GetRefusedRequestsWithUserId(int id);
        void Add (RequestHost requestHost); 
        void Update (RequestHost requestHost);  
        void SaveChanges ();    

    }
}
