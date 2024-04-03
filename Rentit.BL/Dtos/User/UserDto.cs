using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fname { get; set; }   =string .Empty;
        public string Lname { get; set; }   = string .Empty;    
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; }= string.Empty;
        public string Image_URL { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set; }
        public DateTime? Start_HostingDate { get; set; }
        public string Role {  get; set; }   = string.Empty; 
        public int RoleId { get; set; } 
        public List<RequestRentReadDto> RequestsRent { get; set; } = new();
        public List<RequestHostReadDto> RequestsHost { get; set; } = new();
        public List<PropertyReadDetailsDto> UserProperties { get; set; } = new();
        public List<PropertyReadDetailsDto> UserFavourites { get; set; } = new();
    }
}
