using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.DAL
{
    public interface IAttributeRepo
    {
        List<Attributes> GetAll();
        Attributes? GetbyId (int id);     
    }
}
