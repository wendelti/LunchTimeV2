using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Infra.Data
{
    public class LunchTimeInitializer : DropCreateDatabaseAlways<LunchTimeContext>
    {
        protected override void Seed(LunchTimeContext context)
        {
            IList<Restaurant> restaurants = new List<Restaurant>();

            restaurants.Add(new Restaurant() { Name = "Sushi" });
            restaurants.Add(new Restaurant() { Name = "Churrascaria" });
            restaurants.Add(new Restaurant() { Name = "Vegano" });
            restaurants.Add(new Restaurant() { Name = "Mexicano" });
            restaurants.Add(new Restaurant() { Name = "Caseiro" });
            context.Restaurants.AddRange(restaurants);

            IList<Team> teams = new List<Team>();

            teams.Add(new Team() { TeamName = "Front-End" });
            teams.Add(new Team() { TeamName = "Back-End" });
            teams.Add(new Team() { TeamName = "BackOffice" });
            context.Teams.AddRange(teams);


            base.Seed(context);
        }
    }

}
