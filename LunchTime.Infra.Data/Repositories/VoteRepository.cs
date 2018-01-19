using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Infra.Data.Repositories
{
    public class VoteRepository
    {

        public bool Add(Vote newVote)
        {
            try
            {
                using (var ctx = new LunchTimeContext())
                {
                    ctx.Votes.Add(newVote);
                    ctx.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public object FindWinnerByDayOfWeek(int dayOfWeek)
        {

            try
            {
                object restaurant = null;
                using (var ctx = new LunchTimeContext())
                {
                    restaurant = ctx.Votes
                    .Where(v => v.DayOfWeek == dayOfWeek)
                    .GroupBy(v => v.Restaurant)
                    .Select(v => new { Restaurant = v.Key, Qty = v.Count() })
                    .OrderByDescending(v => v.Qty)
                    .FirstOrDefault();

                    //restaurant = winnerRestaurant.Restaurant;
                }

                return restaurant;
            }
            catch (Exception)
            {
                return null;
            }


        }

    }
}
