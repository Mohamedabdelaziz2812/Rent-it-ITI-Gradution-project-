using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos;

public class ReviewAddDto
{
    public int id { get; set; }
    public string Review { get; set; } = string.Empty;

}
