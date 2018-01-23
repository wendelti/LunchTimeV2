using LunchTime.Application.Adapters;
using LunchTime.Application.ViewModels;
using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public interface IRestauranteAppService
    {
        void AddRestaurant(string name);
        Restaurant FindById(int restaurantId);
        IEnumerable<RestaurantViewModel> FindAll();
    }

    public class RestaurantAppService : IRestauranteAppService
    {
        RestaurantRepository _restaurantRepository;

        public RestaurantAppService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

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

        public IEnumerable<RestaurantViewModel> FindAll()
        {
            var viewModelAdapter = new RestaurantEntityToRestaurantViewModelAdapter();
            foreach (Restaurant restauant in _restaurantRepository.FindAll())
            {
                yield return viewModelAdapter.GetView(restauant);
            }
        }
        

    }
}
