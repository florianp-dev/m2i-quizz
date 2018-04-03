﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModelEntities.Entities;

namespace _FilRouge.Web_Quizz.Controllers
{

    public class MasterDifficultiesController : Controller
    {
        private readonly DataBaseContext db = new DataBaseContext();
        // GET: MasterDifficulties
        public ActionResult GetAllMasterDifficulty()
        {
            return View("Index", db.MasterDifficulties.ToList());
        }

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
              return View(masterDifficulty);
          }
        
          // GET: MasterDifficulties/Create
          public ActionResult Create()
          {
              return View();
          }
        
          // POST: MasterDifficulties/Create
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "MasterDifficultyID,Wording,DifficultyType")] MasterDifficulty masterDifficulty)
          {
              if (ModelState.IsValid)
              {
                  db.MasterDifficulties.Add(masterDifficulty);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
        
              return View(masterDifficulty);
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
              return View(masterDifficulty);
          }
        
          // POST: MasterDifficulties/Edit/5
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "MasterDifficultyID,Wording,DifficultyType")] MasterDifficulty masterDifficulty)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(masterDifficulty).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(masterDifficulty);
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
              return View(masterDifficulty);
          }
        
          // POST: MasterDifficulties/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              MasterDifficulty masterDifficulty = db.MasterDifficulties.Find(id);
              db.MasterDifficulties.Remove(masterDifficulty);
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