using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public interface IPropertyManager
    {
        IEnumerable<ListPropertyReadDto> GetAll();
        ListPropertyReadDto? GetById(int id);
        bool Add(int requestID);
        bool Update (PropertyUpdateDto propertyUpdate);
        bool Delete(int id);
        PropertyReadDetailsDto? GetPropertyDetails (int id);
        void AddReview(ReviewAddDto review, int propertyid , int userid);
      

    }
}
