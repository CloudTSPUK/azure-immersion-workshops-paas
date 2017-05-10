using StoreSample.Web.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StoreSample.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index(string query = null)
        {
            // this is where we'll go the DB
            // generate the model
            var books = new List<Book>();

            for (int i = 0; i < 20; i++)
            {
                books.Add(new Book()
                {
                    Author = "An. Author",
                    Title = "The Long Road to Ruin",
                    Price = 15m,
                    Description = "A very nice book about a winding path of a young developer, who liked to play the guitar.",
                    IdBook = 1
                });
            }

            if(!string.IsNullOrEmpty(query))
            {
                ViewBag.Query = query;
                books = books.GetRange(0, 5);
            }

            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}