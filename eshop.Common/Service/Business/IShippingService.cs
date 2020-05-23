using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IShippingService
    {
        Task Add(ShippingDto shippingDto);


        // Marks an entity as modified
        Task Update(ShippingDto shippingDto);


        // Marks an entity to be removed
        Task Delete(ShippingDto shippingDto);


        // Get an entity by int id
        Task<ShippingDto> GetById(int id);


        Task<IEnumerable<ShippingDto>> GetAll();
    }
}
