using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class RequestHostDto
    {

        public required int UserID { get; set; }

        public required int Request_StateID { get; set; }
        public required string Property_Name { get; set; } = string.Empty;
        public required int Nighly_Price { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required int Nums_Guests { get; set; }
        public required int Nums_Beds { get; set; }
        public required int Nums_Bathrooms { get; set; }
        public required int Nums_Bedrooms { get; set; }

        public LocationAddDto LocationAdd { get; set; } = null!;
        public required int PlaceType_ID { get; set; }

        public required int PropetyTypeId { get; set; }
   
    }
}
