using System.Collections.Generic;

namespace StoreSample.Data
{
    public class BookQueryResult 
    {
        public int TotalCount { get; set; }

        public List<Book> Result { get; set; }
    }
}