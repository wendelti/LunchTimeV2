using LunchTime.Application;
using LunchTime.Application.ViewModels;
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


        public UserController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public ActionResult VerifyIfEmailAlreadyExists(string email)
        {

            EmailSearchResponseViewModel emailView = _userAppService.FindByEmail(email);

            return Json(emailView);

        }

        public ActionResult AddNewUser(string name, string email, int teamId)
        {
            var response = _userAppService.Add(name, email, teamId);
            
            return Json(response);

        }




    }
}