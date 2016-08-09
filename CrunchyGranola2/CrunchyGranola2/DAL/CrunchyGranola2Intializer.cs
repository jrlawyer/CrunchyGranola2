using CrunchyGranola2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrunchyGranola2.DAL
{
    public class CrunchyGranola2Intializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<CrunchyGranola2Context>
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
        }

    }
}