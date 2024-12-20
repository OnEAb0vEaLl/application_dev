using _22023EMVC.Data;
using _22023EMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2023EMVCWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int productId;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Products.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }
        [HttpPut]
        public async Task<IActionResult> update(Product product)
        {
            var existing = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);
            if (existing == null)
            {
                return BadRequest("product not found.");
            }
            _context.Products.Update(product);
            _context.SaveChanges();
       
        return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            var existing = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (existing == null)
            {
                return BadRequest("product not found.");
            }
            _context.Products.Remove(existing);
            _context.SaveChanges();

            return Ok("delete successfully!!!");

        }
    }
}
