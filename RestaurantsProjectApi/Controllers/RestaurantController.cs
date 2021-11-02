using Microsoft.AspNetCore.Mvc;
using RestaurantsProjectApi.Entities;
using RestaurantsProjectApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restaurantService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetById(int id)
        {
            var restaurant = await _restaurantService.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            return Ok(await _restaurantService.AddAsync(restaurant));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurant(Restaurant restaurant)
        {
            await _restaurantService.UpdateRestaurantAsync(restaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _restaurantService.DeleteAsync(id);
            return NoContent();
        }
    }
}
