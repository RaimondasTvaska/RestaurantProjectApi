using Microsoft.EntityFrameworkCore;
using RestaurantsProjectApi.Data;
using RestaurantsProjectApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Repositories
{
    public class MenuRepository
    {
        private readonly DataContext _context;

        public MenuRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Menu menu)
        {
            _context.Add(menu);
            await _context.SaveChangesAsync();
        }
        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.Menus.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<Menu>> GetAllMenusAsync()
        {
            return await _context.Menus.ToListAsync();
        }
        public async Task UpdateMenu(Menu menu)
        {
            _context.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Menu menu)
        {
            _context.Remove(menu);
            await _context.SaveChangesAsync();
        }
    }
}

