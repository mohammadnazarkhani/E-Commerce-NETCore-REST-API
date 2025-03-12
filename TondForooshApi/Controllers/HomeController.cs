using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TondForooshApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await repository.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product? p = await repository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
                return NotFound();

            return Ok(p);
        }
    }
}
