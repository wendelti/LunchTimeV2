using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using LunchTime.Infra.Data;
using LunchTime.Infra.Data.Repositories;

namespace LunchTime.Infra.CrossCutting.Helper.IoC
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {

            Bind<LunchTimeContext>().To<LunchTimeContext>();
            Bind<RestaurantRepository>().To<RestaurantRepository>();

            Bind<VoteRepository>().To<VoteRepository>();
            Bind<UserRepository>().To<UserRepository>();

        }
    }
}
