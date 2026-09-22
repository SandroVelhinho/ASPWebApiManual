using Models;
using System.ComponentModel.DataAnnotations;
namespace DTO;

public class CreateUserDto
{

    [Required(ErrorMessage = "Nome é obrigatorio")]
    public string Name { get; set; }

    [Required(ErrorMessage = "password obrigatio")]
    public string Password { get; set; }

    [Required(ErrorMessage = "password obrigatia")]
    [Compare("Password", ErrorMessage = "Passwords não coincidem")]
    public string ConfirmPassword { get; set; }

    public RolesEnum Role { get; set; } = RolesEnum.User;

}
