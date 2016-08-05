namespace StoreSample.Data
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The BookSearchQuery represents a construct that allows us to specify
    /// the parameters we want to set for performing searches on the books 
    /// collection. Things like sort order, page numbers, etc., will go in here.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BookSearchQuery
    {
        /// <summary>
        /// Gets or sets the search term that is used to conduct the search.
        /// </summary>
        public string SearchTerm { get; set; }
    }
}