using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    // Different Product Types

    /// <summary>
    /// TODO: Implement electronic product class
    /// </summary>
    public class ElectronicProduct : Product
    {
        // TODO: Add these properties
        // - Brand (string)
        // - WarrantyMonths (int)
        // - Voltage (string)
        // - IsRefurbished (bool)
        public string Brand { get; set; }
        public int WarrantyMonths { get; set; }
        public string Voltage { get; set; }
        public bool IsRefurbished { get; set; }
        /// <summary>
        /// TODO: Override GetProductDetails to include electronic specifics
        /// Format: "Brand: {Brand}, Model: {Name}, Warranty: {WarrantyMonths} months"
        /// </summary>
        public override string GetProductDetails()
        {
            return $"Name: {Name},Quantity: {Quantity}, Price: {Price} Brand: {Brand}, Warranty: {WarrantyMonths} months, Voltage:{Voltage}, IsRefurbished: {IsRefurbished}";
        }

        /// <summary>
        /// TODO: Calculate warranty expiration date
        /// </summary>
        public DateTime GetWarrantyExpiryDate()
        {
            // TODO: Return DateAdded.AddMonths(WarrantyMonths)
            return DateAdded.AddMonths(WarrantyMonths);
        }

        /// <summary>
        /// TODO: Check if warranty is still valid
        /// </summary>
        public bool IsWarrantyValid()
        {
            // TODO: Compare warranty expiry with current date
            return DateTime.Now<=GetWarrantyExpiryDate();
        }
    }
}
