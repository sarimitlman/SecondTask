using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Proposal
    {
        public int ProposalId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public DateTime ProposalDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
