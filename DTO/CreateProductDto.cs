using System.ComponentModel.DataAnnotations;
using Models;

namespace DTO;

public class CreateProductDto
{
    [Required(ErrorMessage = "Nome de produto é obrigatorio")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Price Obrigatio")]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    public Category Category { get; set; }



}
