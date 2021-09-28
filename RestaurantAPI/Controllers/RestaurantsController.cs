using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants")]
    public class RestaurantsController 
    {
        private IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            var restaurants = _restaurantService.GetRestaurants();
            return restaurants;
        }
        [HttpGet("{id}")]
        public RestaurantModel GetRestaurant(int id)
        {
            var restaurant = _restaurantService.GetRestaurant(id);
            return restaurant;
        }
        [HttpPost]
        public RestaurantModel CreateRestaurant([FromBody]RestaurantModel restaurant)
        {
            var newRestaurant = _restaurantService.CreateRestaurant(restaurant);
            return newRestaurant;
        }
        [HttpDelete("{restaurantId}")]
        public bool DeleteRestaurant(int restaurantId)
        {
            var delete = _restaurantService.DeleteRestaurant(restaurantId);
            return delete;
        }
        [HttpPut("{idRestaurant}")]
        public RestaurantModel PutRestaurant(int idRestaurant,[FromBody]RestaurantModel restaurant)
        {
            return _restaurantService.UpdateRestaurant(idRestaurant, restaurant);
        }

    }

}
