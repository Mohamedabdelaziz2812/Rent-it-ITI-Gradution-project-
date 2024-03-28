using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public class ClientRepo : IClientRepo
    {
        private readonly MyContext context;

        public ClientRepo(MyContext _context)
        {
            this.context = _context;    
        }

        public void AddUser(Client user)
        {
            context.Users.Add(user);      
        }
        public void UpdateUser(Client user)
        {
        }

        public Client? GetUserDetails(int id)
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.RequestRents)
                  .ThenInclude(rr => rr.Property)
                    .ThenInclude(p => p.Location)
                .Include(u => u.RequestRents)
                  .ThenInclude(rr => rr.Host)
                .Include(u => u.RequestRents)
                  .ThenInclude(rr => rr.Request_state_Admin)
                .Include(u => u.RequestHosts)
                  .ThenInclude(rh => rh.Place_Type)
                .Include(u => u.RequestHosts)
                  .ThenInclude(rh => rh.Property_Type)
                .Include(u => u.RequestHosts)
                  .ThenInclude(rh => rh.Request_state)
                .Include(u => u.RequestHosts)
                  .ThenInclude(rh => rh.governate)
                .Include(u => u.Properties)
                  .ThenInclude(p => p.Location)
                     .ThenInclude(l => l.Governate)
                .Include(u => u.Properties)
                  .ThenInclude(p => p.Place_Type)
                .Include(u => u.Properties)
                  .ThenInclude(p => p.Property_Type)
                .Include(u => u.Properties)
                  .ThenInclude(p => p.Property_States)
                .Include(u=> u.Properties)  
                  .ThenInclude(u=>u.Property_imgs)
                .Include(u=>u.Properties)   
                  .ThenInclude(u=>u.Attributes_property)
                .FirstOrDefault(u => u.Id == id); 
        }

        public int SaveChanges()
        {
            return context.SaveChanges();  
        }
    }
}
