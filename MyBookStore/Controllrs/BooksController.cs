using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using MyBookStore.ModelViews;
using MyBookStore.Repostoriy;

namespace MyBookStore.Controllrs
{
    public class BooksController : Controller
    {
        private readonly IBookStoreRepostoriycs<Books> _books;
        private readonly IBookStoreRepostoriycs<Authors> _authors;
        private readonly IHostingEnvironment _hosting;

        public BooksController(IBookStoreRepostoriycs<Books> books ,IBookStoreRepostoriycs<Authors> Authors,IHostingEnvironment hosting)
        {
            _books = books;
            _authors = Authors;
            _hosting = hosting;
        }
        // GET: Books
        public ActionResult Index()
        {
            var x = _books.List();
            return View(x);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var x = _books.Find(id);
            return View(x);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            
            return View(GetBooksAuthorsViewModel());
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksAuthorsViewModel book)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if(book.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "upload");
                    filename = book.File.FileName;
                    string fullpath = Path.Combine(uploads, filename);
                    book.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                }

                if (book.AuthorId == -1)
                {
                    ViewBag.massges = "the file of the Authors is not selected";
                   
                    return View(GetBooksAuthorsViewModel());
                }
                try
                {
                    Books x = new Books()
                    {
                        Description = book.Description,
                        Id = book.Id,
                        Title = book.Title,
                        Authors = _authors.Find(book.AuthorId),
                        ImgUrl = filename
                        

                    };
                    _books.Add(x);
                    // TODO: Add insert logic here

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "plaes fill all required filed");
                return View(GetBooksAuthorsViewModel());
            }
           
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {

            var x = _books.Find(id);



            var model = new BooksAuthorsViewModel()
            { Title = x.Title,
                Id = x.Id,
                Description = x.Description,
                AuthorId = x.Authors.Id,
                ImgUrl = x.ImgUrl,
                Authors = _authors.List().ToList()

               
                 
            };
            return View(model);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BooksAuthorsViewModel books)
        {
            string filename = string.Empty;
            if (books.File != null) 
            {
              
                string uploads = Path.Combine(_hosting.WebRootPath, "upload");
                filename = books.File.FileName;
                string oldpath = _books.Find(books.Id).ImgUrl;
                string fulloldpath = Path.Combine(uploads, oldpath);
                string fullpath = Path.Combine(uploads, filename);
                if (fullpath != fulloldpath)
                {
                    //delete old file
                    System.IO.File.Delete(fulloldpath);

                    //save the new file
                    books.File.CopyTo(new FileStream(fullpath, FileMode .Create));
                }
            }
           

          

            try
            {
                Books bo = new Books()
                {
                    Title = books.Title,
                    Description = books.Description,
                    Id = books.Id,
                    ImgUrl = filename,
                    Authors = _authors.Find(books.AuthorId)
                };
                _books.Update(bo, books.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var x = _books.Find(id);
            return View(x);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Books books)
        {
            try
            {
                _books.Delete(id);  

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public List<Authors> GetAuthors()
        {
            var authors = _authors.List().ToList();
            authors.Insert(0,new Authors { Id = -1, FullName = "---plase select authoes-----" });
            return (authors);
        }
        public BooksAuthorsViewModel GetBooksAuthorsViewModel()
        {
            var model = new BooksAuthorsViewModel()
            {
                Authors = GetAuthors()
            };
            return (model);
        }
    }
}