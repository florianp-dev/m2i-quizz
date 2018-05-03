using System.Web.Mvc;
using ModelEntities.ModelViews;
using Services;
using ModelEntities.Entities;
using System.Web.Security;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

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
            return View(_service.GetAllQuizzes());
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
                    DifficultyID = quizz.DifficultyID

                };
                db.Quizzes.Add(quizze);
                db.SaveChanges();

              //  foreach (var question in allQuestions)
              //  {
              //      var answer = new Answer
              //      {
              //          AnswerID = insertViewModel[i].AnswerID,
              //          Content = insertViewModel[i].Content,
              //          IsCorrect = insertViewModel[i].IsCorrect,
              //          LinkedQuestion = db.Questions.Find(insertViewModel[i].QuestionID),
              //          CommentID = answerComment.QCommentID
              //      };
              //      db.Answers.Add(answer);
              //      db.SaveChanges();
              //  }
               return RedirectToAction("Index", "Quizzes");
             }


            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", "PercentID");
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording");
            return View(quizz);
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