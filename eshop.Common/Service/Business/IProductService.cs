using eshop.Persistence.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IProductService
    {
        Task Add(ProductDto product);


        // Marks an entity as modified
        Task Update(ProductDto product);


        // Marks an entity to be removed
        Task Delete(int id);


        // Get an entity by int id
        Task<ProductDto> GetById(int id);


        Task<IEnumerable<ProductDto>> GetAll();
    }
}
