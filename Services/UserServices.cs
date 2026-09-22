
using Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace Services;

public class UserServices : IUserServices
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UserServices(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string?> Create(CreateUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            HashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = dto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return GenerateJwtToken(user);
    }

    public async Task<string?> Login(LoginUserDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == dto.Name);
        if (user == null) return null;

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.HashPassword);
        if (!isPasswordValid) return null;

        return GenerateJwtToken(user);
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }


    private string GenerateJwtToken(User user)
    {
        // 1. As Claims: O "BI" do utilizador carimbado dentro do token
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Role, user.Role.ToString()) // "Admin" ou "User"
    };

        // 2. A Chave e a Assinatura Criptográfica
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. Montar o Token com prazo de validade
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2), // O token expira em 2 horas
            signingCredentials: creds
        );

        // 4. Converte o objeto token na string de texto que o utilizador vai receber
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}