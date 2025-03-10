namespace Templet.Core.Features.Users.Queries.Response;

public class GetUserPaginatedListResponse
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int? DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}