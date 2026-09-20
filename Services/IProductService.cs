using Models;
using DTO;
namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll(Category? category = null);
        Task<Product> GetById(int id);
        Task<Product> Create(CreateProductDto dto);
        Task<bool> Update(UpdateProductDto dto);
        Task<bool> Delete(int id);


    }
}