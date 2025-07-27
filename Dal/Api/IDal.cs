using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public IUser User { get; }
        public IClient Client { get; }
        public IInvoice Invoice { get; }
        public IPayment Payment { get; }
        //public IEmailCampaign EmailCampaign { get; }
        public IProposal Proposal { get; }
        public ITransaction Transaction { get; }

           
    }
}
