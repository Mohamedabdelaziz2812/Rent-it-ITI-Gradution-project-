using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Rentit.DAL
{
    public class Propertyy
    {
        public int Id { get; set; }
        public string Property_Name { get; set; } = string.Empty;
        public int Nighly_Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Nums_Guests { get; set; }
        public int Nums_Beds { get; set; }
        public int Nums_Bathrooms { get; set; }
        public int Nums_Bedrooms { get; set; }
        public int Nums_Web_visitors { get; set; }
        [ForeignKey("Location")]
        public int Loc_id { get; set; }
        public Location Location { get; set; } = null!;
        [ForeignKey("Place_Type")]
        public int PlaceType_ID { get; set; }
        public PlaceType Place_Type { get; set; } = null!;
        [ForeignKey("Property_Type")]
        public int PropetyTypeId { get; set; }
        public PropertyType Property_Type { get; set; } = null!;
        [ForeignKey("Property_States")]
        public int StateId { get; set; }
        public PropertyStates Property_States { get; set; } = null!;
        [ForeignKey("User")]
        public int HostId { get; set; }
        public Client User { get; set; } = null!;
        public ICollection<Image> Property_imgs { get; set; } = new HashSet<Image>();
        public ICollection<Attributes> Attributes { get; set; } = new HashSet<Attributes>();
        public ICollection<RequestRent> RequestRents { get; set; } = new HashSet<RequestRent>();
        public ICollection<UserReview> UserReviews { get; set; } = new HashSet<UserReview>();
    }
}
