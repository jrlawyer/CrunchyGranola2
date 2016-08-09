using CrunchyGranola2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrunchyGranola2.DAL
{
    public class CrunchyGranola2Initializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<CrunchyGranola2Context>
    {
        protected override void Seed(CrunchyGranola2Context context)
        {
            var customers = new List<Customer>
            {
                new Customer {CustomerID = 1, FirstName = "James", LastName = "Alexander", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 2, FirstName = "Jennifer", LastName = "Lawyer", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 3, FirstName = "Stephanie", LastName = "Lawyer", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 4, FirstName = "Anthony", LastName = "Gage", DateOfLastPurchase=DateTime.Parse("2016-08-01")}
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductID = 10, Description = "Handmade Scarf", Price = 15, UpcCode = 1234567, LeadTime = "2 months", Quantity = 1},
                new Product {ProductID = 11, Description = "Organic Apples", Price = 1, UpcCode = 1234568, LeadTime = "1 week", Quantity = 5},
                new Product {ProductID = 12, Description = "Funky Hat", Price = 10, UpcCode = 1234569, LeadTime = "3 months", Quantity = 1},
                new Product {ProductID = 13, Description = "Ocean Caught Salmon", Price = 8, UpcCode = 1234570, LeadTime = "1 week", Quantity = 2},
                new Product {ProductID = 14, Description = "Expensive Vitamins", Price = 50, UpcCode = 1234571, LeadTime = "1 month", Quantity = 3},
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var purchase = new List<Purchase>
            {
                new Purchase {PurchaseID = 100, CustomerID = 1, ProductID = 11 },
                new Purchase {PurchaseID = 100, CustomerID = 1, ProductID = 13 },
                new Purchase {PurchaseID = 101, CustomerID = 2, ProductID = 10 },
                new Purchase {PurchaseID = 101, CustomerID = 2, ProductID = 14 },
                new Purchase {PurchaseID = 102, CustomerID = 3, ProductID = 14 },
                new Purchase {PurchaseID = 103, CustomerID = 4, ProductID = 12 },

            };

            purchase.ForEach(u => context.Purchases.Add(u));
            context.SaveChanges();
        }

    }
}