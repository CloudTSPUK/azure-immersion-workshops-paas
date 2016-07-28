using System.Collections.Generic;

namespace StoreSample.Data
{
    public class BookQueryResult
    {
        public BookQueryResult()
        {
            this.Result = new List<Book>();
        }

        public int TotalCount { get; set; }

        public int Count
        {
            get
            {
                return this.Result.Count;
            }
        }

        public List<Book> Result { get; set; }
    }
}