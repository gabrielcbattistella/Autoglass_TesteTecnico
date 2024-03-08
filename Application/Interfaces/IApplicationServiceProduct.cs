using Application.DTOs;
using Domain.BaseResponse;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceProduct
    {
        void Add(ProductDTO obj);
        void Update(ProductDTO entity);
        void Delete(ProductDTO entity);
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        PagedResult<ProductDTO> Filter(ProductDTO obj, int page, int pageSize);
    }
}
