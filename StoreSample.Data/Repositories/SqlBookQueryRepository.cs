namespace StoreSample.Data.Repositories
{
    using Infrastructure;
    using StoreSample.Data.Interfaces;
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
            Guard.NotNull(this.storeSampleDbContext, "The book database context connection is null. Cannot query the book database.");

            return this.storeSampleDbContext.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            Guard.NotNull(this.storeSampleDbContext, "The book database context connection is null. Cannot query the book database.");

            return this.storeSampleDbContext.Books.SingleOrDefault(b => b.IdBook == bookId);
        }

        public BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery)
        {
            Guard.NotNull(this.storeSampleDbContext, "The book database context connection is null. Cannot query the book database.");

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
    }
}
