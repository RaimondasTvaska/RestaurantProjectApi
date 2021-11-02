using Microsoft.AspNetCore.Mvc;
using RestaurantsProjectApi.Entities;
using RestaurantsProjectApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetAll()
        {
            return Ok(await _menuService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Menu>>> GetById(int id)
        {
            var menu = await _menuService.GetByIdAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Menu menu)
        {
            return Ok(await _menuService.AddAsync(menu));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(int id, Menu menu)
        {
            await _menuService.UpdateMenuAsync(id, menu);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuService.DeleteAsync(id);
            return NoContent();
        }
    }
}
