using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
    }
}
