namespace Lab11_MiguelQuispe.Application.DTOs;

public class UserRoleDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public DateTime? AssignedAt { get; set; }
}