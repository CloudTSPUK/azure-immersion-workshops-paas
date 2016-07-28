using System.Collections.Generic;

namespace StoreSample.Data.Interfaces
{
    public interface IBookQueryRepository
    {
        IList<Book> GetAllBooks();

        Book GetBookById(int bookId);
    }
}
