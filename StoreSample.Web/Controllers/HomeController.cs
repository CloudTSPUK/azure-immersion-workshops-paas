using StoreSample.Web.Data;
using System.Collections.Generic;
using System.Linq;
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

            using (var store = new StoreSample.Web.Data.Entities())
            {

                var results = store.Books.AsQueryable();

                if (!string.IsNullOrEmpty(query))
                {
                    var lQuery = query.ToLower();
                    results = results.Where(x => x.Title.ToLower().Contains(lQuery) || x.Description.ToLower().Contains(lQuery));
                }

                books = results.ToList();
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