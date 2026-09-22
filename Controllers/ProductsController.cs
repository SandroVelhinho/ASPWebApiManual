using Models;
using DTO;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts([FromQuery] Category? category)
    {
        var products = await _productService.GetAll(category);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductDto dto)
    {
        Console.WriteLine($"Objeto que passou pelo body do post: {dto}");
        var product = await _productService.Create(dto);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductDto dto)
    {
        var result = await _productService.Update(dto);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteProduct([FromQuery] int id)
    {
        var result = await _productService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }

}