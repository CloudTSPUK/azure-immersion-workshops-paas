using StoreSample.Web.Data;
using StoreSample.Web.Models;
using System;
using System.Web.Mvc;

namespace StoreSample.Web.Controllers
{
    public class BooksController : Controller
    {
        /// <summary>
        /// The methods gets the book by id from the data store.
        /// </summary>
        /// <remarks>This method only exists because both methods in the controller
        /// actually need the same one. Typically, this could have been done by introducing
        /// a service class, but because we wanted to minimize the complexity of the application,
        /// this will do just fine.</remarks>
        /// <param name="id">The id of the book to retrieve.</param>
        /// <returns>Returns a <see cref="Book"/> object, if found, or null if not.</returns>
        private Book GetBookFromStore(int id)
        {
            var book = new Book()
            {
                Author = "R. Andom",
                Title = "A Short Road To Longevity",
                Price = 15m,
                Description = "A very nice book about a way to go quick, slowly.",
                IdBook = 1
            };

            return book;
        }

        /// <summary>
        /// The action reaches out to the database, to get the proper book, 
        /// and pass the model to the view.
        /// </summary>
        /// <param name="id">The id of the book to show.</param>
        /// <returns>Returns a view result, with the model of the book.</returns>
        public ActionResult Details(int id)
        {
            var book = GetBookFromStore(id);
            return View(book);
        }



        [HttpGet]
        public ActionResult Buy(int id)
        {
            // NOTE: since we are pretty certain the user came to this page from the Details
            //       action, we know this could be greatly improved by caching the book. But
            //       that is premature optimization. 
            var book = GetBookFromStore(id);
            var model = new BookPurchaseViewModel()
            {
                Quantity = 1, // we obviously default to one 
                Book = book,
                // to avoid anybody accidentally inputing their CC number, we prefill it with a GUID
                CreditCardNumber = Guid.NewGuid().ToString()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Buy(BookPurchaseViewModel model)
        {
            // we should be doing validation, and making sure that 
            // the data is properly entered. But seeing as this is a 
            // very simple demo, we don't really have to, and it would
            // again, introduce unnecessary complexity which we can avoid.

            var order = new Order()
            {
                BookId = model.Book.IdBook,
                CreditCardNumber = model.CreditCardNumber,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HouseNumber = model.HouseNumber,
                PostCode = model.PostCode,
                Quantity = model.Quantity,
                TotalPrice = model.Quantity * model.Book.Price,
                TelephoneNumber = model.TelephoneNumber,
                OrderPlacedAtUtc = DateTime.UtcNow
            };

            // TODO: submit to queue

            return RedirectToAction("Index", "Home");
        }
    }
}