using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class RequestRentAddDto
    {
        public int UserId { get; set; }  
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
        public int ServiceFee { get; set; }
        public int NumOfGuests { get; set; }
    }
}
