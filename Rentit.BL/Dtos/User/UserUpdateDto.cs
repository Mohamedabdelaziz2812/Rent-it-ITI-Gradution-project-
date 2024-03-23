
namespace Rentit.BL.Dtos;

public class UserUpdateDto
{
    public int Id { get; set; }
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Image_URL { get; set; } = string.Empty;
   // public List<PropertyReadDetailsDto> UserProperties { get; set; } = new();
}
