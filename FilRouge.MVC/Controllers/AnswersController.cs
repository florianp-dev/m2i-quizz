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
            Question question = db.Questions.Find(id);
            List<Answer> answer = db.Answers.Select(m => m).Where(m=>m.QuestionID == id).ToList();
            if (answer == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content", answer.CommentID);
            ViewBag.Question = question;
            ViewBag.Answer = answer;
            var ListAnswerView = new List<InsertAnswer_AnswerCommentViewModel>()
            { new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value, AnswerID = answer[0].AnswerID, CommentID=answer[0].CommentID, Content=answer[0].Content, IsCorrect= answer[0].IsCorrect,QCommentID=answer[0].LinkedComment.QCommentID,QContent=answer[0].LinkedComment.Content},
            { new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value,AnswerID = answer[1].AnswerID, CommentID=answer[1].CommentID, Content=answer[1].Content, IsCorrect= answer[1].IsCorrect,QCommentID=answer[1].LinkedComment.QCommentID,QContent=answer[1].LinkedComment.Content } },
            { new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value, AnswerID = answer[2].AnswerID, CommentID=answer[2].CommentID, Content=answer[2].Content, IsCorrect= answer[2].IsCorrect,QCommentID=answer[2].LinkedComment.QCommentID,QContent=answer[2].LinkedComment.Content } },
            { new InsertAnswer_AnswerCommentViewModel() { QuestionID = id.Value, AnswerID = answer[3].AnswerID, CommentID=answer[3].CommentID, Content=answer[3].Content, IsCorrect= answer[3].IsCorrect,QCommentID=answer[3].LinkedComment.QCommentID,QContent=answer[3].LinkedComment.Content } }
            };
            return View(ListAnswerView);
        }

        // POST: Answers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<InsertAnswer_AnswerCommentViewModel> answer)
        {
            if (ModelState.IsValid)
            {
                foreach (var answ in answer)
                {
                    Answer t = new Answer
                    {
                        AnswerID = answ.AnswerID,
                        Content = answ.Content,
                        IsCorrect = answ.IsCorrect,
                        QuestionID = answ.QuestionID,
                        CommentID = answ.CommentID
                    };
                    db.Entry(t).State = EntityState.Modified;
                    db.SaveChanges();
                    var answerComment = new AnswerComment
                    {
                        QCommentID = answ.QCommentID,
                        Content = answ.QContent
                    };
                    db.Entry(answerComment).State = EntityState.Modified;
                    db.SaveChanges();
                }
                //foreach (var answ in answer)
                //{                
                //    db.Entry(answ).State = EntityState.Modified;
                //    db.SaveChanges();
                //
                //}
                return RedirectToAction("Index", "Questions");
            }         
                //ViewBag.CommentID = new SelectList(db.QComments, "QCommentID", "Content", answ.CommentID);
                //ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Wording", answ.QuestionID);
           
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
