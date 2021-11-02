using RestaurantsProjectApi.Entities;
using RestaurantsProjectApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsProjectApi.Services
{
    public class MenuService
    {
        private MenuRepository _menuRepository;
        private RestaurantRepository _restaurantRepository;

        public MenuService(MenuRepository menuRepository, RestaurantRepository restaurantRepository)
        {
            _menuRepository = menuRepository;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<List<Menu>> GetAllAsync()
        {
            var menuEntities = await _menuRepository.GetAllMenusAsync();
            //var dtos = employeeEntities.Select(e => new EmployeeDto()
            //{
            //    Id = e.Id,
            //    FirstName = e.FirstName,
            //    LastName = e.LastName,
            //    CompanyListId = e.CompanyListId,
            //    GenderType = e.GenderType.ToString()

            //});

            return menuEntities.ToList();
        }
        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _menuRepository.GetByIdAsync(id);
        }
        public async Task<int> AddAsync(Menu menu)
        {

            var entity = new Menu()
            {
                Title = menu.Title,
                Price = menu.Price,
                Weight = menu.Weight,
                Meat = menu.Meat,
                About = menu.About
            };
            if (menu.Meat > menu.Weight)
            {

                throw new ArgumentException("Ką čia įrašei ?????");

            }
            await _menuRepository.CreateAsync(entity);
            return entity.Id;
        }
        public async Task UpdateMenuAsync(int id, Menu menu)
        {
            var entity = new Menu()
            {
                Id = menu.Id,
                Title = menu.Title,
                Price = menu.Price,
                Weight = menu.Weight,
                Meat = menu.Meat,
                About = menu.About,
                //Restaurant = menu.Restaurant
            };
            if (menu.Meat > menu.Weight)
            {

                throw new ArgumentException("Ką čia įrašei ?????");

            }


            await _menuRepository.UpdateMenu(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var menu = await GetByIdAsync(id);
            await _menuRepository.DeleteAsync(menu);
        }

    }
}
