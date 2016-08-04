namespace StoreSample.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IStoreSampleDataSource
    {
        IList<Book> Books { get; set; }
        IList<Order> Orders { get; set; }
        Order AddNewOrder(Order order);
        bool SaveChanges();
    }
}
