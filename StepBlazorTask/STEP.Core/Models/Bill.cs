using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Core.Models
{
    public class Bill
    {
        public int InvoiceMonth { get; set; }
        public int InvoiceYear { get; set; }
        public int TotalBilling { get; set; }
        public int TotalApproved { get; set; }
        public int TotalPaid { get; set; }
        public int TotalBalance { get; set; }
        public string PresentationPeriod { get
            {
                DateTime date = new DateTime(InvoiceYear, InvoiceMonth, 1);
                return date.ToString("MMMM yyyy");
            } 
        }
    }
}
