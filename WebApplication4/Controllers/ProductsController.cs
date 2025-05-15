using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll(int top= 0)
        {
            var products = _productService.GetProducts(top);
           
            return Ok(products);
        }
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product)
        {
            var products=_productService.GetProducts();
            product.Id = products.Count() > 0 ? products.Max(p => p.Id) + 1 : 1;
            _productService.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            var item = _productService.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
