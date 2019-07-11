using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedSpark.Thot.Api.Models;
using ErrorMessage = RedSpark.Thot.Api.Const.ErrorMessage.Product;

namespace RedSpark.Thot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ICollection<Product> Products { get; }

        public ProductsController(ICollection<Product> products)
        {
            this.Products = products;
        }


        #region Create
        // GET api/products
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public ActionResult Post([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                return BadRequest(ErrorMessage.ProductNameIsRequired);
            }

            product.Id = Products.Count + 1;
            Products.Add(product);

            return CreatedAtAction(nameof(Post), product);
        }
        #endregion
        #region Read
        // GET api/products
        [HttpGet]
        public ActionResult<ICollection<Product>> Get()
        {
            return Ok(Products);
        }

        // GET api/products/2
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = FindProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        #endregion
        #region Update
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product productNew)
        {
            if (string.IsNullOrEmpty(productNew.Name))
                return BadRequest(ErrorMessage.ProductNameIsRequired);

            var product = FindProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productNew.Name;

            return Ok(product);
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = FindProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);

            return Ok(product);
        }
        #endregion


        #region Help
        private Product FindProduct(int id)
        {
            return Products.SingleOrDefault(p => p.Id.Equals(id));
        }
        #endregion
    }
}
