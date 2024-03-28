using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class ImageToAddRequestHostDto
    {
        public string Img_URL { get; set; } = string.Empty;
        public int? Img_order { get; set; }
    }
}
