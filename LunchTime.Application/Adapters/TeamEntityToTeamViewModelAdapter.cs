using LunchTime.Application.ViewModels;
using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application.Adapters
{
    public class TeamEntityToTeamViewModelAdapter
    {

        public TeamViewModel GetView(Team team)
        {
            var teamViewModel = new TeamViewModel();
            teamViewModel.teamId = team.TeamId;
            teamViewModel.teamName = team.TeamName;
            return teamViewModel;

        }
    }
}
