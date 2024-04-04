using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class RequestRentReadDto
    {
        public required int id {  get; set; }   
        public required int UserId { get; set; }   
        public required string UserName { get; set; } = string.Empty;    
        public required int HostId { get; set; } 
        public required string HostName { get; set; } = string.Empty;
        public required int PorpertyID { get; set; }
        public required string Property_img { get; set; }= string.Empty;
        public required string PropertyName {  get; set; } = string.Empty;   
        public required string Street { get; set; } = string.Empty;
        public required string District { get; set; } = string.Empty;    
        public required string City { get; set; } = string.Empty;
        public required string Message {  get; set; } = string.Empty;        
        public required DateTime CheckInDate { get; set; }   
        public required DateTime CheckOutDate { get; set;}
        public required int Duration { get; set; }   
        public required int RequestStateID {  get; set; }    
        public required string RequestStateName { get; set; } = string.Empty;
        public required double Nightly_price { get; set; }   
        public required double Service_Fees { get; set; }    
        public required double Total_price { get; set;}
        public required int HostStateID { get; set; }   
        public required int AdminStateID { get; set; }  
    }
}
