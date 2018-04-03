using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;

namespace _FilRouge.Web_Quizz.Controllers
{
    public class PercentsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Percents
        public ActionResult Index()
        {
            return View(db.Percents.ToList());
        }

        // GET: Percents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Percent percent = db.Percents.Find(id);
            if (percent == null)
            {
                return HttpNotFound();
            }
            return View(percent);
        }

        // GET: Percents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Percents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PercentID,Beginner,Intermediate,Expert")] Percent percent)
        {
            if (ModelState.IsValid)
            {
                db.Percents.Add(percent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(percent);
        }

        // GET: Percents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Percent percent = db.Percents.Find(id);
            if (percent == null)
            {
                return HttpNotFound();
            }
            return View(percent);
        }

        // POST: Percents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PercentID,Beginner,Intermediate,Expert")] Percent percent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(percent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(percent);
        }

        // GET: Percents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Percent percent = db.Percents.Find(id);
            if (percent == null)
            {
                return HttpNotFound();
            }
            return View(percent);
        }

        // POST: Percents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Percent percent = db.Percents.Find(id);
            db.Percents.Remove(percent);
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
