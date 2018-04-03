using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;

namespace _FilRouge.Web_Quizz.Controllers
{
    public class TechnoesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Technoes
        public ActionResult Index()
        {
            return View(db.Technos.ToList());
        }

        // GET: Technoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techno techno = db.Technos.Find(id);
            if (techno == null)
            {
                return HttpNotFound();
            }
            return View(techno);
        }

        // GET: Technoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technoes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechnoID,Wording")] Techno techno)
        {
            if (ModelState.IsValid)
            {
                db.Technos.Add(techno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(techno);
        }

        // GET: Technoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techno techno = db.Technos.Find(id);
            if (techno == null)
            {
                return HttpNotFound();
            }
            return View(techno);
        }

        // POST: Technoes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechnoID,Wording")] Techno techno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(techno);
        }

        // GET: Technoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techno techno = db.Technos.Find(id);
            if (techno == null)
            {
                return HttpNotFound();
            }
            return View(techno);
        }

        // POST: Technoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Techno techno = db.Technos.Find(id);
            db.Technos.Remove(techno);
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
