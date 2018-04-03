using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;

namespace _FilRouge.Web_Quizz.Controllers
{
    public class DifficultiesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Difficulties
        public ActionResult Index()
        {
            return View(db.Difficulties.ToList());
        }

        // GET: Difficulties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        // GET: Difficulties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Difficulties/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DifficultyID,Wording,DifficultyType")] Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                db.Difficulties.Add(difficulty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(difficulty);
        }

        // GET: Difficulties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        // POST: Difficulties/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DifficultyID,Wording,DifficultyType")] Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(difficulty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(difficulty);
        }

        // GET: Difficulties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        // POST: Difficulties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Difficulty difficulty = db.Difficulties.Find(id);
            db.Difficulties.Remove(difficulty);
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
