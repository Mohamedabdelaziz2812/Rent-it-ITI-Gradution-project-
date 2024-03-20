using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public class RequestRentRepo : IRequestRentRepo
    {
        private readonly MyContext context;

        public RequestRentRepo(MyContext _context)
        {
            this.context = _context;    
        }

        public void Add(RequestRent requestRent)
        {
            context.RequestRents.Add(requestRent);  
        }

        public IEnumerable<RequestRent> GetAllForAdmin()
        {
            return context.RequestRents
                .Include(rr=>rr.User)
                .Include(rr=>rr.Host)
                .Include(rr=>rr.Request_state_Admin)
                .Include(rr=>rr.Request_state_Host)
                .Include(rr=>rr.Property)
                .ThenInclude(rr=>rr.Location)
                .ThenInclude(l=>l.Governate)
                .OrderBy(rr=>rr.Request_StateID_Admin)
                .ToList(); 
        }

        public RequestRent? GetByID(int id)
        {
            return context.RequestRents
                .Include(rr => rr.User)
                .Include(rr => rr.Host)
                .Include(rr => rr.Request_state_Admin)
                .Include(rr => rr.Request_state_Host)
                .Include(rr => rr.Property)
                .ThenInclude(rr => rr.Location)
                .ThenInclude(l => l.Governate)
                .FirstOrDefault(rr=>rr.Id == id);    
        }
        public IEnumerable<RequestRent> GetRequestsRentWithHostId(int id)
        {
            return context.RequestRents
                .Where(rr=>rr.HostID== id)
                .Include(rr => rr.User)
                .Include(rr => rr.Host)
                .Include(rr => rr.Request_state_Admin)
                .Include(rr => rr.Request_state_Host)
                .Include(rr => rr.Property)
                .ThenInclude(rr => rr.Location)
                .ThenInclude(l => l.Governate)
                .OrderBy(rr=>rr.Request_StateID_Host)
                .ToList();  
        }

        public IEnumerable<RequestRent> GetRequestsRentWithUserId(int id)
        {
            return context.RequestRents
                .Where(rr => rr.UserID == id || rr.HostID==id)
                .Include(rr => rr.User)
                .Include(rr => rr.Host)
                .Include(rr => rr.Request_state_Admin)
                .Include(rr => rr.Request_state_Host)
                .Include(rr => rr.Property)
                .ThenInclude(rr => rr.Location)
                .ThenInclude(l => l.Governate)
                .OrderBy(rr => rr.Request_StateID_Host)
                .ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(RequestRent requestRent)
        {
            context.RequestRents.Update(requestRent);
        }
    }
}
