//using BL.Api;
//using Dal;
//using global::BL.Api;
//using global::BL.Services;
//using Microsoft.Extensions.DependencyInjection;

//namespace BL
//{
//    namespace BL
//    {
//        public class BLManager : IBL
//        {
//            public IBLUser User { get; }
//            public IBLClient Client { get; }
//            public IBLInvoice Invoice { get; }
//            public IBLPayment Payment { get; }
//            public IBLEmailCampaign EmailCampaign { get; }
//            public IBLProposal Proposal { get; }
//            public IBLTransaction Transaction { get; }

//            public BLManager()
//            {
//                ServiceCollection services = new ServiceCollection();
//                services.AddSingleton<IBLUser, BLUserService>();
//                services.AddSingleton<IBLClient, BLClientService>();
//                services.AddSingleton<IBLInvoice, BLInvoiceService>();
//                services.AddSingleton<IBLPayment, BLPaymentService>();
//                services.AddSingleton<IBLEmailCampaign, BLEmailCampaignService>();
//                services.AddSingleton<IBLProposal, BLProposalService>();
//                services.AddSingleton<IBLTransaction, BLTransactionService>();

//                ServiceProvider serviceProvider = services.BuildServiceProvider();
//                User = serviceProvider.GetService<IBLUser>();
//                Client = serviceProvider.GetService<IBLClient>();
//                Invoice = serviceProvider.GetService<IBLInvoice>();
//                Payment = serviceProvider.GetService<IBLPayment>();
//                EmailCampaign = serviceProvider.GetService<IBLEmailCampaign>();
//                Proposal = serviceProvider.GetService<IBLProposal>();
//                Transaction = serviceProvider.GetService<IBLTransaction>();
//            }
//        }
//    }
//}
using BL.Api;

namespace BL
{
    public class BLManager : IBL
    {
        public IBLUser User { get; }
        public IBLClient Client { get; }
        public IBLInvoice Invoice { get; }
        public IBLPayment Payment { get; }
        //public IBLEmailCampaign EmailCampaign { get; }
        public IBLProposal Proposal { get; }
        public IBLTransaction Transaction { get; }

        public BLManager(
            IBLUser user,
            IBLClient client,
            IBLInvoice invoice,
            IBLPayment payment,
            //IBLEmailCampaign emailCampaign,
            IBLProposal proposal,
            IBLTransaction transaction)
        {
            User = user;
            Client = client;
            Invoice = invoice;
            Payment = payment;
            //EmailCampaign = emailCampaign;
            Proposal = proposal;
            Transaction = transaction;
        }
    }
}