using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using ModelEntities.ModelViews;

namespace FilRouge.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult MenuTechno()
        {
            return RedirectToAction("Index","Technoes");
        }
        public ActionResult MenuQuestion()
        {
            return RedirectToAction("Index", "Questions");
        }
        public ActionResult MenuDifficult()
        {
            return RedirectToAction("Index", "Difficulties");
        }
        public ActionResult MenuQuizzes()
        {
            return RedirectToAction("Index", "Quizzes");
        }
    }
}