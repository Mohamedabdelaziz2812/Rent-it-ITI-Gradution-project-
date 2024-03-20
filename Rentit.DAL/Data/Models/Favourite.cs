using System.ComponentModel.DataAnnotations.Schema;

namespace Rentit.DAL
{
    public class Favourite
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; }
        [ForeignKey("Property")]
        public int? PropertyID { get; set; }
        public User User { get; set; } = null!;
        public Propertyy Property { get; set; } = null!;
    }
}
