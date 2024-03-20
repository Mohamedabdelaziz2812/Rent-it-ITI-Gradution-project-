using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class ImageChildDto
    {
        public int Id { get; set; }
        public string Img_URL { get; set; } = string.Empty;
        public int? Img_order { get; set; }
    }
}
