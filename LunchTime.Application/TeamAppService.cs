using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public class TeamAppService : BaseAppService
    {
        
        public TeamAppService()
        {
        }

        public Team FindTeamById(int teamID)
        {

            var team = _teamRepository.FindById(teamID);

            return team;


        }

        public List<Team> FindAll()
        {

            return _teamRepository.FindAll();
            

        }


        public bool Add(string teamName)
        {

            var team = new Team();
            team.TeamName = teamName;

            return _teamRepository.Add(team);
        }




    }
}
