using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBL
    {
        IBLUser User { get; }
        IBLClient Client { get; }
        IBLInvoice Invoice { get; }
        IBLPayment Payment { get; }
        //IBLEmailCampaign EmailCampaign { get; }
        IBLProposal Proposal { get; }
        IBLTransaction Transaction { get; }
    }
}
