using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface ICategoryService
    {
        Task Add(CategoryDto product);


        // Marks an entity as modified
        Task Update(CategoryDto product);


        // Marks an entity to be removed
        Task Delete(int id);


        // Get an entity by int id
        Task<CategoryDto> GetById(int id);


        Task<IEnumerable<CategoryDto>> GetAll();
    }
}
