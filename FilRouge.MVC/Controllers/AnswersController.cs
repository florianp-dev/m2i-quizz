using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEntities.Entities;
using ModelEntities.ModelViews;
using Services;

namespace FilRouge.Web.Controllers
{
    public class AnswersController : Controller
    {
        private readonly AnswersService _answerService = new AnswersService();
        private DataBaseContext db = new DataBaseContext();

        // GET: Answers
        public ActionResult Index()
        {
            var answer = _answerService.GetAllAnswers();
            return View("Index", answer);
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer.MapToAnswerViewModel());
        }

        // GET: Answers/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content");
            ViewBag.Question = question;
            return View(new List<InsertAnswer_AnswerCommentViewModel>() { new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value }, new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value }, new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value }, new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value } });
        }

        // POST: Answers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<InsertAnswer_AnswerCommentViewModel> insertViewModel)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < insertViewModel.Count(); i++)
                {
                
                    var answerComment = new AnswerComment
                    {
                        QCommentID = insertViewModel[i].QCommentID,
                        Content = insertViewModel[i].QContent
                    };
                    db.QComments.Add(answerComment);
                    db.SaveChanges();
                    var answer = new Answer
                    {
                        AnswerID = insertViewModel[i].AnswerID,
                        Content = insertViewModel[i].Content,
                        IsCorrect = insertViewModel[i].IsCorrect,
                        LinkedQuestion = db.Questions.Find(insertViewModel[i].QuestionID),
                        CommentID = answerComment.QCommentID
                    };
                    db.Answers.Add(answer);
                    db.SaveChanges();
                }
               return RedirectToAction("Index", "Questions");
            }

            //ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content", answer.CommentID);
            //ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Wording", answer.QuestionID);
            return View(insertViewModel);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content", answer.CommentID);
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Wording", answer.QuestionID);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnswerID,Content,IsCorrect,QuestionID,CommentID")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content", answer.CommentID);
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Wording", answer.QuestionID);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer.MapToAnswerViewModel());
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
