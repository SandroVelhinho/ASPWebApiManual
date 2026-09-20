
using Models;
using DTO;

namespace Services;

public class ProductService : IProductService
{
    private readonly List<Product> _productList = new();

    public ProductService()
    {
        Create(new CreateProductDto { Name = "Laptop", Price = 999.99m, Quantity = 10, Category = Category.Electronics }).GetAwaiter().GetResult();
        Create(new CreateProductDto { Name = "Laptop", Price = 999.99m, Quantity = 10, Category = Category.Books }).GetAwaiter().GetResult();
        Create(new CreateProductDto { Name = "Laptop", Price = 999.99m, Quantity = 10, Category = Category.Clothing }).GetAwaiter().GetResult();
        Create(new CreateProductDto { Name = "Laptop", Price = 999.99m, Quantity = 10, Category = Category.HomeGoods }).GetAwaiter().GetResult();
    }

    public async Task<List<Product>> GetAll(Category? category = null)
    {
        if (category == null)
        {
            return _productList;
        }
        else
        {
            return _productList.Where(p => p.Category == category).ToList();
        }
    }

    public async Task<Product> GetById(int id)
    {
        var product = _productList.FirstOrDefault(p => p.Id == id);
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
            Id = _productList.Count + 1,
            Name = dto.Name,

            Price = dto.Price,
            Category = dto.Category
        };

        _productList.Add(product);
        return product;
    }

    public async Task<bool> Update(UpdateProductDto dto)
    {
        var product = _productList.FirstOrDefault(p => p.Id == dto.Id);
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

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var product = _productList.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return false;
        }

        _productList.Remove(product);
        return true;
    }
}

