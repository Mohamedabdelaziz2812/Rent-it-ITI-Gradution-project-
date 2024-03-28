using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public class AttributeRepo : IAttributeRepo
    {
        private readonly MyContext context;
        public AttributeRepo(MyContext _context)
        {
            this.context = _context;
        }
        public List<Attributes> GetAll()
        {
            return context.Attributes.ToList(); 
        }

        public Attributes? GetbyId(int id)
        {
            return context.Attributes.FirstOrDefault(a => a.Id == id);
        }
    }
}
