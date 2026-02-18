using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private readonly List<Product> _products;
        private readonly object _lockObject = new object();

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            _products.Add(product);
            return true;
        }

        public Product FindProduct(string productId)
        {
            return _products.FirstOrDefault(item => item.Id == productId);
        }

        public string GenerateCategorySummary()
        {
            var categorySummary = _products
            .GroupBy(p => p.Category)
            .Select(g => new
            {

                Category = g.Key,
                TotalProducts = g.Count(),
                TotalValue = g.Sum(p => p.Price * p.Quantity)
            })
            .ToList();
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Category Summary Report");
            reportBuilder.AppendLine("------------------------");
            foreach (var category in categorySummary)
            {
                reportBuilder.AppendLine($"Category: {category.Category}");
                reportBuilder.AppendLine($"Total Products: {category.TotalProducts}");
                reportBuilder.AppendLine($"Total Value: {category.TotalValue:C}");
                reportBuilder.AppendLine();
            }

            return reportBuilder.ToString();
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
            var now = DateTime.Now;
            var expiringProducts = _products
                .Where(p => p is GroceryProduct gp && (gp.ExpiryDate - now).TotalDays <= daysThreshold)
                .ToList();

            if (!expiringProducts.Any())
                return "No products expiring soon.";

            return string.Join(Environment.NewLine, expiringProducts.Select(p => p.ToString()));
        }

        public string GenerateInventoryReport()
        {
            if (!_products.Any())
            {
                return "No products in inventory.";
            }

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Inventory Report");
            reportBuilder.AppendLine("-----------------");

            foreach (var product in _products.OrderBy(p => p.Category).ThenBy(p => p.Name))
            {
                reportBuilder.AppendLine($"Id: {product.Id}");
                reportBuilder.AppendLine($"Name: {product.Name}");
                reportBuilder.AppendLine($"Category: {product.Category}");
                reportBuilder.AppendLine($"Price: {product.Price:C}");
                reportBuilder.AppendLine($"Quantity: {product.Quantity}");
                reportBuilder.AppendLine($"Value: {product.CalculateValue():C}");
                reportBuilder.AppendLine();
            }

            reportBuilder.AppendLine($"Total Products: {_products.Count}");
            reportBuilder.AppendLine($"Total Inventory Value: {GetTotalInventoryValue():C}");

            return reportBuilder.ToString();
        }

        public string GenerateValueReport()
        {
            if (!_products.Any())
            {
                return "No products in inventory.";
            }

            var mostValuable = _products
                .OrderByDescending(p => p.CalculateValue())
                .First();
            var leastValuable = _products
                .OrderBy(p => p.CalculateValue())
                .First();

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Value Report");
            reportBuilder.AppendLine("------------");
            reportBuilder.AppendLine("Most Valuable Product");
            reportBuilder.AppendLine($"Id: {mostValuable.Id}");
            reportBuilder.AppendLine($"Name: {mostValuable.Name}");
            reportBuilder.AppendLine($"Category: {mostValuable.Category}");
            reportBuilder.AppendLine($"Value: {mostValuable.CalculateValue():C}");
            reportBuilder.AppendLine();
            reportBuilder.AppendLine("Least Valuable Product");
            reportBuilder.AppendLine($"Id: {leastValuable.Id}");
            reportBuilder.AppendLine($"Name: {leastValuable.Name}");
            reportBuilder.AppendLine($"Category: {leastValuable.Category}");
            reportBuilder.AppendLine($"Value: {leastValuable.CalculateValue():C}");

            return reportBuilder.ToString();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            return _products.Where(p => p.Quantity <= threshold).ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public decimal GetTotalInventoryValue()
        {
            return _products.Sum(p => p.CalculateValue());
        }

        public bool RemoveProduct(string productId)
        {
            var product = FindProduct(productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {
            var product = FindProduct(productId);
            if (product != null)
            {
                product.Quantity = newQuantity;
                return true;
            }
            return false;
        }


    }
}