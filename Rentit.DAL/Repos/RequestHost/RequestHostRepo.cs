using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public class RequestHostRepo : IRequestHostRepo
    {
        private readonly MyContext context;
        public RequestHostRepo(MyContext _context)
        {
            this.context = _context;
        }
        public void Add(RequestHost requestHost)
        {
            context.RequestHosts.Add(requestHost);  
        }

        //public IEnumerable<RequestHost> GetAcceptedRequestsWithUserId(int id)
        //{
        //    return context.RequestHosts
        //                    .Where(x => x.UserID == id && x.Request_StateID == 2)
        //                    .ToList();
        //}

        public IEnumerable<RequestHost> GetAll()
        {
            return context.RequestHosts.OrderBy(r=>r.Request_StateID).ToList();
        }

        public RequestHost? GetByID(int id)
        {
            return context.RequestHosts.FirstOrDefault(r=>r.Id == id);  
        }

        //public IEnumerable<RequestHost> GetPendingRequestsWithUserId(int id)
        //{
        //    return context.RequestHosts
        //                    .Where(x => x.UserID == id && x.Request_StateID == 1)
        //                    .ToList();
        //}

        //public IEnumerable<RequestHost> GetRefusedRequestsWithUserId(int id)
        //{
        //   return context.RequestHosts
        //        .Where(x => x.UserID == id && x.Request_StateID==3)
        //        .ToList();
        //}

        //public IEnumerable<RequestHost> GetRequestHostAccecpted()
        //{
        //    return context.RequestHosts
        //        .Where(p=>p.Request_StateID==2)
        //        .ToList();
        //}

        //public IEnumerable<RequestHost> GetRequestHostPending()
        //{
        //    return context.RequestHosts
        //        .Where(p => p.Request_StateID == 1)
        //        .ToList();
        //}

        //public IEnumerable<RequestHost> GetRequestHostRefused()
        //{
        //    return context.RequestHosts
        //        .Where(p => p.Request_StateID == 3)
        //        .ToList();
        //}

        public IEnumerable<RequestHost> GetRequestsWithUserId(int id)
        {
           return context.RequestHosts
                .Where(r=>r.UserID == id)
                .OrderBy(r=>r.Request_StateID)  
                .ToList();    
        }

        public void SaveChanges()
        {
            context.SaveChanges();  
        }

        public void Update(RequestHost requestHost)
        {
            context.RequestHosts.Update(requestHost);
        }
    }
}
