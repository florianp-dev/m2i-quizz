using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _FilRouge.Web_Quizz.Controllers
{
    public class DifficultiesController : Controller
    {
        // GET: Difficulties
        public ActionResult Index()
        {
            return View();
        }

        // GET: Difficulties/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Difficulties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Difficulties/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Difficulties/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Difficulties/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Difficulties/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Difficulties/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
