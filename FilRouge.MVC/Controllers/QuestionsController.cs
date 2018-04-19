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
    public class QuestionsController : Controller
    {
        private readonly QuestionService _questionsService = new  QuestionService();
        private DataBaseContext db = new DataBaseContext();
       
        // GET: Questions
        public ActionResult Index()
        {
            var questions = _questionsService.GetAllQuestions();
            return View("Index", questions);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
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
            return View(question.MapToQuestionsViewModel());
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording");
            ViewBag.QTypeID = new SelectList(db.QTypes, "QTypeID", "Wording");
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording");
            return View();
        }

        // POST: Questions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,Wording,IsActive,TechnoID,QTypeID,DifficultyID")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                if (question.QTypeID == 2)
                {
                    return RedirectToAction("Index", "Questions");
                }                    
                else
                {
                    return RedirectToAction("Create", "Answers", new { id = question.QuestionID });
                }
                    
            }

            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", question.DifficultyID);
            ViewBag.QTypeID = new SelectList(db.QTypes, "QTypeID", "Wording", question.QTypeID);
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording", question.TechnoID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", question.DifficultyID);
            ViewBag.QTypeID = new SelectList(db.QTypes, "QTypeID", "Wording", question.QTypeID);
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording", question.TechnoID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,Wording,IsActive,TechnoID,QTypeID,DifficultyID")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DifficultyID = new SelectList(db.Difficulties, "DifficultyID", "Wording", question.DifficultyID);
            ViewBag.QTypeID = new SelectList(db.QTypes, "QTypeID", "Wording", question.QTypeID);
            ViewBag.TechnoID = new SelectList(db.Technos, "TechnoID", "Wording", question.TechnoID);
            return View(question);
        }

        // GET: Questions/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question.MapToQuestionsViewModel());
        //}

        //// POST: Questions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Question question = db.Questions.Find(id);
        //    db.Questions.Remove(question);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
