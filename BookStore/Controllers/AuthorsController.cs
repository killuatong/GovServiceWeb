﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.DAL;
using System.Web.ModelBinding;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {

        private BookContext db = new BookContext();

        /*
        // GET: /Authors/
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }
         */

        // GET: Authors
        public ActionResult Index([Form] QueryOptions queryOptions)
        {
            
            //power by Dynamic Linq Query
            //var authors = db.Authors.OrderBy(queryOptions.Sort);

            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;

            var authors = db.Authors.
                            OrderBy(queryOptions.Sort).
                            Skip(start).
                            Take(queryOptions.PageSize);

            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

            //ViewBag.QueryOptions = queryOptions;

            AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();


            //return View(authors.ToList());
            //return View(AutoMapper.Mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList()));
            return View(new ResultList<AuthorViewModel>
            {
                QueryOptions = queryOptions,
                Results = AutoMapper.Mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList())
            }
            );
             

            
        }


        // GET: /Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View("Form", author);
        }

        // GET: /Authors/Create
        public ActionResult Create()
        {
            //return View();
            return View("Form", new Author());
        }

        // POST: /Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Form", author);
        }

        // GET: /Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View("FormEdit", author);
        }

        // POST: /Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("FormEdit", author);
        }

        // GET: /Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: /Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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
