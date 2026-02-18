using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice.Utilities
{
    
        /// <summary>
        /// TODO: Implement validation helper class
        /// </summary>
        public static class ProductValidator
        {
            /// <summary>
            /// TODO: Validate product data
            /// Check:
            /// - ID not null/empty
            /// - Name not null/empty
            /// - Price > 0
            /// - Quantity >= 0
            /// </summary>
            public static bool ValidateProduct(Product product, out string errorMessage)
            {
                if (product == null)
                {
                    errorMessage = "Product cannot be null.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Id))
                {
                    errorMessage = "Product ID is required.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    errorMessage = "Product name is required.";
                    return false;
                }

                if (product.Price <= 0)
                {
                    errorMessage = "Product price must be greater than 0.";
                    return false;
                }

                if (product.Quantity < 0)
                {
                    errorMessage = "Product quantity cannot be negative.";
                    return false;
                }

                errorMessage = string.Empty;
                return true;
            }

            /// <summary>
            /// TODO: Validate electronic product specific rules
            /// </summary>
            public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
            {
                if (!ValidateProduct(product, out errorMessage))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Brand))
                {
                    errorMessage = "Brand is required for electronic products.";
                    return false;
                }

                if (product.WarrantyMonths <= 0)
                {
                    errorMessage = "Warranty months must be greater than 0.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Voltage))
                {
                    errorMessage = "Voltage is required for electronic products.";
                    return false;
                }

                errorMessage = string.Empty;
                return true;
            }

            /// <summary>
            /// TODO: Validate grocery product specific rules
            /// </summary>
            public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
            {
                if (!ValidateProduct(product, out errorMessage))
                {
                    return false;
                }

                if (product.ExpiryDate == default)
                {
                    errorMessage = "Expiry date is required for grocery products.";
                    return false;
                }

                if (product.Weight <= 0)
                {
                    errorMessage = "Weight must be greater than 0 for grocery products.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.StorageTemperature))
                {
                    errorMessage = "Storage temperature is required for grocery products.";
                    return false;
                }

                errorMessage = string.Empty;
                return true;
            }

            /// <summary>
            /// TODO: Validate clothing product specific rules
            /// </summary>
            public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
            {
                if (!ValidateProduct(product, out errorMessage))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Size))
                {
                    errorMessage = "Size is required for clothing products.";
                    return false;
                }

                if (!product.IsValidSize())
                {
                    errorMessage = "Invalid clothing size.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Color))
                {
                    errorMessage = "Color is required for clothing products.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Material))
                {
                    errorMessage = "Material is required for clothing products.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Gender))
                {
                    errorMessage = "Gender is required for clothing products.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Season))
                {
                    errorMessage = "Season is required for clothing products.";
                    return false;
                }

                errorMessage = string.Empty;
                return true;
            }
        }
}
