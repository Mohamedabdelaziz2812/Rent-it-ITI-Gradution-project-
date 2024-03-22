using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public record RegisterDto
    {
        public string UserName {  get; init; }  = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Email { get; init; }   =string.Empty;
        public string FName { get; init; } = string.Empty;
        public string LName { get; init; } = string.Empty;
    }
}
