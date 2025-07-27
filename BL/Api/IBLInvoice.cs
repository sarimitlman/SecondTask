using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLInvoice
    {
        Task<int> GetSumAsync();
        Task<int> GetSumByUserIdAsync(int userId);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<IEnumerable<Invoice>> GetAllByUserIdAsync(int userId);
        Task<Invoice?> GetByIdAsync(int id);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(int id);
        Task<(int current, int previous, double percentChange)> GetInvoicesSummaryAsync();
    }
}
