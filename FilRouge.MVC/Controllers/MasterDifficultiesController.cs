using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;
using Services;
using ModelEntities.ModelViews;

namespace FilRouge.Web.Controllers
{

    public class MasterDifficultiesController : Controller
    {
        private readonly MasterDifficultiesService _masterdifficultiesService = new MasterDifficultiesService();
        // GET: Difficulties
        public ActionResult Index()
        {
            var masterdifficulty = _masterdifficultiesService.GetAllMasterDifficulty();
            return View("Index", masterdifficulty);
        }
        private DataBaseContext db = new DataBaseContext();
        //GET: MasterDifficulties/Details/5
        public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              MasterDifficulty masterDifficulty = db.MasterDifficulties.Find(id);
              if (masterDifficulty == null)
              {
                  return HttpNotFound();
              }
              return View(masterDifficulty.MapToMasterDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Create
          public ActionResult Create()
          {
            var ListPercentItems = _masterdifficultiesService.SetPercentDropDownList();
            ViewBag.Percent = ListPercentItems;
            return View();
          }
        
          // POST: MasterDifficulties/Create
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "MasterDifficultyID,Wording,PercentID")] MasterDifficulty masterDifficulty)
          {
              if (ModelState.IsValid)
              {
                  db.MasterDifficulties.Add(masterDifficulty);
                  db.SaveChanges();
                  return RedirectToAction("GetAllMasterDifficulty");
              }
        
              return View(masterDifficulty.MapToMasterDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Edit/5
          public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              MasterDifficulty masterDifficulty = db.MasterDifficulties.Find(id);
              if (masterDifficulty == null)
              {
                  return HttpNotFound();
              }
            var ListPercentItems = _masterdifficultiesService.SetPercentDropDownList();
            ViewBag.Percent = ListPercentItems;
            return View(masterDifficulty.MapToMasterDifficultyViewModel());
          }
        
          // POST: MasterDifficulties/Edit/5
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "MasterDifficultyID,Wording,PercentID")] MasterDifficulty masterDifficulty)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(masterDifficulty).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("GetAllMasterDifficulty");
              }
              return View(masterDifficulty.MapToMasterDifficultyViewModel());
          }
        
          // GET: MasterDifficulties/Delete/5
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              MasterDifficulty masterDifficulty = db.MasterDifficulties.Find(id);
              if (masterDifficulty == null)
              {
                  return HttpNotFound();
              }
              return View(masterDifficulty.MapToMasterDifficultyViewModel());
          }
        
          // POST: MasterDifficulties/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              MasterDifficulty masterDifficulty = db.MasterDifficulties.Find(id);
              db.MasterDifficulties.Remove(masterDifficulty);
              db.SaveChanges();
              return RedirectToAction("GetAllMasterDifficulty");
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
