using LunchTime.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LunchTime.Controllers
{
    public class HomeController : Controller
    {

        private RestaurantAppService _restaurantAppService;
        private TeamAppService _teamAppService;

        public HomeController()
        {
            _restaurantAppService = new RestaurantAppService();
            _teamAppService = new TeamAppService();
        }


        public ActionResult Index()
        {

            ViewBag.Teams = new SelectList(_teamAppService.FindAll(), "teamId", "teamName", "");
            ViewBag.Restaurants = _restaurantAppService.FindAll();

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public bool SalvarCadastro(string pNome, string pEmail)
        {

            return true;
        }

        public bool SalvarVoto(int pDiaSemana, string pEmail, int pIDRestaurante)
        {

            return true;
        }


        public ActionResult VerResultado(int pDiaSemana)
        {
            return Json(new { foo = "bar" });
        }




    }
}