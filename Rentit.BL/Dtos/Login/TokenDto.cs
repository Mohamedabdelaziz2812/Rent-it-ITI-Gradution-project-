using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }        
    }
}
