namespace Templet.Data.DTOs;

public class GetUserRolesResponse
{
    public string UserId { get; set; }
    public List<UserRoles> UserRoles { get; set; }
}

public class UserRoles
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public bool HasRole { get; set; }
} 