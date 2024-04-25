using MBBE.Data;
using MBBE.Models;

namespace YourNamespace
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Products.Any())
            {
                var productCategories = new List<ProductCategory>()
                {
                    new ProductCategory()
                    {
                         Product = new Product()
                            {
                                ProductId = Guid.NewGuid(),
                                Name = "Laptop",
                                Description = "High-performance laptop with the latest Intel processor.",
                                Price = 9999,
                                StockQuantity = 50,
                                Brand = "ExampleBrand",
                            },
                         Category = new Category()
                            {
                                CategoryId = Guid.NewGuid(),
                                Name = "Laptop"
                            }
                    },
                    new ProductCategory()
                    {
                         Product = new Product()
                            {
                                ProductId = Guid.NewGuid(),
                                Name = "Iphone 15",
                                Description = "High-performance laptop with the latest Intel processor Iphone 15.",
                                Price = 9999,
                                StockQuantity = 50,
                                Brand = "Apple",
                            },

                         Category = new Category()
                            {
                                CategoryId = Guid.NewGuid(),
                                Name = "Phone"
                            }
                    },
                    new ProductCategory()
                    {
                         Product = new Product()
                            {
                                ProductId = Guid.NewGuid(),
                                Name = "Samsung 15",
                                Description = "High-performance laptop with the latest Intel processor Iphone 15.",
                                Price = 9999,
                                StockQuantity = 50,
                                Brand = "Samsung",
                            },
                         Category = new Category()
                            {
                                CategoryId = Guid.NewGuid(),
                                Name = "Samsung"
                            }
                    },
                };

                dataContext.ProductCategories.AddRange(productCategories);
                dataContext.SaveChanges();
            }
        }
    }
}
