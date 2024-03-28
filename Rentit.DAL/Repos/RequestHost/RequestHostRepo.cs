using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<RequestHost> GetAll()
        {
            return context.RequestHosts
                .Include(r=>r.Request_state)
                .Include(r=>r.User)
                .Include(r=>r.governate)
                .Include(r=>r.Place_Type)
                .Include(r=>r.Property_Type)
                .OrderBy(r=>r.Request_StateID).ToList();
        }

        public RequestHost? GetByID(int id)
        {
            return context.RequestHosts.Include(r=>r.Imgs).Include(r=>r.Attributes_requests).FirstOrDefault(r=>r.Id == id);  
        }
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
        public void AddImagesToRequest(ImgesForRequest imgesrequest)
        {
            context.ImgesForRequests.Add(imgesrequest);
        }
    }
}
