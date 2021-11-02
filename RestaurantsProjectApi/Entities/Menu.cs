using System.Collections.Generic;

namespace RestaurantsProjectApi.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public int Meat { get; set; }
        public string About { get; set; }
        //public List<Restaurant> Restaurant { get; set; }
    }
}
