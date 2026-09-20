using Models;
using System.ComponentModel.DataAnnotations;

namespace DTO;


public class UpdateProductDto
{
    [Required(ErrorMessage = "Queres mesmo editar sem ID ? Tas burro?")]
    public int Id { get; set; }
    public required string? Name { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public int? Quantity { get; set; } = null;
    public Category? Category { get; set; } = null;
    public DateTime? CreatedAt { get; set; } = null;
}