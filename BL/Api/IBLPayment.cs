using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLPayment
    {
        Task<decimal> GetSumAsync();
        Task<decimal> GetSumByUserIdAsync(int userId);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetAllByUserIdAsync(int userId);
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int id);
        Task<(decimal current, decimal previous, double percentChange)> GetPaymentsSummaryAsync();
    }
}
