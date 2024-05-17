using MBBE.Data;
using MBBE.Dtos.Product;
using MBBE.Interfaces;
using MBBE.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MBBE.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public async Task<Product> CreateProductAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> UpdateProductAsync(Guid id, UpdateStockRequestDto productDto)
        {
            var productUpdate = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (productUpdate == null)
                return null;
            productUpdate.Name = productDto.Name;
            productUpdate.Price = productDto.Price;
            productUpdate.ProductImage = productDto.Name;
            productUpdate.Brand = productDto.Brand;
            productUpdate.StockQuantity = productDto.StockQuantity;
            productUpdate.Description = productDto.Description;

            await _context.SaveChangesAsync();
            return productUpdate;
        }

    }
}
