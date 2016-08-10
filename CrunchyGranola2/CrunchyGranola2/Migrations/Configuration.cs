namespace CrunchyGranola2.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrunchyGranola2.DAL.CrunchyGranola2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrunchyGranola2.DAL.CrunchyGranola2Context context)
        {
            var customers = new List<Customer>
            {
                new Customer {CustomerID = 1, FirstName = "James", LastName = "Alexander", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 2, FirstName = "Jennifer", LastName = "Lawyer", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 3, FirstName = "Rita", LastName = "Swinehart", DateOfLastPurchase=DateTime.Parse("2016-08-01")},
                new Customer {CustomerID = 4, FirstName = "Anthony", LastName = "Gage", DateOfLastPurchase=DateTime.Parse("2016-08-01")}
            };

            customers.ForEach(c => context.Customers.AddOrUpdate(s => s.LastName, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductID = 10, Description = "Handmade Scarf", Price = 15, UpcCode = 1234567, LeadTime = "2 months", Quantity = 1},
                new Product {ProductID = 11, Description = "Organic Apples", Price = 1, UpcCode = 1234568, LeadTime = "1 week", Quantity = 5},
                new Product {ProductID = 12, Description = "Funky Hat", Price = 10, UpcCode = 1234569, LeadTime = "3 months", Quantity = 1},
                new Product {ProductID = 13, Description = "Ocean Caught Salmon", Price = 8, UpcCode = 1234570, LeadTime = "1 week", Quantity = 2},
                new Product {ProductID = 14, Description = "Expensive Vitamins", Price = 50, UpcCode = 1234571, LeadTime = "1 month", Quantity = 3},
            };

            products.ForEach(p => context.Products.AddOrUpdate(c => c.ProductID, p));
            context.SaveChanges();

            var purchases = new List<Purchase>
            {
                new Purchase {PurchaseID = 100, CustomerID = customers.Single(c=>c.LastName == "Alexander").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 11).ProductID,
                },
                new Purchase {PurchaseID = 100, CustomerID = customers.Single(c=>c.LastName == "Alexander").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 13).ProductID,
                },
                new Purchase {PurchaseID = 101, CustomerID = customers.Single(c=>c.LastName == "Lawyer").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 10).ProductID,
                },
                new Purchase {PurchaseID = 101, CustomerID = customers.Single(c=>c.LastName == "Lawyer").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 14).ProductID,
                },
                new Purchase {PurchaseID = 102, CustomerID = customers.Single(c=>c.LastName == "Swinehart").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 14).ProductID,
                },
                new Purchase {PurchaseID = 103, CustomerID = customers.Single(c=>c.LastName == "Gage").CustomerID,
                    ProductID = products.Single(p => p.ProductID == 12).ProductID,
                },

            };

            foreach (Purchase p in purchases)
            {
                var purchaseInDataBase = context.Purchases.Where(
                    c =>
                    c.Customer.CustomerID == p.CustomerID &&
                    c.Product.ProductID == p.ProductID).SingleOrDefault();
                if (purchaseInDataBase == null)
                {
                    context.Purchases.Add(p);
                }
            }

            context.SaveChanges();
        }
    }
}

