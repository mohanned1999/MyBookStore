using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using MyBookStore.Repostoriy;

namespace MyBookStore.Controllrs
{
    public class AuthorsController : Controller
    {
        private readonly IBookStoreRepostoriycs<Authors> _authors;

        public AuthorsController(IBookStoreRepostoriycs<Authors> Authors)
        {
        
            _authors = Authors;
        }
        // GET: Authors
        public ActionResult Index()
        {

            var x = _authors.List();
            return View(x);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            var det = _authors.Find(id);
            return View(det);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Authors NewAuthors)
        {
            try
            {
                _authors.Add(NewAuthors);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            var m = _authors.Find(id);
            return View(m);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Authors EAuthors)
        {
            try
            {
                _authors.Update(EAuthors, id);

                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            var m = _authors.Find(id);
            return View(m);
        }

        // POST: Authors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Authors DAuthor)
        {
            try
            {
                _authors.Delete(id);
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}