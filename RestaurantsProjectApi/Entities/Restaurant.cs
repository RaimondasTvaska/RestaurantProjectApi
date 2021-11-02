using System.Text.Json.Serialization;

namespace RestaurantsProjectApi.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Customers { get; set; }
        public int Employees { get; set; }
        public int? MenuId { get; set; }
       [JsonIgnore]
        public Menu Menu { get; set; }
    }
}

/*
 * show list show one
 * 
 * 
 * 
 * */