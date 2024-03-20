using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public class GeneralResponse
    {
        public string Message { get; set; }
        public GeneralResponse(string message)
        {
            this.Message = message; 
        }

    }
}
