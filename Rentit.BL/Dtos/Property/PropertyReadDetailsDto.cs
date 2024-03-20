using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class PropertyReadDetailsDto
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
        public LocationReadDto location { get; set; } = null!;
        public string placeType { get; set; } = string.Empty;
        public string Property_Type { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int HostId { get; set; }
        public string HostName { get; set; } = string.Empty;

        public List<ImageChildDto> Images { get; set; } = new();
        public List<AttributesChildDto> attributes { get; set; } = new();
    }
}
