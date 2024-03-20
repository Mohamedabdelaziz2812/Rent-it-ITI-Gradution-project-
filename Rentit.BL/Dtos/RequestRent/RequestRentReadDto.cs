using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class RequestRentReadDto
    {
        public int UsertId { get; set; }   
        public string UserName { get; set; } = string.Empty;    
        public int HostId { get; set; } 
        public string HostName { get; set; } = string.Empty;
        public int PorpertyID { get; set; }
        public string PropertyName {  get; set; } = string.Empty;   
        public string Street { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;    
        public string City { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }   
        public DateTime CheckOutDate { get; set;}
        public int Duration { get; set; }   
        public int RequestStateID {  get; set; }    
        public string RequestStateName { get; set; } = string.Empty;
        public double Nightly_price { get; set; }   
        public double Service_Fees { get; set; }    
        public double Total_price { get; set;}
    }
}
