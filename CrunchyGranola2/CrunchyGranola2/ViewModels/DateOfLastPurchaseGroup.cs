using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrunchyGranola2.ViewModels
{
    public class DateOfLastPurchaseGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateOfLastPurchase { get; set; }

        public int CustomerCount { get; set; }
    }
}

