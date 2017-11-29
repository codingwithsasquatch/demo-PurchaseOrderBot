using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoFlowers.Models
{
    public class PoDetails
    {
        public int Number { get; set; }

        public int LineNumber { get; set; }

        public string Description { get; set; }

        public string ToBeInvoiced { get; set; }

        public string ToBeDelivered { get; set; }

        public int InvoiceNumber { get; set; }

        public string InvoiceQuantity { get; set; }

        public DateTime GrPostingDate { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}