namespace StoreSample.Data.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repositories;
    using Moq;
    using Interfaces;
    using System.Collections.Generic;

    [TestClass]
    public class SqlBookRepositoryTests
    {
        private static Mock<IStoreSampleDataSource> mockSqlStoreSampleDataSource;
        private static List<Book> expectedBooks = new List<Book>();
        private static Book expectedBook;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            mockSqlStoreSampleDataSource = new Mock<IStoreSampleDataSource>();

            int maxNumberOfTestBooks = 3;

            for (int i = 0; i < maxNumberOfTestBooks; i++)
            {
                expectedBooks.Add(new Book()
                {
                    IdBook = i,
                    Author = string.Format("Author {0}", i),
                    Description = string.Format("Description {0}", i),
                    Title = string.Format("Title {0}", i),
                    Price = Convert.ToDecimal(i),
                    Orders = null
                });
            }

            mockSqlStoreSampleDataSource.Setup(sssds => sssds.Books).Returns(expectedBooks);

            expectedBook = new Book()
            {
                Author = "X",
                Description = "Y",
                Price = 1.0M,
                Title = "Z",
                IdBook = 4,
                Orders = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_NullStoreSampleDbContext_NullReferenceException()
        {
            IBookQueryRepository bookRepository = new SqlBookRepository(null);
        }

        [TestMethod]
        public void Constructor_ValidStoreSampleDataSource_SqlBookRepositoryInstance()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            IBookQueryRepository bookRepository = new SqlBookRepository(mockDataStore);

            Assert.IsNotNull(bookRepository);
        }

        [TestMethod]
        public void GetAllBooks_ValidBookRepository_AllBooksReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            IBookQueryRepository bookRepository = new SqlBookRepository(mockDataStore);

            List<Book> actualBooks = bookRepository.GetAllBooks();

            Assert.IsNotNull(actualBooks);
            Assert.AreEqual(expectedBooks.Count, actualBooks.Count);
            Assert.AreEqual(expectedBooks[0].IdBook, actualBooks[0].IdBook);
        }

        [TestMethod]
        public void GetBookById_ValidBookRepository_ExpectedBookReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            IBookQueryRepository bookRepository = new SqlBookRepository(mockDataStore);

            Book actualBook = bookRepository.GetBookById(0);

            Assert.IsNotNull(actualBook);
            Assert.AreSame(expectedBooks[0], actualBook);
        }

        [TestMethod]
        public void QueryBooks_NullBookSearchQuery_AllBooksReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            IBookSearchRepository bookRepository = new SqlBookRepository(mockDataStore);

            BookQueryResult actualBookQueryResult = bookRepository.QueryBooks(null);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(expectedBooks.Count, actualBookQueryResult.TotalCount);
        }

        [TestMethod]
        public void QueryBooks_EmptyBookSearchQuerySearchTerm_AllBooksReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            IBookSearchRepository bookRepository = new SqlBookRepository(mockDataStore);

            BookQueryResult actualBookQueryResult = bookRepository.QueryBooks(null);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(expectedBooks.Count, actualBookQueryResult.TotalCount);
        }

        [TestMethod]
        public void QueryBooks_AuthorSearch_ExpectedBookReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            mockDataStore.Books.Add(expectedBook);

            IBookSearchRepository bookRepository = new SqlBookRepository(mockDataStore);

            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "X"
            };

            BookQueryResult actualBookQueryResult = bookRepository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(actualBookQueryResult.Result.Count, 1);
            Assert.AreEqual(expectedBook.Author, actualBookQueryResult.Result[0].Author);
        }

        public void QueryBooks_DescriptionSearch_ExpectedBookReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            mockDataStore.Books.Add(expectedBook);

            IBookSearchRepository bookRepository = new SqlBookRepository(mockDataStore);

            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "Y"
            };

            BookQueryResult actualBookQueryResult = bookRepository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(actualBookQueryResult.Result.Count, 1);
            Assert.AreEqual(expectedBook.Author, actualBookQueryResult.Result[0].Author);
        }

        public void QueryBooks_TitleSearch_ExpectedBookReturned()
        {
            IStoreSampleDataSource mockDataStore = mockSqlStoreSampleDataSource.Object;

            mockDataStore.Books.Add(expectedBook);

            IBookSearchRepository bookRepository = new SqlBookRepository(mockDataStore);

            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "Z"
            };

            BookQueryResult actualBookQueryResult = bookRepository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(actualBookQueryResult.Result.Count, 1);
            Assert.AreEqual(expectedBook.Author, actualBookQueryResult.Result[0].Author);
        }
    }
}
