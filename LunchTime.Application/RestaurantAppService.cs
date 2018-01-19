using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public class RestaurantAppService : BaseAppService
    {

        public void AddRestaurant(string name)
        {
            var restaurant = new Restaurant();
            restaurant.Name = name;

            _restaurantRepository.AddRestaurant(restaurant);

        }

        public Restaurant FindById(int restaurantId)
        {
            return _restaurantRepository.FindById(restaurantId);
        }

        public List<Restaurant> FindAll()
        {

            return _restaurantRepository.FindAll();


        }

    }
}
