using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces.Services;
using Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IServiceProduct _service;
        private readonly IMapperProduct _mapper;

        public ApplicationServiceProduct(IServiceProduct service, IMapperProduct mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(ProductDTO obj)
        {
            var objProduct = _mapper.MapperToEntity(obj);
            _service.Add(objProduct);
        }

        public void Delete(ProductDTO obj)
        {
            var objProduct = _mapper.MapperToEntity(obj);
            _service.Delete(objProduct);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var objProduct = _service.GetAll();
            return _mapper.MapperListProducts(objProduct);
        }

        public ProductDTO GetById(int id)
        {
            var objProduct = _service.GetById(id);
            return _mapper.MapperToDTO(objProduct);
        }

        public void Update(ProductDTO obj)
        {
            var objProduct = _mapper.MapperToEntity(obj);
            _service.Update(objProduct);
        }
    }
}
