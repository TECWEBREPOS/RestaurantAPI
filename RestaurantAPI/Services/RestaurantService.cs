using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IList<RestaurantModel> _restaurants;
        public RestaurantService()
        {
            _restaurants = new List<RestaurantModel>();
            _restaurants.Add(new RestaurantModel()
            {
                Id = 1,
                Name = "Panchita",
                Address = "Av. America",
                Phone = "12345678",
                Founded= new DateTime(1991,8,12)
            });
            _restaurants.Add(new RestaurantModel()
            {
                Id = 2,
                Name = "Pollos Lucho",
                Address = "Av. America",
                Phone = "12345678",
                Founded = new DateTime(2001, 8, 12)
            });

        }
        public RestaurantModel CreateRestaurant(RestaurantModel restaurant) { 
            var lastRestaurant = _restaurants.OrderByDescending(e => e.Id).FirstOrDefault();
            int nextId  = lastRestaurant != null ? lastRestaurant.Id+1 : 1;
            restaurant.Id = nextId;

            _restaurants.Add(restaurant);
            return restaurant;
        }

        public bool DeleteRestaurant(int restaurantId)
        {
            var restaurantDelete = _restaurants.Single(e => e.Id == restaurantId);
            if (restaurantDelete == null)
                return false;
            _restaurants.Remove(restaurantDelete);
            return true;
        }

        public RestaurantModel GetRestaurant(int restaurantId)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant != null) return restaurant;

            throw new Exception("Restaurant was not found");
        }

        public IEnumerable<RestaurantModel> GetRestaurants()
        { 
            return _restaurants;
        }

        public RestaurantModel UpdateRestaurant(int restaurantId, RestaurantModel restaurant)
        {
            var restaurantToUpdate = _restaurants.Single(e => e.Id == restaurantId);


            restaurantToUpdate.Name = restaurant.Name ?? restaurantToUpdate.Name;
            restaurantToUpdate.Address = restaurant.Address ?? restaurantToUpdate.Address;
            restaurantToUpdate.Founded = restaurant.Founded ?? restaurantToUpdate.Founded;
            restaurantToUpdate.Phone = restaurant.Phone ?? restaurantToUpdate.Phone  ;

            return restaurantToUpdate;

        }
    }
}
