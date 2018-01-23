using LunchTime.Application;
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

        public VotingController(RestaurantAppService restaurantAppService)
        {
            _voteAppService = new VoteAppService();
            _userAppService = new UserAppService();
            _restaurantAppService = restaurantAppService;
        }

        public ActionResult Add(int dayOfWeek, string email, int restaurantId)
        {
            var response = _voteAppService.Add(dayOfWeek, email, restaurantId);
            return Json(response);

        }

        public ActionResult ShowResult(int dayOfWeek)
        {
            var restaurant = _voteAppService.FindWinnerByDayOfWeek(dayOfWeek);
            return Json(restaurant);
        }


    }
}