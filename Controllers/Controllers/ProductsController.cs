using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IApplicationServiceProduct _applicationServiceProducts;


        public ProductsController(IApplicationServiceProduct ApplicationServiceProduct)
        {
            _applicationServiceProducts = ApplicationServiceProduct;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceProducts.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceProducts.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProducts.Add(productDTO);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProducts.Update(productDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProducts.Delete(productDTO);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
