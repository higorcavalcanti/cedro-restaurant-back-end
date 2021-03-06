﻿using System;
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
    public class RestaurantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantController(AppDbContext context)
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
        public async Task<ActionResult<List<Restaurant>>> GetAll()
        {
            return await _context.Restaurants
                //.Include(r => r.Dishes)
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "Restaurant.Get")]
        public async Task<ActionResult<Restaurant>> GetById(long id)
        {
            try
            {
                var item = await _context.Restaurants.FindAsync(id);
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

        [HttpPost(Name = "Restaurant.Create")]
        public async Task<IActionResult> Create(Restaurant newItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.Restaurants.AddAsync(newItem);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("Restaurant.Get", new { id = newItem.Id }, newItem);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}", Name = "Restaurant.Update")]
        public async Task<IActionResult> Update(long id, Restaurant newItem)
        {
            try
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
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}", Name = "Restaurant.Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
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
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}