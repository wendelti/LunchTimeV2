using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Domain.Entities
{
    public class User
    {
        public User()
        {

        }

        public int UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }



    }
}
