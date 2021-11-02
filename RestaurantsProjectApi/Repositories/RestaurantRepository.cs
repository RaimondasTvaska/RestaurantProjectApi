using Microsoft.EntityFrameworkCore;
using RestaurantsProjectApi.Data;
using RestaurantsProjectApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Repositories
{
    public class RestaurantRepository
    {
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Restaurant restaurant)
        {
            _context.Add(restaurant);
            await _context.SaveChangesAsync();
        }
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.Include(m => m.Menu).ToListAsync();
        }
        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            _context.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            _context.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
