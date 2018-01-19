using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchTime.Domain;
using LunchTime.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LunchTime.Infra.Data
{

    public class LunchTimeContext : DbContext
    {
        public LunchTimeContext() : base()
        {
            Database.SetInitializer(new LunchTimeInitializer());

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }


    }



}

