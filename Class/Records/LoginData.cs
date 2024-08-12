using System.Security.Claims;

namespace Backend.Class.Records;
public record LoginData
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}