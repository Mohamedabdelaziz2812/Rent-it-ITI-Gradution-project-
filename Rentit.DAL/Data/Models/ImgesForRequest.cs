using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentit.DAL    
{
    public class ImgesForRequest
    {
        public int Id { get; set; }
        [Required]
        public string Img_URL { get; set; } = string.Empty;
        public int? Img_order { get; set; }

        [ForeignKey("Request_host")]
        public int Request_HostId { get; set; }
        public RequestHost Request_host { get; set; } = null!;
    }
}

