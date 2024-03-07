using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
