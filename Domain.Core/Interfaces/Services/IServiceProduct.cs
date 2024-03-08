using Domain.BaseResponse;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IServiceProduct : IServiceBase<Product>
    {
        PagedResult<Product> Filter(Product entity, int page, int pageSize);
    }
}
