using LunchTime.Application.Adapters;
using LunchTime.Application.ViewModels;
using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application
{
    public interface ITeamAppService
    {
        bool Add(string teamName);
        Team FindTeamById(int teamID);
        IEnumerable<TeamViewModel> FindAll();
    }

    public class TeamAppService : ITeamAppService
    {
        TeamRepository _teamRepository;
        
        public TeamAppService(TeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team FindTeamById(int teamID)
        {

            var team = _teamRepository.FindById(teamID);

            return team;


        }

        public IEnumerable<TeamViewModel> FindAll()
        {
            var viewModelAdapter = new TeamEntityToTeamViewModelAdapter();
            foreach (Team team in _teamRepository.FindAll())
            {
                yield return viewModelAdapter.GetView(team);
            }            
        }


        public bool Add(string teamName)
        {

            var team = new Team();
            team.TeamName = teamName;

            return _teamRepository.Add(team);
        }




    }
}
