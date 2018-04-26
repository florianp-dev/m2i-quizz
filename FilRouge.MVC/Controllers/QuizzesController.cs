using System.Web.Mvc;
using ModelEntities.ModelViews;
using Services;

namespace FilRouge.Web.Controllers
{
    public class QuizzesController : Controller
    {
        private static QuizzService _service = new QuizzService();

        public ActionResult Index()
        {
            return View(_service.GetAllQuizzes());
        }

        public ActionResult Create(QuizzViewModel qvm)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}