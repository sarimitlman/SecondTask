//using Dal.Models;
//using Dal.Api;
//using BL.Api;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BL.Services

//{
//    public class BLEmailCampaignService : IBLEmailCampaign
//    {
//        private readonly IEmailCampaign _dalEmailCampaign;

//        public BLEmailCampaignService(IEmailCampaign dalEmailCampaign)
//        {
//            _dalEmailCampaign = dalEmailCampaign;
//        }

//        public Task<IEnumerable<EmailCampaign>> GetAllAsync() => _dalEmailCampaign.GetAllAsync();
//        public Task<EmailCampaign?> GetByIdAsync(int id) => _dalEmailCampaign.GetByIdAsync(id);
//        public Task AddAsync(EmailCampaign campaign) => _dalEmailCampaign.AddAsync(campaign);
//        public Task UpdateAsync(EmailCampaign campaign) => _dalEmailCampaign.UpdateAsync(campaign);
//        public Task DeleteAsync(int id) => _dalEmailCampaign.DeleteAsync(id);
//    }
//}
