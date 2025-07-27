//using Dal.Api;
//using Dal.DBContext;
//using Microsoft.Extensions.DependencyInjection;

//namespace Dal
//{
//    public class DalManager : IDal
//    {
//        public IUser? User { get; }
//        public IClient? Client { get; }
//        public IInvoice? Invoice { get; }
//        public IPayment? Payment { get; }
//        public IEmailCampaign? EmailCampaign { get; }
//        public IProposal? Proposal { get; }
//        public ITransaction? Transaction { get; }


//        public DalManager()
//        {
//            ServiceCollection services = new ServiceCollection();
//            services.AddSingleton<CrmDbContext>();
//            services.AddSingleton<IUser, UserService>();
//            services.AddSingleton<IClient, ClientService>();
//            services.AddSingleton<IInvoice, InvoiceService>();
//            services.AddSingleton<IPayment, PaymentService>();
//            services.AddSingleton<IEmailCampaign, EmailCampaignService>();
//            services.AddSingleton<IProposal, ProposalService>();
//            services.AddSingleton<ITransaction, TransactionService>();

//            ServiceProvider serviceProvider = services.BuildServiceProvider();
//            User = serviceProvider.GetService<IUser>();
//            Client = serviceProvider.GetService<IClient>();
//            Invoice = serviceProvider.GetService<IInvoice>();
//            Payment = serviceProvider.GetService<IPayment>();
//            EmailCampaign = serviceProvider.GetService<IEmailCampaign>();
//            Proposal = serviceProvider.GetService<IProposal>();
//            Transaction = serviceProvider.GetService<ITransaction>();
//        }
//    }
//}using Dal.Api;

using Dal.Api;
namespace Dal
{
    public class DalManager : IDal
    {
        public IUser User { get; }
        public IClient Client { get; }
        public IInvoice Invoice { get; }
        public IPayment Payment { get; }
        //public IEmailCampaign EmailCampaign { get; }
        public IProposal Proposal { get; }
        public ITransaction Transaction { get; }

        public DalManager(
            IUser user,
            IClient client,
            IInvoice invoice,
            IPayment payment,
            //IEmailCampaign emailCampaign,
            IProposal proposal,
            ITransaction transaction)
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
