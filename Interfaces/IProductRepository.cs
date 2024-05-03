using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}
