

namespace Templet.Data.Entities.Identity;

public class UserRefreshToken
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime AddedTime { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual Employee? user { get; set; }
}