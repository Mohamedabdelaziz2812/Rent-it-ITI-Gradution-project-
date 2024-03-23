using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IPropertyRepo
    {
        IEnumerable<Propertyy> GetAll();
        Propertyy? GetByID(int id);  
        IEnumerable<Propertyy> GetByStates(int state);
        void Add(Propertyy property);
        void AddLocation(Location location);    
        void Update(Propertyy property);    
        void Delete(Propertyy property);
        int SaveChanges();
        Propertyy? GetPropertyWithImagesAndAttributs(int id);
        IEnumerable<Propertyy> GetPropertiesForUser(int id);
        void AddReview(UserReview review);

    }
}
