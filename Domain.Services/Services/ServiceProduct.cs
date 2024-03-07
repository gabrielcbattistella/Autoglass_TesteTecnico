using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        private readonly IRepositoryProduct _repository;

        public ServiceProduct(IRepositoryProduct repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
