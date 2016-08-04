namespace StoreSample.Data.Unit.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repositories;
    using Moq;
    using Interfaces;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SqlBookRepositoryTests
    {
        private static Mock<IStoreSampleDataSource> mockSqlStoreSampleDataSource;
        private static List<Book> expectedBooks = new List<Book>();
        private static Book expectedBookToQuery;

        private IStoreSampleDataSource mockDataStore;
        private IBookQueryRepository bookQueryRepository;
        private IBookSearchRepository bookSearchRespository;

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

            expectedBookToQuery = new Book()
            {
                Author = "X",
                Description = "Y",
                Price = 1.0M,
                Title = "Z",
                IdBook = 4,
                Orders = null
            };

            expectedBooks.Add(expectedBookToQuery);

            mockSqlStoreSampleDataSource.Setup(sssds => sssds.Books).Returns(expectedBooks);
        }

        [TestInitialize]
        public void Initialize()
        {
            this.mockDataStore = mockSqlStoreSampleDataSource.Object;

            this.bookQueryRepository = new SqlBookRepository(this.mockDataStore);
            this.bookSearchRespository = new SqlBookRepository(this.mockDataStore);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_NullStoreSampleDataSource_NullReferenceExceptionQueryRepository()
        {
            IBookQueryRepository bookRepository = new SqlBookRepository(null);
        }

        [TestMethod]
        public void Constructor_ValidStoreSampleDataSource_SqlBookQueryRepositoryInstance()
        {
            IBookQueryRepository bookRepository = new SqlBookRepository(this.mockDataStore);

            Assert.IsNotNull(bookRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_NullStoreSampleDataSource_NullReferenceExceptionSearchRepository()
        {
            IBookSearchRepository bookRepository = new SqlBookRepository(null);
        }

        [TestMethod]
        public void Constructor_ValidStoreSampleDataSource_SqlBookSearchRepositoryInstance()
        {
            IBookSearchRepository bookRepository = new SqlBookRepository(this.mockDataStore);

            Assert.IsNotNull(bookRepository);
        }

        [TestMethod]
        public void GetAllBooks_ValidBookRepository_AllBooksReturned()
        {
            List<Book> actualBooks = this.bookQueryRepository.GetAllBooks();

            Assert.IsNotNull(actualBooks);
            Assert.AreEqual(expectedBooks.Count, actualBooks.Count);
            Assert.AreEqual(expectedBooks[0].IdBook, actualBooks[0].IdBook);
        }

        public void GetOrderById_NonExistantBookIdProvided_NullBookReturned()
        {
            Book actualBook = this.bookQueryRepository.GetBookById(int.MaxValue);

            Assert.IsNull(actualBook);
        }

        [TestMethod]
        public void GetBookById_ValidBookId_ExpectedBookReturned()
        {
            Book actualBook = this.bookQueryRepository.GetBookById(0);

            Assert.IsNotNull(actualBook);
            Assert.AreSame(expectedBooks[0], actualBook);
        }

        [TestMethod]
        public void QueryBooks_NullBookSearchQuery_AllBooksReturned()
        {
            BookQueryResult actualBookQueryResult = this.bookSearchRespository.QueryBooks(null);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(expectedBooks.Count, actualBookQueryResult.TotalCount);
        }

        [TestMethod]
        public void QueryBooks_EmptyBookSearchQuerySearchTerm_AllBooksReturned()
        {
            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = string.Empty
            };

            BookQueryResult actualBookQueryResult = this.bookSearchRespository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(expectedBooks.Count, actualBookQueryResult.TotalCount);
        }

        [TestMethod]
        public void QueryBooks_AuthorSearch_ExpectedBookReturned()
        {
            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "X"
            };

            BookQueryResult actualBookQueryResult = this.bookSearchRespository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(1, actualBookQueryResult.Result.Count);
            Assert.AreEqual(expectedBookToQuery.Author, actualBookQueryResult.Result[0].Author);
        }

        [TestMethod]
        public void QueryBooks_DescriptionSearch_ExpectedBookReturned()
        {
            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "Y"
            };

            BookQueryResult actualBookQueryResult = this.bookSearchRespository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(1, actualBookQueryResult.Result.Count);
            Assert.AreEqual(expectedBookToQuery.Description, actualBookQueryResult.Result[0].Description);
        }

        [TestMethod]
        public void QueryBooks_TitleSearch_ExpectedBookReturned()
        {
            BookSearchQuery bookQuery = new BookSearchQuery()
            {
                SearchTerm = "Z"
            };

            BookQueryResult actualBookQueryResult = this.bookSearchRespository.QueryBooks(bookQuery);

            Assert.IsNotNull(actualBookQueryResult);
            Assert.AreEqual(1, actualBookQueryResult.Result.Count);
            Assert.AreEqual(expectedBookToQuery.Title, actualBookQueryResult.Result[0].Title);
        }
    }
}
