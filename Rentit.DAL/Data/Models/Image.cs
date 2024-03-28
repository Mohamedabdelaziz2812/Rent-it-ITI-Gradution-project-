using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentit.DAL
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Img_URL { get; set; } = string.Empty;
        public int? Img_order { get; set; }
        [ForeignKey("Property")]
        public int? PropertyId { get; set; }
        public Propertyy Property { get; set; } = null!;
    }
}
