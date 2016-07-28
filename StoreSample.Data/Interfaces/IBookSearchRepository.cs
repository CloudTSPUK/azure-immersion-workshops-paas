namespace StoreSample.Data.Interfaces
{
    /// <summary>
    /// This class represents the basic contract for defining the search interaction
    /// for books. It is separated out as its own interface so that we are able to 
    /// extend it with a different implementation at a later time (e.g. replace the
    /// search with Azure Search, instead of using SQL for this).
    /// </summary>
    public interface IBookSearchRepository
    {
        /// <summary>
        /// Executes a query, with the given parameters, and returns the search results.
        /// </summary>
        /// <param name="bookSearchQuery">The object containing the definition of the search query,
        /// including serach term(s), sorting data, etc.</param>
        /// <returns>Returns a result, containing the results and the relevant information.</returns>
        BookQueryResult QueryBooks(BookSearchQuery bookSearchQuery);
    }
}
