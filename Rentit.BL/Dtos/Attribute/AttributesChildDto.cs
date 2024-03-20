using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class AttributesChildDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Icon_Url { get; set; } = string.Empty;
    }
}
