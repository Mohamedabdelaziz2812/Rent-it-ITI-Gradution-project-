using System.ComponentModel.DataAnnotations;

namespace Rentit.DAL
{
    public class Governate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Location> Locations { get; set; } = new HashSet<Location>();
    }
}
