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
        public BookQueryResult()
        {
            this.Result = new List<Book>();
        }

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