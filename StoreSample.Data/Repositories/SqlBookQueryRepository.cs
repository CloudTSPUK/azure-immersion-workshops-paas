namespace StoreSample.Data.Repositories
{
    using StoreSample.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlBookQueryRepository : IBookQueryRepository, IBookSearchRepository
    {
        private StoreSampleDbContext storeSampleDbContext;

        public SqlBookQueryRepository(StoreSampleDbContext storeSampleDbContext)
        {
            this.storeSampleDbContext = storeSampleDbContext;
        }

        public IList<Book> GetAllBooks()
        {
            this.CheckDbContext();

            return this.storeSampleDbContext.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            this.CheckDbContext();

            return this.storeSampleDbContext.Books.SingleOrDefault(b => b.IdBook == bookId);
        }

        public BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery)
        {
            this.CheckDbContext();

            string searchTerm = bookSearchQuery.SearchTerm.ToLowerInvariant();

            List<Book> queryResults = this.storeSampleDbContext.Books.Where(book => (book.Author ?? string.Empty).ToLowerInvariant().Contains(searchTerm)
                                                                            || (book.Description ?? string.Empty).ToLowerInvariant().Contains(searchTerm)
                                                                            || (book.Title ?? string.Empty).ToLowerInvariant().Contains(searchTerm))
                                                                            .ToList();

            return new BookQueryResult()
            {
                Result = queryResults,
                TotalCount = this.storeSampleDbContext.Books.Count()
            };
        }

        private void CheckDbContext()
        {
            if (this.storeSampleDbContext == null)
            {
                throw new NullReferenceException("The book database context connection is null. Cannot query the book database.");
            }
        }
    }
}
