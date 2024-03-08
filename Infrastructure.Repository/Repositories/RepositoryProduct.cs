using Domain.BaseResponse;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private readonly SqlContext _sqlContext;

        public RepositoryProduct(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public override void Delete(Product entity)
        {
            try
            {
                var productEntity = _sqlContext.Set<Product>().Find(entity.CodigoProduto);
                productEntity.Ativo = false;
                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PagedResult<Product> FilterProducts(Product entity, int page, int pageSize = 5)
        {
            var result = _sqlContext.Set<Product>()
                .Where(x => entity.CodigoProduto == default || x.CodigoProduto == entity.CodigoProduto)
                .Where(x => x.Ativo == entity.Ativo)
                .Where(x => entity.CodigoFornecedor == default || x.CodigoFornecedor == entity.CodigoFornecedor)
                .GetPaged(page, pageSize);

            return result;
        }
    }
}
