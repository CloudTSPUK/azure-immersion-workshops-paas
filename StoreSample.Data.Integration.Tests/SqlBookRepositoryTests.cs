namespace StoreSample.Data.Integration.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Interfaces;
    using Repositories;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SqlBookRepositoryTests
    {
        private int expectedNumberOfSeedBooks = 10;
        private int expectedSeedBookId = 1;
        private string expectedSeedBookAuthor = "Andrew Hodges";
        private string expectedSeedBookTitle = "Alan Turing: The Enigma";
        private int expectedNumberOfSeedBooksReturnedByAuthorTerm = 1;
        private int expectedNumberOfSeedBooksReturnedByKeyWordTerm = 3;

        private static SqlBookRepository sqlBookRepository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            IStoreSampleDataSource sqlStoreSampleDataSource = new SqlStoreSampleDataSource();

            sqlBookRepository = new SqlBookRepository(sqlStoreSampleDataSource);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            sqlBookRepository = null;
        }

        [TestMethod]
        public void Constuctor_ValidSqlDbContext_InstanceReturned()
        {
            Assert.IsNotNull(sqlBookRepository);
        }

        [TestMethod]
        public void GetAllBooks_BookRepositoryCanRetrieveDbBooks_AllSeedBooksReturned()
        {
            List<Book> actualSeedBooks = sqlBookRepository.GetAllBooks();

            Assert.IsNotNull(actualSeedBooks);
            Assert.AreEqual(expectedNumberOfSeedBooks, actualSeedBooks.Count);
        }

        [TestMethod]
        public void GetBookById_SeedBookIdPresentInDb_SeedBookReturned()
        {
            Book actualSeedBook = sqlBookRepository.GetBookById(expectedSeedBookId);

            Assert.IsNotNull(actualSeedBook);
            Assert.AreEqual(expectedSeedBookId, actualSeedBook.IdBook);
        }

        [TestMethod]
        public void QueryBooks_AuthorSearchBookPresentInDB_SeedBookReturned()
        {
            BookSearchQuery bookSearchQuery = new BookSearchQuery()
            {
                SearchTerm = "Andrew"
            };

            BookQueryResult actualSeedBookQueryResult = sqlBookRepository.QueryBooks(bookSearchQuery);

            Assert.IsNotNull(actualSeedBookQueryResult);
            Assert.AreEqual(actualSeedBookQueryResult.Count, expectedNumberOfSeedBooksReturnedByAuthorTerm);
            Assert.AreEqual(actualSeedBookQueryResult.Result[0].Author, expectedSeedBookAuthor);
            Assert.AreEqual(actualSeedBookQueryResult.Result[0].IdBook, expectedSeedBookId);
        }

        [TestMethod]
        public void QueryBooks_TitleSearchBookPresentInDB_SeedBookReturned()
        {
            BookSearchQuery bookSearchQuery = new BookSearchQuery()
            {
                SearchTerm = "Enigma"
            };

            BookQueryResult actualSeedBookQueryResult = sqlBookRepository.QueryBooks(bookSearchQuery);

            Assert.IsNotNull(actualSeedBookQueryResult);
            Assert.AreEqual(actualSeedBookQueryResult.Count, expectedNumberOfSeedBooksReturnedByAuthorTerm);
            Assert.AreEqual(actualSeedBookQueryResult.Result[0].Title, expectedSeedBookTitle);
            Assert.AreEqual(actualSeedBookQueryResult.Result[0].IdBook, expectedSeedBookId);
        }

        [TestMethod]
        public void QueryBooks_KeyWordSearchBooksPresentInDB_SeedBooksReturned()
        {
            BookSearchQuery bookSearchQuery = new BookSearchQuery()
            {
                SearchTerm = "python"
            };

            BookQueryResult actualSeedBookQueryResult = sqlBookRepository.QueryBooks(bookSearchQuery);

            Assert.IsNotNull(actualSeedBookQueryResult);
            Assert.AreEqual(expectedNumberOfSeedBooksReturnedByKeyWordTerm, actualSeedBookQueryResult.Count);
        }
    }
}
