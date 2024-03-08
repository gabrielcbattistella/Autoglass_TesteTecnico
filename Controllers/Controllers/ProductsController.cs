using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(_applicationServiceProducts.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceProducts.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                var validator = new CreateProductValidator();

                var result = validator.Validate(productDTO);

                var error = result.Errors.Select(e => e.ErrorMessage);

                if (!result.IsValid)
                {
                    return BadRequest(error);
                }

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

        [HttpPut]
        public ActionResult Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                var validator = new CreateProductValidator();

                var result = validator.Validate(productDTO);

                var error = result.Errors.Select(e => e.ErrorMessage);

                if (!result.IsValid)
                {
                    return BadRequest(error);
                }

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
