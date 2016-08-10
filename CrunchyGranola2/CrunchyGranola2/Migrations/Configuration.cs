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


            var employees = new List<Employee>
            {
                new Employee {EmployeeID = 1, FirstName = "Nicole", LastName = "Thompson", HireDate=DateTime.Parse("2014-08-01"),
                    DepartmentName = "Produce"},
                new Employee {EmployeeID = 2, FirstName = "Sean", LastName = "Gehlhausen", HireDate=DateTime.Parse("2014-09-01"),
                    DepartmentName = "Health"},
                new Employee {EmployeeID = 3, FirstName = "Austin", LastName = "Cassel", HireDate=DateTime.Parse("2013-05-20"),
                    DepartmentName = "Seafood"},
                new Employee {EmployeeID = 4, FirstName = "Jeff", LastName = "Baker", HireDate=DateTime.Parse("2015-02-13"),
                    DepartmentName = "Produce"},
                new Employee {EmployeeID = 5, FirstName = "Maria", LastName = "Morales", HireDate=DateTime.Parse("2015-02-15"),
                    DepartmentName = "Seafood"},
                new Employee {EmployeeID = 6, FirstName = "Jen", LastName = "Fall", HireDate=DateTime.Parse("2016-02-13"),
                    DepartmentName = "Apparel"},
                new Employee {EmployeeID = 7, FirstName = "Amanda", LastName = "Hall", HireDate=DateTime.Parse("2011-03-13"),
                    DepartmentName = "Apparel"},
                new Employee {EmployeeID = 8, FirstName = "Melanie", LastName = "Harper", HireDate=DateTime.Parse("2014-10-01"),
                    DepartmentName = "Health"},

            };

            employees.ForEach(e => context.Employees.AddOrUpdate(s => s.LastName, e));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { DepartmentID = 200, DepartmentName = "Seafood", Budget = 3500,
                    EmployeeID = employees.Single(i=>i.LastName=="Morales").EmployeeID },
                new Department { DepartmentID = 201, DepartmentName = "Produce", Budget = 4500,
                    EmployeeID = employees.Single(i=>i.LastName=="Baker").EmployeeID },
                new Department { DepartmentID = 202, DepartmentName = "Apparel", Budget = 3000,
                    EmployeeID = employees.Single(i=>i.LastName=="Hall").EmployeeID },
                new Department { DepartmentID = 203, DepartmentName = "Health", Budget = 2500,
                    EmployeeID = employees.Single(i=>i.LastName=="Gehlhausen").EmployeeID }
            };

            departments.ForEach(d => context.Departments.AddOrUpdate(s => s.DepartmentID, d));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductID = 10, Description = "Handmade Scarf", Price = 15, UpcCode = 1234567, LeadTime = "2 months", Quantity = 1,
                    DepartmentID = departments.Single(d=>d.DepartmentName=="Apparel").DepartmentID},
                new Product {ProductID = 11, Description = "Organic Apples", Price = 1, UpcCode = 1234568, LeadTime = "1 week", Quantity = 5,
                    DepartmentID = departments.Single(d=>d.DepartmentName=="Produce").DepartmentID},
                new Product {ProductID = 12, Description = "Funky Hat", Price = 10, UpcCode = 1234569, LeadTime = "3 months", Quantity = 1,
                    DepartmentID = departments.Single(d=>d.DepartmentName=="Apparel").DepartmentID},
                new Product {ProductID = 13, Description = "Ocean Caught Salmon", Price = 8, UpcCode = 1234570, LeadTime = "1 week", Quantity = 2,
                    DepartmentID = departments.Single(d=>d.DepartmentName=="Seafood").DepartmentID},
                new Product {ProductID = 14, Description = "Expensive Vitamins", Price = 50, UpcCode = 1234571, LeadTime = "1 month", Quantity = 3,
                    DepartmentID = departments.Single(d=>d.DepartmentName=="Health").DepartmentID},
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
