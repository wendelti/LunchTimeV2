using LunchTime.Application.ViewModels;
using LunchTime.Domain.Entities;
using LunchTime.Infra.CrossCutting.Helper;
using LunchTime.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LunchTime.Application.ViewModels.EmailSearchResponseViewModel;

namespace LunchTime.Application
{
    public interface IUserAppService
    {
        EmailSearchResponseViewModel FindByEmail(string email);
        ResponseViewModel Add(string name, string email, int teamId);
    }

    public class UserAppService : IUserAppService
    {

        UserRepository _userRepository;
        TeamRepository _teamRepository;

        public UserAppService(UserRepository userRepository, TeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public EmailSearchResponseViewModel FindByEmail(string email)
        {

            var emailSearchResponse = new EmailSearchResponseViewModel();

            if (StringHelper.IsValidEmail(email))
            {
                var user = _userRepository.FindByEmail(email);
                if (user == null)
                {
                    emailSearchResponse.result = Result.NewUser;
                    emailSearchResponse.msg = "Email não existe, complete seu cadastro!";
                } else
                {
                    emailSearchResponse.result = Result.FindedEmail;
                    emailSearchResponse.msg = "OK";
                }
                
            }
            else
            {
                emailSearchResponse.result = Result.InvalidEmail;
                emailSearchResponse.msg = "Este email não é válido!";
            }

            return emailSearchResponse;           

        }

        public ResponseViewModel Add(string name, string email, int teamId)
        {

            var user = new User();
            user.Name = name;
            user.Email = email;
            user.Team = _teamRepository.FindById(teamId);

            var response = new ResponseViewModel();

            try
            {
                if (_userRepository.Add(user))
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

    }
}
