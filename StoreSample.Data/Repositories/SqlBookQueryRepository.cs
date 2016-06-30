using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreSample.Data.Repositories
{
    public class SqlBookQueryRepository : IBookQueryRepository
    {     
        public SqlBookQueryRepository(StoreSampleDbContext storeSampleDbContext)
        {
            
        }

        public IList<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
