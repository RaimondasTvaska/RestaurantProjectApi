using RestaurantsProjectApi.Entities;
using RestaurantsProjectApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;


        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;

        }


        public async Task<List<Restaurant>> GetAllAsync()
        {
            var entities = await _restaurantRepository.GetAllRestaurantsAsync();

            //var mos = new List<Restaurant>();

            //foreach (var entity in entities)
            //{
            //    var mo = new Restaurant()
            //    {
            //        Title = entity.Menu.Title
            //    };
            //    mos.Add(mo);

            //}

            return entities.ToList();
        }
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _restaurantRepository.GetByIdAsync(id);
        }
        public async Task<int> AddAsync(Restaurant restaurant)
        {

            var entity = new Restaurant()
            {
                Name = restaurant.Name,
                Customers = restaurant.Customers,
                Employees = restaurant.Employees,
                MenuId = restaurant.MenuId,
            };
            if (entity.MenuId == 0)
            {
                entity.MenuId = null;
            }

            await _restaurantRepository.CreateAsync(entity);
            return entity.Id;
        }
        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            var entity = new Restaurant()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Customers = restaurant.Customers,
                Employees = restaurant.Employees,
                MenuId = restaurant.MenuId,
            };
            if (restaurant.MenuId != restaurant.MenuId)
            {
                throw new ArgumentException("Menu not found");
            }

            await _restaurantRepository.UpdateRestaurant(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var restaurant = await GetByIdAsync(id);
            await _restaurantRepository.DeleteAsync(restaurant);
        }

    }
}
