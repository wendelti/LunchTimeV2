using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Infra.Data.Repositories
{
    public class a { }
    public class TeamRepository
    {
        public Team FindById(int teamID)
        {
            Team team = null;

            using (var ctx = new LunchTimeContext())
            {
                team = (from t in ctx.Teams
                        where t.TeamId == teamID
                        select t).FirstOrDefault();
            }

            return team;


        }

        public List<Team> FindAll()
        {
            List<Team> team = null;

            using (var ctx = new LunchTimeContext())
            {
                team = (from t in ctx.Teams
                        select t).ToList<Team>();
            }

            return team;


        }

        public bool Add(Team newTeam)
        {
            try
            {
                using (var ctx = new LunchTimeContext())
                {
                    ctx.Teams.Add(newTeam);
                    ctx.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
