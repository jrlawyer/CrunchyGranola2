using CrunchyGranola2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrunchyGranola2.ViewModels
{
    public class PurchaseData
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}