using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Domain.Entities
{
    public class Team
    {
        public Team()
        {

        }

        public int  TeamId{get;set;}
        public string TeamName { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
