using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Scott's Pizza", Cuisine = Restaurant.CuisineType.Italian, Location = "Maryland" },
                new Restaurant() { Id = 2, Name = "Cinnamon Club", Cuisine = Restaurant.CuisineType.Indian, Location = "London" },
                new Restaurant() { Id = 3, Name = "La Costa", Cuisine = Restaurant.CuisineType.Mexican, Location = "California" }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where String.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }
    }
}
