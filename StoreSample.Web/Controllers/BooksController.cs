using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using StoreSample.Data;
using StoreSample.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace StoreSample.Controllers
{
    public class BooksController : Controller
    {
        /// <summary>
        /// The action reaches out to the database, to get the proper book, 
        /// and pass the model to the view.
        /// </summary>
        /// <param name="Id">The id of the book to show.</param>
        /// <returns>Returns a view result, with the model of the book.</returns>
        public ActionResult Details(int Id)
        {
            var book = GetBookFromStoreSampleDatabase(Id);

            return View(book);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            // NOTE: since we are pretty certain the user came to this page from the Details
            //       action, we know this could be greatly improved by caching the book. But
            //       that is premature optimization. 
            var book = GetBookFromStoreSampleDatabase(id);

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
        public ActionResult Buy(BookPurchaseViewModel bookModel)
        {
            // we should be doing validation, and making sure that 
            // the data is properly entered. But seeing as this is a 
            // very simple demo, we don't really have to, and it would
            // again, introduce unnecessary complexity which we can avoid.

            var order = new Order()
            {
                BookId = bookModel.Book.IdBook,
                CreditCardNumber = bookModel.CreditCardNumber,
                Email = bookModel.Email,
                FirstName = bookModel.FirstName,
                LastName = bookModel.LastName,
                HouseNumber = bookModel.HouseNumber,
                PostCode = bookModel.PostCode,
                Quantity = bookModel.Quantity,
                TotalPrice = bookModel.Quantity * bookModel.Book.Price,
                TelephoneNumber = bookModel.TelephoneNumber,
                OrderPlacedAtUtc = DateTime.UtcNow
            };

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue.
            CloudQueue buyBookQueue = queueClient.GetQueueReference("buybookqueue");

            // Create the queue if it doesn't already exist.
            buyBookQueue.CreateIfNotExists();

            string orderJson = JsonConvert.SerializeObject(order);

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(orderJson);

            buyBookQueue.AddMessage(message);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The methods gets the book by id from the data store.
        /// </summary>
        /// <remarks>This method only exists because both methods in the controller
        /// actually need the same one. Typically, this could have been done by introducing
        /// a service class, but because we wanted to minimize the complexity of the application,
        /// this will do just fine.</remarks>
        /// <param name="bookId">The id of the book to retrieve.</param>
        /// <returns>Returns a <see cref="Book"/> object, if found, or null if not.</returns>
        private Book GetBookFromStoreSampleDatabase(int bookId)
        {
            using (var storeSampleBookDatabase = new Entities())
            {
                var targetBook = storeSampleBookDatabase.Books.Single(book => book .IdBook == bookId);

                return targetBook;
            }
        }
    }
}