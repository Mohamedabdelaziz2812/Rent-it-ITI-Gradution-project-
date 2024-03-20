using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class PropertyUpdateDto
    {
        public int Id { get; set; }
        public string Property_Name { get; set; } = string.Empty;
        public int Nighly_Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Nums_Guests { get; set; }
        public int Nums_Beds { get; set; }
        public int Nums_Bathrooms { get; set; }
        public int Nums_Bedrooms { get; set; }
        public int PlaceType_ID { get; set; }
        public int PropetyTypeId { get; set; }
        public int StateId { get; set; }
    }
}
