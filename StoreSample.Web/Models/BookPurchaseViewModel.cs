using StoreSample.Data;
using System.ComponentModel.DataAnnotations;

namespace StoreSample.Models
{
    /// <summary>
    /// This model contains all the details required to view & submit a book
    /// purchase order.
    /// </summary>
    public class BookPurchaseViewModel
    {
        /// <summary>
        /// We might need the book when we're displaying confirmation to the user.
        /// Note however, this will not get submitted back to us, unless we actually
        /// use hidden forms in the form that displays it.
        /// </summary>
        public Book Book { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "House number")]
        public string HouseNumber { get; set; }

        [Display(Name = "Postal code")]
        public string PostCode { get; set; }

        [Display(Name = "FAKE Credit Card Number")]
        public string CreditCardNumber { get; set; }
    }
}