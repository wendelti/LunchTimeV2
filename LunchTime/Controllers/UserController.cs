using LunchTime.Application;
using LunchTime.Domain.Entities;
using LunchTime.Infra.CrossCutting.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LunchTime.Controllers
{
    public class UserController : Controller
    {
        private UserAppService _userAppService;
        private TeamAppService _TeamAppService;
        public enum Result
        {
            InvalidEmail = 0,
            NewUser = 1,
            FindedEmail = 2
        }

        public UserController()
        {
            _userAppService = new UserAppService();
            _TeamAppService = new TeamAppService();
        }

        public ActionResult VerifyIfEmailAlreadyExists(string email)
        {
            if (StringHelper.IsValidEmail(email))
            {
                if (_userAppService.FindByEmail(email) == null)
                {
                    return Json(new { result = (int)Result.NewUser, msg = "Email não existe, complete seu cadastro!" });
                }

                return Json(new { result = (int)Result.FindedEmail, msg = "OK" });
            }
            else
            {
                return Json(new { result = (int)Result.InvalidEmail, msg = "Este email não é válido!" });
            }

        }

        public ActionResult AddNewUser(string name, string email, int teamId)
        {
            try
            {

                var user = new User();
                user.Name = name;
                user.Email = email;
                user.Team = _TeamAppService.FindTeamById(teamId);

                if (_userAppService.Add(user))
                {
                    return Json(new { result = "OK" });
                }
                else
                {
                    return Json(new { result = "Erro ao Salvar" });
                }

            }
            catch (Exception e)
            {
                return Json(new
                {
                    result = "Erro ao Salvar: " + e.Message
                });

            }





        }




    }
}