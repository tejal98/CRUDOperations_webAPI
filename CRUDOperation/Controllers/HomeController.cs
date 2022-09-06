using CRUDOperation.Data;
using CRUDOperation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly BlogDBContext _context;

        public HomeController(BlogDBContext context) // => _context = context;
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _context.Products.FindAsync(id);
            return products == null ? NotFound() : Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = products.Id }, products);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Products products)
        {
            if (id != products.Id) return BadRequest();

            _context.Entry(products).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var productsToDel = await _context.Products.FindAsync(id);
            if (productsToDel == null) return NotFound();

            _context.Products.Remove(productsToDel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}