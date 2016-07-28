using System.Collections.Generic;

namespace StoreSample.Data
{
    /// <summary>
    /// Represents the result of a search query. This construct can (and will)
    /// contain more than just a simple result list. It will also have information
    /// about the total count of items, the count in this page, etc.
    /// </summary>
    public class BookQueryResult
    {
        /// <summary>
        /// Gets or sets the total count of results in the database. This number
        /// is the TOTAL number of books in the system, unlike <see cref="Count"/>.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the count of the books returned in this particular query.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the result list.
        /// </summary>
        public List<Book> Result { get; set; }
    }
}