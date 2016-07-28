using System;
using System.Collections.Generic;

namespace StoreSample.Data.Interfaces
{
    /// <summary>
    /// The main contract of interacting with orderes. 
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets the order by the order ID.
        /// </summary>
        /// <param name="orderId">The order Id of the Order that should be returned.</param>
        /// <returns>Returns the order, or null, in case the order cannot be found.</returns>
        Order GetOrderById(int orderId);

        /// <summary>
        /// Returns all the orderes in the system.
        /// </summary>
        /// <returns>Always returns a list of orders, however that list can be empty, if no 
        /// orders exist in the system. The result is never null.</returns>
        IList<Order> GetOrders();
        
        /// <summary>
        /// Adds an order to the system. 
        /// </summary>
        /// <returns>Returns the <see cref="Order"/> object that was created for this particular
        /// order instance.</returns>
        Order AddOrder();
    }
}
