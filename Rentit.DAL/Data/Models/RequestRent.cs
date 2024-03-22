using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentit.DAL
{
    public class RequestRent
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public Client User { get; set; } = null!;
        [ForeignKey("Host")]
        public int HostID { get; set; }
        public Client Host { get; set; } = null!;
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Propertyy Property { get; set; } = null!;
        [ForeignKey("Request_state_Host")]
        public int Request_StateID_Host { get; set; }
        public RequestState Request_state_Host { get; set; } = null!;

        [ForeignKey("Request_state_Admin")]
        public int Request_StateID_Admin { get; set; }
        public RequestState Request_state_Admin { get; set; } = null!;
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
        public double Nightly_price { get; set; }
        public double ServiceFee { get; set; }
        public double WebsiteFee { get; set; }
        public double Total_price { get; set; }
        public int StayDurationInDays { get; set; }
        public int NumOfGuests { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
