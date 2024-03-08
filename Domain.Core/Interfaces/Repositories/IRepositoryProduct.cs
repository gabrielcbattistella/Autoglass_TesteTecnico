using Domain.BaseResponse;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
        PagedResult<Product> FilterProducts(Product entity, int page, int pageSize = 5);
    }
}
