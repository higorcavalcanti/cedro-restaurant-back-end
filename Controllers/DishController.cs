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
    [Route("api/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DishController(AppDbContext context)
        {
            _context = context;
            
            if (_context.Dishes.Count() == 0)
            {
                Random rnd = new Random();
                for (int i = 0; i < 30; i++)
                {
                    _context.Dishes.Add(new Dish {
                        Name = "Prato " + i,
                        Price = rnd.Next(1, 50),
                        RestaurantId = rnd.Next(1, 4)
                    });
                }                
                _context.SaveChanges();
            } 
        }

        [HttpGet(Name = "Dish.GetAll")]
        public async Task<ActionResult<List<Dish>>> GetAll()
        {
            try
            {
                return await _context.Dishes
                    .Include(d => d.Restaurant)                    
                    .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "Dish.Get")]
        public async Task<ActionResult<Dish>> GetById(long id)
        {
            try
            {
                var item = await _context.Dishes.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost(Name = "Dish.Create")]
        public async Task<IActionResult> Create(Dish newItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.Dishes.AddAsync(newItem);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("Dish.Get", new { id = newItem.Id }, newItem);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}", Name = "Dish.Update")]
        public async Task<IActionResult> Update(long id, Dish newItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = await _context.Dishes.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }

                item.Name = newItem.Name;
                item.Price = newItem.Price;
                item.RestaurantId = newItem.RestaurantId;

                _context.Dishes.Update(item);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}", Name = "Dish.Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var item = await _context.Dishes.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }

                _context.Dishes.Remove(item);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}