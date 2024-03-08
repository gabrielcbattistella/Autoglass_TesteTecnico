using Application.DTOs;
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
    }
}
