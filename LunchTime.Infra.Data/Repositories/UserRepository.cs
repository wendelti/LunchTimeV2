using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Infra.Data.Repositories
{
    public class UserRepository
    {

        public User FindByEmail(string email)
        {
            User user = null;

            using (var ctx = new LunchTimeContext())
            {
                user = (from u in ctx.Users
                           where u.Email == email
                           select u).FirstOrDefault();
            }

            return user;


        }

        public bool Add(User newUser)
        {
            try
            {
                using (var ctx = new LunchTimeContext())
                {
                    ctx.Users.Add(newUser);
                    ctx.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }    

        }
    }


}
