namespace Models;

public enum RolesEnum
{
    Admin,
    User
}

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string HashPassword { get; set; }
    public RolesEnum Role { get; set; } = RolesEnum.User;
}