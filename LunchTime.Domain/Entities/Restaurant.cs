using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Domain.Entities
{
    public class Restaurant
    {
        public Restaurant()
        {

        }

        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
