using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Invoice
    {
        public int? InvoiceId { get; set; }
        public int? UserId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
    }

}
