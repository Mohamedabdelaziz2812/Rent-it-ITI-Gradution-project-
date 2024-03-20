using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class LocationAddDto
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Building_no { get; set; }
        public string Building_name { get; set; } = string.Empty;
        public string District_name { get; set; } = string.Empty;
        public string Location_url { get; set; } = string.Empty;
        public int GovernateId { get; set; }
    }
}
