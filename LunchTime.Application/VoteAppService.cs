using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchTime.Domain.Entities;
using LunchTime.Infra.Data.Repositories;
using LunchTime.Application.ViewModels;

namespace LunchTime.Application
{
    public interface IVoteAppService
    {
        ResponseViewModel Add(int dayOfWeek, string email, int restaurantId);
    }

    public class VoteAppService : IVoteAppService
    {

        VoteRepository _voteRepository;
        UserRepository _userRepository;

        public VoteAppService(VoteRepository voteRepository, UserRepository userRepository)
        {
            _voteRepository = voteRepository;
            _userRepository = userRepository;
        }
        
        public ResponseViewModel Add(int dayOfWeek, string email, int restaurantId)
        {

            var vote = new Vote();
            vote.DayOfWeek = dayOfWeek;
            vote.UserID = _userRepository.FindByEmail(email).UserID;
            vote.RestaurantID = restaurantId;
            vote.VoteDate = DateTime.Now;

            var response = new ResponseViewModel();

            try
            {
                if (_voteRepository.Add(vote))
                {
                    response.result = "OK";
                }
                else
                {
                    response.result = "Erro ao Salvar";
                }
            }
            catch (Exception e)
            {
                response.result = "Erro ao Salvar: " + e.Message;
            }

            return response;
        }

        public object FindWinnerByDayOfWeek(int dayOfWeek)
        {
            return _voteRepository.FindWinnerByDayOfWeek(dayOfWeek);
        }


    }
}
