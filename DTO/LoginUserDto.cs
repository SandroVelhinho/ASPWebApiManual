using Models;
using System.ComponentModel.DataAnnotations;

namespace DTO;

public class LoginUserDto
{
    [Required(ErrorMessage = "campos em falta")]
    public string Name { get; set; }

    [Required(ErrorMessage = "campos em falta")]
    public string Password { get; set; }
}