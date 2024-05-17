using MBBE.Dtos.Product;
using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();

        Task<Product> CreateProductAsync(Product productModel);

        Task<Product> GetProductByIdAsync(Guid id);

        Task<Product> UpdateProductAsync(Guid id, UpdateStockRequestDto updateStockRequestDto);
    }
}
