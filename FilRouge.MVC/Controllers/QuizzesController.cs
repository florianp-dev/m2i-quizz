using System.Web.Mvc;
using ModelEntities.ModelViews;
using Services;
using ModelEntities.Entities;
using System.Web.Security;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;

namespace FilRouge.Web.Controllers
{
    public class QuizzesController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }




        private static QuizzService _service = new QuizzService();
        private DataBaseContext db = new DataBaseContext();

        public ActionResult Index()
        {
            var quizz = _service.GetAllQuizzes();
            return View("Index", quizz);
        }

        public ActionResult Create()
        {
            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", "PercentID");
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording");
            return View(new QuizzViewModel());
        }

        // POST: Questions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuizzViewModel quizz)
        {
            quizz.LinkedDifficulty = db.Difficulties.Find(quizz.DifficultyID);
            quizz.LinkedTechno = db.Technos.Find(quizz.TechnoID);
            var allQuestions = _service.CreateQuiz(quizz.LinkedTechno, quizz.LinkedDifficulty, quizz.NbQuestions, quizz.CandidateFirstname, quizz.CandidateLastname);

            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;

            if (ModelState.IsValid)
            {
                var quizze = new Quizz
                {
                    CandidateFirstname = quizz.CandidateFirstname,
                    CandidateLastname = quizz.CandidateLastname,
                    NbQuestions = quizz.NbQuestions,
                    UserID = user.Id.ToString(),
                    TechnoID = quizz.TechnoID,
                    DifficultyID = quizz.DifficultyID,
                    LinkedQuestions = new List<Question>()
            
                };
                quizze.LinkedQuestions.AddRange(allQuestions.LinkedQuestions.Select(l=> new Question {
                QuestionID=l.QuestionID,
                DifficultyID = l.DifficultyID,
                IsActive = l.IsActive,
                QTypeID = l.QTypeID,
                TechnoID = l.TechnoID,
                Wording = l.Wording
                }));

                db.Quizzes.Add(quizze);
                db.SaveChanges();

               return RedirectToAction("Index", "Quizzes");
             }


            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", "PercentID");
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording");
            return View(quizz);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = db.Quizzes.Find(id);
            ViewBag.User = quizz.UserID;
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz.MapToQuizzViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                quizz.UserID = UserManager.FindByNameAsync(User.Identity.Name).Result.Id.ToString();
                db.Entry(quizz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Quizzes");
            }
            return View(quizz);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = db.Quizzes.Find(id);
            ViewBag.Question = quizz.LinkedQuestions;
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz.MapToQuizzViewModel());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}