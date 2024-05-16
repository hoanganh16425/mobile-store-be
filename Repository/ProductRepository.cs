using MBBE.Data;
using MBBE.Interfaces;
using MBBE.Models;
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

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

    }
}
