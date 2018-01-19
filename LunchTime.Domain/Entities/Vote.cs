using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Domain.Entities
{
    public class Vote
    {
        public Vote()
        {
        }

        public int VoteID { get; set; }
        public DateTime? VoteDate { get; set; }
        public int DayOfWeek { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
        
    }
}
