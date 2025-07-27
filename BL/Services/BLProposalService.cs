using Dal.Models;
using Dal.Api;
using BL.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{

    public class BLProposalService : IBLProposal
    {
        private readonly IProposal _dalProposal;

        public BLProposalService(IProposal dalProposal)
        {
            _dalProposal = dalProposal;
        }

        public Task<IEnumerable<Proposal>> GetAllAsync() => _dalProposal.GetAllAsync();
        public Task<Proposal?> GetByIdAsync(int id) => _dalProposal.GetByIdAsync(id);
        public Task AddAsync(Proposal proposal) => _dalProposal.AddAsync(proposal);
        public Task UpdateAsync(Proposal proposal) => _dalProposal.UpdateAsync(proposal);
        public Task DeleteAsync(int id) => _dalProposal.DeleteAsync(id);
    }
}
