using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class UploadRequestHostDto
    {
        public List<IFormFile> imgs { get; set; } = new();
        public string propertyAdd { get; set; } = null!;
    }
}
