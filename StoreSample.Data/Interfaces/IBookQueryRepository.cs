using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSample.Data.Interfaces
{
    interface IBookQueryRepository
    {
        IList<Book> GetAllBooks();

        Book GetBookById(int bookId);

        BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery);
    }
}
