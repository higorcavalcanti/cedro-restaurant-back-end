using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cedro_restaurant_back_end.Models;
using System.Net;

namespace cedro_restaurant_back_end.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
            
            if (_context.Restaurants.Count() == 0)
            {
                _context.Restaurants.Add(new Restaurant { Name = "Restaurant 1" });
                _context.Restaurants.Add(new Restaurant { Name = "Restaurant 2" });
                _context.Restaurants.Add(new Restaurant { Name = "Restaurant 4" });
                _context.Restaurants.Add(new Restaurant { Name = "Restaurant 3" });
                _context.SaveChanges();
            }            
        }

        [HttpGet(Name = "Restaurant.GetAll")]
        public async Task<List<Restaurant>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }

        [HttpGet("{id}", Name = "Restaurant.Get")]
        public async Task<ActionResult<Restaurant>> GetById(long id)
        {
            var item = await _context.Restaurants.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost(Name = "Restaurant.Create")]
        public async Task<IActionResult> Create(Restaurant newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Restaurants.AddAsync(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("Restaurant.Get", new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}", Name = "Restaurant.Update")]
        public async Task<IActionResult> Update(long id, Restaurant newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _context.Restaurants.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = newItem.Name;

            _context.Restaurants.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}", Name = "Restaurant.Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Restaurants.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}