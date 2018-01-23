using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Infra.Data.Repositories
{
    public class RestaurantRepository
    {

        public LunchTimeContext _ctx;

        public RestaurantRepository(LunchTimeContext ctx)
        {
            _ctx = ctx;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _ctx.Restaurants.Add(restaurant);
            _ctx.SaveChanges();
        }

        public Restaurant FindById(int restaurantId)
        {
            Restaurant restaurant = null;

            restaurant = (from t in _ctx.Restaurants
                            where t.RestaurantID == restaurantId
                            select t).FirstOrDefault();
         

            return restaurant;


        }

        public List<Restaurant> FindAll()
        {
            List<Restaurant> restaurant = null;

        
            restaurant = (from t in _ctx.Restaurants
                            select t).ToList<Restaurant>();

            return restaurant;

        }
    }
}
