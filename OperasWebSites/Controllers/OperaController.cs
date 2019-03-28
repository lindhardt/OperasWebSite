using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB _contextDB = new OperasDB();

        // GET: Opera
        public ActionResult Index()
        {
            return View("Index", _contextDB.Operas.ToList());
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            Opera opera = _contextDB.Operas.Find(id);

            if(opera == null)
            {
               return HttpNotFound();
            }

            return View("Details", opera);
        }

        // GET: Create
        public ActionResult Create()
        {
            Opera opera = new Opera();

            return View("Create", opera);
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Opera opera)
        {
            if( ModelState.IsValid )
            {
                _contextDB.Operas.Add(opera);
                _contextDB.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Create", opera);
        }

        //TODO: GET: Edit
        public ActionResult Edit(int id)
        {
            Opera opera = _contextDB.Operas.Find(id);

            if(opera != null)
            {
                return View("Edit", opera);
            }

            return RedirectToAction("Index");
        }

        //TODO: POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Opera opera )
        {
            if(ModelState.IsValid)
            {
                _contextDB.Entry(opera).State = EntityState.Modified;
                _contextDB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", opera);
        }

    }
}