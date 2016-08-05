namespace StoreSample.Data.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface defines the contract for interacting with a Store Sample datasource.
    /// </summary>
    public interface IStoreSampleDataSource
    {
        /// <summary>
        /// A list of the current Books as retrieved from the target Store Sample datasource.
        /// </summary>
        List<Book> Books { get; }

        /// <summary>
        /// A list of the current Orders as retrieved from the target Store Sample datasource.
        /// </summary>
        List<Order> Orders { get; }

        /// <summary>
        /// Adds an order to the target Store Sample datasource.It is important to note that the order to be
        /// added will only appear in the local Orders collection once <see cref="SaveChanges"/> has been called
        /// and executes successfully.
        /// </summary>
        /// <param name="order">The Order to be added to the Orders collection.</param>
        /// <returns>The Order that has been added to the Orders collection.</returns>
        Order AddNewOrder(Order order);

        /// <summary>
        /// Saves any changes that have been made to local the Book and Order collections 
        /// back to the Store Sample datasource. Calling this method will if successful will update the local 
        /// Book and Orders collections.
        /// </summary>
        /// <returns>A bool indicating the success or failure of the Save operation. When true
        /// the Save operation was successful. When false the Save operation failed.</returns>
        bool SaveChanges();
    }
}
