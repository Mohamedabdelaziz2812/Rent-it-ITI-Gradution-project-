using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Rentit.DAL
{
    public class Attributes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Icon_Url { get; set; } = string.Empty;
        public ICollection<Propertyy>? Properties { get; set; }
        public ICollection<RequestHost>? Requesthosts { get; set; }
    }
}
