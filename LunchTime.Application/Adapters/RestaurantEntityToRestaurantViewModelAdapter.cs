using LunchTime.Application.ViewModels;
using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application.Adapters
{
    public class RestaurantEntityToRestaurantViewModelAdapter
    {

        public RestaurantViewModel GetView(Restaurant restaurant)
        {
            var restaurantViewModel = new RestaurantViewModel();
            restaurantViewModel.RestaurantId = restaurant.RestaurantID;
            restaurantViewModel.Name = restaurant.Name;
            return restaurantViewModel;
        }
    }
}
