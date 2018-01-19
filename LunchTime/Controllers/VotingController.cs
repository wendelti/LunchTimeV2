using LunchTime.Application;
using LunchTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LunchTime.Controllers
{
    public class VotingController : Controller
    {

        private VoteAppService _voteAppService;
        private UserAppService _userAppService;
        private RestaurantAppService _restaurantAppService;

        public VotingController()
        {
            _voteAppService = new VoteAppService();
            _userAppService = new UserAppService();
            _restaurantAppService = new RestaurantAppService();
        }

        public ActionResult Add(int dayOfWeek, string email, int restaurantId)
        {
            try
            {

                var vote = new Vote();
                vote.DayOfWeek = dayOfWeek;
                vote.UserID = _userAppService.FindByEmail(email).UserID;
                vote.RestaurantID = restaurantId;
                vote.VoteDate = DateTime.Now;

                if (_voteAppService.Add(vote))
                {
                    return Json(new { msg = "OK" });
                }
                else
                {
                    return Json(new { msg = "Erro ao Salvar" });
                }

            }
            catch (Exception e)
            {
                return Json(new { msg = "Erro ao Salvar: " + e.Message });
            }
        }

        public ActionResult ShowResult(int dayOfWeek)
        {
            var restaurant = _voteAppService.FindWinnerByDayOfWeek(dayOfWeek);
            return Json(restaurant);
        }


    }
}