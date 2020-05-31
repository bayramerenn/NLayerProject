using NLayerProject.Entity.Concrete;
using System.Threading.Tasks;

namespace NLayerProject.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}