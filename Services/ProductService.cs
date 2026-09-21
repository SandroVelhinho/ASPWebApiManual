
using Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;

    }

    public async Task<List<Product>> GetAll(Category? category = null)
    {



        if (category == null)
        {
            return await _context.Products.ToListAsync();
        }
        else
        {
            return await _context.Products.Where(p => p.Category == category).ToListAsync();
        }
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public async Task<Product> Create(CreateProductDto dto)
    {
        var product = new Product
        {

            Name = dto.Name,

            Price = dto.Price,
            Category = dto.Category
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> Update(UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(dto.Id);
        if (product == null)
        {
            return false;
        }

        if (dto.Name != null)
        {
            product.Name = dto.Name;
        }
        if (dto.Price.HasValue)
        {
            product.Price = dto.Price.Value;
        }
        if (dto.Quantity.HasValue)
        {
            product.Quantity = dto.Quantity.Value;
        }
        if (dto.Category.HasValue)
        {
            product.Category = dto.Category.Value;
        }
        if (dto.CreatedAt.HasValue)
        {
            product.CreatedAt = dto.CreatedAt.Value;
        }
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}

