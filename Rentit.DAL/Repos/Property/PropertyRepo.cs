using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public class PropertyRepo : IPropertyRepo
    {
        private readonly MyContext context;
        public PropertyRepo(MyContext _context)
        {
             this.context= _context;
        }
        public void Add(Propertyy property)
        {
            context.Properties.Add(property);
        }
        public void AddLocation(Location location)
        {
           context.Locations.Add(location);
        }


        public void Delete(Propertyy property)
        {
           context.Properties.Remove(property); 
        }
        public IEnumerable<Propertyy> GetAll()
        {
            return context.Properties
                .Include(p=>p.Place_Type)
                .Include(p => p.Property_Type)
                .Include(p=>p.User)
                .Include(p=>p.Property_States)
                .Include(p => p.Property_imgs)
                .Include(p => p.Attributes_property)
                .Include(p=>p.RequestRents)
                .Include(p=>p.Location)
                .ThenInclude(x=>x.Governate)
                .OrderByDescending(p=>p.Nums_Web_visitors);
        }
        public Propertyy? GetByID(int id)
        {
           return context.Properties.FirstOrDefault(p => p.Id == id);       
        }
        public IEnumerable<Propertyy> GetByStates(int state)
        {
            return context.Properties.Where(p => p.StateId == state).ToList();
        }
        public IEnumerable<Propertyy> GetPropertiesForUser(int id)
        {
            return context.Properties.Where(p=>p.HostId == id).ToList();    
        }
        public Propertyy? GetPropertyWithImagesAndAttributs(int id)
        {
           return context.Properties
                .Include(p=>p.Property_imgs)
                .Include(p=>p.Place_Type)
                .Include(p=>p.Attributes_property)
                .Include(p=>p.Property_Type)
                .Include(p=>p.User)
                .Include(p=>p.Property_States)
                .Include(p=>p.Location)
                .ThenInclude(x => x.Governate)
                .Include(p=>p.UserReviews)
                .FirstOrDefault(p=>p.Id == id);    
        }


        public int SaveChanges()
        {
             return context.SaveChanges();  
        }
        public void Update(Propertyy property)
        {
            context.Properties.Update(property);   
        }
        public void AddReview(UserReview review)
        {
            context.Set<UserReview>().Add(review);
        }
    }
}
