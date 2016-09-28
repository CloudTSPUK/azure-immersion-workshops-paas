using StoreSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreSample.Web.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Details
        public ActionResult Details(int id)
        {
            var book = new Book()
            {
                Author = "J.K. Rowling",
                Title = "Harry Potter: Something something",
                Price = 15m,
                Description = "A very nice book about a wizard.",
                IdBook = 1
            };

            return View(book);
        }
    }
}