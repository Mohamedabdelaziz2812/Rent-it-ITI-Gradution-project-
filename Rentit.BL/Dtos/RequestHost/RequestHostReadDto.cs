using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class RequestHostReadDto
    {
        public required int UserID { get; set; }
        public required int Request_StateID { get; set; }
        public required string Request_State {  get; set; } =string.Empty;
        public required string Property_Name { get; set; } = string.Empty;
        public required int Nighly_Price { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required int Nums_Guests { get; set; }
        public required int Nums_Beds { get; set; }
        public required int Nums_Bathrooms { get; set; }
        public required int Nums_Bedrooms { get; set; }
        public required string Street { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required int Building_no { get; set; }
        public required string Building_name { get; set; } = string.Empty;
        public required string District_name { get; set; } = string.Empty;
        public required string Location_url { get; set; } = string.Empty;
        public required int GovernateId { get; set; }
        public required string governate {  get; set; } = string.Empty;     
        public required int PlaceType_ID { get; set; }
        public required string Place_Type { get; set; } = string.Empty;
        public required int PropetyTypeId { get; set; }
        public required string Property_Type{ get; set; } = string.Empty;

    }
}
