using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentit.DAL
{
    public class RequestHost
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public Client User { get; set; } = null!;
        [ForeignKey("Request_state")]
        public int Request_StateID { get; set; }
        public RequestState Request_state { get; set; } = null!;
        public string Property_Name { get; set; } = string.Empty;
        public int Nighly_Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Nums_Guests { get; set; }
        public int Nums_Beds { get; set; }
        public int Nums_Bathrooms { get; set; }
        public int Nums_Bedrooms { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Building_no { get; set; }
        public string Building_name { get; set; } = string.Empty;
        public string District_name { get; set; } = string.Empty;
        public string Location_url { get; set; } = string.Empty;
        [ForeignKey("governate")]
        public int GovernateId { get; set; }
        public Governate governate { get; set; }=null!; 

        [ForeignKey("Place_Type")]
        public int PlaceType_ID { get; set; }
        public PlaceType Place_Type { get; set; } = null!;
        [ForeignKey("Property_Type")]
        public int PropetyTypeId { get; set; }
        public string Message {  get; set; } = string.Empty;    
        public PropertyType Property_Type { get; set; } = null!;
        public ICollection<ImgesForRequest> Imgs { get; set; } = new HashSet<ImgesForRequest>();
        public ICollection<Attributes> Attributes_requests { get; set; } = new HashSet<Attributes>();
    }
}
