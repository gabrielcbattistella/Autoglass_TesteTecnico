using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduct
    {
        Product MapperToEntity(ProductDTO productDTO);
        IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products);
        ProductDTO MapperToDTO(Product product);
    }
}
