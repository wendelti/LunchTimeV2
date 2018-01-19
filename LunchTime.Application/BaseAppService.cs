using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public class BaseAppService
    {
        #region "Singletons"
        
        private static volatile UserRepository _userRepositoryInstance;
        private static object _userRepositorySyncRoot = new Object();
        public static UserRepository _userRepository
        {
            get
            {
                if (_userRepositoryInstance == null)
                {
                    lock (_userRepositorySyncRoot)
                    {
                        if (_userRepositoryInstance == null)
                            _userRepositoryInstance = new UserRepository();
                    }
                }

                return _userRepositoryInstance;
            }
        }


        private static volatile VoteRepository _voteRepositoryInstance;
        private static object _voteRepositorySyncRoot = new Object();
        public static VoteRepository _voteRepository
        {
            get
            {
                if (_voteRepositoryInstance == null)
                {
                    lock (_voteRepositorySyncRoot)
                    {
                        if (_voteRepositoryInstance == null)
                            _voteRepositoryInstance = new VoteRepository();
                    }
                }

                return _voteRepositoryInstance;
            }
        }


        private static volatile RestaurantRepository _restaurantRepositoryInstance;
        private static object _restaurantRepositorySyncRoot = new Object();
        public static RestaurantRepository _restaurantRepository
        {
            get
            {
                if (_restaurantRepositoryInstance == null)
                {
                    lock (_restaurantRepositorySyncRoot)
                    {
                        if (_restaurantRepositoryInstance == null)
                            _restaurantRepositoryInstance = new RestaurantRepository();
                    }
                }

                return _restaurantRepositoryInstance;
            }
        }


        private static volatile TeamRepository _teamRepositoryInstance;
        private static object _teamRepositorySyncRoot = new Object();
        public static TeamRepository _teamRepository
        {
            get
            {
                if (_teamRepositoryInstance == null)
                {
                    lock (_teamRepositorySyncRoot)
                    {
                        if (_teamRepositoryInstance == null)
                            _teamRepositoryInstance = new TeamRepository();
                    }
                }

                return _teamRepositoryInstance;
            }
        }

        #endregion
        

    }
}
