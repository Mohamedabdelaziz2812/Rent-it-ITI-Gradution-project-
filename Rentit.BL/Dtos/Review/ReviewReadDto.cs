using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos;

public class ReviewReadDto
{
    public string Client_Name { get; set; } = string.Empty;            
    public string Review { get; set; } = string.Empty;
    public string Img_Url { get; set; } = string.Empty;

}
