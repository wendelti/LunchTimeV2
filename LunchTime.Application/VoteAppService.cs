using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;

namespace LunchTime.Application
{
    public class VoteAppService : BaseAppService
    {

        public bool Add(Vote newVote)
        {
            return _voteRepository.Add(newVote);
        }

        public object FindWinnerByDayOfWeek(int dayOfWeek)
        {
            return _voteRepository.FindWinnerByDayOfWeek(dayOfWeek);
        }


    }
}
