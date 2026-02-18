// using System.Linq;
// using NUnit.Framework;
// using FlexibleInventorySystem_Practice;
// using FlexibleInventorySystem_Practice.Models;
// using FlexibleInventorySystem_Practice.Services;

// namespace FlexibleInventorySystem_Practice.Tests
// {
//     [TestFixture]
//     public class InventoryManagerTests
//     {
//         [Test]
//         public void AddProduct_ValidProduct_ReturnsTrue()
//         {
//             var inventory = new InventoryManager();
//             Product product = SampleData.GetSampleProducts().First();

//             bool result = inventory.AddProduct(product);

//             Assert.That(result, Is.True);
//         }

//         [Test]
//         public void AddProduct_NullProduct_ReturnsTrue()
//         {
//             var inventory = new InventoryManager();

//             bool result = inventory.AddProduct(null!);

//             Assert.That(result, Is.True);
//         }

//         [Test]
//         public void FindProduct_ExistingProduct_ReturnsProduct()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             Product product = inventory.FindProduct("E001");

//             Assert.That(product, Is.Not.Null);
//             Assert.That(product!.Name, Is.EqualTo("Laptop"));
//         }

//         [Test]
//         public void RemoveProduct_ExistingProduct_ReturnsTrue()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             bool result = inventory.RemoveProduct("G001");

//             Assert.That(result, Is.True);
//             Assert.That(inventory.FindProduct("G001"), Is.Null);
//         }

//         [Test]
//         public void RemoveProduct_UnknownProduct_ReturnsFalse()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             bool result = inventory.RemoveProduct("X999");

//             Assert.That(result, Is.False);
//         }

//         [Test]
//         public void UpdateQuantity_ExistingProduct_UpdatesQuantity()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             bool result = inventory.UpdateQuantity("C001", 25);
//             Product product = inventory.FindProduct("C001");

//             Assert.That(result, Is.True);
//             Assert.That(product, Is.Not.Null);
//             Assert.That(product!.Quantity, Is.EqualTo(25));
//         }

//         [Test]
//         public void GetLowStockProducts_ReturnsExpectedItems()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             var results = inventory.GetLowStockProducts(10);

//             Assert.That(results.Count, Is.EqualTo(1));
//             Assert.That(results[0].Id, Is.EqualTo("E001"));
//         }

//         [Test]
//         public void GenerateInventoryReport_WithSampleData_ReturnsReport()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             string report = inventory.GenerateInventoryReport();

//             Assert.That(report, Is.Not.Null);
//             Assert.That(report, Does.Contain("Inventory Report"));
//             Assert.That(report, Does.Contain("E001"));
//             Assert.That(report, Does.Contain("G001"));
//             Assert.That(report, Does.Contain("C001"));
//         }

//         [Test]
//         public void GenerateCategorySummary_WithSampleData_ReturnsSummary()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             string report = inventory.GenerateCategorySummary();

//             Assert.That(report, Is.Not.Null);
//             Assert.That(report, Does.Contain("Category Summary Report"));
//             Assert.That(report, Does.Contain("Electronics"));
//             Assert.That(report, Does.Contain("Groceries"));
//             Assert.That(report, Does.Contain("Clothing"));
//         }

//         [Test]
//         public void GenerateValueReport_WithSampleData_ReturnsValueReport()
//         {
//             var inventory = CreateInventoryWithSampleData();

//             string report = inventory.GenerateValueReport();

//             Assert.That(report, Is.Not.Null);
//             Assert.That(report, Does.Contain("Value Report"));
//             Assert.That(report, Does.Contain("Most Valuable Product"));
//             Assert.That(report, Does.Contain("Least Valuable Product"));
//         }

//         private static InventoryManager CreateInventoryWithSampleData()
//         {
//             var inventory = new InventoryManager();
//             foreach (var product in SampleData.GetSampleProducts())
//             {
//                 inventory.AddProduct(product);
//             }

//             return inventory;
//         }
//     }
// }
