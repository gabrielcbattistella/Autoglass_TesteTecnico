using Application.DTOs;
using Domain.Entities;
using Infrastructure.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperProduct : IMapperProduct
    {
        List<ProductDTO> productDTOs = new List<ProductDTO>();

        public IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products)
        {
            foreach (var item in products)
            {

                ProductDTO productDTO = new ProductDTO
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo,
                    DataFabricacao = item.DataFabricacao,
                    DataValidade = item.DataValidade,
                    CodigoFornecedor = item.CodigoFornecedor,
                    DescricaoFornecedor = item.DescricaoFornecedor,
                    CNPJFornecedor = item.CNPJFornecedor
                };

                productDTOs.Add(productDTO);
            }

            return productDTOs;
        }

        public ProductDTO MapperToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                CodigoProduto = product.CodigoProduto,
                Descricao = product.Descricao,
                Ativo = product.Ativo,
                DataFabricacao = product.DataFabricacao,
                DataValidade = product.DataValidade,
                CodigoFornecedor = product.CodigoFornecedor,
                DescricaoFornecedor = product.DescricaoFornecedor,
                CNPJFornecedor = product.CNPJFornecedor
            };

            return productDTO;
        }

        public Product MapperToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                CodigoProduto = productDTO.CodigoProduto,
                Descricao = productDTO.Descricao,
                Ativo = productDTO.Ativo.HasValue ? productDTO.Ativo.Value : true,
                DataFabricacao = productDTO.DataFabricacao,
                DataValidade = productDTO.DataValidade,
                CodigoFornecedor = productDTO.CodigoFornecedor,
                DescricaoFornecedor = productDTO.DescricaoFornecedor,
                CNPJFornecedor = productDTO.CNPJFornecedor
            };

            return product;
        }
    }
}
