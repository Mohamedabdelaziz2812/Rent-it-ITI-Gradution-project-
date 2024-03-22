using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentit.DAL
{
    public class Client
    {
        public int Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Img_URL { get; set; } =string.Empty;      
        public DateTime JoinedDate { get; set; }
        public DateTime? Start_HostingDate { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public UserRole Role { get; set; } = null!;
        public ICollection<Propertyy> Properties { get; set; } = new HashSet<Propertyy>();
        public ICollection<RequestRent> RequestRents { get; set; } = new HashSet<RequestRent>();
        public ICollection<RequestHost> RequestHosts { get; set; } = new HashSet<RequestHost>();
        public ICollection<Favourite> Favorites { get; set; } = new HashSet<Favourite>();
    }
}
