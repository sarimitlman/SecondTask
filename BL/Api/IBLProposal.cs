using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLProposal
    {
        Task<IEnumerable<Proposal>> GetAllAsync();
        Task<Proposal?> GetByIdAsync(int id);
        Task AddAsync(Proposal proposal);
        Task UpdateAsync(Proposal proposal);
        Task DeleteAsync(int id);
    }
}
