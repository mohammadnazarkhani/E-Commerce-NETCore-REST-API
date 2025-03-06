using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TondForooshApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TondForooshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ITondForooshRepository repository;
        public HomeController(ITondForooshRepository repo)
        {
            repository = repo;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = repository.Products.ToList();
            return Ok(products);
        }
    }
}
