using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;
using Services;
using ModelEntities.ModelViews;

namespace FilRouge.Web.Controllers
{

    public class DifficultiesController : Controller
    {
        private readonly DifficultiesService _difficultiesService = new DifficultiesService();
        // GET: Difficulties
        public ActionResult Index()
        {
            var difficulty = _difficultiesService.GetAllDifficulty();
            return View("Index", difficulty);
        }
        private DataBaseContext db = new DataBaseContext();
        //GET: MasterDifficulties/Details/5
        public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Difficulty Difficulty = db.Difficulties.Find(id);
              if (Difficulty == null)
              {
                  return HttpNotFound();
              }
              return View(Difficulty.MapToDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Create
          public ActionResult Create()
          {
            var ListPercentItems = _difficultiesService.SetPercentDropDownList();
            ViewBag.Percent = ListPercentItems;
            return View();
          }
        
          // POST: MasterDifficulties/Create
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "DifficultyID,Wording,PercentID")] Difficulty Difficulty)
          {
              if (ModelState.IsValid)
              {
                  db.Difficulties.Add(Difficulty);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
        
              return View(Difficulty.MapToDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Edit/5
          public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Difficulty Difficulty = db.Difficulties.Find(id);
              if (Difficulty == null)
              {
                  return HttpNotFound();
              }
            var ListPercentItems = _difficultiesService.SetPercentDropDownList();
            ViewBag.Percent = ListPercentItems;
            return View(Difficulty.MapToDifficultyViewModel());
          }
        
          // POST: MasterDifficulties/Edit/5
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "DifficultyID,Wording,PercentID")] Difficulty Difficulty)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(Difficulty).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(Difficulty.MapToDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Delete/5
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Difficulty Difficulty = db.Difficulties.Find(id);
              if (Difficulty == null)
              {
                  return HttpNotFound();
              }
              return View(Difficulty.MapToDifficultyViewModel());
          }
        
          // POST: MasterDifficulties/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              Difficulty Difficulty = db.Difficulties.Find(id);
              db.Difficulties.Remove(Difficulty);
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
