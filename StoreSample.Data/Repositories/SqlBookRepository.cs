namespace StoreSample.Data.Repositories
{
    using Infrastructure;
    using StoreSample.Data.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlBookRepository : IBookQueryRepository, IBookSearchRepository
    {
        private IStoreSampleDataSource sqlStoreSampleDataSource;

        public SqlBookRepository(IStoreSampleDataSource sqlStoreSampleDataSource)
        {
            Guard.NotNull(sqlStoreSampleDataSource, "The passed sql data source was null. Cannot instantiate a sql book repository.");

            this.sqlStoreSampleDataSource = sqlStoreSampleDataSource;
        }

        public List<Book> GetAllBooks()
        {
            this.CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            this.CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Books.SingleOrDefault(b => b.IdBook == bookId);
        }

        public BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery)
        {
            this.CheckSqlDataSource();

            BookQueryResult bookQueryResult = new BookQueryResult()
            {
                TotalCount = this.sqlStoreSampleDataSource.Books.Count()
            };

            if (bookSearchQuery == null)
            {
                bookQueryResult.Result = this.sqlStoreSampleDataSource.Books.ToList();

                return bookQueryResult;
            }

            string searchTerm = bookSearchQuery.SearchTerm.ToLowerInvariant();

            if(string.IsNullOrEmpty(bookSearchQuery.SearchTerm))
            {
                bookQueryResult.Result = this.sqlStoreSampleDataSource.Books.ToList();

                return bookQueryResult;
            }

            List<Book> queryResults = this.sqlStoreSampleDataSource.Books.Where(book => (book.Author ?? string.Empty).ToLowerInvariant().Contains(searchTerm)
                                                                            || (book.Description ?? string.Empty).ToLowerInvariant().Contains(searchTerm)
                                                                            || (book.Title ?? string.Empty).ToLowerInvariant().Contains(searchTerm))
                                                                            .ToList();
            bookQueryResult.Result = queryResults;

            return bookQueryResult;
            
        }

        private void CheckSqlDataSource()
        {
            Guard.NotNull(sqlStoreSampleDataSource, "The book SQL book datasource is null. Cannot query the book datasource.");
        }
    }
}
