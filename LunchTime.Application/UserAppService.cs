using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public class UserAppService : BaseAppService
    {

        public UserAppService()
        {
        }

        public User FindByEmail(string email)
        {

            return _userRepository.FindByEmail(email);           

        }

        public bool Add(User newUser)
        {
            return _userRepository.Add(newUser);
        }

    }
}
