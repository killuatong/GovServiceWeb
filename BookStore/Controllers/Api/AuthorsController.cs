using BookStore.DAL;
using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Linq.Dynamic;

namespace BookStore.Controllers.Api
{
    public class AuthorsController : ApiController
    {

        private BookContext db = new BookContext();

        // GET: api/Authors
        public ResultList<AuthorViewModel> Get([FromUri]QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;
            var authors = db.Authors.
                OrderBy(queryOptions.Sort).
                Skip(start).
                Take(queryOptions.PageSize);
            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

            AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();
            return new ResultList<AuthorViewModel>
            {
                QueryOptions = queryOptions,
                Results = AutoMapper.Mapper.Map<List<Author>, List<AuthorViewModel>>
                (authors.ToList())
            };
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