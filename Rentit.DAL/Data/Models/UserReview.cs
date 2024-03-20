using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentit.DAL
{
    public class UserReview
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? Userid { get; set; }
        public User User { get; set; } = null!;
        [ForeignKey("Property")]
        public int? PropertyID { get; set; }
        public Propertyy Property { get; set; } = null!;
        public string Comment { get; set; } = string.Empty;
        public DateTime Review_date { get; set; }
    }
}
