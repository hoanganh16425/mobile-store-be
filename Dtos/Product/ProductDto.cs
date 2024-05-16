using MBBE.Models;
using System.ComponentModel.DataAnnotations;

namespace MBBE.Dtos.Product
{
    public class CreateStockRequestDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public string? ProductImage { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public string? Brand { get; set; }
    }

    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public string? ProductImage { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Brand { get; set; }
    }
}
