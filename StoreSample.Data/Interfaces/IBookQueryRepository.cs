using System.Collections.Generic;

namespace StoreSample.Data.Interfaces
{
    /// <summary>
    /// The class defines the contract for querying the books in the system.
    /// </summary>
    public interface IBookQueryRepository
    {
        /// <summary>
        /// Gets a non-filtered, non-ordered list of all the books in the system.
        /// </summary>
        /// <returns>Returns a simple list containing all the books.</returns>
        IList<Book> GetAllBooks();

        /// <summary>
        /// Gets a book by its ID.
        /// </summary>
        /// <param name="bookId">The ID of the book to find.</param>
        /// <returns>Returns the Book, represented by the given ID, or Null in case no 
        /// book with that ID has been found.</returns>
        Book GetBookById(int bookId);
    }
}
