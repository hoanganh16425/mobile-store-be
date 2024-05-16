using MBBE.Dtos.Account;
using MBBE.Dtos.Product;
using MBBE.Models;

namespace MBBE.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProductFromDto(this CreateStockRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                ProductImage = productDto.ProductImage,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Brand = productDto.Brand,
    };
        }
    }
}
