using System.ComponentModel.DataAnnotations.Schema;

namespace Rentit.DAL
{
    public class Location
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Building_no { get; set; }
        public string Building_name { get; set; } = string.Empty;
        public string District_name { get; set; } = string.Empty;
        public string Location_url { get; set; } = string.Empty;
        [ForeignKey("Governate")]
        public int GovernateId { get; set; }
        public Governate Governate { get; set; } = null!;
    }
}
