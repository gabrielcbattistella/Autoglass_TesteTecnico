using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduct
    {
        Product MapperToEntity(ProductDTO productDTO);
        IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products);
        ProductDTO MapperToDTO(Product product);
    }
}
