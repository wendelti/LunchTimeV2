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

        public void AddRestaurant(Restaurant restaurant)
        {
            using (var ctx = new LunchTimeContext())
            {
                ctx.Restaurants.Add(restaurant);
                ctx.SaveChanges();
            }
        }

        public Restaurant FindById(int restaurantId)
        {
            Restaurant restaurant = null;

            using (var ctx = new LunchTimeContext())
            {
                restaurant = (from t in ctx.Restaurants
                              where t.RestaurantID == restaurantId
                              select t).FirstOrDefault();
            }

            return restaurant;


        }

        public List<Restaurant> FindAll()
        {
            List<Restaurant> restaurant = null;

            using (var ctx = new LunchTimeContext())
            {
                restaurant = (from t in ctx.Restaurants
                              select t).ToList<Restaurant>();
            }

            return restaurant;

        }
    }
}
